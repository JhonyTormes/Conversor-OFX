using System;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Conversor_OFX.Models
{
    public class ConexaoSQL
    {
        
        public string Banco { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }

        public SqlConnection Con = new SqlConnection();
    
        public ConexaoSQL() 
        {

        }


        public (bool Sucesso, bool AbrirFormConfig)  testarConexao() 
        {
            //Força a cultura pt-BR para o caso do idioma da máquina não estiver em português, evitando
            //possíveis erros causados pela mudança nas mensagens das excessões, utilizadas para definir os Ifs do teste
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");

            try
            {

                string[] config = new string[3];
                config = File.ReadAllLines("C:\\Config.txt");

                Banco = config[0];
                Usuario = config[1];
                Senha = config[2];

                Con.ConnectionString = $"Data Source=(local);Initial Catalog={Banco};User ID={Usuario};Password={Senha}";
                SqlCommand comando = new SqlCommand("SELECT * FROM Transacoes");
                comando.Connection = Conectar();
                comando.ExecuteNonQuery();
                Con.Close();

                return (true, false);
            }
            catch (Exception ex)
            {
                Con.Close();
                String mensagem = ex.Message;
                if (ex.Message.StartsWith("Falha de logon do usuário")) 
                {
                    MessageBox.Show("Login e senha incorretos, favor insira as informações novamente",
                "Atenção", MessageBoxButtons.OK);
                    return (false,true);
                }
                else if (ex.Message.StartsWith("Não foi possível localizar o arquivo 'C:\\Config.txt'"))
                {
                    MessageBox.Show("Arquivo de configuração do banco de dados inexistente" +
                                    ", favor insira as informações de acesso","Atenção", MessageBoxButtons.OK);
                    return (false, true);
                }
                else if (ex.Message.StartsWith("Não é possível abrir o banco de dados"))
                {
                    DialogResult resposta = MessageBox.Show("O banco de dados CONVERSOR ainda não existe, gostaria" +
                        " de criá-lo?",
                        "Atenção", MessageBoxButtons.YesNo);
                    if (resposta == DialogResult.Yes)
                    {
                        MessageBox.Show("Para criar o banco copie o script a seguir e execute no SQL", "", MessageBoxButtons.OK);
                        frmScriptBanco scriptBanco = new frmScriptBanco();
                        scriptBanco.ShowDialog();
                        return (false, false);
                     
                    }
                    else if (resposta == DialogResult.No)
                    {
                        // voltar
                    }
                    
                }
                else if (ex.Message.StartsWith("Nome de objeto 'Transacoes' inválido"))
                {
                    DialogResult resposta = MessageBox.Show("A tabela Transações não existe no banco de dados, gostaria" +
                       " de criá-la?",
                       "Atenção", MessageBoxButtons.YesNo);
                    if (resposta == DialogResult.Yes)
                    {
                        MessageBox.Show("Para criar a tabela copie o script a seguir e execute no SQL", "", MessageBoxButtons.OK);
                        frmScriptBanco scriptBanco = new frmScriptBanco();
                        scriptBanco.txbScript.Text = "USE CONVERSOR\r\n\r\nCREATE TABLE Transacoes(Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,\r\n\t\t\t\t\t\tTRNTYPE VARCHAR(10),\r\n\t\t\t\t\t\tDTPOSTED  VARCHAR(30),\r\n\t\t\t\t\t\tTRNAMT NVARCHAR(50),\r\n\t\t\t\t\t\tFITID NVARCHAR(50),\r\n\t\t\t\t\t\tCHECKNUM NVARCHAR(50),\r\n\t\t\t\t\t\tNAME VARCHAR(50),\r\n\t\t\t\t\t\tMEMO VARCHAR(100),\r\n\t\t\t\t\t\tSHA1 VARCHAR(40))";
                        scriptBanco.ShowDialog();
                        return (false, false);
                    }                  
                }
                else if (ex.Message.StartsWith("Erro de rede ou específico à instância ao estabelecer conexão com o SQL Server"))
                {
                    MessageBox.Show("Não foi possível comunicar com a instância do SQL" +
                                    ", verifique se o serviço do SQL está em execução", "Atenção", MessageBoxButtons.OK);
                    return (false, false);
                }
                else
                MessageBox.Show($"Não foi possível comunicar com o banco de dados.\n Erro: {ex.Message}","Atenção!",MessageBoxButtons.OK);
                
                return (false, true);
                throw;
            }
        }


        public SqlConnection Conectar()
        {


            if (Con.State == System.Data.ConnectionState.Closed)
            {
                string[] config = new string[3];
                config = File.ReadAllLines("C:\\Config.txt");

                Banco = config[0];
                Usuario = config[1];
                Senha = config[2];

                Con.ConnectionString = $"Data Source=(local);Initial Catalog={Banco};User ID={Usuario};Password={Senha}";
                Con.Open();
            }
            return Con;
        }

        public SqlConnection Desconectar()
        {
            if (Con.State == System.Data.ConnectionState.Open)
            {
                Con.Close();
            }
            return Con;
        }
    }
}
