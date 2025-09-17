namespace ControleDeEstacionamento.Desktop.Modelos
{
    public class PrecoEstacionamento
    {
        public decimal ValorHoraInicial { get; set; }
        public decimal ValorHoraAdicional { get; set; }
        public DateTime DataInicioVigencia { get; set; }
        public DateTime DataFimVigencia { get; set; }
    }
}