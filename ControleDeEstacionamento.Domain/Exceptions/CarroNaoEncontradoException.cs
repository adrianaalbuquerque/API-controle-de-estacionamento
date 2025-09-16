using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstacionamento.Domain.Exceptions
{
    public class CarroNaoEncontradoException : Exception
    {
        public CarroNaoEncontradoException(string placa)
       : base($"Não é possível realizar saida para o carro com placa '{placa}' porque ele não foi registrado.") { }
    }
}
