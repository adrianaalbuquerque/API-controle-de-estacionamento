using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstacionamento.Domain.Exceptions
{
    public class VigenciaInvalidaException : Exception
    {
        public VigenciaInvalidaException()
       : base($"Data de vigência inicial não pode ser maior que a data de vigência final.") { }
    }
}
