using Consultorio.Model;
using Consultorio.ViewModel.Atores;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Consultorio.Data.Produtos
{
    class ProdutoData
    {
        /*public static List<Produto> ListarTodosProdutos()
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
        }*/

        public static string AlterarProduto(Produto produtoChegada)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    ctx.Entry(produtoChegada).State = EntityState.Modified;
                    ctx.SaveChanges();

                    return "Produto alterado com sucesso!";
                }
            }catch(Exception e)
            {
                return e.Message;
            }          
        }

        public static List<Produto> BuscarProdutosNome(string nome, out bool encontrado)
        {
            List<Produto> lista = new List<Produto>();
            try
            {
                using(ConsultorioContext ctx = new ConsultorioContext())
                {
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

        public static string CadastrarCompra(ProdutoCompra produtoCompra)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    produtoCompra.Produto = ctx.Produtos.Find(produtoCompra.Produto.Id);
                    produtoCompra.QuemRegistrou = ctx.Atores.Find(produtoCompra.QuemRegistrou.Id);

                    produtoCompra.Produto.Quantidade += produtoCompra.QuantidaDeComprada;

                    ctx.Entry(produtoCompra.Produto).State = EntityState.Modified;

                    ctx.ProdutosCompras.Add(produtoCompra);
                    
                    ctx.SaveChanges();
                    return "Compra cadastrada com Sucesso!";
                }
            }
            catch
            {
                return "Erro em salvar a compra";
            }
        }

        public static string RetiradaDeEstoque(Produto produto, string motivoRetirada)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    Log log = new Log();
                    log.Ator = ctx.Atores.Find(SingletonAtorLogado.Instancia.Ator.Id);
                    log.Date = DateTime.Now;

                    Produto produtoAntigo = ctx.Produtos.Include(p => p.Procedimentos).Where(a => a.Id == produto.Id).SingleOrDefault();

                    log.ComoEra = ($"Id:{produtoAntigo.Id}, Nome:{produtoAntigo.Nome}, Quantidade:{produtoAntigo.Quantidade}");
                    log.ComoFicou = ($"Id:{produto.Id}, Nome:{produto.Nome}, Quantidade:{produto.Quantidade}, Motivo da retirada:{motivoRetirada}");

                    produtoAntigo.Quantidade = produto.Quantidade;

                    ctx.Logs.Add(log);
                    ctx.SaveChanges();
                    return "Alteração concluida";
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return "Não foi possivel salvar alterações";
            }
        }

        public static List<Produto> BuscarProdutosEstoqueAbaixoDe(int qtdBusca)
        {
            List<Produto> listaDeProdutos = new List<Produto>();
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    listaDeProdutos = ctx.Produtos.Where(p => p.Quantidade <= qtdBusca).ToList();
                    return listaDeProdutos;
                }
            }
            catch
            {
                return listaDeProdutos;
            }
        }
    }
}
