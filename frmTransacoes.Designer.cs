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
            this.components = new System.ComponentModel.Container();
            this.lblTransacoes = new System.Windows.Forms.Label();
            this.dataGridViewTransacoes = new System.Windows.Forms.DataGridView();
            this.btnSalvarNoBanco = new System.Windows.Forms.Button();
            this.SELECIONAR = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblSelecionar = new System.Windows.Forms.LinkLabel();
            this.tRNTYPEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dTPOSTEDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tRNAMTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fITIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHECKNUMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mEMODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTMTTRNBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblDesselecionarTodos = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransacoes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTMTTRNBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTransacoes
            // 
            this.lblTransacoes.AutoSize = true;
            this.lblTransacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransacoes.Location = new System.Drawing.Point(449, 9);
            this.lblTransacoes.Name = "lblTransacoes";
            this.lblTransacoes.Size = new System.Drawing.Size(109, 24);
            this.lblTransacoes.TabIndex = 1;
            this.lblTransacoes.Text = "Transacoes";
            // 
            // dataGridViewTransacoes
            // 
            this.dataGridViewTransacoes.AllowUserToOrderColumns = true;
            this.dataGridViewTransacoes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewTransacoes.AutoGenerateColumns = false;
            this.dataGridViewTransacoes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewTransacoes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewTransacoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTransacoes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SELECIONAR,
            this.tRNTYPEDataGridViewTextBoxColumn,
            this.dTPOSTEDDataGridViewTextBoxColumn,
            this.tRNAMTDataGridViewTextBoxColumn,
            this.fITIDDataGridViewTextBoxColumn,
            this.cHECKNUMDataGridViewTextBoxColumn,
            this.nAMEDataGridViewTextBoxColumn,
            this.mEMODataGridViewTextBoxColumn});
            this.dataGridViewTransacoes.DataSource = this.sTMTTRNBindingSource;
            this.dataGridViewTransacoes.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dataGridViewTransacoes.Location = new System.Drawing.Point(12, 40);
            this.dataGridViewTransacoes.Name = "dataGridViewTransacoes";
            this.dataGridViewTransacoes.Size = new System.Drawing.Size(984, 447);
            this.dataGridViewTransacoes.TabIndex = 0;
            this.dataGridViewTransacoes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTransacoes_CellContentClick);
            // 
            // btnSalvarNoBanco
            // 
            this.btnSalvarNoBanco.Location = new System.Drawing.Point(453, 502);
            this.btnSalvarNoBanco.Name = "btnSalvarNoBanco";
            this.btnSalvarNoBanco.Size = new System.Drawing.Size(109, 24);
            this.btnSalvarNoBanco.TabIndex = 2;
            this.btnSalvarNoBanco.Text = "Salvar no banco";
            this.btnSalvarNoBanco.UseVisualStyleBackColor = true;
            this.btnSalvarNoBanco.Click += new System.EventHandler(this.btnSalvarNoBanco_Click);
            // 
            // SELECIONAR
            // 
            this.SELECIONAR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SELECIONAR.HeaderText = "";
            this.SELECIONAR.Name = "SELECIONAR";
            this.SELECIONAR.Width = 30;
            // 
            // lblSelecionar
            // 
            this.lblSelecionar.AutoSize = true;
            this.lblSelecionar.Location = new System.Drawing.Point(12, 490);
            this.lblSelecionar.Name = "lblSelecionar";
            this.lblSelecionar.Size = new System.Drawing.Size(86, 13);
            this.lblSelecionar.TabIndex = 3;
            this.lblSelecionar.TabStop = true;
            this.lblSelecionar.Text = "Selecionar todos";
            this.lblSelecionar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSelecionar_LinkClicked);
            // 
            // tRNTYPEDataGridViewTextBoxColumn
            // 
            this.tRNTYPEDataGridViewTextBoxColumn.DataPropertyName = "TRNTYPE";
            this.tRNTYPEDataGridViewTextBoxColumn.HeaderText = "TRNTYPE";
            this.tRNTYPEDataGridViewTextBoxColumn.Name = "tRNTYPEDataGridViewTextBoxColumn";
            this.tRNTYPEDataGridViewTextBoxColumn.ReadOnly = true;
            this.tRNTYPEDataGridViewTextBoxColumn.Width = 83;
            // 
            // dTPOSTEDDataGridViewTextBoxColumn
            // 
            this.dTPOSTEDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dTPOSTEDDataGridViewTextBoxColumn.DataPropertyName = "DTPOSTED";
            this.dTPOSTEDDataGridViewTextBoxColumn.HeaderText = "DTPOSTED";
            this.dTPOSTEDDataGridViewTextBoxColumn.Name = "dTPOSTEDDataGridViewTextBoxColumn";
            this.dTPOSTEDDataGridViewTextBoxColumn.ReadOnly = true;
            this.dTPOSTEDDataGridViewTextBoxColumn.Width = 99;
            // 
            // tRNAMTDataGridViewTextBoxColumn
            // 
            this.tRNAMTDataGridViewTextBoxColumn.DataPropertyName = "TRNAMT";
            this.tRNAMTDataGridViewTextBoxColumn.HeaderText = "TRNAMT";
            this.tRNAMTDataGridViewTextBoxColumn.Name = "tRNAMTDataGridViewTextBoxColumn";
            this.tRNAMTDataGridViewTextBoxColumn.ReadOnly = true;
            this.tRNAMTDataGridViewTextBoxColumn.Width = 78;
            // 
            // fITIDDataGridViewTextBoxColumn
            // 
            this.fITIDDataGridViewTextBoxColumn.DataPropertyName = "FITID";
            this.fITIDDataGridViewTextBoxColumn.HeaderText = "FITID";
            this.fITIDDataGridViewTextBoxColumn.Name = "fITIDDataGridViewTextBoxColumn";
            this.fITIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.fITIDDataGridViewTextBoxColumn.Width = 59;
            // 
            // cHECKNUMDataGridViewTextBoxColumn
            // 
            this.cHECKNUMDataGridViewTextBoxColumn.DataPropertyName = "CHECKNUM";
            this.cHECKNUMDataGridViewTextBoxColumn.HeaderText = "CHECKNUM";
            this.cHECKNUMDataGridViewTextBoxColumn.Name = "cHECKNUMDataGridViewTextBoxColumn";
            this.cHECKNUMDataGridViewTextBoxColumn.ReadOnly = true;
            this.cHECKNUMDataGridViewTextBoxColumn.Width = 93;
            // 
            // nAMEDataGridViewTextBoxColumn
            // 
            this.nAMEDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nAMEDataGridViewTextBoxColumn.DataPropertyName = "NAME";
            this.nAMEDataGridViewTextBoxColumn.HeaderText = "NAME";
            this.nAMEDataGridViewTextBoxColumn.Name = "nAMEDataGridViewTextBoxColumn";
            this.nAMEDataGridViewTextBoxColumn.ReadOnly = true;
            this.nAMEDataGridViewTextBoxColumn.Width = 245;
            // 
            // mEMODataGridViewTextBoxColumn
            // 
            this.mEMODataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.mEMODataGridViewTextBoxColumn.DataPropertyName = "MEMO";
            this.mEMODataGridViewTextBoxColumn.HeaderText = "MEMO";
            this.mEMODataGridViewTextBoxColumn.Name = "mEMODataGridViewTextBoxColumn";
            this.mEMODataGridViewTextBoxColumn.Width = 252;
            // 
            // sTMTTRNBindingSource
            // 
            this.sTMTTRNBindingSource.DataSource = typeof(Xml2CSharp.STMTTRN);
            // 
            // lblDesselecionarTodos
            // 
            this.lblDesselecionarTodos.AutoSize = true;
            this.lblDesselecionarTodos.Location = new System.Drawing.Point(12, 508);
            this.lblDesselecionarTodos.Name = "lblDesselecionarTodos";
            this.lblDesselecionarTodos.Size = new System.Drawing.Size(103, 13);
            this.lblDesselecionarTodos.TabIndex = 4;
            this.lblDesselecionarTodos.TabStop = true;
            this.lblDesselecionarTodos.Text = "Desselecionar todos";
            this.lblDesselecionarTodos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblDesselecionarTodos_LinkClicked);
            // 
            // frmTransacoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 537);
            this.Controls.Add(this.lblDesselecionarTodos);
            this.Controls.Add(this.lblSelecionar);
            this.Controls.Add(this.btnSalvarNoBanco);
            this.Controls.Add(this.lblTransacoes);
            this.Controls.Add(this.dataGridViewTransacoes);
            this.MaximizeBox = false;
            this.Name = "frmTransacoes";
            this.Text = "frmTransacoes";
            this.Load += new System.EventHandler(this.frmTransacoes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransacoes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTMTTRNBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTransacoes;
        private System.Windows.Forms.DataGridView dataGridViewTransacoes;
        private System.Windows.Forms.Button btnSalvarNoBanco;
        private System.Windows.Forms.BindingSource sTMTTRNBindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SELECIONAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn tRNTYPEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dTPOSTEDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tRNAMTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fITIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cHECKNUMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mEMODataGridViewTextBoxColumn;
        private System.Windows.Forms.LinkLabel lblSelecionar;
        private System.Windows.Forms.LinkLabel lblDesselecionarTodos;
    }
}