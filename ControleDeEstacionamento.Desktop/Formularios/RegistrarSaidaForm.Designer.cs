namespace ControleDeEstacionamento.Desktop.Formularios
{
    partial class RegistrarSaidaForm
    {
        private System.ComponentModel.IContainer components = null;

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblPlaca = new System.Windows.Forms.Label();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();

            this.SuspendLayout();

            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(155, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Registrar Saída";

            //
            // lblPlaca
            //
            this.lblPlaca.AutoSize = true;
            this.lblPlaca.Location = new System.Drawing.Point(20, 70);
            this.lblPlaca.Name = "lblPlaca";
            this.lblPlaca.Size = new System.Drawing.Size(94, 15);
            this.lblPlaca.TabIndex = 1;
            this.lblPlaca.Text = "Placa do Veículo:";

            //
            // txtPlaca
            //
            this.txtPlaca.Location = new System.Drawing.Point(130, 67);
            this.txtPlaca.MaxLength = 8;
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(120, 23);
            this.txtPlaca.TabIndex = 2;
            this.txtPlaca.PlaceholderText = "Ex: ABC1234";
            this.txtPlaca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;

            //
            // progressBar
            //
            this.progressBar.Location = new System.Drawing.Point(20, 110);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(230, 20);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 3;
            this.progressBar.Visible = false;

            //
            // btnCancelar
            //
            this.btnCancelar.Location = new System.Drawing.Point(90, 150);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 30);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            //
            // btnRegistrar
            //
            this.btnRegistrar.Location = new System.Drawing.Point(180, 150);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(80, 30);
            this.btnRegistrar.TabIndex = 5;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);

            //
            // RegistrarSaidaForm
            //
            this.AcceptButton = this.btnRegistrar;
            this.CancelButton = this.btnCancelar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 200);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblPlaca);
            this.Controls.Add(this.txtPlaca);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnRegistrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistrarSaidaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registrar Saída";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblPlaca;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}