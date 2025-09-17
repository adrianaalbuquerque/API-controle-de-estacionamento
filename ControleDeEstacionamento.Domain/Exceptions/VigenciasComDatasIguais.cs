using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstacionamento.Domain.Exceptions
{
    public class VigenciasComDatasIguais : Exception
    {
        public VigenciasComDatasIguais()
        : base($"Datas de vigências iguais.") { }
    }
}
