using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstacionamento.Domain.Exceptions
{
    public class VigenciaMenorQueDataAtualException : Exception
    {
        public VigenciaMenorQueDataAtualException()
       : base($"Data da vigência menor que data atual.") { }
    }
}
