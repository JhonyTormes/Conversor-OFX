using Conversor_OFX.Classes;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Conversor_OFX.Models
{
    public class SalvarNoBanco
    {
        

	    ConexaoSQL conexao = new ConexaoSQL(); 
        SqlCommand comando = new SqlCommand();
        ConsultaSha1 consultar = new ConsultaSha1();
        public bool sha1Existe { get; set; }     
        public bool insertTransacoes(string TRNTYPE,
                                 string DTPOSTED,
                                 string TRNAMT,
                                 string FITID,
                                 string CHECKNUM,
                                 string NAME,
                                 string MEMO,
                                 string SHA1)
        {

            if (!consultar.consultaTransacao(SHA1))
            {
                
                comando.CommandText = "insert into Transacoes (TRNTYPE, DTPOSTED,TRNAMT,FITID,CHECKNUM,NAME,MEMO,SHA1)" +
                                      " values (@TRNTYPE, @DTPOSTED,@TRNAMT,@FITID,@CHECKNUM,@NAME,@MEMO,@SHA1)";

                comando.Parameters.AddWithValue("TRNTYPE", TRNTYPE);
                comando.Parameters.AddWithValue("DTPOSTED", DTPOSTED);
                comando.Parameters.AddWithValue("TRNAMT", TRNAMT);
                comando.Parameters.AddWithValue("FITID", FITID);
                comando.Parameters.AddWithValue("CHECKNUM", CHECKNUM);
                comando.Parameters.AddWithValue("NAME", NAME);
                comando.Parameters.AddWithValue("MEMO", MEMO);
                comando.Parameters.AddWithValue("SHA1", SHA1);


                try
                {
                    comando.Connection = conexao.Conectar();

                    comando.ExecuteNonQuery();

                    comando.Parameters.Clear();

                    conexao.Desconectar();
                    
                    sha1Existe = false;
                    return sha1Existe;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Erro ao se conectar com o banco de dados\nErro: {ex}", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                    sha1Existe=true;
                    return sha1Existe;
                }
                
            }
            return true;
        }
    }
}
