using ControleDeEstacionamento.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstacionamento.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Carro> carro { get; set; }
        public DbSet<PrecoEstacionamento> preco_estacionamento { get; set; }
        public DbSet<EntradaSaida> entrada_saida { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=controle_estacionamento;Username=postgres;Password=1234");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Carro>()
        //        .HasKey(e => e.Placa);

        //    modelBuilder.Entity<Carro>().ToTable("carro");
        //}
    }
}
