using ControleDeEstacionamento.Domain.Models;

namespace ControleDeEstacionamento.Domain.Interfaces
{
    public interface IEntradaSaidaRepository
    {
        public Task<EntradaSaida> BuscaUltimaEntradaSaidaAsync(string placa);
        public Task RegistrarEntradaAsync(EntradaSaida entrada);
        public Task RegistraSaidaAsync(EntradaSaida saida);
    }
}
