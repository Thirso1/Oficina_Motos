namespace Oficina_Motos.View.Cadastros
{
    partial class FrmInsereFornecedor
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
            this.dgFornecedores = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cel_vendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_contato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_endereco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInserir = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgFornecedores)).BeginInit();
            this.SuspendLayout();
            // 
            // dgFornecedores
            // 
            this.dgFornecedores.AllowUserToAddRows = false;
            this.dgFornecedores.AllowUserToDeleteRows = false;
            this.dgFornecedores.AllowUserToResizeColumns = false;
            this.dgFornecedores.AllowUserToResizeRows = false;
            this.dgFornecedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFornecedores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.vendedor,
            this.cel_vendedor,
            this.id_contato,
            this.id_endereco,
            this.Column4,
            this.Column5});
            this.dgFornecedores.Location = new System.Drawing.Point(12, 63);
            this.dgFornecedores.Name = "dgFornecedores";
            this.dgFornecedores.RowHeadersVisible = false;
            this.dgFornecedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgFornecedores.Size = new System.Drawing.Size(761, 268);
            this.dgFornecedores.TabIndex = 0;
            this.dgFornecedores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFornecedores_CellClick);
            this.dgFornecedores.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgFornecedores_CellMouseMove);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "id";
            this.Column1.HeaderText = "id";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "nome";
            this.Column2.HeaderText = "nome";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 350;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "cnpj";
            this.Column3.HeaderText = "cnpj";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 140;
            // 
            // vendedor
            // 
            this.vendedor.DataPropertyName = "vendedor";
            this.vendedor.HeaderText = "vendedor";
            this.vendedor.Name = "vendedor";
            this.vendedor.ReadOnly = true;
            this.vendedor.Width = 150;
            // 
            // cel_vendedor
            // 
            this.cel_vendedor.DataPropertyName = "cel_vendedor";
            this.cel_vendedor.HeaderText = "cel_vendedor";
            this.cel_vendedor.Name = "cel_vendedor";
            this.cel_vendedor.ReadOnly = true;
            this.cel_vendedor.Visible = false;
            // 
            // id_contato
            // 
            this.id_contato.DataPropertyName = "id_contato";
            this.id_contato.HeaderText = "id_contato";
            this.id_contato.Name = "id_contato";
            this.id_contato.ReadOnly = true;
            this.id_contato.Visible = false;
            // 
            // id_endereco
            // 
            this.id_endereco.DataPropertyName = "id_endereco";
            this.id_endereco.HeaderText = "id_endereco";
            this.id_endereco.Name = "id_endereco";
            this.id_endereco.ReadOnly = true;
            this.id_endereco.Visible = false;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "status";
            this.Column4.HeaderText = "status";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "site";
            this.Column5.HeaderText = "site";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(698, 337);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(75, 23);
            this.btnInserir.TabIndex = 1;
            this.btnInserir.Text = "Adicionar";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(12, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(337, 37);
            this.label13.TabIndex = 68;
            this.label13.Text = "Adcionar Fornecedor";
            // 
            // FrmInsereFornecedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 372);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.dgFornecedores);
            this.Name = "FrmInsereFornecedor";
            this.Text = "FrmInsereFornecedor";
            this.Load += new System.EventHandler(this.FrmInsereFornecedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgFornecedores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgFornecedores;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn cel_vendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_contato;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_endereco;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}