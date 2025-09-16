using ControleDeEstacionamento.Domain.Interfaces;
using ControleDeEstacionamento.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace ControleDeEstacionamento.Infrastructure.Repository
{
    public class CarroRepository : ICarroRepository
    {
        private readonly AppDbContext _context;
        public CarroRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Carro?> ObterCarroAsync(string placa)
        {
            return await _context.carro
                   .FirstOrDefaultAsync(c => c.Placa == placa);
        }

        public async Task InsereCarroAsync(Carro carro)
        {
            await _context.carro.AddAsync(carro);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidaPlacaAsync(string placa)
        {
            placa = placa.Trim().ToUpper();
            var regex = new Regex(@"^[A-Z]{3}[0-9][A-Z0-9][0-9]{2}$");
            return await Task.FromResult(regex.IsMatch(placa));
        }
    }
}