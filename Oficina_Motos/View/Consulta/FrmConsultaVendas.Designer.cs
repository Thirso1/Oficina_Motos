namespace Oficina_Motos.View
{
    partial class FrmConsultaVendas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dgResultClie = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtcpf = new System.Windows.Forms.MaskedTextBox();
            this.dgVendas = new System.Windows.Forms.DataGridView();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dpFim = new System.Windows.Forms.DateTimePicker();
            this.dpInicio = new System.Windows.Forms.DateTimePicker();
            this.btnNome = new System.Windows.Forms.Button();
            this.textNome = new System.Windows.Forms.TextBox();
            this.textNumero = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnVisualizar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label21 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgResultClie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgVendas)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Cliente",
            "CPF",
            "N° Venda",
            "Data"});
            this.comboBox1.Location = new System.Drawing.Point(163, 70);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(92, 21);
            this.comboBox1.TabIndex = 63;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dgResultClie
            // 
            this.dgResultClie.AllowUserToAddRows = false;
            this.dgResultClie.AllowUserToDeleteRows = false;
            this.dgResultClie.AllowUserToResizeColumns = false;
            this.dgResultClie.AllowUserToResizeRows = false;
            this.dgResultClie.BackgroundColor = System.Drawing.Color.White;
            this.dgResultClie.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgResultClie.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgResultClie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResultClie.ColumnHeadersVisible = false;
            this.dgResultClie.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column5});
            this.dgResultClie.Location = new System.Drawing.Point(163, 115);
            this.dgResultClie.Name = "dgResultClie";
            this.dgResultClie.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgResultClie.RowHeadersVisible = false;
            this.dgResultClie.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgResultClie.Size = new System.Drawing.Size(409, 163);
            this.dgResultClie.TabIndex = 62;
            this.dgResultClie.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgResultClie_CellContentClick);
            this.dgResultClie.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgResultClie_CellMouseMove);
            this.dgResultClie.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgResultClie_KeyDown);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "id";
            this.Column1.HeaderText = "cod";
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
            this.Column2.Width = 300;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "cpf";
            this.Column5.HeaderText = "Column5";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // txtcpf
            // 
            this.txtcpf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcpf.Location = new System.Drawing.Point(163, 118);
            this.txtcpf.Mask = "000,000,000-00";
            this.txtcpf.Name = "txtcpf";
            this.txtcpf.Size = new System.Drawing.Size(92, 21);
            this.txtcpf.TabIndex = 60;
            this.txtcpf.Click += new System.EventHandler(this.txtcpf_Click);
            this.txtcpf.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcpf_KeyPress);
            this.txtcpf.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtcpf_KeyUp);
            // 
            // dgVendas
            // 
            this.dgVendas.AllowUserToAddRows = false;
            this.dgVendas.AllowUserToDeleteRows = false;
            this.dgVendas.AllowUserToOrderColumns = true;
            this.dgVendas.AllowUserToResizeColumns = false;
            this.dgVendas.AllowUserToResizeRows = false;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Menu;
            this.dgVendas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgVendas.BackgroundColor = System.Drawing.Color.White;
            this.dgVendas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgVendas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgVendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVendas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column15,
            this.Column18,
            this.Column17,
            this.Column16,
            this.Column19});
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Miriam CLM", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgVendas.DefaultCellStyle = dataGridViewCellStyle20;
            this.dgVendas.GridColor = System.Drawing.Color.White;
            this.dgVendas.Location = new System.Drawing.Point(32, 205);
            this.dgVendas.Name = "dgVendas";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgVendas.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dgVendas.RowHeadersVisible = false;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgVendas.RowsDefaultCellStyle = dataGridViewCellStyle22;
            this.dgVendas.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Miriam CLM", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.dgVendas.RowTemplate.Height = 30;
            this.dgVendas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgVendas.Size = new System.Drawing.Size(1013, 402);
            this.dgVendas.TabIndex = 59;
            this.dgVendas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgVendas_CellClick);
            this.dgVendas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgVendas_CellContentClick);
            this.dgVendas.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgVendas_CellMouseMove);
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "data";
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.Padding = new System.Windows.Forms.Padding(3);
            this.Column11.DefaultCellStyle = dataGridViewCellStyle14;
            this.Column11.HeaderText = "Data Hora";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 140;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "id";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.Padding = new System.Windows.Forms.Padding(3);
            this.Column12.DefaultCellStyle = dataGridViewCellStyle15;
            this.Column12.HeaderText = "N° Venda";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "valor";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "C2";
            dataGridViewCellStyle16.NullValue = null;
            dataGridViewCellStyle16.Padding = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.Column13.DefaultCellStyle = dataGridViewCellStyle16;
            this.Column13.HeaderText = "Valor";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // Column15
            // 
            this.Column15.DataPropertyName = "nome";
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.Padding = new System.Windows.Forms.Padding(3);
            this.Column15.DefaultCellStyle = dataGridViewCellStyle17;
            this.Column15.HeaderText = "Cliente";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Width = 300;
            // 
            // Column18
            // 
            this.Column18.DataPropertyName = "cpf";
            this.Column18.HeaderText = "CPF";
            this.Column18.Name = "Column18";
            this.Column18.ReadOnly = true;
            this.Column18.Width = 120;
            // 
            // Column17
            // 
            this.Column17.DataPropertyName = "status";
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.Padding = new System.Windows.Forms.Padding(3);
            this.Column17.DefaultCellStyle = dataGridViewCellStyle18;
            this.Column17.HeaderText = "Status";
            this.Column17.Name = "Column17";
            this.Column17.ReadOnly = true;
            this.Column17.Width = 130;
            // 
            // Column16
            // 
            this.Column16.DataPropertyName = "id_cliente";
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.Padding = new System.Windows.Forms.Padding(3);
            this.Column16.DefaultCellStyle = dataGridViewCellStyle19;
            this.Column16.HeaderText = "id_cliente";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            this.Column16.Visible = false;
            // 
            // Column19
            // 
            this.Column19.DataPropertyName = "id_usuario";
            this.Column19.HeaderText = "id_usuario";
            this.Column19.Name = "Column19";
            this.Column19.ReadOnly = true;
            this.Column19.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(299, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 17);
            this.label7.TabIndex = 56;
            this.label7.Text = "Data Final";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(80, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 17);
            this.label6.TabIndex = 55;
            this.label6.Text = "Data Inicial";
            // 
            // dpFim
            // 
            this.dpFim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFim.Location = new System.Drawing.Point(377, 166);
            this.dpFim.Name = "dpFim";
            this.dpFim.Size = new System.Drawing.Size(105, 21);
            this.dpFim.TabIndex = 54;
            this.dpFim.MouseEnter += new System.EventHandler(this.dpInicio_MouseEnter);
            // 
            // dpInicio
            // 
            this.dpInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpInicio.Location = new System.Drawing.Point(163, 166);
            this.dpInicio.Name = "dpInicio";
            this.dpInicio.Size = new System.Drawing.Size(105, 21);
            this.dpInicio.TabIndex = 53;
            this.dpInicio.MouseEnter += new System.EventHandler(this.dpInicio_MouseEnter);
            // 
            // btnNome
            // 
            this.btnNome.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnNome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNome.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnNome.Location = new System.Drawing.Point(569, 110);
            this.btnNome.Name = "btnNome";
            this.btnNome.Size = new System.Drawing.Size(116, 35);
            this.btnNome.TabIndex = 52;
            this.btnNome.Text = "Buscar";
            this.btnNome.UseVisualStyleBackColor = true;
            this.btnNome.Click += new System.EventHandler(this.btnNome_Click);
            // 
            // textNome
            // 
            this.textNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNome.Location = new System.Drawing.Point(163, 94);
            this.textNome.Name = "textNome";
            this.textNome.Size = new System.Drawing.Size(346, 21);
            this.textNome.TabIndex = 51;
            this.textNome.Click += new System.EventHandler(this.textNome_Click);
            this.textNome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textNome_KeyDown);
            this.textNome.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textNome_KeyUp);
            // 
            // textNumero
            // 
            this.textNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNumero.Location = new System.Drawing.Point(163, 142);
            this.textNumero.Name = "textNumero";
            this.textNumero.Size = new System.Drawing.Size(92, 21);
            this.textNumero.TabIndex = 50;
            this.textNumero.Click += new System.EventHandler(this.textNumero_Click);
            this.textNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textNumero_KeyPress);
            this.textNumero.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textNumero_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Location = new System.Drawing.Point(38, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 17);
            this.label4.TabIndex = 49;
            this.label4.Text = "Tipo de Consulta:";
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.BackColor = System.Drawing.SystemColors.Control;
            this.btnVisualizar.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnVisualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVisualizar.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnVisualizar.Location = new System.Drawing.Point(661, 617);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(116, 35);
            this.btnVisualizar.TabIndex = 67;
            this.btnVisualizar.Text = "Visualizar";
            this.btnVisualizar.UseVisualStyleBackColor = false;
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnCancelar.Location = new System.Drawing.Point(539, 617);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(116, 35);
            this.btnCancelar.TabIndex = 66;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditar.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnEditar.Location = new System.Drawing.Point(417, 617);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(116, 35);
            this.btnEditar.TabIndex = 65;
            this.btnEditar.Text = "Recuperar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(108, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 68;
            this.label2.Text = "Nome:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(119, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 17);
            this.label3.TabIndex = 69;
            this.label3.Text = "CPF:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkBlue;
            this.label5.Location = new System.Drawing.Point(84, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 17);
            this.label5.TabIndex = 70;
            this.label5.Text = "N° Venda:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkBlue;
            this.panel1.Controls.Add(this.label21);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1085, 63);
            this.panel1.TabIndex = 71;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(13, 5);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(428, 51);
            this.label21.TabIndex = 8;
            this.label21.Text = "Consulta de Vendas";
            // 
            // FrmConsultaVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 660);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnVisualizar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dgResultClie);
            this.Controls.Add(this.txtcpf);
            this.Controls.Add(this.dgVendas);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dpFim);
            this.Controls.Add(this.dpInicio);
            this.Controls.Add(this.btnNome);
            this.Controls.Add(this.textNome);
            this.Controls.Add(this.textNumero);
            this.Controls.Add(this.label4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConsultaVendas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmConsultaVendas";
            this.Load += new System.EventHandler(this.FrmConsultaVendas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgResultClie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgVendas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dgResultClie;
        private System.Windows.Forms.MaskedTextBox txtcpf;
        private System.Windows.Forms.DataGridView dgVendas;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dpFim;
        private System.Windows.Forms.DateTimePicker dpInicio;
        private System.Windows.Forms.Button btnNome;
        private System.Windows.Forms.TextBox textNome;
        private System.Windows.Forms.TextBox textNumero;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnVisualizar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
    }
}