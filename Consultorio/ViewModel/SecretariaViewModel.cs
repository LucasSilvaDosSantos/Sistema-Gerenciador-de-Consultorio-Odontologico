using Consultorio.Data;
using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.ViewModel
{
    class SecretariaViewModel
    {
        public static string CadastroDeNovaSecretaria(Secretaria secretaria)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    ctx.Secretarias.Add(secretaria);
                    ctx.SaveChanges();
                    return ("Salvo nova Secretária");
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
