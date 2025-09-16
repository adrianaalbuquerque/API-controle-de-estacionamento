using ControleDeEstacionamento.Application.DTOs;
using ControleDeEstacionamento.Domain.Exceptions;
using ControleDeEstacionamento.Domain.Interfaces;
using ControleDeEstacionamento.Domain.Models;
using ControleDeEstacionamento.Infrastructure.Repository;
using System.Numerics;

namespace ControleDeEstacionamento.Model.Services
{
    public class EstacionamentoService
    {
        private readonly ICarroRepository _carroRepository;
        private readonly IEntradaSaidaRepository _entradaSaidaRepository;
        private readonly IPrecoEstacionamentoRepository _precoEstacionamentoRepository;

        public EstacionamentoService(ICarroRepository carroRepository, IEntradaSaidaRepository entradaSaidaRepository, IPrecoEstacionamentoRepository precoEstacionamentoRepository)
        {
            _carroRepository = carroRepository;
            _entradaSaidaRepository = entradaSaidaRepository;
            _precoEstacionamentoRepository = precoEstacionamentoRepository;
        }

        public async Task RegistrarEntradaAsync(string placa)
        {
            var placaNormalizada = await ValidarENormalizarPlacaAsync(placa);
            placa = placaNormalizada;

            var existeCarro = await _carroRepository.ObterCarroAsync(placa);
            var existeCarroSemSaida = await _entradaSaidaRepository.ExisteCarroSemSaidaAsync(placa);
            if (existeCarro != null)
                if(existeCarroSemSaida)
                    throw new CarroComEntradaSemSaidaException(placa);
                else
                    await _carroRepository.InsereCarroAsync(new Carro { Placa = placa });
            
            var dataEntrada = DateTime.UtcNow;
            var entrada = new EntradaSaida
            {
                PlacaCarro = placa,
                DataEntrada = dataEntrada
            };

            if (entrada.DataEntrada > DateTime.UtcNow)
                throw new DataEntradaInvalidaException(entrada.PlacaCarro);

            await _entradaSaidaRepository.RegistrarEntradaAsync(entrada);
        }

        public async Task<EntradaSaidaDTO?> RegistrarSaidaAsync(string placa)
        {
            var placaNormalizada = await ValidarENormalizarPlacaAsync(placa);
            placa = placaNormalizada;

            var existeCarro = await _carroRepository.ObterCarroAsync(placa);
            if (existeCarro == null)
                throw new CarroNaoEncontradoException(placa);

            var ultimaEntradaSaida = await _entradaSaidaRepository.BuscaUltimaEntradaSaidaAsync(placa);

            if (ultimaEntradaSaida == null)
                throw new EntradaNaoEncontradaException(placa);

            if (ultimaEntradaSaida.DataSaida != null)
                throw new SaidaJaRegistradaException(placa);

            ultimaEntradaSaida.DataSaida = DateTime.UtcNow;

            if (ultimaEntradaSaida.DataSaida < ultimaEntradaSaida.DataEntrada)
                throw new DataHoraSaidaAnteriorAEntradaException();

            var precoVigente = await _precoEstacionamentoRepository.BuscaPrecoEstacionamentoVigenteAsync();

            if (precoVigente == null)
                throw new InvalidOperationException("Não há preço vigente cadastrado.");

            ultimaEntradaSaida.SetValorAPagar(precoVigente.ValorHoraInicial, precoVigente.ValorHoraAdicional);

            await _entradaSaidaRepository.RegistraSaidaAsync(ultimaEntradaSaida);

            var ultimaEntradaSaidaDTO = new EntradaSaidaDTO()
            {
                PlacaCarro = ultimaEntradaSaida.PlacaCarro,
                DataEntrada = ultimaEntradaSaida.DataEntrada,
                DataSaida = ultimaEntradaSaida.DataSaida
            };
            return ultimaEntradaSaidaDTO;
        }
        public async Task AdicionarPrecoEstacionamento(PrecoEstacionamentoDTO precoEstacionamentoDTO)
        {
            var existeVigenciaConflitante = await _precoEstacionamentoRepository
                .ExisteVigenciaConflitanteAsync(precoEstacionamentoDTO.DataInicioVigencia, precoEstacionamentoDTO.DataFimVigencia);
            if (!existeVigenciaConflitante)
            {
                PrecoEstacionamento precoEstacionamento = new PrecoEstacionamento
                {
                    DataInicioVigencia = precoEstacionamentoDTO.DataInicioVigencia,
                    DataFimVigencia = precoEstacionamentoDTO.DataFimVigencia,
                    ValorHoraInicial = precoEstacionamentoDTO.ValorHoraInicial,
                    ValorHoraAdicional = precoEstacionamentoDTO.ValorHoraAdicional
                };

                await _precoEstacionamentoRepository.InserePrecoEstacionamentoAsync(precoEstacionamento);
            }; ///TODO: lançar exceção conflitante - o controller que trata
        }
        public static string NormalizarPlaca(string placa)
        {
            return placa.Trim().ToUpper().Replace("-", "");
        }
        public async Task<string> ValidarENormalizarPlacaAsync(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
                throw new PlacaInvalidaException(placa);

            placa = NormalizarPlaca(placa);

            if (!await _carroRepository.ValidaPlacaAsync(placa))
                throw new PlacaInvalidaException(placa);

            return placa;
        }

    }
}
