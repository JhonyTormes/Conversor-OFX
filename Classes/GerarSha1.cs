using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversor_OFX.Classes
{
    public class GerarSha1
    {
        public string GerarCodigoSha1(string caminhoArquivoTemporario)
        {
            var sha1 = new System.Security.Cryptography.SHA1Managed();
            var plaintextBytes = Encoding.UTF8.GetBytes(caminhoArquivoTemporario);
            var hashBytes = sha1.ComputeHash(plaintextBytes);

            var sb = new StringBuilder();
            foreach (var hashByte in hashBytes)
            {
                sb.AppendFormat("{0:x2}", hashByte);
            }

            string hashString = sb.ToString();

            return hashString;
        }

    }
}
