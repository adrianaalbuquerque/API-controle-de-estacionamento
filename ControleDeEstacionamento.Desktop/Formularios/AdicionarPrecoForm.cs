using ControleDeEstacionamento.Desktop.ClientesAPI;
using ControleDeEstacionamento.Desktop.Modelos;

namespace ControleDeEstacionamento.Desktop.Formularios
{
    public partial class AdicionarPrecoForm : Form
    {
        private EstacionamentoApiClient _apiClient;

        public AdicionarPrecoForm()
        {
            InitializeComponent();
            _apiClient = new EstacionamentoApiClient();
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                progressBar.Visible = true;
                btnSalvar.Enabled = false;
                btnCancelar.Enabled = false;

                var preco = new PrecoEstacionamento
                {
                    ValorHoraInicial = numValorHoraInicial.Value,
                    ValorHoraAdicional = numValorHoraAdicional.Value,
                    DataInicioVigencia = ConverterParaUtc(dtpDataInicioVigencia.Value),
                    DataFimVigencia = ConverterParaUtc(dtpDataFimVigencia.Value)
                };

                await _apiClient.AdicionarPrecoAsync(preco);
                MessageBox.Show("Preço adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                btnSalvar.Enabled = true;
                btnCancelar.Enabled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private DateTime ConverterParaUtc(DateTime dataLocal)
        {
            return DateTime.SpecifyKind(dataLocal.AddHours(3), DateTimeKind.Utc);
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