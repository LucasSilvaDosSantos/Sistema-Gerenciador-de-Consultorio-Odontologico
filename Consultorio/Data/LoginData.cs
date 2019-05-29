using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Data
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
                        encontrado = false;
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
