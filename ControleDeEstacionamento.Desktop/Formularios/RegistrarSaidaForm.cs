using ControleDeEstacionamento.Desktop.ClientesAPI;
using ControleDeEstacionamento.Desktop.Modelos;

namespace ControleDeEstacionamento.Desktop.Formularios
{
    public partial class RegistrarSaidaForm : Form
    {
        private EstacionamentoApiClient _apiClient;

        public RegistrarSaidaForm()
        {
            InitializeComponent();
            _apiClient = new EstacionamentoApiClient();
        }

        private async void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtPlaca.Text))
                {
                    MessageBox.Show("Por favor, informe a placa do veículo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPlaca.Focus();
                    return;
                }

                progressBar.Visible = true;
                btnRegistrar.Enabled = false;
                btnCancelar.Enabled = false;
                txtPlaca.Enabled = false;

                var resultado = await _apiClient.RegistrarSaidaAsync(txtPlaca.Text.Trim().ToUpper());

                resultado.DataEntrada = ConverterParaUtcMenos3(resultado.DataEntrada);
                if (resultado.DataSaida.HasValue)
                {
                    resultado.DataSaida = ConverterParaUtcMenos3(resultado.DataSaida.Value);
                }

                var tempoPassado = resultado.DataSaida.HasValue
                    ? resultado.DataSaida.Value - resultado.DataEntrada
                    : TimeSpan.Zero;

                var tempoFormatado = $"{(int)tempoPassado.TotalHours}h {tempoPassado.Minutes}min {tempoPassado.Seconds}s";

                var mensagem = $"Saída registrada com sucesso!\n\n" +
                              $"Placa: {resultado.PlacaCarro}\n" +
                              $"Entrada: {resultado.DataEntrada:dd/MM/yyyy HH:mm:ss}\n" +
                              $"Saída: {resultado.DataSaida?.ToString("dd/MM/yyyy HH:mm:ss") ?? "N/A"}\n" +
                              $"Tempo passado: {tempoFormatado}\n" +
                              $"Valor a pagar: {resultado.ValorAPagar:C2}";

                MessageBox.Show(mensagem, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                progressBar.Visible = false;
                btnRegistrar.Enabled = true;
                btnCancelar.Enabled = true;
                txtPlaca.Enabled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private DateTime ConverterParaUtcMenos3(DateTime dataUtc)
        {
            return dataUtc.AddHours(-3);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _apiClient?.Dispose();
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}