using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Consultorio.Data.Atores
{
    class AtorData
    {
        static public string GerarHashMd5(string entrada)
        {
            using (MD5 md5Hash = MD5.Create()) { 
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
        }

        static public Ator BuscaAtorPorId(int id)
        {
            Ator ator;
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {

                    if (id != 0)
                    {
                        ator = ctx.Atores.FirstOrDefault(at => at.Id == id);                        
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

        public static List<Ator> TodosOsAtores()
        {
            List<Ator> listaAtores = new List<Ator>();
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    return listaAtores = ctx.Atores.ToList();
                }
            }
            catch (Exception)
            {
                return listaAtores;
            }
        }

        public static string CadastroDeAtor(Ator atorEntrada)
        {
            string msg;
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    if (atorEntrada.Id == 0)
                    {
                        ctx.Atores.Add(atorEntrada);
                        msg = "Colaborador Cadastrado!";
                    }
                    else
                    {
                        ctx.Entry(atorEntrada).State = EntityState.Modified;
                        msg = "Colaborador Modificado!";
                    }
                    ctx.SaveChanges();
                    return msg;
                }
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }
    }
}
