using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Consultorio.Data
{
    class ProcedimentoData
    {
        public static string CadastroDeNovoProcedimento(Procedimento procedimento)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    var a = new List<Produto>(procedimento.Produtos);

                    procedimento.Produtos.Clear();

                    foreach (Produto auxP in a)
                    {
                        procedimento.Produtos.Add(ctx.Produtos.First(aux => aux.Id == auxP.Id));
                    }

                    foreach (var item in procedimento.Produtos)
                    {
                        ctx.Entry(item).State = EntityState.Modified;
                    }

                    ctx.Procedimentos.Add(procedimento);
                    ctx.SaveChanges();
                    return ("Salvo novo Procedimento!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return ("error" + e.Message);
            }
        }

        public static string AlterarProcedimento(Procedimento procedimento)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    Procedimento p = ctx.Procedimentos.Include(aux1 => aux1.Produtos).First(aux => aux.Id == procedimento.Id);


                    p.Nome = procedimento.Nome;
                    p.Preco = procedimento.Preco;
                    p.Descricao = procedimento.Descricao;

                    p.Produtos.Clear();

                    foreach(Produto auxP in procedimento.Produtos)
                    {
                        p.Produtos.Add(ctx.Produtos.First(aux => aux.Id == auxP.Id));
                    }

                    foreach(var item in p.Produtos)
                    {
                        ctx.Entry(item).State = EntityState.Modified;
                    }
                    
                    ctx.SaveChanges();
                    return ("Salvo alterações no procedimento!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return ("error" + e.Message);
            }
        }

        public static List<Procedimento> ListarTodosProcedimentos()
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    var lista = ctx.Procedimentos.ToList();

                    return lista;
                }
            }
            catch (Exception)
            {
                List<Procedimento> lista = null;
                return lista;
            }
        }

        public static List<Procedimento> BuscarProcedimentos(int id, string nome)
        {
            List<Procedimento> lista = new List<Procedimento>();
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    if (id != 0)
                    {
                        lista = ctx.Procedimentos.Where(p => p.Id == id).ToList();
                        return lista;
                    }
                    else if (nome != "")
                    {
                        lista = ctx.Procedimentos.Where(p => p.Nome.Contains(nome)).ToList();
                        return lista;
                    }
                    return lista;
                }
            }
            catch (Exception)
            {
                return lista;
            }
        }

        public static Procedimento PegarProcedimento(int id)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    Procedimento procedimento = ctx.Procedimentos.Include(p => p.Produtos).Where(a => a.Id == id).FirstOrDefault();
                    return procedimento;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}