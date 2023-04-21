using Conversor_OFX.Models;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Conversor_OFX.Classes
{
    public class ConsultaSha1
    {
        ConexaoSQL conexao = new ConexaoSQL();
        public bool sha1Existe { get; set; }
        public bool consultaTransacao(string SHA1)
        {

            SqlCommand comando = new SqlCommand("SELECT * FROM Transacoes WHERE SHA1 = @SHA1");
            comando.Parameters.AddWithValue("SHA1", @SHA1);
          

            try
            {
                comando.Connection = conexao.Conectar();

                comando.ExecuteNonQuery();

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    sha1Existe = true;
                }
                else
                {
                    sha1Existe = false;
                }

                reader.Close();

                comando.Parameters.Clear();

                conexao.Desconectar();

                return sha1Existe;
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Erro ao se conectar com o banco de dados\nErro: {ex}", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);  
                return sha1Existe;
            }
        }
    }
}
