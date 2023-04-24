using System;
using System.Windows.Forms;
using Conversor_OFX.Classes;
using Conversor_OFX.Models;

namespace Conversor_OFX
{
    public partial class frmConfigBanco : Form
    {
        public frmConfigBanco()
        {
            InitializeComponent();
        }

        public void btnSalvar_Click(object sender, EventArgs e)
        {
            var config = new frmConfigBanco();
            ConfiguraBanco configuraBanco = new ConfiguraBanco();
            configuraBanco.ConfigBanco(txtBanco.Text, txbUsuario.Text, txbSenha.Text);
            Close();
        }
    }
}
