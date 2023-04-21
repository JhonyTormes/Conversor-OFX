using System;
using System.Windows.Forms;
using System.IO;

namespace Conversor_OFX.Classes
{
    public class ConfiguraBanco
    {
        public void ConfigBanco(string banco, string usuario, string senha) {
            if (File.Exists("C://Config.txt"))
            {
                File.Delete("C://Config.txt");
            }
            try
            {
                File.Create("C://Config.txt").Close();
                using (StreamWriter sw = File.AppendText("C://Config.txt"))
                {
                    sw.WriteLine(banco);
                    sw.WriteLine(usuario);
                    sw.WriteLine(senha);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Não foi possível salvar a configuração");
            }
        }
    }
}
