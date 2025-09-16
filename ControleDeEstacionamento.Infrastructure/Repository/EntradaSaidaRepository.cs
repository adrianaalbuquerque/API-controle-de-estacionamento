using ControleDeEstacionamento.Domain.Interfaces;
using ControleDeEstacionamento.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstacionamento.Infrastructure.Repository
{
    public class EntradaSaidaRepository : IEntradaSaidaRepository
    {
        private readonly AppDbContext _context;     
        
        public EntradaSaidaRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<EntradaSaida?> BuscaUltimaEntradaSaidaAsync(string placa)
        {
            var ultimaEntradaSaida = await _context.entrada_saida
                .Where(e => e.PlacaCarro == placa)
                .OrderByDescending(e => e.DataEntrada)
                .FirstOrDefaultAsync();

            return ultimaEntradaSaida;
        }
        public async Task RegistrarEntradaAsync(EntradaSaida entrada)
        {
            await _context.entrada_saida.AddAsync(entrada);
            await _context.SaveChangesAsync();

        }
        public async Task RegistraSaidaAsync(EntradaSaida saida)
        {
            _context.Update(saida);
            await _context.SaveChangesAsync();
        }
    }
}
