using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Consultorio.Data;
using Consultorio.Model;

namespace Consultorio.ViewModel
{
    class DentistaViewModel
    {
        static public string GerarHashMd5(string entrada)
        {
            MD5 md5Hash = MD5.Create();
            // Converter a String para array de bytes, que é como a biblioteca trabalha.
            byte[] data = md5Hash.ComputeHash(Encoding.Default.GetBytes(entrada));

            // Cria-se um StringBuilder para recompôr a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop para formatar cada byte como uma String em hexadecimal
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public static string CadastroDeNovoDentista(Dentista dentista)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    ctx.Dentistas.Add(dentista);
                    ctx.SaveChanges();
                    return ("Salvo novo dentista");
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return ("error" + e.Message);
            }
        }
    }
}
