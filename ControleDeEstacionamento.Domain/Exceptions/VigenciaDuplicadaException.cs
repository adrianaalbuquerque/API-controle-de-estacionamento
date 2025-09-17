using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstacionamento.Domain.Exceptions
{
    public class VigenciaDuplicadaException : Exception
    {
        public VigenciaDuplicadaException()
           : base("Já existe um preço cadastrado para esse período de vigência.") { }
    }
}
