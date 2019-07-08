using Consultorio.Data;
using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Data
{
    class GestorDeEstoqueData
    {
        public static string CadastroDeNovoGestorDeEstoque(GestorDeEstoque gestorDeEstoque)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    gestorDeEstoque.Senha = AtoresData.GerarHashMd5(gestorDeEstoque.Senha);
                    ctx.GestoresDeEstoque.Add(gestorDeEstoque);
                    ctx.SaveChanges();
                    return ("Salvo novo Gestor de Estoque!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return ("error" + e.Message);
            }
        }

        public static string AlterarGestor(GestorDeEstoque gestor)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    GestorDeEstoque g = ctx.GestoresDeEstoque.Find(gestor.Id);

                    g.Nome = gestor.Nome;
                    g.Email = gestor.Email;
                    g.Telefone1 = gestor.Telefone1;
                    g.Telefone2 = gestor.Telefone2;
                    g.Login = gestor.Login;

                    gestor.Senha = AtoresData.GerarHashMd5(gestor.Senha);
                    g.Senha = gestor.Senha;

                    ctx.Entry(g).State = System.Data.Entity.EntityState.Modified;

                    ctx.SaveChanges();
                    return ("Salvo alterações de Gestor de Estoque!");
                }
            }
            catch (Exception e)
            {
                return ("error" + e.Message);
            }
        }
    }
}
