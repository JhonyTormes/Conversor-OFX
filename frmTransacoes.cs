using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xml2CSharp;
using System.Xml.Serialization;


namespace Conversor_OFX
{
    public partial class frmTransacoes : Form
    {
        public List<BANKMSGSRSV1> objOFX { get; set; }
        public frmTransacoes()
        {
            try
            {
                InitializeComponent();
                OpenFileDialog caminhoXML = new OpenFileDialog();
                caminhoXML.Filter = "Arquivo XML | *.xml";
                caminhoXML.ShowDialog();


                using (StreamReader stream = new StreamReader(caminhoXML.FileName))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(List<BANKMSGSRSV1>), new XmlRootAttribute("OFX"));
                    objOFX = (List<BANKMSGSRSV1>)serializador.Deserialize(stream);
                }

                dataGridViewTransacoes.DataSource = objOFX[0].STMTTRNRS.STMTRS.BANKTRANLIST.STMTTRN;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void ColorirCelulas()
        {
            foreach (DataGridViewRow row in dataGridViewTransacoes.Rows)
            {
                if (row.Cells[0].Value.Equals("CREDIT"))
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(137, 232, 138);
                }
                else if(row.Cells[0].Value.Equals("DEBIT"))
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(227, 131, 129);
                }
                else if (row.Cells[0].Value.Equals("DEP"))
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(25, 191, 47);
                }
                else if (row.Cells[0].Value.Equals("CHECK"))
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(78, 166, 230);
                }
            }

        }
private void dataGridViewTransacoes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
