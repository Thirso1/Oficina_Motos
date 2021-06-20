namespace Oficina_Motos.View
{
    partial class FrmAberturaCaixa1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDinheiro = new System.Windows.Forms.TextBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.textSaldoEmCaixa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textDataUltimoFechamento = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textRecolUltFechamento = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textUsuarioUltFechamento = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textValorAbertura = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textUsuario = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Abertura de Caixa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(46, 438);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Valor de Abertura:";
            // 
            // txtDinheiro
            // 
            this.txtDinheiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDinheiro.Location = new System.Drawing.Point(210, 397);
            this.txtDinheiro.Name = "txtDinheiro";
            this.txtDinheiro.Size = new System.Drawing.Size(208, 29);
            this.txtDinheiro.TabIndex = 2;
            this.txtDinheiro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDinheiro.TextChanged += new System.EventHandler(this.txtDinheiro_TextChanged);
            this.txtDinheiro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDinheiro_KeyPress);
            this.txtDinheiro.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDinheiro_KeyUp);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnConfirmar.FlatAppearance.BorderSize = 5;
            this.btnConfirmar.FlatAppearance.CheckedBackColor = System.Drawing.Color.ForestGreen;
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(376, 502);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(110, 37);
            this.btnConfirmar.TabIndex = 3;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // textSaldoEmCaixa
            // 
            this.textSaldoEmCaixa.BackColor = System.Drawing.Color.White;
            this.textSaldoEmCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSaldoEmCaixa.Location = new System.Drawing.Point(210, 362);
            this.textSaldoEmCaixa.Name = "textSaldoEmCaixa";
            this.textSaldoEmCaixa.ReadOnly = true;
            this.textSaldoEmCaixa.Size = new System.Drawing.Size(208, 29);
            this.textSaldoEmCaixa.TabIndex = 7;
            this.textSaldoEmCaixa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(70, 368);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Saldo em caixa:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // textDataUltimoFechamento
            // 
            this.textDataUltimoFechamento.BackColor = System.Drawing.Color.White;
            this.textDataUltimoFechamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDataUltimoFechamento.Location = new System.Drawing.Point(209, 165);
            this.textDataUltimoFechamento.Name = "textDataUltimoFechamento";
            this.textDataUltimoFechamento.ReadOnly = true;
            this.textDataUltimoFechamento.Size = new System.Drawing.Size(208, 26);
            this.textDataUltimoFechamento.TabIndex = 9;
            this.textDataUltimoFechamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(107, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Data hora:";
            // 
            // textRecolUltFechamento
            // 
            this.textRecolUltFechamento.BackColor = System.Drawing.Color.White;
            this.textRecolUltFechamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textRecolUltFechamento.Location = new System.Drawing.Point(209, 197);
            this.textRecolUltFechamento.Name = "textRecolUltFechamento";
            this.textRecolUltFechamento.ReadOnly = true;
            this.textRecolUltFechamento.Size = new System.Drawing.Size(208, 26);
            this.textRecolUltFechamento.TabIndex = 11;
            this.textRecolUltFechamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(63, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Valor Recolhido:";
            // 
            // textUsuarioUltFechamento
            // 
            this.textUsuarioUltFechamento.BackColor = System.Drawing.Color.White;
            this.textUsuarioUltFechamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUsuarioUltFechamento.Location = new System.Drawing.Point(209, 133);
            this.textUsuarioUltFechamento.Name = "textUsuarioUltFechamento";
            this.textUsuarioUltFechamento.ReadOnly = true;
            this.textUsuarioUltFechamento.Size = new System.Drawing.Size(208, 26);
            this.textUsuarioUltFechamento.TabIndex = 12;
            this.textUsuarioUltFechamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(127, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "Usuário:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button1.FlatAppearance.BorderSize = 5;
            this.button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.ForestGreen;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(260, 502);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 37);
            this.button1.TabIndex = 12;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textValorAbertura
            // 
            this.textValorAbertura.BackColor = System.Drawing.Color.White;
            this.textValorAbertura.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textValorAbertura.Location = new System.Drawing.Point(210, 432);
            this.textValorAbertura.Name = "textValorAbertura";
            this.textValorAbertura.ReadOnly = true;
            this.textValorAbertura.Size = new System.Drawing.Size(208, 29);
            this.textValorAbertura.TabIndex = 9;
            this.textValorAbertura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(49, 403);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(158, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "Suprimento Inicial:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Navy;
            this.label9.Location = new System.Drawing.Point(172, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(174, 24);
            this.label9.TabIndex = 12;
            this.label9.Text = "Último Fechamento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(121, 331);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Usuário:";
            // 
            // textUsuario
            // 
            this.textUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUsuario.Location = new System.Drawing.Point(209, 325);
            this.textUsuario.Name = "textUsuario";
            this.textUsuario.Size = new System.Drawing.Size(208, 29);
            this.textUsuario.TabIndex = 15;
            this.textUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Navy;
            this.label10.Location = new System.Drawing.Point(229, 289);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 24);
            this.label10.TabIndex = 12;
            this.label10.Text = "Abertura";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(2, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(507, 69);
            this.panel3.TabIndex = 15;
            // 
            // FrmAberturaCaixa1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(508, 561);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textRecolUltFechamento);
            this.Controls.Add(this.textUsuario);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.textValorAbertura);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDinheiro);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textSaldoEmCaixa);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textDataUltimoFechamento);
            this.Controls.Add(this.textUsuarioUltFechamento);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnConfirmar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAberturaCaixa1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAberturaCaixa1";
            this.Load += new System.EventHandler(this.FrmAberturaCaixa1_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDinheiro;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.TextBox textSaldoEmCaixa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textDataUltimoFechamento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textUsuarioUltFechamento;
        private System.Windows.Forms.TextBox textRecolUltFechamento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textValorAbertura;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
    }
}