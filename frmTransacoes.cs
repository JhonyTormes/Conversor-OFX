using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Xml2CSharp;
using System.Xml.Serialization;
using Conversor_OFX.Models;
using System.Xml;
using Conversor_OFX.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Linq;

namespace Conversor_OFX
{
    public partial class frmTransacoes : Form
    {
        public List<BANKMSGSRSV1> objOFX { get; set; }
        XmlDocument arquivoXml = new XmlDocument();
        public OpenFileDialog CaminhoXML { get; set; }
        public bool ConexaoBemSucedida { get; set; }
        public bool AbrirFormConfig { get; set; }
        public frmTransacoes()
        {
            try
            {
                //Abrir arquivo XML que será desserializado

                InitializeComponent();
                OpenFileDialog caminhoXML = new OpenFileDialog();
                caminhoXML.Filter = "Arquivo XML | *.xml";
                caminhoXML.ShowDialog();
                CaminhoXML = caminhoXML;

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

        private void frmTransacoes_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewTransacoes.Rows)
            {
                row.Cells[0].Value = false;
                inserirValorEmNulos();
                ColorirCelulas();
            }
        }

        //Para evitar erros com valores nulos no banco, foi criado esse método que insere um hífen em todos os nulos
        public void inserirValorEmNulos()
        {
            foreach (DataGridViewRow row in dataGridViewTransacoes.Rows)
            {
                for (int i = 1; i < 8; i++)
                {
                    if (row.Cells[i].Value == null)
                    {
                        row.Cells[i].Value = "-";
                    }
                    
                }
            }
        }

        public void ColorirCelulas()
        {
            foreach (DataGridViewRow row in dataGridViewTransacoes.Rows)
            {
                if (row.Cells[1].Value.Equals("CREDIT"))
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(137, 232, 138);
                }
                else if (row.Cells[1].Value.Equals("DEBIT"))
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(227, 131, 129);
                }
                else if (row.Cells[1].Value.Equals("DEP"))
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(25, 191, 47);
                }
                else if (row.Cells[1].Value.Equals("CHECK"))
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(78, 166, 230);
                }
            }

        }

        //Salva as transações selecionadas no banco de dados, antes de fazer o insert, é gerado um hash sha1 para a string
        //da concatenação de todos os dados da transação e então é validado se esse hash já não está salvo no banco,
        //fazendo com que não seja possível registrar uma transação com todos os campos exatamente iguais
        //
        //OBS: Quando o método ConexaoSQL é chamado para salvar as informações, são executados testes de acesso ao SQL com as informações
        //do arquivo C://Config.txt, do acesso ao banco CONVERSOR, e de acesso à tabela Transações. Caso algum falhe, será aberto o Form
        //para realizar a configuração, ou instruções de criação do banco e inicialização do SQL Server

        private void btnSalvarNoBanco_Click(object sender, EventArgs e)
        {
            
            int contarCheckBoxMarcadas = 0;
            foreach (DataGridViewRow row in dataGridViewTransacoes.Rows)
            {
                if (row.Cells[0].Value.Equals(true))
                {
                    contarCheckBoxMarcadas++;
                }
            }

            if (contarCheckBoxMarcadas > 0)
            {
                SalvarNoBanco salvarNoBanco = new SalvarNoBanco();

                int registrosSalvos = 0;
                int registrosNaoSalvos = 0;

                ConexaoSQL conexao = new ConexaoSQL();
                (ConexaoBemSucedida, AbrirFormConfig) = conexao.testarConexao();

                do
                {
                    if (ConexaoBemSucedida == false)
                    {
                        if (AbrirFormConfig == true)
                        {
                            frmConfigBanco configBanco = new frmConfigBanco();
                            configBanco.ShowDialog();
                        }
                        (ConexaoBemSucedida, AbrirFormConfig) = conexao.testarConexao();
                    }
                } while (!(ConexaoBemSucedida == true && AbrirFormConfig == false));



                foreach (DataGridViewRow row in dataGridViewTransacoes.Rows)
                {

                    if (bool.Parse(row.Cells[0].Value.ToString()))
                    {
                        var linha = row.Cells[1].Value.ToString() +
                                                row.Cells[2].Value.ToString() +
                                                row.Cells[3].Value.ToString() +
                                                row.Cells[4].Value.ToString() +
                                                row.Cells[5].Value.ToString() +
                                                row.Cells[6].Value.ToString() +
                                                row.Cells[7].Value.ToString();

                        GerarSha1 gerarSha1 = new GerarSha1();
                        string sha1 = gerarSha1.GerarCodigoSha1(linha);

                        bool sha1Existe = salvarNoBanco.insertTransacoes(row.Cells[1].Value.ToString(),
                                                        row.Cells[2].Value.ToString(),
                                                        row.Cells[3].Value.ToString(),
                                                        row.Cells[4].Value.ToString(),
                                                        row.Cells[5].Value.ToString(),
                                                        row.Cells[6].Value.ToString(),
                                                        row.Cells[7].Value.ToString(),
                                                        sha1);
                        if (sha1Existe)
                        {
                            registrosNaoSalvos += 1;
                        }
                        else
                        {
                            registrosSalvos += 1;
                            row.DefaultCellStyle.Font = new Font(DefaultFont, FontStyle.Bold);
                        }
                    }


                }
                if (registrosSalvos > 0 && registrosNaoSalvos == 0)
                {
                    MessageBox.Show($"Transações cadastradas com sucesso\n" +
                                    $" Todas as {registrosSalvos} transções foram salvas!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (registrosSalvos > 0 && registrosNaoSalvos > 0)
                {
                    MessageBox.Show($"Algumas transações já estavam registradas no banco de dados\nTransações salvas: {registrosSalvos}" +
                                    $"\nTransações não salvas: {registrosNaoSalvos}", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Nenhum registro foi salvo!\nTodas as transações" +
                                    " selecionadas estavam duplicadas", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                //Desselecionar celulas
                foreach (DataGridViewRow row in dataGridViewTransacoes.Rows)
                {
                    ((DataGridViewCheckBoxCell)row.Cells[0]).Value = false;
                }
                lblQtdTransacoes.Text = "0 Transações selecionadas";

            }
            else
            {
                MessageBox.Show($"Não há nenhuma transação selecionada", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        //Atualiza label de transações selecionadas
        private void lblSelecionar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int contador = 0;
            foreach (DataGridViewRow row in dataGridViewTransacoes.Rows)
            {
                ((DataGridViewCheckBoxCell)row.Cells[0]).Value = true;
                contador++;
            }
            lblQtdTransacoes.Text = $"{contador} Transações selecionadas";
        }
        //Atualiza label de transações selecionadas
        private void lblDesselecionarTodos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewTransacoes.Rows)
            {
                ((DataGridViewCheckBoxCell)row.Cells[0]).Value = false;
            }
            lblQtdTransacoes.Text = "0 Transações selecionadas";
        }
        //Atualiza label de transações selecionadas
        private void dataGridViewTransacoes_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int contador = 0;
            foreach (DataGridViewRow linha in dataGridViewTransacoes.Rows)
            { 
                var cell = linha.Cells[0] as DataGridViewCheckBoxCell;
                if ((bool)cell.EditedFormattedValue)
                {
                    contador++;
                }

            }
            lblQtdTransacoes.Text = $"{contador} Transações selecionadas";
        }
        //Atualiza label de transações selecionadas ao marcar e desmarcar checkbox
        public void atualizaQtdCheckbox()
        {
            int contador = 0;
            foreach (DataGridViewRow linha in dataGridViewTransacoes.Rows)
            { 
                var cell = linha.Cells[0] as DataGridViewCheckBoxCell; 
                if ((bool)cell.EditedFormattedValue)
                {
                    contador++;
                }

            }
            lblQtdTransacoes.Text = $"{contador} Transações selecionadas";
        }
    }
}