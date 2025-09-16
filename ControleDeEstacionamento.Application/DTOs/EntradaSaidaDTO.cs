using ControleDeEstacionamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstacionamento.Application.DTOs
{
    public class EntradaSaidaDTO
    {
        public int Id {  get; set; }
        public string PlacaCarro { get; set; } = string.Empty;
        public DateTime DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }
        public decimal ValorAPagar { get; set; }
    }
}
