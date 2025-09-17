using ControleDeEstacionamento.Application.DTOs;
using ControleDeEstacionamento.Application.Services;
using ControleDeEstacionamento.Domain.Exceptions;
using ControleDeEstacionamento.Domain.Interfaces;
using ControleDeEstacionamento.Domain.Models;
using FakeItEasy;
using Xunit;

namespace Estacionamento.Tests.Application.Services
{
    public class EstacionamentoServiceTests
    {
        private readonly ICarroRepository _carroRepo;
        private readonly IEntradaSaidaRepository _entradaSaidaRepo;
        private readonly IPrecoEstacionamentoRepository _precoRepo;
        private readonly EstacionamentoService _service;

        public EstacionamentoServiceTests()
        {
            _carroRepo = A.Fake<ICarroRepository>();
            _entradaSaidaRepo = A.Fake<IEntradaSaidaRepository>();
            _precoRepo = A.Fake<IPrecoEstacionamentoRepository>();

            _service = new EstacionamentoService(_carroRepo, _entradaSaidaRepo, _precoRepo);
        }

        // Teste de entrada com placa inválida
        [Fact]
        public async Task RegistrarEntrada_DeveLancarPlacaInvalidaException_SePlacaForVazia()
        {
            await Assert.ThrowsAsync<PlacaInvalidaException>(() =>
                _service.RegistrarEntradaAsync(""));
        }

        // Teste de entrada com carro já no estacionamento
        [Fact]
        public async Task RegistrarEntrada_DeveLancarCarroComEntradaSemSaidaException_SeCarroEstiverNoEstacionamento()
        {
            var placa = "XYZ1234";

            A.CallTo(() => _carroRepo.ValidaPlacaAsync(placa)).Returns(true);
            A.CallTo(() => _carroRepo.ObterCarroAsync(placa)).Returns(new Carro { Placa = placa });
            A.CallTo(() => _entradaSaidaRepo.ExisteCarroSemSaidaAsync(placa)).Returns(true);

            await Assert.ThrowsAsync<CarroComEntradaSemSaidaException>(() =>
                _service.RegistrarEntradaAsync(placa));
        }

        // Teste de saída com carro inexistente
        [Fact]
        public async Task RegistrarSaida_DeveLancarCarroNaoEncontradoException_SeCarroNaoExistir()
        {
            var placa = "ABC1234";

            A.CallTo(() => _carroRepo.ValidaPlacaAsync(placa)).Returns(true);
            A.CallTo(() => _carroRepo.ObterCarroAsync(placa)).Returns(null as Carro);

            await Assert.ThrowsAsync<CarroNaoEncontradoException>(() =>
                _service.RegistrarSaidaAsync(placa));
        }

        // Teste de saída com sucesso
        [Fact]
        public async Task RegistrarSaida_DeveRetornarDTO_SeTudoEstiverValido()
        {
            var placa = "XYZ1234";
            var entrada = new EntradaSaida
            {
                PlacaCarro = placa,
                DataEntrada = DateTime.UtcNow.AddHours(-2),
                DataSaida = null
            };

            var preco = new PrecoEstacionamento
            {
                ValorHoraInicial = 10,
                ValorHoraAdicional = 5
            };

            A.CallTo(() => _carroRepo.ValidaPlacaAsync(placa)).Returns(true);
            A.CallTo(() => _carroRepo.ObterCarroAsync(placa)).Returns(new Carro { Placa = placa });
            A.CallTo(() => _entradaSaidaRepo.BuscaUltimaEntradaSaidaAsync(placa)).Returns(entrada);
            A.CallTo(() => _precoRepo.BuscaPrecoEstacionamentoVigenteAsync()).Returns(preco);

            var resultado = await _service.RegistrarSaidaAsync(placa);

            Assert.NotNull(resultado);
            Assert.Equal(placa, resultado.PlacaCarro);
            Assert.NotNull(resultado.DataSaida);
        }
    }
}
