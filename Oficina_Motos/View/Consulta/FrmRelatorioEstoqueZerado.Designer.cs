namespace Oficina_Motos.View.Consulta
{
    partial class FrmRelatorioEstoqueZerado
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTipoRelatorio = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgProdutos = new System.Windows.Forms.DataGridView();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnAberto = new System.Windows.Forms.Button();
            this.dgFornecedor = new System.Windows.Forms.DataGridView();
            this.pnFornecedor = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pnPedidos = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dgPedido = new System.Windows.Forms.DataGridView();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProdutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFornecedor)).BeginInit();
            this.pnFornecedor.SuspendLayout();
            this.pnPedidos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPedido)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.lblTipoRelatorio);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(4, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1162, 54);
            this.panel1.TabIndex = 32;
            // 
            // lblTipoRelatorio
            // 
            this.lblTipoRelatorio.AutoSize = true;
            this.lblTipoRelatorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoRelatorio.ForeColor = System.Drawing.Color.White;
            this.lblTipoRelatorio.Location = new System.Drawing.Point(402, 8);
            this.lblTipoRelatorio.Name = "lblTipoRelatorio";
            this.lblTipoRelatorio.Size = new System.Drawing.Size(126, 39);
            this.lblTipoRelatorio.TabIndex = 1;
            this.lblTipoRelatorio.Text = "Zerado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(28, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(368, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Produtos com Estoque";
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgProdutos.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgProdutos.Location = new System.Drawing.Point(39, 70);
            this.dgProdutos.Name = "dgProdutos";
            this.dgProdutos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgProdutos.RowHeadersVisible = false;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgProdutos.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgProdutos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgProdutos.Size = new System.Drawing.Size(1084, 520);
            this.dgProdutos.TabIndex = 33;
            this.dgProdutos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProdutos_CellClick);
            this.dgProdutos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProdutos_CellValueChanged);
            // 
            // btnNovo
            // 
            this.btnNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.Location = new System.Drawing.Point(411, 600);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(164, 35);
            this.btnNovo.TabIndex = 34;
            this.btnNovo.Text = "Novo Pedido";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnAberto
            // 
            this.btnAberto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAberto.Location = new System.Drawing.Point(581, 600);
            this.btnAberto.Name = "btnAberto";
            this.btnAberto.Size = new System.Drawing.Size(164, 35);
            this.btnAberto.TabIndex = 35;
            this.btnAberto.Text = "Pedido em aberto";
            this.btnAberto.UseVisualStyleBackColor = true;
            // 
            // dgFornecedor
            // 
            this.dgFornecedor.AllowUserToAddRows = false;
            this.dgFornecedor.AllowUserToDeleteRows = false;
            this.dgFornecedor.AllowUserToOrderColumns = true;
            this.dgFornecedor.AllowUserToResizeColumns = false;
            this.dgFornecedor.AllowUserToResizeRows = false;
            this.dgFornecedor.BackgroundColor = System.Drawing.Color.White;
            this.dgFornecedor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgFornecedor.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dgFornecedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFornecedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.dgFornecedor.Location = new System.Drawing.Point(3, 37);
            this.dgFornecedor.Name = "dgFornecedor";
            this.dgFornecedor.RowHeadersVisible = false;
            this.dgFornecedor.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgFornecedor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgFornecedor.Size = new System.Drawing.Size(638, 220);
            this.dgFornecedor.TabIndex = 36;
            this.dgFornecedor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFornecedor_CellClick);
            this.dgFornecedor.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgFornecedor_CellMouseMove);
            // 
            // pnFornecedor
            // 
            this.pnFornecedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnFornecedor.Controls.Add(this.button1);
            this.pnFornecedor.Controls.Add(this.label2);
            this.pnFornecedor.Controls.Add(this.dgFornecedor);
            this.pnFornecedor.Location = new System.Drawing.Point(262, 172);
            this.pnFornecedor.Name = "pnFornecedor";
            this.pnFornecedor.Size = new System.Drawing.Size(644, 260);
            this.pnFornecedor.TabIndex = 37;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(584, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 23);
            this.button1.TabIndex = 38;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 20);
            this.label2.TabIndex = 37;
            this.label2.Text = "Selecione um Fornecedor";
            // 
            // pnPedidos
            // 
            this.pnPedidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnPedidos.Controls.Add(this.button2);
            this.pnPedidos.Controls.Add(this.label3);
            this.pnPedidos.Controls.Add(this.dgPedido);
            this.pnPedidos.Location = new System.Drawing.Point(250, 321);
            this.pnPedidos.Name = "pnPedidos";
            this.pnPedidos.Size = new System.Drawing.Size(674, 273);
            this.pnPedidos.TabIndex = 39;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(648, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(23, 23);
            this.button2.TabIndex = 38;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(8, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(263, 20);
            this.label3.TabIndex = 37;
            this.label3.Text = "Selecione um Pedido em aberto";
            // 
            // dgPedido
            // 
            this.dgPedido.AllowUserToAddRows = false;
            this.dgPedido.AllowUserToDeleteRows = false;
            this.dgPedido.AllowUserToOrderColumns = true;
            this.dgPedido.AllowUserToResizeColumns = false;
            this.dgPedido.AllowUserToResizeRows = false;
            this.dgPedido.BackgroundColor = System.Drawing.Color.White;
            this.dgPedido.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgPedido.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dgPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPedido.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column10,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn8,
            this.Column11,
            this.Column12,
            this.Column13});
            this.dgPedido.Location = new System.Drawing.Point(4, 37);
            this.dgPedido.Name = "dgPedido";
            this.dgPedido.RowHeadersVisible = false;
            this.dgPedido.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgPedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPedido.Size = new System.Drawing.Size(665, 233);
            this.dgPedido.TabIndex = 36;
            this.dgPedido.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPedido_CellClick);
            this.dgPedido.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgPedido_CellMouseMove);
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "data";
            this.Column10.HeaderText = "data";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.HeaderText = "N°";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 30;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "fornecedor";
            this.dataGridViewTextBoxColumn2.HeaderText = "Fornecedor";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 300;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "cnpj";
            this.dataGridViewTextBoxColumn3.HeaderText = "cnpj";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "valor";
            this.dataGridViewTextBoxColumn4.HeaderText = "valor";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "status";
            this.dataGridViewTextBoxColumn8.HeaderText = "status";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "usuario";
            this.Column11.HeaderText = "usuario";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Visible = false;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "id_usuario";
            this.Column12.HeaderText = "id_usuario";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Visible = false;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "id_fornecedor";
            this.Column13.HeaderText = "id_fornecedor";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(34, 603);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(327, 26);
            this.label4.TabIndex = 2;
            this.label4.Text = "Incluir os itens selecionados em:";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Location = new System.Drawing.Point(970, 600);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(153, 35);
            this.btnImprimir.TabIndex = 40;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "id";
            this.Column1.HeaderText = "id";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 20;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "nome";
            this.Column2.HeaderText = "fornecedor";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 320;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "cnpj";
            this.Column3.HeaderText = "cnpj";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "vendedor";
            this.Column4.HeaderText = "vendedor";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "cel_vendedor";
            this.Column5.HeaderText = "cel_vendedor";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "id_contato";
            this.Column6.HeaderText = "id_contato";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "id_endereco";
            this.Column7.HeaderText = "id_endereco";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "status";
            this.Column8.HeaderText = "status";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Visible = false;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "site";
            this.Column9.HeaderText = "site";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Visible = false;
            // 
            // FrmRelatorioEstoqueZerado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 648);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pnPedidos);
            this.Controls.Add(this.pnFornecedor);
            this.Controls.Add(this.btnAberto);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.dgProdutos);
            this.Controls.Add(this.panel1);
            this.Name = "FrmRelatorioEstoqueZerado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRelatorioEstoque";
            this.Load += new System.EventHandler(this.FrmRelatorioEstoque_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProdutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFornecedor)).EndInit();
            this.pnFornecedor.ResumeLayout(false);
            this.pnFornecedor.PerformLayout();
            this.pnPedidos.ResumeLayout(false);
            this.pnPedidos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPedido)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTipoRelatorio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgProdutos;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnAberto;
        private System.Windows.Forms.DataGridView dgFornecedor;
        private System.Windows.Forms.Panel pnFornecedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnPedidos;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    }
}