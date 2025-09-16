using ControleDeEstacionamento.Domain.Models;

namespace ControleDeEstacionamento.Domain.Interfaces
{
    public interface ICarroRepository
    {
        public Task<Carro?> BuscarPorPlacaAsync(string placa);
        public Task InsereCarroAsync(Carro carro);
    }
}
