using ControleDeEstacionamento.Application.DTOs;
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
            var carroExistente = await _carroRepository.BuscarPorPlacaAsync(placa);
            if (carroExistente == null)
            {
                await _carroRepository.InsereCarroAsync(new Carro { Placa = placa });
            }
            var dataEntrada = DateTime.UtcNow;
            var entrada = new EntradaSaida
            {
                PlacaCarro = placa,
                DataEntrada = dataEntrada
            };

            await _entradaSaidaRepository.RegistrarEntradaAsync(entrada);
        }

        public async Task RegistrarSaidaAsync(string placa)
        {
            var ultimaEntradaSaida = await _entradaSaidaRepository.BuscaUltimaEntradaSaidaAsync(placa);

            if (ultimaEntradaSaida == null) return;
            if (ultimaEntradaSaida.DataSaida == null)
            {
                return;
            }            

            ultimaEntradaSaida.DataSaida = DateTime.UtcNow;
            var precoVigente = await _precoEstacionamentoRepository.BuscaPrecoEstacionamentoVigenteAsync();
            if(precoVigente == null) return; ///TODO: se tiver null tem que lançar exceção
            ultimaEntradaSaida.SetValorAPagar(precoVigente.ValorHoraInicial, precoVigente.ValorHoraAdicional);

            await _entradaSaidaRepository.RegistraSaidaAsync(ultimaEntradaSaida);
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
    }
}
