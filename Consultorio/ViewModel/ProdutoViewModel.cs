using Consultorio.Data;
using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.ViewModel
{
    class ProdutoViewModel
    {
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
                        p.Validade = produtoChegada.Validade;
                    }
                    p.Descricao = produtoChegada.Descricao;
                    ctx.SaveChanges();
                    return true;
                }
            }catch(Exception e)
            {
                return false;
            }          
        }
    }
}
