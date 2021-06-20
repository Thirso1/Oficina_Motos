namespace Oficina_Motos.View
{
    partial class FrmEditaItemVenda
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
            this.label6 = new System.Windows.Forms.Label();
            this.textDescricao = new System.Windows.Forms.TextBox();
            this.textSubTotal = new System.Windows.Forms.TextBox();
            this.textQtde = new System.Windows.Forms.TextBox();
            this.textDesconto = new System.Windows.Forms.TextBox();
            this.textValorUni = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(257, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 26);
            this.label6.TabIndex = 22;
            this.label6.Text = "Editar Item";
            // 
            // textDescricao
            // 
            this.textDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDescricao.Location = new System.Drawing.Point(22, 84);
            this.textDescricao.Name = "textDescricao";
            this.textDescricao.ReadOnly = true;
            this.textDescricao.Size = new System.Drawing.Size(197, 26);
            this.textDescricao.TabIndex = 21;
            // 
            // textSubTotal
            // 
            this.textSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSubTotal.Location = new System.Drawing.Point(474, 84);
            this.textSubTotal.Name = "textSubTotal";
            this.textSubTotal.ReadOnly = true;
            this.textSubTotal.Size = new System.Drawing.Size(77, 26);
            this.textSubTotal.TabIndex = 20;
            // 
            // textQtde
            // 
            this.textQtde.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textQtde.Location = new System.Drawing.Point(308, 84);
            this.textQtde.Name = "textQtde";
            this.textQtde.Size = new System.Drawing.Size(77, 26);
            this.textQtde.TabIndex = 19;
            this.textQtde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textQtde_KeyPress);
            this.textQtde.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textQtde_KeyUp);
            // 
            // textDesconto
            // 
            this.textDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDesconto.Location = new System.Drawing.Point(391, 84);
            this.textDesconto.Name = "textDesconto";
            this.textDesconto.Size = new System.Drawing.Size(77, 26);
            this.textDesconto.TabIndex = 18;
            this.textDesconto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textDesconto_KeyPress);
            this.textDesconto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textDesconto_KeyUp);
            // 
            // textValorUni
            // 
            this.textValorUni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textValorUni.Location = new System.Drawing.Point(225, 84);
            this.textValorUni.Name = "textValorUni";
            this.textValorUni.ReadOnly = true;
            this.textValorUni.Size = new System.Drawing.Size(77, 26);
            this.textValorUni.TabIndex = 17;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(557, 81);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 29);
            this.btnSalvar.TabIndex = 16;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(305, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Qtde";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(388, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Desconto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(222, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Valor Uni";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(471, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Sub Total";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Descrição";
            // 
            // FrmEditaItemVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 133);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textDescricao);
            this.Controls.Add(this.textSubTotal);
            this.Controls.Add(this.textQtde);
            this.Controls.Add(this.textDesconto);
            this.Controls.Add(this.textValorUni);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditaItemVenda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEditaItemVenda";
            this.Load += new System.EventHandler(this.FrmEditaItemVenda_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textDescricao;
        private System.Windows.Forms.TextBox textSubTotal;
        private System.Windows.Forms.TextBox textQtde;
        private System.Windows.Forms.TextBox textDesconto;
        private System.Windows.Forms.TextBox textValorUni;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}