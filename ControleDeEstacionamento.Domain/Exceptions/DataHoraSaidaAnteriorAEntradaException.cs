using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstacionamento.Domain.Exceptions
{
    public class DataHoraSaidaAnteriorAEntradaException : Exception
    {
        public DataHoraSaidaAnteriorAEntradaException()
        : base($"Data/Hora de saída anterior a data/hora de entrada.") { }
    }
}
