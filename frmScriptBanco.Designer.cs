namespace Conversor_OFX
{
    partial class frmScriptBanco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScriptBanco));
            this.txbScript = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txbScript
            // 
            this.txbScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbScript.Font = new System.Drawing.Font("Lucida Sans Typewriter", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbScript.Location = new System.Drawing.Point(0, 0);
            this.txbScript.Name = "txbScript";
            this.txbScript.ReadOnly = true;
            this.txbScript.Size = new System.Drawing.Size(800, 450);
            this.txbScript.TabIndex = 0;
            this.txbScript.Text = resources.GetString("txbScript.Text");
            // 
            // frmScriptBanco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txbScript);
            this.Name = "frmScriptBanco";
            this.Text = "frmScriptBanco";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox txbScript;
    }
}