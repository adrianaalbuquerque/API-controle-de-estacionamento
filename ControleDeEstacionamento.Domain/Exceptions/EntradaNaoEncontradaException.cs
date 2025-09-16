using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstacionamento.Domain.Exceptions
{
    public class EntradaNaoEncontradaException: Exception
    {
        public EntradaNaoEncontradaException(string placa)
            : base($"Entrada não encontrada para carro com a placa '{placa}'.") { }
    }
}
