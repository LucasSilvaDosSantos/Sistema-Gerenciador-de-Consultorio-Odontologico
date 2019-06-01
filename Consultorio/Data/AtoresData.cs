using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Data
{
    class AtoresData
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

        static public Atores BuscaAtorPorId(int id)
        {
            Atores ator;
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {

                    if (id != 0)
                    {
                        ator = ctx.Dentistas.Where(at => at.Id == id).FirstOrDefault();                        
                        if (ator != null)
                        {
                            return ator;
                        }
                        ator = ctx.Secretarias.Where(at => at.Id == id).FirstOrDefault();
                        if (ator != null)
                        {
                            return ator;
                        }
                        ator = ctx.GestoresDeEstoque.Where(at => at.Id == id).FirstOrDefault();
                        if (ator != null)
                        {
                            return ator;
                        }
                    }
                    else
                    {
                        return ator = null;
                    }
                }
            }
            catch (Exception)
            {
                return ator = null;
            }
            return ator = null;
        }
    }
}
