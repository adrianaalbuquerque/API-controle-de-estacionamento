using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstacionamento.Domain.Exceptions
{
    public class ValorHoraAdicionalInvalidoException : Exception
    {
        public ValorHoraAdicionalInvalidoException()
           : base("O valor da hora adicional deve ser maior que zero.") { }
    }
}
