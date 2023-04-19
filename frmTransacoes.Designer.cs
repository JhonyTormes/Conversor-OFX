namespace Conversor_OFX
{
    partial class frmTransacoes
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
            this.lblTransacoes = new System.Windows.Forms.Label();
            this.dataGridViewTransacoes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransacoes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTransacoes
            // 
            this.lblTransacoes.AutoSize = true;
            this.lblTransacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransacoes.Location = new System.Drawing.Point(350, 9);
            this.lblTransacoes.Name = "lblTransacoes";
            this.lblTransacoes.Size = new System.Drawing.Size(109, 24);
            this.lblTransacoes.TabIndex = 1;
            this.lblTransacoes.Text = "Transacoes";
            // 
            // dataGridViewTransacoes
            // 
            this.dataGridViewTransacoes.AllowUserToOrderColumns = true;
            this.dataGridViewTransacoes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewTransacoes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewTransacoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTransacoes.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dataGridViewTransacoes.Location = new System.Drawing.Point(12, 40);
            this.dataGridViewTransacoes.Name = "dataGridViewTransacoes";
            this.dataGridViewTransacoes.ReadOnly = true;
            this.dataGridViewTransacoes.Size = new System.Drawing.Size(776, 398);
            this.dataGridViewTransacoes.TabIndex = 0;
            this.dataGridViewTransacoes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTransacoes_CellContentClick);
            // 
            // frmTransacoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTransacoes);
            this.Controls.Add(this.dataGridViewTransacoes);
            this.Name = "frmTransacoes";
            this.Text = "frmTransacoes";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransacoes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTransacoes;
        private System.Windows.Forms.DataGridView dataGridViewTransacoes;
    }
}