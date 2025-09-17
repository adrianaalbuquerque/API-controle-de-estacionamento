using ControleDeEstacionamento.Domain.Interfaces;
using ControleDeEstacionamento.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstacionamento.Infrastructure.Repository
{
    public class PrecoEstacionamentoRepository : IPrecoEstacionamentoRepository
    {
        private readonly AppDbContext _context;
        public PrecoEstacionamentoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task InserePrecoEstacionamentoAsync(PrecoEstacionamento precoEstacionamento)
        {
            await _context.preco_estacionamento.AddAsync(precoEstacionamento);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> ExisteVigenciaConflitanteAsync(DateTime dataInicioVigencia, DateTime dataFimVigencia)
        {
            var existeVigenciaConflitante = await _context.preco_estacionamento
                .Where(e =>
                    (dataInicioVigencia <= e.DataInicioVigencia && dataFimVigencia >= e.DataFimVigencia) //dentro
                        || (dataInicioVigencia >= e.DataInicioVigencia && dataFimVigencia <= e.DataFimVigencia) // fora
                        || (dataInicioVigencia <= e.DataInicioVigencia && dataFimVigencia <= e.DataFimVigencia) //esquerda
                        || (dataInicioVigencia >= e.DataInicioVigencia && dataFimVigencia >= e.DataFimVigencia)) // direita
                .AnyAsync();
            return existeVigenciaConflitante;
        }

        public async Task<PrecoEstacionamento?> BuscaPrecoEstacionamentoVigenteAsync()
        {
            DateTime dataAgora = DateTime.UtcNow;

            var precoEstacionamentoVigente = await _context.preco_estacionamento
                .Where(e => (e.DataInicioVigencia <= dataAgora && e.DataFimVigencia >= dataAgora))
                .FirstOrDefaultAsync();
            return precoEstacionamentoVigente;
        }

        public async Task<IEnumerable<PrecoEstacionamento>> BuscarTodosPrecosEstacionamentoAsync()
        {
            return await _context.preco_estacionamento
                .OrderByDescending(p => p.DataInicioVigencia)
                .ToListAsync();
        }

    }
}
