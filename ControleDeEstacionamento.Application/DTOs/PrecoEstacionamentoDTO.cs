using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstacionamento.Application.DTOs
{
    public class PrecoEstacionamentoDTO
    {
        public decimal ValorHoraInicial { get; set; }
        public decimal ValorHoraAdicional { get; set; }
        public DateTime DataInicioVigencia { get; set; }
        public DateTime DataFimVigencia { get; set; }
    }
}
