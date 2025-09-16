using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstacionamento.Domain.Models
{
    public class PrecoEstacionamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public decimal ValorHoraInicial { get; set; }
        [Required]
        public decimal ValorHoraAdicional { get; set; }

        [Required]
        public DateTime DataInicioVigencia { get; set; }

        [Required]
        public DateTime DataFimVigencia { get; set; }
    }
}