using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstacionamento.Domain.Models
{
    public class EntradaSaida
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey(nameof(Carro))]
        public string PlacaCarro { get; set; } = string.Empty;  // FK de carro
        public Carro Carro { get; set; }  // propriedade de navegação
        [Required]
        public DateTime DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }
        [Required]
        public decimal ValorAPagar { get; set; }

        public void SetValorAPagar(decimal valorHoraInicial, decimal valorHoraAdicional)
        {
            if (DataSaida == null)
            {
                throw new NullReferenceException("O veículo ainda não saiu do estacionamento");
            }

            var tempoPassado = DataSaida - DataEntrada;
            if (tempoPassado <= TimeSpan.FromMinutes(30))
            {
                ValorAPagar = valorHoraInicial / 2;
                return;
            }
            var tolerancia = TimeSpan.FromMinutes(10);
            if (tempoPassado <= TimeSpan.FromHours(1) + tolerancia)
            {
                ValorAPagar = valorHoraInicial;
                return;
            }
            var horasAdicionais = tempoPassado.Value.TotalHours - 1; // retirando a hora inicial
            var temHoraExcedente = tempoPassado.Value.Minutes > 10;
            ValorAPagar = valorHoraInicial + Convert.ToDecimal(horasAdicionais) * valorHoraAdicional + (temHoraExcedente ? valorHoraAdicional : 0);
            
        }
    }
}
