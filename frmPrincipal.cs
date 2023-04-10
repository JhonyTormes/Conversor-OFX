using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Xml;
using Conversor_OFX.Models;

namespace Conversor_OFX
{
    public partial class frmPrincipal : Form
    {
        private XmlDocument xmlDoc { get; set; }
        private OpenFileDialog Caminho { get; set; }

        public frmPrincipal()
        {
            InitializeComponent();
        }

         private void abrirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Abre o arquivo e executa a leitura, retornando o seu conteúdo para a propriedade Caminho, para que
            //as informações possam ser acessadas pelos outros componentes.

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Arquivo OFX| *.ofx";
            ofd.ShowDialog();
            if (string.IsNullOrEmpty(ofd.FileName) == false)
            {
                try
                {
                    using (StreamReader leitor = new StreamReader(ofd.FileName, Encoding.GetEncoding(CultureInfo.GetCultureInfo("pt-BR").TextInfo.ANSICodePage)))
                    {
                        txtConteudo.Text = leitor.ReadToEnd();
                        Caminho= ofd;
                    }
        
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Não foi possível abrir o arquivo. Erro: {ex.Message}", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void salvarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Salva o arquivo permitindo salvar apenas caso o arquivo esteja com o padrão de XML da conversão utilizada.

            if (txtConteudo.Text.StartsWith("<?xml"))
            {
                try
                {
                    string nomeArquivoSemExtensao = Path.GetFileNameWithoutExtension(Caminho.SafeFileName);
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Arquivo XML | *.xml";
                    sfd.FileName = nomeArquivoSemExtensao;
                    sfd.ShowDialog();

                    if (string.IsNullOrEmpty(sfd.FileName) == false)
                    {
                        using (StreamWriter writer = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                        {
                                writer.Write(txtConteudo.Text);
                                writer.Flush();
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Não foi possível salvar o arquivo. Erro: {ex.Message}", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Não foi possível salvar, o arquivo não está no formato de XML da conversão", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void converterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Converte o conteúdo do arquivo aberto para o padrão XML, retirando os espaços caso o arquivo já esteja
            // identado, retirando os cabeçallhos do OFX e fechando todas as tags que não tenham fechamento.

            if (txtConteudo.Text != "")
            {
                try
                {
                    String[] linhas = File.ReadAllLines(Caminho.FileName.TrimStart());
                    XmlDocument arquivoXml = new XmlDocument();
                    var escritor = new StringBuilder();

                    foreach (var linha in linhas)
                    {
                        string linhaSemEspaco = linha.TrimStart();

                        if (linhaSemEspaco.StartsWith("<"))
                        {
                            if (linhaSemEspaco.EndsWith(">"))
                            {
                                escritor.Append(linhaSemEspaco);
                            }
                            else
                            {
                                string[] tagAberta = linhaSemEspaco.Split('<', '>');
                                escritor.Append(linhaSemEspaco + "</" + tagAberta[1] + ">");

                            }
                        }
                    }
                    arquivoXml.LoadXml(escritor.ToString());
                    txtConteudo.Text = TratarXml.Identador(arquivoXml);
                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Não foi possível converter o arquivo. Erro: {ex.Message}", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                MessageBox.Show($"Arquivo vazio.\nNão foi possível converter.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
