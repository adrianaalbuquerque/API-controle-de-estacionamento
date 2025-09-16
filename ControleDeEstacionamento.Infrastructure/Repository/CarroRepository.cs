using ControleDeEstacionamento.Domain.Interfaces;
using ControleDeEstacionamento.Domain.Models;

namespace ControleDeEstacionamento.Infrastructure.Repository
{
    public class CarroRepository : ICarroRepository
    {
        private readonly AppDbContext _context;
        public CarroRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Carro?> BuscarPorPlacaAsync(string placa)
        {
            var carro = await _context.carro.FindAsync(placa);
            return carro;
        }

        public async Task InsereCarroAsync(Carro carro)
        {
            await _context.carro.AddAsync(carro);
            await _context.SaveChangesAsync();
        }
    }
}