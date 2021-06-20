namespace Oficina_Motos.View
{
    partial class FrmTroco
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
            this.texdinheiro = new System.Windows.Forms.TextBox();
            this.lblfinaliza = new System.Windows.Forms.Label();
            this.lbltroco = new System.Windows.Forms.Label();
            this.lbldinheiro = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textroco = new System.Windows.Forms.TextBox();
            this.textTotal = new System.Windows.Forms.TextBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // texdinheiro
            // 
            this.texdinheiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.texdinheiro.Location = new System.Drawing.Point(170, 151);
            this.texdinheiro.Name = "texdinheiro";
            this.texdinheiro.Size = new System.Drawing.Size(169, 53);
            this.texdinheiro.TabIndex = 45;
            this.texdinheiro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.texdinheiro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.texdinheiro_KeyPress);
            this.texdinheiro.KeyUp += new System.Windows.Forms.KeyEventHandler(this.texdinheiro_KeyUp);
            // 
            // lblfinaliza
            // 
            this.lblfinaliza.AutoSize = true;
            this.lblfinaliza.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfinaliza.Location = new System.Drawing.Point(125, 9);
            this.lblfinaliza.Name = "lblfinaliza";
            this.lblfinaliza.Size = new System.Drawing.Size(152, 55);
            this.lblfinaliza.TabIndex = 42;
            this.lblfinaliza.Text = "Troco";
            // 
            // lbltroco
            // 
            this.lbltroco.AutoSize = true;
            this.lbltroco.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltroco.Location = new System.Drawing.Point(64, 221);
            this.lbltroco.Name = "lbltroco";
            this.lbltroco.Size = new System.Drawing.Size(100, 37);
            this.lbltroco.TabIndex = 41;
            this.lbltroco.Text = "Troco";
            // 
            // lbldinheiro
            // 
            this.lbldinheiro.AutoSize = true;
            this.lbldinheiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldinheiro.Location = new System.Drawing.Point(28, 162);
            this.lbldinheiro.Name = "lbldinheiro";
            this.lbldinheiro.Size = new System.Drawing.Size(136, 37);
            this.lbldinheiro.TabIndex = 40;
            this.lbldinheiro.Text = "Dinheiro";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(68, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 37);
            this.label2.TabIndex = 39;
            this.label2.Text = "Total ";
            // 
            // textroco
            // 
            this.textroco.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textroco.Location = new System.Drawing.Point(170, 210);
            this.textroco.Name = "textroco";
            this.textroco.ReadOnly = true;
            this.textroco.Size = new System.Drawing.Size(169, 53);
            this.textroco.TabIndex = 38;
            this.textroco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textTotal
            // 
            this.textTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTotal.Location = new System.Drawing.Point(170, 92);
            this.textTotal.Name = "textTotal";
            this.textTotal.ReadOnly = true;
            this.textTotal.Size = new System.Drawing.Size(169, 53);
            this.textTotal.TabIndex = 37;
            this.textTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.Location = new System.Drawing.Point(194, 311);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(145, 42);
            this.btnConfirmar.TabIndex = 46;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Location = new System.Drawing.Point(43, 311);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(145, 42);
            this.btnVoltar.TabIndex = 47;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            // 
            // FrmTroco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 387);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.texdinheiro);
            this.Controls.Add(this.lblfinaliza);
            this.Controls.Add(this.lbltroco);
            this.Controls.Add(this.lbldinheiro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textroco);
            this.Controls.Add(this.textTotal);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTroco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTroco";
            this.Load += new System.EventHandler(this.FrmTroco_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox texdinheiro;
        private System.Windows.Forms.Label lblfinaliza;
        private System.Windows.Forms.Label lbltroco;
        private System.Windows.Forms.Label lbldinheiro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textroco;
        private System.Windows.Forms.TextBox textTotal;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnVoltar;
    }
}