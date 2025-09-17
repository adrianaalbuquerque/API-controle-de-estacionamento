namespace ControleDeEstacionamento.Desktop.Formularios
{
    partial class ControleDeEstacionamento
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPagePrecos = new System.Windows.Forms.TabPage();
            this.tabPageEntradasSaidas = new System.Windows.Forms.TabPage();
            this.dataGridViewPrecos = new System.Windows.Forms.DataGridView();
            this.btnAdicionarPreco = new System.Windows.Forms.Button();
            this.lblTituloPrecos = new System.Windows.Forms.Label();
            this.dataGridViewEntradasSaidas = new System.Windows.Forms.DataGridView();
            this.btnRegistrarEntrada = new System.Windows.Forms.Button();
            this.btnRegistrarSaida = new System.Windows.Forms.Button();
            this.lblTituloEntradasSaidas = new System.Windows.Forms.Label();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.lblPlaca = new System.Windows.Forms.Label();

            this.tabControl.SuspendLayout();
            this.tabPagePrecos.SuspendLayout();
            this.tabPageEntradasSaidas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrecos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEntradasSaidas)).BeginInit();
            this.SuspendLayout();

            //
            // tabControl
            //
            this.tabControl.Controls.Add(this.tabPagePrecos);
            this.tabControl.Controls.Add(this.tabPageEntradasSaidas);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(900, 600);
            this.tabControl.TabIndex = 0;

            //
            // tabPagePrecos
            //
            this.tabPagePrecos.Controls.Add(this.dataGridViewPrecos);
            this.tabPagePrecos.Controls.Add(this.btnAdicionarPreco);
            this.tabPagePrecos.Controls.Add(this.lblTituloPrecos);
            this.tabPagePrecos.Location = new System.Drawing.Point(4, 24);
            this.tabPagePrecos.Name = "tabPagePrecos";
            this.tabPagePrecos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePrecos.Size = new System.Drawing.Size(892, 572);
            this.tabPagePrecos.TabIndex = 0;
            this.tabPagePrecos.Text = "Preços";
            this.tabPagePrecos.UseVisualStyleBackColor = true;

            //
            // dataGridViewPrecos
            //
            this.dataGridViewPrecos.AllowUserToAddRows = false;
            this.dataGridViewPrecos.AllowUserToDeleteRows = false;
            this.dataGridViewPrecos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPrecos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPrecos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPrecos.Location = new System.Drawing.Point(20, 80);
            this.dataGridViewPrecos.Name = "dataGridViewPrecos";
            this.dataGridViewPrecos.ReadOnly = true;
            this.dataGridViewPrecos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPrecos.Size = new System.Drawing.Size(850, 400);
            this.dataGridViewPrecos.TabIndex = 2;
            this.dataGridViewPrecos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                new System.Windows.Forms.DataGridViewTextBoxColumn() {
                    Name = "ValorHoraInicial",
                    HeaderText = "Valor Hora Inicial",
                    DataPropertyName = "ValorHoraInicial",
                    DefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle() { Format = "C2" }
                },
                new System.Windows.Forms.DataGridViewTextBoxColumn() {
                    Name = "ValorHoraAdicional",
                    HeaderText = "Valor Hora Adicional",
                    DataPropertyName = "ValorHoraAdicional",
                    DefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle() { Format = "C2" }
                },
                new System.Windows.Forms.DataGridViewTextBoxColumn() {
                    Name = "DataInicioVigencia",
                    HeaderText = "Início Vigência",
                    DataPropertyName = "DataInicioVigencia",
                    DefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle() { Format = "dd/MM/yyyy HH:mm:ss" }
                },
                new System.Windows.Forms.DataGridViewTextBoxColumn() {
                    Name = "DataFimVigencia",
                    HeaderText = "Fim Vigência",
                    DataPropertyName = "DataFimVigencia",
                    DefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle() { Format = "dd/MM/yyyy HH:mm:ss" }
                }
            });

            //
            // btnAdicionarPreco
            //
            this.btnAdicionarPreco.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdicionarPreco.Location = new System.Drawing.Point(760, 510);
            this.btnAdicionarPreco.Name = "btnAdicionarPreco";
            this.btnAdicionarPreco.Size = new System.Drawing.Size(110, 35);
            this.btnAdicionarPreco.TabIndex = 1;
            this.btnAdicionarPreco.Text = "Adicionar Preço";
            this.btnAdicionarPreco.UseVisualStyleBackColor = true;

            //
            // lblTituloPrecos
            //
            this.lblTituloPrecos.AutoSize = true;
            this.lblTituloPrecos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTituloPrecos.Location = new System.Drawing.Point(20, 20);
            this.lblTituloPrecos.Name = "lblTituloPrecos";
            this.lblTituloPrecos.Size = new System.Drawing.Size(228, 24);
            this.lblTituloPrecos.TabIndex = 0;
            this.lblTituloPrecos.Text = "Preços de Estacionamento";

            //
            // tabPageEntradasSaidas
            //
            this.tabPageEntradasSaidas.Controls.Add(this.dataGridViewEntradasSaidas);
            this.tabPageEntradasSaidas.Controls.Add(this.lblPlaca);
            this.tabPageEntradasSaidas.Controls.Add(this.txtPlaca);
            this.tabPageEntradasSaidas.Controls.Add(this.btnRegistrarSaida);
            this.tabPageEntradasSaidas.Controls.Add(this.btnRegistrarEntrada);
            this.tabPageEntradasSaidas.Controls.Add(this.lblTituloEntradasSaidas);
            this.tabPageEntradasSaidas.Location = new System.Drawing.Point(4, 24);
            this.tabPageEntradasSaidas.Name = "tabPageEntradasSaidas";
            this.tabPageEntradasSaidas.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEntradasSaidas.Size = new System.Drawing.Size(892, 572);
            this.tabPageEntradasSaidas.TabIndex = 1;
            this.tabPageEntradasSaidas.Text = "Entradas e Saídas";
            this.tabPageEntradasSaidas.UseVisualStyleBackColor = true;

            //
            // dataGridViewEntradasSaidas
            //
            this.dataGridViewEntradasSaidas.AllowUserToAddRows = false;
            this.dataGridViewEntradasSaidas.AllowUserToDeleteRows = false;
            this.dataGridViewEntradasSaidas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewEntradasSaidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEntradasSaidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEntradasSaidas.Location = new System.Drawing.Point(20, 120);
            this.dataGridViewEntradasSaidas.Name = "dataGridViewEntradasSaidas";
            this.dataGridViewEntradasSaidas.ReadOnly = true;
            this.dataGridViewEntradasSaidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEntradasSaidas.Size = new System.Drawing.Size(850, 360);
            this.dataGridViewEntradasSaidas.TabIndex = 5;

            //
            // lblPlaca
            //
            this.lblPlaca.AutoSize = true;
            this.lblPlaca.Location = new System.Drawing.Point(20, 70);
            this.lblPlaca.Name = "lblPlaca";
            this.lblPlaca.Size = new System.Drawing.Size(37, 15);
            this.lblPlaca.TabIndex = 4;
            this.lblPlaca.Text = "Placa:";

            //
            // txtPlaca
            //
            this.txtPlaca.Location = new System.Drawing.Point(65, 67);
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(120, 23);
            this.txtPlaca.TabIndex = 3;
            this.txtPlaca.PlaceholderText = "Ex: ABC1234";

            //
            // btnRegistrarSaida
            //
            this.btnRegistrarSaida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegistrarSaida.Location = new System.Drawing.Point(760, 510);
            this.btnRegistrarSaida.Name = "btnRegistrarSaida";
            this.btnRegistrarSaida.Size = new System.Drawing.Size(110, 35);
            this.btnRegistrarSaida.TabIndex = 2;
            this.btnRegistrarSaida.Text = "Registrar Saída";
            this.btnRegistrarSaida.UseVisualStyleBackColor = true;

            //
            // btnRegistrarEntrada
            //
            this.btnRegistrarEntrada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegistrarEntrada.Location = new System.Drawing.Point(630, 510);
            this.btnRegistrarEntrada.Name = "btnRegistrarEntrada";
            this.btnRegistrarEntrada.Size = new System.Drawing.Size(110, 35);
            this.btnRegistrarEntrada.TabIndex = 1;
            this.btnRegistrarEntrada.Text = "Registrar Entrada";
            this.btnRegistrarEntrada.UseVisualStyleBackColor = true;

            //
            // lblTituloEntradasSaidas
            //
            this.lblTituloEntradasSaidas.AutoSize = true;
            this.lblTituloEntradasSaidas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTituloEntradasSaidas.Location = new System.Drawing.Point(20, 20);
            this.lblTituloEntradasSaidas.Name = "lblTituloEntradasSaidas";
            this.lblTituloEntradasSaidas.Size = new System.Drawing.Size(160, 24);
            this.lblTituloEntradasSaidas.TabIndex = 0;
            this.lblTituloEntradasSaidas.Text = "Entradas e Saídas";

            //
            // ControleDeEstacionamento
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.tabControl);
            this.Name = "ControleDeEstacionamento";
            this.Text = "Controle de Estacionamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ControleDeEstacionamento_Load);

            this.tabControl.ResumeLayout(false);
            this.tabPagePrecos.ResumeLayout(false);
            this.tabPagePrecos.PerformLayout();
            this.tabPageEntradasSaidas.ResumeLayout(false);
            this.tabPageEntradasSaidas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrecos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEntradasSaidas)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPagePrecos;
        private System.Windows.Forms.TabPage tabPageEntradasSaidas;
        private System.Windows.Forms.DataGridView dataGridViewPrecos;
        private System.Windows.Forms.Button btnAdicionarPreco;
        private System.Windows.Forms.Label lblTituloPrecos;
        private System.Windows.Forms.DataGridView dataGridViewEntradasSaidas;
        private System.Windows.Forms.Button btnRegistrarEntrada;
        private System.Windows.Forms.Button btnRegistrarSaida;
        private System.Windows.Forms.Label lblTituloEntradasSaidas;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.Label lblPlaca;
    }
}
