using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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
                    // para modificar itens ja rastreados pelo entity

                    ctx.Entry(produtoChegada).State = EntityState.Modified;
                    ctx.SaveChanges();

                    return "Produto alterado com sucesso!";
                }
            }catch(Exception e)
            {
                return e.Message;
            }          
        }

        // busca por produtos especificos utilizando id ou nome
        public static List<Produto> BuscarProdutosNome(string nome, out bool encontrado)
        {
            List<Produto> lista = new List<Produto>();
            try
            {
                using(ConsultorioContext ctx = new ConsultorioContext())
                {
                    /*if (id != 0)
                    {
                        lista = ctx.Produtos.Where(p => p.Id == id).ToList();
                        return lista;
                    }*/
                    if (nome != "")
                    {
                        lista = ctx.Produtos.Where(p => p.Nome.Contains(nome)).ToList();
                        if (lista.Count() > 0)
                        {
                            encontrado = true;
                        }
                        else
                        {
                            encontrado = false;
                        }
                        
                        return lista;
                    }
                    encontrado = false;
                    return lista;
                }
            }
            catch (Exception)
            {
                encontrado = false;
                return lista;
            }
        }

        public static List<Produto> BuscarProdutosId(string id, out bool encontrado)
        {
            List<Produto> lista = new List<Produto>();
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    if (id != null || id != "")
                    {
                        lista = ctx.Produtos.Where(p => p.Id.ToString().Contains(id)).ToList();
                        if (lista.Count() > 0)
                        {
                            encontrado = true;
                        }
                        else
                        {
                            encontrado = false;
                        }
                        return lista;
                    }
                    encontrado = false;
                    return lista;
                }
            }
            catch (Exception)
            {
                encontrado = false;
                return lista;
            }
        }

        public static Produto SelecionarProduto(int id)
        {
            Produto p = new Produto();
            try
            {
                
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    p = ctx.Produtos.Find(id);
                    return p;
                }
            }
            catch (Exception)
            {
                return p;
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
