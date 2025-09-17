namespace ControleDeEstacionamento.Desktop.Formularios
{
    partial class AdicionarPrecoForm
    {
        private System.ComponentModel.IContainer components = null;

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblValorHoraInicial = new System.Windows.Forms.Label();
            this.lblValorHoraAdicional = new System.Windows.Forms.Label();
            this.lblDataInicioVigencia = new System.Windows.Forms.Label();
            this.lblDataFimVigencia = new System.Windows.Forms.Label();
            this.numValorHoraInicial = new System.Windows.Forms.NumericUpDown();
            this.numValorHoraAdicional = new System.Windows.Forms.NumericUpDown();
            this.dtpDataInicioVigencia = new System.Windows.Forms.DateTimePicker();
            this.dtpDataFimVigencia = new System.Windows.Forms.DateTimePicker();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();

            ((System.ComponentModel.ISupportInitialize)(this.numValorHoraInicial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numValorHoraAdicional)).BeginInit();
            this.SuspendLayout();

            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(162, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Adicionar Preço";

            //
            // lblValorHoraInicial
            //
            this.lblValorHoraInicial.AutoSize = true;
            this.lblValorHoraInicial.Location = new System.Drawing.Point(20, 70);
            this.lblValorHoraInicial.Name = "lblValorHoraInicial";
            this.lblValorHoraInicial.Size = new System.Drawing.Size(100, 15);
            this.lblValorHoraInicial.TabIndex = 1;
            this.lblValorHoraInicial.Text = "Valor Hora Inicial:";

            //
            // numValorHoraInicial
            //
            this.numValorHoraInicial.DecimalPlaces = 2;
            this.numValorHoraInicial.Location = new System.Drawing.Point(150, 68);
            this.numValorHoraInicial.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            this.numValorHoraInicial.Name = "numValorHoraInicial";
            this.numValorHoraInicial.Size = new System.Drawing.Size(120, 23);
            this.numValorHoraInicial.TabIndex = 2;

            //
            // lblValorHoraAdicional
            //
            this.lblValorHoraAdicional.AutoSize = true;
            this.lblValorHoraAdicional.Location = new System.Drawing.Point(20, 110);
            this.lblValorHoraAdicional.Name = "lblValorHoraAdicional";
            this.lblValorHoraAdicional.Size = new System.Drawing.Size(119, 15);
            this.lblValorHoraAdicional.TabIndex = 3;
            this.lblValorHoraAdicional.Text = "Valor Hora Adicional:";

            //
            // numValorHoraAdicional
            //
            this.numValorHoraAdicional.DecimalPlaces = 2;
            this.numValorHoraAdicional.Location = new System.Drawing.Point(150, 108);
            this.numValorHoraAdicional.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            this.numValorHoraAdicional.Name = "numValorHoraAdicional";
            this.numValorHoraAdicional.Size = new System.Drawing.Size(120, 23);
            this.numValorHoraAdicional.TabIndex = 4;

            //
            // lblDataInicioVigencia
            //
            this.lblDataInicioVigencia.AutoSize = true;
            this.lblDataInicioVigencia.Location = new System.Drawing.Point(20, 150);
            this.lblDataInicioVigencia.Name = "lblDataInicioVigencia";
            this.lblDataInicioVigencia.Size = new System.Drawing.Size(95, 15);
            this.lblDataInicioVigencia.TabIndex = 5;
            this.lblDataInicioVigencia.Text = "Início Vigência:";

            //
            // dtpDataInicioVigencia
            //
            this.dtpDataInicioVigencia.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpDataInicioVigencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataInicioVigencia.Location = new System.Drawing.Point(150, 148);
            this.dtpDataInicioVigencia.Name = "dtpDataInicioVigencia";
            this.dtpDataInicioVigencia.ShowUpDown = true;
            this.dtpDataInicioVigencia.Size = new System.Drawing.Size(160, 23);
            this.dtpDataInicioVigencia.TabIndex = 6;

            //
            // lblDataFimVigencia
            //
            this.lblDataFimVigencia.AutoSize = true;
            this.lblDataFimVigencia.Location = new System.Drawing.Point(20, 190);
            this.lblDataFimVigencia.Name = "lblDataFimVigencia";
            this.lblDataFimVigencia.Size = new System.Drawing.Size(82, 15);
            this.lblDataFimVigencia.TabIndex = 7;
            this.lblDataFimVigencia.Text = "Fim Vigência:";

            //
            // dtpDataFimVigencia
            //
            this.dtpDataFimVigencia.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpDataFimVigencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataFimVigencia.Location = new System.Drawing.Point(150, 188);
            this.dtpDataFimVigencia.Name = "dtpDataFimVigencia";
            this.dtpDataFimVigencia.ShowUpDown = true;
            this.dtpDataFimVigencia.Size = new System.Drawing.Size(160, 23);
            this.dtpDataFimVigencia.TabIndex = 8;

            //
            // progressBar
            //
            this.progressBar.Location = new System.Drawing.Point(20, 230);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(290, 20);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 9;
            this.progressBar.Visible = false;

            //
            // btnCancelar
            //
            this.btnCancelar.Location = new System.Drawing.Point(150, 270);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 30);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            //
            // btnSalvar
            //
            this.btnSalvar.Location = new System.Drawing.Point(240, 270);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(80, 30);
            this.btnSalvar.TabIndex = 11;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);

            //
            // AdicionarPrecoForm
            //
            this.AcceptButton = this.btnSalvar;
            this.CancelButton = this.btnCancelar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 320);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblValorHoraInicial);
            this.Controls.Add(this.numValorHoraInicial);
            this.Controls.Add(this.lblValorHoraAdicional);
            this.Controls.Add(this.numValorHoraAdicional);
            this.Controls.Add(this.lblDataInicioVigencia);
            this.Controls.Add(this.dtpDataInicioVigencia);
            this.Controls.Add(this.lblDataFimVigencia);
            this.Controls.Add(this.dtpDataFimVigencia);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdicionarPrecoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Adicionar Preço";

            ((System.ComponentModel.ISupportInitialize)(this.numValorHoraInicial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numValorHoraAdicional)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblValorHoraInicial;
        private System.Windows.Forms.Label lblValorHoraAdicional;
        private System.Windows.Forms.Label lblDataInicioVigencia;
        private System.Windows.Forms.Label lblDataFimVigencia;
        private System.Windows.Forms.NumericUpDown numValorHoraInicial;
        private System.Windows.Forms.NumericUpDown numValorHoraAdicional;
        private System.Windows.Forms.DateTimePicker dtpDataInicioVigencia;
        private System.Windows.Forms.DateTimePicker dtpDataFimVigencia;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}