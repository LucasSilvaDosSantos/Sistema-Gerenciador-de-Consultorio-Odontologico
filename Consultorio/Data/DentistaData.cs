using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Consultorio.Data;
using Consultorio.Model;

namespace Consultorio.Data
{
    class DentistaData
    {
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
                return ("error" + e.Message);
            }
        }

        public static string AlterarDentista(Dentista dentista)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    Dentista d = ctx.Dentistas.Find(dentista.Id);

                    d.Nome = dentista.Nome;
                    d.Email = dentista.Email;
                    d.Telefone1 = dentista.Telefone1;
                    d.Telefone2 = dentista.Telefone2;
                    d.Crosp = dentista.Crosp;
                    d.Login = dentista.Login;
                    d.Senha = dentista.Senha;

                    ctx.Entry(d).State = System.Data.Entity.EntityState.Modified;

                    ctx.SaveChanges();
                    return ("Salvo alterações de dentista");
                }
            }
            catch (Exception e)
            {
                return ("error" + e.Message);
            }
        }
    }
}
