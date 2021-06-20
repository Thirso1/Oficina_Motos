namespace Oficina_Motos.View
{
    partial class FrmRecebimento
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textRestante = new System.Windows.Forms.TextBox();
            this.textValorPago = new System.Windows.Forms.TextBox();
            this.textTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textValorDigitado = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.textDescontoPorcet = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textDescontoReais = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDinheiro = new FontAwesome.Sharp.IconButton();
            this.btnCartao = new FontAwesome.Sharp.IconButton();
            this.btnCheque = new FontAwesome.Sharp.IconButton();
            this.btnCrediario = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(106, 324);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 24);
            this.label4.TabIndex = 32;
            this.label4.Text = "Restante:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(20, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 24);
            this.label3.TabIndex = 31;
            this.label3.Text = "Recebido:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(49, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 55);
            this.label2.TabIndex = 30;
            this.label2.Text = "Total:";
            // 
            // textRestante
            // 
            this.textRestante.BackColor = System.Drawing.Color.White;
            this.textRestante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textRestante.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textRestante.ForeColor = System.Drawing.Color.Red;
            this.textRestante.Location = new System.Drawing.Point(274, 315);
            this.textRestante.Name = "textRestante";
            this.textRestante.ReadOnly = true;
            this.textRestante.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textRestante.Size = new System.Drawing.Size(120, 38);
            this.textRestante.TabIndex = 29;
            this.textRestante.Text = "0,00";
            // 
            // textValorPago
            // 
            this.textValorPago.BackColor = System.Drawing.Color.White;
            this.textValorPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textValorPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textValorPago.ForeColor = System.Drawing.Color.Navy;
            this.textValorPago.Location = new System.Drawing.Point(158, 201);
            this.textValorPago.Name = "textValorPago";
            this.textValorPago.ReadOnly = true;
            this.textValorPago.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textValorPago.Size = new System.Drawing.Size(94, 38);
            this.textValorPago.TabIndex = 28;
            this.textValorPago.Text = "0,00";
            // 
            // textTotal
            // 
            this.textTotal.BackColor = System.Drawing.Color.White;
            this.textTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTotal.ForeColor = System.Drawing.Color.Navy;
            this.textTotal.Location = new System.Drawing.Point(204, 113);
            this.textTotal.Name = "textTotal";
            this.textTotal.ReadOnly = true;
            this.textTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textTotal.Size = new System.Drawing.Size(190, 62);
            this.textTotal.TabIndex = 27;
            this.textTotal.Text = "0000,00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 37);
            this.label1.TabIndex = 25;
            this.label1.Text = "Recebimento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(106, 281);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 24);
            this.label5.TabIndex = 41;
            this.label5.Text = "Valor a Receber:";
            // 
            // textValorDigitado
            // 
            this.textValorDigitado.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textValorDigitado.ForeColor = System.Drawing.Color.Navy;
            this.textValorDigitado.Location = new System.Drawing.Point(274, 271);
            this.textValorDigitado.Name = "textValorDigitado";
            this.textValorDigitado.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textValorDigitado.Size = new System.Drawing.Size(120, 38);
            this.textValorDigitado.TabIndex = 0;
            this.textValorDigitado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textValorDigitado_KeyPress);
            this.textValorDigitado.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textValorDigitado_KeyUp);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column2});
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(3, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.Size = new System.Drawing.Size(254, 164);
            this.dataGridView1.TabIndex = 42;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column3
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.HeaderText = "Forma Pagamento";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // Column2
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column2.HeaderText = "Valor";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(923, 62);
            this.panel1.TabIndex = 43;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(41, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 24);
            this.label6.TabIndex = 44;
            this.label6.Text = "Valores Recebidos";
            // 
            // textDescontoPorcet
            // 
            this.textDescontoPorcet.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDescontoPorcet.ForeColor = System.Drawing.Color.Navy;
            this.textDescontoPorcet.Location = new System.Drawing.Point(274, 183);
            this.textDescontoPorcet.Name = "textDescontoPorcet";
            this.textDescontoPorcet.Size = new System.Drawing.Size(120, 38);
            this.textDescontoPorcet.TabIndex = 48;
            this.textDescontoPorcet.Text = "0,00";
            this.textDescontoPorcet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textDescontoPorcet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textDesconto_KeyPress);
            this.textDescontoPorcet.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textDescontoPorcet_KeyUp);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(104, 237);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(164, 24);
            this.label8.TabIndex = 49;
            this.label8.Text = "Desconto em R$";
            // 
            // textDescontoReais
            // 
            this.textDescontoReais.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDescontoReais.ForeColor = System.Drawing.Color.Navy;
            this.textDescontoReais.Location = new System.Drawing.Point(274, 227);
            this.textDescontoReais.Name = "textDescontoReais";
            this.textDescontoReais.Size = new System.Drawing.Size(120, 38);
            this.textDescontoReais.TabIndex = 52;
            this.textDescontoReais.Text = "0,00";
            this.textDescontoReais.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textDescontoReais.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textDescontoReais_KeyPress);
            this.textDescontoReais.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textDescontoReais_KeyUp);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.textValorPago);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(492, 113);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(257, 251);
            this.panel2.TabIndex = 53;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(106, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 24);
            this.label7.TabIndex = 54;
            this.label7.Text = "Desconto em %";
            // 
            // btnDinheiro
            // 
            this.btnDinheiro.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnDinheiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDinheiro.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnDinheiro.IconChar = FontAwesome.Sharp.IconChar.MoneyBillWave;
            this.btnDinheiro.IconColor = System.Drawing.Color.Navy;
            this.btnDinheiro.IconSize = 36;
            this.btnDinheiro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDinheiro.Location = new System.Drawing.Point(52, 442);
            this.btnDinheiro.Name = "btnDinheiro";
            this.btnDinheiro.Rotation = 0D;
            this.btnDinheiro.Size = new System.Drawing.Size(170, 56);
            this.btnDinheiro.TabIndex = 55;
            this.btnDinheiro.Text = "Dinheiro";
            this.btnDinheiro.UseVisualStyleBackColor = true;
            this.btnDinheiro.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // btnCartao
            // 
            this.btnCartao.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnCartao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCartao.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnCartao.IconChar = FontAwesome.Sharp.IconChar.CreditCard;
            this.btnCartao.IconColor = System.Drawing.Color.Navy;
            this.btnCartao.IconSize = 36;
            this.btnCartao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCartao.Location = new System.Drawing.Point(228, 442);
            this.btnCartao.Name = "btnCartao";
            this.btnCartao.Rotation = 0D;
            this.btnCartao.Size = new System.Drawing.Size(170, 56);
            this.btnCartao.TabIndex = 56;
            this.btnCartao.Text = "Cartão";
            this.btnCartao.UseVisualStyleBackColor = true;
            this.btnCartao.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // btnCheque
            // 
            this.btnCheque.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheque.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnCheque.IconChar = FontAwesome.Sharp.IconChar.MoneyCheckAlt;
            this.btnCheque.IconColor = System.Drawing.Color.Navy;
            this.btnCheque.IconSize = 36;
            this.btnCheque.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheque.Location = new System.Drawing.Point(404, 442);
            this.btnCheque.Name = "btnCheque";
            this.btnCheque.Rotation = 0D;
            this.btnCheque.Size = new System.Drawing.Size(170, 56);
            this.btnCheque.TabIndex = 57;
            this.btnCheque.Text = "Cheque";
            this.btnCheque.UseVisualStyleBackColor = true;
            this.btnCheque.Click += new System.EventHandler(this.iconButton3_Click);
            // 
            // btnCrediario
            // 
            this.btnCrediario.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnCrediario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrediario.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnCrediario.IconChar = FontAwesome.Sharp.IconChar.IdCard;
            this.btnCrediario.IconColor = System.Drawing.Color.Navy;
            this.btnCrediario.IconSize = 36;
            this.btnCrediario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCrediario.Location = new System.Drawing.Point(580, 442);
            this.btnCrediario.Name = "btnCrediario";
            this.btnCrediario.Rotation = 0D;
            this.btnCrediario.Size = new System.Drawing.Size(170, 56);
            this.btnCrediario.TabIndex = 58;
            this.btnCrediario.Text = "Crediário";
            this.btnCrediario.UseVisualStyleBackColor = true;
            this.btnCrediario.Click += new System.EventHandler(this.iconButton4_Click);
            // 
            // FrmRecebimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 533);
            this.Controls.Add(this.btnCrediario);
            this.Controls.Add(this.btnCheque);
            this.Controls.Add(this.btnCartao);
            this.Controls.Add(this.btnDinheiro);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.textDescontoReais);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textDescontoPorcet);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textValorDigitado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textRestante);
            this.Controls.Add(this.textTotal);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRecebimento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRecebimento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRecebimento_FormClosing);
            this.Load += new System.EventHandler(this.FrmRecebimento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textRestante;
        private System.Windows.Forms.TextBox textValorPago;
        private System.Windows.Forms.TextBox textTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textValorDigitado;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.TextBox textDescontoPorcet;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textDescontoReais;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private FontAwesome.Sharp.IconButton btnDinheiro;
        private FontAwesome.Sharp.IconButton btnCartao;
        private FontAwesome.Sharp.IconButton btnCheque;
        private FontAwesome.Sharp.IconButton btnCrediario;
    }
}