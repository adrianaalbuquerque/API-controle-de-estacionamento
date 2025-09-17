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

        private async void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabPageEntradasSaidas)
            {
                await CarregarEntradasSaidas();
            }
            else if (tabControl.SelectedTab == tabPagePrecos)
            {
                await CarregarPrecos();
            }
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

        private async Task CarregarEntradasSaidas()
        {
            try
            {
                progressBarEntradasSaidas.Visible = true;
                dataGridViewEntradasSaidas.Enabled = false;
                btnRegistrarEntrada.Enabled = false;
                btnRegistrarSaida.Enabled = false;

                var entradasSaidas = await _apiClient.BuscarTodasEntradasSaidasAsync();

                foreach (var entrada in entradasSaidas)
                {
                    entrada.DataEntrada = ConverterParaUtcMenos3(entrada.DataEntrada);
                    if (entrada.DataSaida.HasValue)
                    {
                        entrada.DataSaida = ConverterParaUtcMenos3(entrada.DataSaida.Value);
                    }
                }

                dataGridViewEntradasSaidas.DataSource = entradasSaidas;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                progressBarEntradasSaidas.Visible = false;
                dataGridViewEntradasSaidas.Enabled = true;
                btnRegistrarEntrada.Enabled = true;
                btnRegistrarSaida.Enabled = true;
            }
        }

        private async void btnAdicionarPreco_Click(object sender, EventArgs e)
        {
            var form = new AdicionarPrecoForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                await CarregarPrecos();
            }
        }

        private async void btnRegistrarEntrada_Click(object sender, EventArgs e)
        {
            var form = new RegistrarEntradaForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                await CarregarEntradasSaidas();
            }
        }

        private async void btnRegistrarSaida_Click(object sender, EventArgs e)
        {
            var form = new RegistrarSaidaForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                await CarregarEntradasSaidas();
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
