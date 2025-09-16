using ControleDeEstacionamento.Domain.Models;

namespace ControleDeEstacionamento.Domain.Interfaces
{
    public interface ICarroRepository
    {
        public Task<Carro?> ObterCarroAsync(string placa);
        public Task InsereCarroAsync(Carro carro);
        public Task<bool> ValidaPlacaAsync(string placa);
    }
}
