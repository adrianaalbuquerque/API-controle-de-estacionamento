using ControleDeEstacionamento.Desktop.ClientesAPI;
using ControleDeEstacionamento.Desktop.Modelos;

namespace ControleDeEstacionamento.Desktop.Formularios
{
    public partial class ControleDeEstacionamento : Form
    {
        private EstacionamentoApiClient _apiClient;

        public ControleDeEstacionamento()
        {
            InitializeComponent();
            _apiClient = new EstacionamentoApiClient();
        }

        private async void ControleDeEstacionamento_Load(object sender, EventArgs e)
        {
            await CarregarPrecos();
        }

        private async Task CarregarPrecos()
        {
            try
            {
                progressBarPrecos.Visible = true;
                dataGridViewPrecos.Enabled = false;
                btnAdicionarPreco.Enabled = false;

                var precos = await _apiClient.BuscarTodosPrecosEstacionamentoAsync();

                foreach (var preco in precos)
                {
                    preco.DataInicioVigencia = ConverterParaUtcMenos3(preco.DataInicioVigencia);
                    preco.DataFimVigencia = ConverterParaUtcMenos3(preco.DataFimVigencia);
                }

                dataGridViewPrecos.DataSource = precos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                progressBarPrecos.Visible = false;
                dataGridViewPrecos.Enabled = true;
                btnAdicionarPreco.Enabled = true;
            }
        }

        private DateTime ConverterParaUtcMenos3(DateTime dataUtc)
        {
            return dataUtc.AddHours(-3);
        }

        private async void btnAdicionarPreco_Click(object sender, EventArgs e)
        {
            var form = new AdicionarPrecoForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                await CarregarPrecos();
            }
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
