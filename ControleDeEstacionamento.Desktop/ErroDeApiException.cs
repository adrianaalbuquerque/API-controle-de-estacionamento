namespace ControleDeEstacionamento.Desktop
{
    public class ErroDeApiException : Exception
    {
        public ErroDeApiException(string message) : base(message)
        {
        }
    }
}