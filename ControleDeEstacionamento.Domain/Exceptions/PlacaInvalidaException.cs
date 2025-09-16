using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstacionamento.Domain.Exceptions
{
    public class PlacaInvalidaException : Exception
    {
        public PlacaInvalidaException(string placa)
            : base($"Placa '{placa}' inválida. Verifique o formato.") { }
    }
}
