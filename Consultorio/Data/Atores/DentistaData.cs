using System;
using System.Data.Entity;
using Consultorio.Model;

namespace Consultorio.Data.Ator
{
    class DentistaData
    {
        public static string CadastroDeNovoDentista(Dentista dentista)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    dentista.Senha = AtoresData.GerarHashMd5(dentista.Senha);
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

                    dentista.Senha = AtoresData.GerarHashMd5(dentista.Senha);
                    d.Senha = dentista.Senha;

                    ctx.Entry(d).State = EntityState.Modified;

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
