using Consultorio.Model;
using System;
using System.Linq;

namespace Consultorio.Data.Atores
{
    class LoginData
    {
        public static Ator BuscarAtores(string entradaLogin, out bool encontrado)
        {
            Ator a;
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    a = ctx.Atores.FirstOrDefault(d => d.Login.Equals(entradaLogin));
                    if (a != null)
                    {
                        encontrado = true;
                        return a;
                    }                   
                }
                encontrado = false;
                return a;
            }
            catch
            {
                encontrado = false;
                return a = null;
            }
        }
    }
}
