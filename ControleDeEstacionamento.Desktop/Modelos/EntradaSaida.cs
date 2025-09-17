namespace ControleDeEstacionamento.Desktop.Modelos
{
    public class EntradaSaida
    {
        public int Id { get; set; }
        public string PlacaCarro { get; set; } = string.Empty;
        public DateTime DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }
        public decimal ValorAPagar { get; set; }
    }
}