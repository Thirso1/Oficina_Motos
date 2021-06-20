namespace Oficina_Motos.View
{
    partial class FrmBuscaOrdemServico
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgOrcamentos = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textTitulo = new System.Windows.Forms.TextBox();
            this.textDados = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dpInicial = new System.Windows.Forms.DateTimePicker();
            this.dpFim = new System.Windows.Forms.DateTimePicker();
            this.lblInicio = new System.Windows.Forms.Label();
            this.lblFim = new System.Windows.Forms.Label();
            this.btnBuscarDatas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgOrcamentos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgOrcamentos
            // 
            this.dgOrcamentos.BackgroundColor = System.Drawing.Color.White;
            this.dgOrcamentos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgOrcamentos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgOrcamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOrcamentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column1,
            this.Column3,
            this.Column7,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Miriam CLM", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgOrcamentos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgOrcamentos.GridColor = System.Drawing.Color.White;
            this.dgOrcamentos.Location = new System.Drawing.Point(12, 125);
            this.dgOrcamentos.Name = "dgOrcamentos";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgOrcamentos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgOrcamentos.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgOrcamentos.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgOrcamentos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Miriam CLM", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.dgOrcamentos.RowTemplate.Height = 28;
            this.dgOrcamentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgOrcamentos.Size = new System.Drawing.Size(964, 296);
            this.dgOrcamentos.TabIndex = 38;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "data_hora";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column2.HeaderText = "Data";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "id_orcamento";
            this.Column1.HeaderText = "N° Orç";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 70;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "equipamento";
            this.Column3.HeaderText = "Veículo";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "defeito";
            this.Column7.HeaderText = "Defeito";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 200;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "valor_total";
            this.Column4.HeaderText = "Valor";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 70;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "status";
            this.Column5.HeaderText = "Status";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 90;
            // 
            // textTitulo
            // 
            this.textTitulo.BackColor = System.Drawing.SystemColors.Control;
            this.textTitulo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTitulo.Location = new System.Drawing.Point(12, 46);
            this.textTitulo.Name = "textTitulo";
            this.textTitulo.Size = new System.Drawing.Size(356, 25);
            this.textTitulo.TabIndex = 39;
            // 
            // textDados
            // 
            this.textDados.Location = new System.Drawing.Point(12, 79);
            this.textDados.Name = "textDados";
            this.textDados.Size = new System.Drawing.Size(167, 20);
            this.textDados.TabIndex = 41;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(185, 77);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 40;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(374, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 26);
            this.label1.TabIndex = 42;
            this.label1.Text = "Consulta de Ordem de Serviço";
            // 
            // dpInicial
            // 
            this.dpInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpInicial.Location = new System.Drawing.Point(73, 80);
            this.dpInicial.Name = "dpInicial";
            this.dpInicial.Size = new System.Drawing.Size(86, 20);
            this.dpInicial.TabIndex = 43;
            // 
            // dpFim
            // 
            this.dpFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFim.Location = new System.Drawing.Point(219, 79);
            this.dpFim.Name = "dpFim";
            this.dpFim.Size = new System.Drawing.Size(86, 20);
            this.dpFim.TabIndex = 44;
            // 
            // lblInicio
            // 
            this.lblInicio.AutoSize = true;
            this.lblInicio.Location = new System.Drawing.Point(20, 86);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(35, 13);
            this.lblInicio.TabIndex = 45;
            this.lblInicio.Text = "Inicio:";
            // 
            // lblFim
            // 
            this.lblFim.AutoSize = true;
            this.lblFim.Location = new System.Drawing.Point(175, 88);
            this.lblFim.Name = "lblFim";
            this.lblFim.Size = new System.Drawing.Size(26, 13);
            this.lblFim.TabIndex = 46;
            this.lblFim.Text = "Fim:";
            // 
            // btnBuscarDatas
            // 
            this.btnBuscarDatas.Location = new System.Drawing.Point(320, 78);
            this.btnBuscarDatas.Name = "btnBuscarDatas";
            this.btnBuscarDatas.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarDatas.TabIndex = 47;
            this.btnBuscarDatas.Text = "Buscar";
            this.btnBuscarDatas.UseVisualStyleBackColor = true;
            // 
            // FrmBuscaOrdemServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 433);
            this.Controls.Add(this.btnBuscarDatas);
            this.Controls.Add(this.lblFim);
            this.Controls.Add(this.lblInicio);
            this.Controls.Add(this.dpFim);
            this.Controls.Add(this.dpInicial);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textDados);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.textTitulo);
            this.Controls.Add(this.dgOrcamentos);
            this.Name = "FrmBuscaOrdemServico";
            this.Text = "FrmResultConsultaOrdemServico";
            this.Load += new System.EventHandler(this.FrmResultConsultaOrdemServico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgOrcamentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgOrcamentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.TextBox textTitulo;
        private System.Windows.Forms.TextBox textDados;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dpInicial;
        private System.Windows.Forms.DateTimePicker dpFim;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Label lblFim;
        private System.Windows.Forms.Button btnBuscarDatas;
    }
}