using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstacionamento.Domain.Exceptions
{
    public class DataEntradaInvalidaException : Exception
    {
        public DataEntradaInvalidaException(string placa)
            : base($"A data de entrada para o veículo com placa '{placa}' não pode estar no futuro.") { }        
    }
}
