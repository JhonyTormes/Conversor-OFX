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

        
        private void txtXML_TextChanged(object sender, EventArgs e)
        {
        }


        private void btnAbrir_Click(object sender, EventArgs e)
        {
            //Abre o arquivo e executa a leitura, retornando o seu conteúdo para a propriedade Caminho, para que
            //as informações possam ser acessadas pelos outros componentes.

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Arquivo OFX| *.ofx";
            ofd.ShowDialog();
            if (!string.IsNullOrEmpty(ofd.FileName))
            {
                try
                {
                    using (StreamReader leitor = new StreamReader(ofd.FileName, Encoding.GetEncoding(CultureInfo.GetCultureInfo("pt-BR").TextInfo.ANSICodePage)))
                    {
                        txtConteudo.Text = leitor.ReadToEnd();
                        Caminho = ofd;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Não foi possível abrir o arquivo. Erro: {ex.Message}", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

                
            
        }

        private void btnConverter_Click(object sender, EventArgs e)
        {
            //Converte o conteúdo do arquivo aberto para o padrão XML, retirando os espaços caso o arquivo já esteja
            // identado, retirando os cabeçallhos do OFX e fechando todas as tags que não tenham fechamento.

            if (txtConteudo.Text != "")
            {
                try
                {
                    String[] linhas = txtConteudo.Lines;

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
                    txtXML.Text = TratarXml.Identador(arquivoXml);
                }
                catch (Exception)
                {

                    MessageBox.Show($"Não foi possível converter o arquivo.\nCertifique-se de abrir um arquivo válido antes de converter"
                                    , "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                MessageBox.Show($"Não foi possível converter o arquivo.\nNão há nenhum conteúdo para converter"
                 , "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //Salva o arquivo permitindo salvar apenas caso o arquivo esteja com o padrão de XML da conversão utilizada.

            if (txtXML.Text.StartsWith("<?xml"))
            {
                try
                {
                    string nomeArquivoSemExtensao = Path.GetFileNameWithoutExtension(Caminho.SafeFileName);
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Arquivo XML | *.xml";
                    sfd.FileName = nomeArquivoSemExtensao;
                    sfd.ShowDialog();

                    if (!string.IsNullOrEmpty(sfd.FileName))
                    {
                        using (StreamWriter writer = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                        {
                            writer.Write(txtXML.Text);
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

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtConteudo.Text) || !string.IsNullOrEmpty(txtXML.Text))
            {
                DialogResult dialogResult = MessageBox.Show("A conversão atual será perdida\nTem certeza que deseja limpar os textos?", "Atenção!", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) ;
                if (dialogResult == DialogResult.OK)
                {
                        txtConteudo.Clear();
                        txtXML.Clear();
                }
            }
            else
            {
                MessageBox.Show("Não há nenhum conteúdo para limpar","Atenção!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            
        }

        private void lblDesserializar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Esse link label foi criado para fins de estudo do objeto DataGridView, ao clicar nele você" +
                            " poderá escolher um arquivo XML que será transformado em objeto(Para vizualizar faça um debug), e depois" +
                            " os dados desse objeto serão inseridos em uma DataGridView","Aviso!",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            try
            {
                frmTransacoes frmtransacoes = new frmTransacoes();
                frmtransacoes.Show();
                frmtransacoes.ColorirCelulas();
                frmtransacoes.inserirValorEmNulos();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Não foi possível desserializar o arquivo\nErro: {ex}");
            }

        }


    }

}
