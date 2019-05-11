using Consultorio.Data;
using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Consultorio.ViewModel
{
    class ProcedimentoViewModel
    {
        public static string CadastroDeNovoProcedimento(Procedimento procedimento)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    ctx.Procedimentos.Add(procedimento);
                    ctx.SaveChanges();
                    return ("Salvo novo Procedimento");
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
                    Procedimento p = ctx.Procedimentos.Find(procedimento.Id);

                    p.Nome = procedimento.Nome;
                    p.Preco = procedimento.Preco;
                    p.Descricao = procedimento.Descricao;

                    ctx.SaveChanges();
                    return ("Salvo alterações de procedimento");
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

        public static List<Procedimento> BuscarProcedimento(int id, string nome)
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

        /*public static List<Produto> ProdutosParaConsulta(Procedimento procedimento)
        {
            List<Produto> lista = new List<Produto>();
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    //lista = ctx.Produtos.Include("Produtos").ToList();

                    //var teste = ctx.Produtos.Include(n => n.)

                    //var teste = ctx.Procedimentos.Include("Produtos"); // não traz nenhuma informação de cliente 

                }
            }
            catch (Exception)
            {
                return lista;
            }


            return lista;
        }*/
    }
}

//var cliente = ctx.Clientes.Where(c => c.Id == clienteEntrada.Id).Include(c => c.Anamnese).FirstOrDefault();

/*public static List<Produto> BuscarProdutos(int id, string nome)
{
    List<Produto> lista = new List<Produto>();
    try
    {
        using (ConsultorioContext ctx = new ConsultorioContext())
        {
            if (id != 0)
            {
                lista = ctx.Produtos.Where(p => p.Id == id).ToList();
                return lista;
            }
            else if (nome != "")
            {
                lista = ctx.Produtos.Where(p => p.Nome.Contains(nome)).ToList();
                return lista;
            }
            return lista;
        }
    }
    catch (Exception)
    {
        return lista;
    }
}*/
