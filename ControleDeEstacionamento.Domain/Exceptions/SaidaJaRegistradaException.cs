using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstacionamento.Domain.Exceptions
{
    public class SaidaJaRegistradaException : Exception
    {
        public SaidaJaRegistradaException(string placa)
             : base($"Carro com placa '{placa}' já registrou saída.") { }
    }
}
