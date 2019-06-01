using Consultorio.Data;
using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Data
{
    //-------------------------------------------*****Classe para interagir entre model e view****-------------------------------------------------------------
    class ProdutoData
    {
        // Exibe todos os prdutos cadastrados no banco de dados 
        public static List<Produto> ListarTodosProdutos()
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
        public static string AlterarProduto(Produto produtoChegada)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    Produto p = ctx.Produtos.Find(produtoChegada.Id);

                    p.Nome = produtoChegada.Nome;
                    p.Quantidade = produtoChegada.Quantidade;
                    p.Validade = produtoChegada.Validade;
                    p.Descricao = produtoChegada.Descricao;

                    ctx.SaveChanges();

                    return "Produto alterado com sucesso!";
                }
            }catch(Exception e)
            {
                return e.Message;
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
        public static string SalvarProduto(Produto p)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    ctx.Produtos.Add(p);
                    ctx.SaveChanges();
                }
                return "Produto Salvo!";
            }
            catch(Exception e)
            {
                return e.Message;
            }          
        }
    }
}
