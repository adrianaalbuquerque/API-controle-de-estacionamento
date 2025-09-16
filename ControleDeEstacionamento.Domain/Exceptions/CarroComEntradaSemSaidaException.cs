using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstacionamento.Domain.Exceptions
{
    public class CarroComEntradaSemSaidaException : Exception
    {
        public CarroComEntradaSemSaidaException(string placa)
        : base($"Não é possível realizar nova entrada para o carro. Carro com placa '{placa}' ainda se encontra no estacionamento.") { }
    }
}
