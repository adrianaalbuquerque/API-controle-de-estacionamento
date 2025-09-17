using ControleDeEstacionamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstacionamento.Tests.Domain.Models
{
    public class EntradaSaidaTests
    {
        public EntradaSaidaTests() { }

        [Fact]
        public void SetValorAPagar_DeveLancarNullReferenceException_QuandoDataSaidaForNula()
        {
            EntradaSaida entradaSaida = new EntradaSaida();
            entradaSaida.DataSaida = null;

            Assert.Throws<NullReferenceException>(() =>
              entradaSaida.SetValorAPagar(0, 0));
        }

        [Fact]
        public void SetValorAPagar_NaoDeveLancarNullReferenceException_QuandoDataSaidaNaoForNula()
        {
            EntradaSaida entradaSaida = new EntradaSaida();
            entradaSaida.DataSaida = DateTime.Now;

            entradaSaida.SetValorAPagar(0, 0);
        }

        [Fact]
        public void SetValorAPagar_DevePagarMetadeDaHoraInicial_QuandoPassar30minutosOuMenos()
        {
            EntradaSaida entradaSaida = new EntradaSaida();
            entradaSaida.DataEntrada = DateTime.Now;
            entradaSaida.DataSaida = entradaSaida.DataEntrada.AddMinutes(30);
            
            entradaSaida.SetValorAPagar(2, 1);
            Assert.Equal(1, entradaSaida.ValorAPagar);

        }

        [Fact]
        public void SetValorAPagar_DevePagarHoraInicial_QuandoNaoPassarDaPrimeiraHoraMaisTolerancia()
        {
            EntradaSaida entradaSaida = new EntradaSaida();
            entradaSaida.DataEntrada = DateTime.Now;
            TimeSpan tolerancia = TimeSpan.FromMinutes(10);
            entradaSaida.DataSaida = entradaSaida.DataEntrada.AddMinutes(60) + tolerancia;

            entradaSaida.SetValorAPagar(2, 1);
            Assert.Equal(2, entradaSaida.ValorAPagar);

        }

        [Fact]
        public void SetValorAPagar_DevePagarHoraInicial_QuandoPassarExatamenteUmaHora()
        {
            EntradaSaida entradaSaida = new EntradaSaida();
            entradaSaida.DataEntrada = DateTime.Now;
            entradaSaida.DataSaida = entradaSaida.DataEntrada.AddMinutes(60);

            entradaSaida.SetValorAPagar(2, 1);
            Assert.Equal(2, entradaSaida.ValorAPagar);

        }

        [Fact]
        public void SetValorAPagar_DevePagarHorasAdicionais_QuandoPassarDaPrimeiraHoraMaisTolerancia()
        {
            EntradaSaida entradaSaida = new EntradaSaida();
            entradaSaida.DataEntrada = DateTime.Now;
            TimeSpan tolerancia = TimeSpan.FromMinutes(10);
            entradaSaida.DataSaida = entradaSaida.DataEntrada.AddMinutes(60) + tolerancia + TimeSpan.FromMinutes(5); //1 hora e 15 minutos

            entradaSaida.SetValorAPagar(2, 1);
            Assert.Equal(3, entradaSaida.ValorAPagar);

        }

        [Fact]
        public void SetValorAPagar_DevePagarHorasAdicionais_QuandoPassarDaPrimeiraHoraMaisToleranciaCaso2()
        {
            EntradaSaida entradaSaida = new EntradaSaida();
            entradaSaida.DataEntrada = DateTime.Now;
            entradaSaida.DataSaida = entradaSaida.DataEntrada.AddHours(2) + TimeSpan.FromMinutes(5); //2 horas e 5 minutos

            entradaSaida.SetValorAPagar(2, 1);
            Assert.Equal(3, entradaSaida.ValorAPagar);

        }

        [Fact]
        public void SetValorAPagar_DevePagarHorasAdicionais_QuandoPassarDaPrimeiraHoraMaisToleranciaCaso3()
        {
            EntradaSaida entradaSaida = new EntradaSaida();
            entradaSaida.DataEntrada = DateTime.Now;
            entradaSaida.DataSaida = entradaSaida.DataEntrada.AddHours(2) + TimeSpan.FromMinutes(15); //2 horas e 15 minutos

            entradaSaida.SetValorAPagar(2, 1);
            Assert.Equal(4, entradaSaida.ValorAPagar);

        }
    }
}
