using ControleDeEstacionamento.Desktop.ClientesAPI;

namespace ControleDeEstacionamento.Desktop.Formularios
{
    public partial class RegistrarEntradaForm : Form
    {
        private EstacionamentoApiClient _apiClient;

        public RegistrarEntradaForm()
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

                await _apiClient.RegistrarEntradaAsync(txtPlaca.Text.Trim().ToUpper());

                MessageBox.Show("Entrada registrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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