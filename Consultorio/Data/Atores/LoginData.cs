using Consultorio.Model;
using System;
using System.Linq;

namespace Consultorio.Data.Ator
{
    class LoginData
    {
        public static Atores BuscarAtores(string entradaLogin, out bool encontrado)
        {
            Atores a;
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {                    
                    a = ctx.Dentistas.Where(d => d.Login.Equals(entradaLogin)).FirstOrDefault();
                    if (a != null)
                    {
                        encontrado = true;
                        return a;
                    }
                    a = ctx.Secretarias.Where(d => d.Login.Equals(entradaLogin)).FirstOrDefault();
                    if (a != null)
                    {
                        encontrado = true;
                        return a;    
                    }
                    a = ctx.GestoresDeEstoque.Where(d => d.Login.Equals(entradaLogin)).FirstOrDefault();
                    if (a != null)
                    {
                        encontrado = true;
                        return a;
                    }
                }
                encontrado = false;
                return a;
            }
            catch(Exception)
            {
                encontrado = false;
                return a = null;
            }
        }
    }
}
