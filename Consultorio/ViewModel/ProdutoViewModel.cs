using Consultorio.Data;
using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.ViewModel
{
    //-------------------------------------------*****Classe para interagir entre model e view****-------------------------------------------------------------
    class ProdutoViewModel
    {
        // Exibe todos os prdutos cadastrados no banco de dados 
        public static List<Produto> ExibirProdutos()
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    var lista = ctx.Produtos.ToList();
                    return lista;
                }
            }
            catch (Exception)
            {
                List<Produto> lista = null;
                return lista;
            }            
        }

        //Executa alteraçoes no produto selecionado e modificado
        public static bool AlterarProduto(Produto produtoChegada)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    Produto p = ctx.Produtos.Find(produtoChegada.Id);
                    p.Nome = produtoChegada.Nome;
                    p.Quantidade = produtoChegada.Quantidade;
                    if (produtoChegada.Validade != null)
                    {

                        p.Validade = DateTime.ParseExact(produtoChegada.Validade.ToString(), "dd/MM/yyyy", CultureInfo.CurrentCulture);
                    }
                    p.Descricao = produtoChegada.Descricao;
                    ctx.SaveChanges();
                    return true;
                }
            }catch(Exception)
            {
                return false;
            }          
        }

        // busca por produtos especificos utilizando id ou nome
        public static List<Produto> BuscarProdutos(int id, string nome)
        {
            List<Produto> lista = new List<Produto>();
            try
            {
                using(ConsultorioContext ctx = new ConsultorioContext())
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
        }

        // salva novo produto no banco de dados
        public static bool SalvarProduto(Produto p)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    ctx.Produtos.Add(p);
                    ctx.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }          
        }
    }
}
