namespace Oficina_Motos.View
{
    partial class FrmConferenciaPedido
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgProdutos = new System.Windows.Forms.DataGridView();
            this.txtCelVendedor = new System.Windows.Forms.MaskedTextBox();
            this.txtVendedor = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.txtCnpj = new System.Windows.Forms.MaskedTextBox();
            this.lblCnpjAtu = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textTotal = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConferir = new System.Windows.Forms.Button();
            this.lblNumero = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.lblNumero);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1002, 71);
            this.panel1.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Conferência de Pedido";
            // 
            // dgProdutos
            // 
            this.dgProdutos.AllowUserToAddRows = false;
            this.dgProdutos.AllowUserToDeleteRows = false;
            this.dgProdutos.AllowUserToResizeColumns = false;
            this.dgProdutos.AllowUserToResizeRows = false;
            this.dgProdutos.BackgroundColor = System.Drawing.Color.White;
            this.dgProdutos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgProdutos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgProdutos.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgProdutos.Location = new System.Drawing.Point(12, 134);
            this.dgProdutos.Name = "dgProdutos";
            this.dgProdutos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgProdutos.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgProdutos.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgProdutos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProdutos.Size = new System.Drawing.Size(954, 341);
            this.dgProdutos.TabIndex = 26;
            this.dgProdutos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProdutos_CellContentClick);
            this.dgProdutos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProdutos_CellValueChanged);
            // 
            // txtCelVendedor
            // 
            this.txtCelVendedor.BackColor = System.Drawing.Color.White;
            this.txtCelVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCelVendedor.Location = new System.Drawing.Point(408, 106);
            this.txtCelVendedor.Mask = "(99)00000-0000";
            this.txtCelVendedor.Name = "txtCelVendedor";
            this.txtCelVendedor.Size = new System.Drawing.Size(122, 22);
            this.txtCelVendedor.TabIndex = 122;
            // 
            // txtVendedor
            // 
            this.txtVendedor.BackColor = System.Drawing.Color.White;
            this.txtVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVendedor.Location = new System.Drawing.Point(95, 106);
            this.txtVendedor.MaxLength = 50;
            this.txtVendedor.Name = "txtVendedor";
            this.txtVendedor.Size = new System.Drawing.Size(269, 22);
            this.txtVendedor.TabIndex = 121;
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.Color.White;
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(95, 77);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(435, 23);
            this.txtNome.TabIndex = 119;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(8, 80);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(81, 17);
            this.label37.TabIndex = 123;
            this.label37.Text = "Fornecedor";
            // 
            // txtCnpj
            // 
            this.txtCnpj.BackColor = System.Drawing.Color.White;
            this.txtCnpj.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCnpj.Location = new System.Drawing.Point(581, 77);
            this.txtCnpj.Mask = "000,000,000/0000-00";
            this.txtCnpj.Name = "txtCnpj";
            this.txtCnpj.Size = new System.Drawing.Size(163, 23);
            this.txtCnpj.TabIndex = 120;
            // 
            // lblCnpjAtu
            // 
            this.lblCnpjAtu.AutoSize = true;
            this.lblCnpjAtu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCnpjAtu.Location = new System.Drawing.Point(536, 80);
            this.lblCnpjAtu.Name = "lblCnpjAtu";
            this.lblCnpjAtu.Size = new System.Drawing.Size(43, 17);
            this.lblCnpjAtu.TabIndex = 124;
            this.lblCnpjAtu.Text = "CNPJ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(374, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 16);
            this.label2.TabIndex = 128;
            this.label2.Text = "Cel";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 127;
            this.label4.Text = "Vendedor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkBlue;
            this.label5.Location = new System.Drawing.Point(652, 484);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 39);
            this.label5.TabIndex = 131;
            this.label5.Text = "Total:";
            // 
            // textTotal
            // 
            this.textTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTotal.Location = new System.Drawing.Point(772, 481);
            this.textTotal.Name = "textTotal";
            this.textTotal.Size = new System.Drawing.Size(194, 47);
            this.textTotal.TabIndex = 130;
            this.textTotal.Text = "0,00";
            this.textTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Location = new System.Drawing.Point(271, 492);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(151, 29);
            this.btnCancelar.TabIndex = 129;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnConferir
            // 
            this.btnConferir.BackColor = System.Drawing.SystemColors.Control;
            this.btnConferir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConferir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConferir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConferir.ForeColor = System.Drawing.Color.Black;
            this.btnConferir.Location = new System.Drawing.Point(428, 492);
            this.btnConferir.Name = "btnConferir";
            this.btnConferir.Size = new System.Drawing.Size(151, 29);
            this.btnConferir.TabIndex = 132;
            this.btnConferir.Text = "Conferir";
            this.btnConferir.UseVisualStyleBackColor = false;
            this.btnConferir.Click += new System.EventHandler(this.btnConferir_Click);
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumero.ForeColor = System.Drawing.Color.White;
            this.lblNumero.Location = new System.Drawing.Point(808, 19);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(49, 36);
            this.lblNumero.TabIndex = 1;
            this.lblNumero.Text = "N°";
            // 
            // FrmConferenciaPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 559);
            this.Controls.Add(this.btnConferir);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textTotal);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCelVendedor);
            this.Controls.Add(this.txtVendedor);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.txtCnpj);
            this.Controls.Add(this.lblCnpjAtu);
            this.Controls.Add(this.dgProdutos);
            this.Controls.Add(this.panel1);
            this.Name = "FrmConferenciaPedido";
            this.Text = "FrmConferenciaPedido";
            this.Load += new System.EventHandler(this.FrmConferenciaPedido_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProdutos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgProdutos;
        private System.Windows.Forms.MaskedTextBox txtCelVendedor;
        private System.Windows.Forms.TextBox txtVendedor;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.MaskedTextBox txtCnpj;
        private System.Windows.Forms.Label lblCnpjAtu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textTotal;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnConferir;
        private System.Windows.Forms.Label lblNumero;
    }
}