using System.ComponentModel.DataAnnotations;

namespace ControleDeEstacionamento.Domain.Models
{
    public class Carro
    {
        [Key]
        [StringLength(8)]
        public string Placa { get; set; } = string.Empty;
        public List<EntradaSaida> EntradasSaidas { get; set; } = new List<EntradaSaida>();
    }

}
