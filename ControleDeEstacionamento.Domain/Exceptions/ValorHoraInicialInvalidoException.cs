using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstacionamento.Domain.Exceptions
{
    public class ValorHoraInicialInvalidoException : Exception
    {
        public ValorHoraInicialInvalidoException()
           : base("O valor da hora inicial deve ser maior que zero.") { }
    }
}
