using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Consultorio.Model;

namespace Consultorio.Data.Clientes
{
    class OrcamentoData
    {
        public static Orcamento BuscarOrcamentoPorIdCliente(int id)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    var orcamento = ctx.Orcamentos.Where(a => a.Cliente.Id == id).Include(b => b.OrcamentosParaProcedimentos.Select(c => c.Procedimento)).Include(e => e.OrcamentosParaProcedimentos.Select(f => f.ColaboradorAlterou)).Include(d => d.Cliente).FirstOrDefault();
                    
                    return orcamento;
                }
            }
            catch
            {
                return null;
            }
        }

        public static string SalvarOrcamento(Orcamento orcamentoEntrada)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    string msg = "";

                    //Para novos orçamentos
                    if (orcamentoEntrada.Id == 0)
                    {
                        ctx.Orcamentos.Add(orcamentoEntrada);
                        
                        //orcamentoEntrada.Id = RecuperarIdOrcamento(orcamentoEntrada);

                        // Caso de procedimento esteja com itens
                        if (orcamentoEntrada.OrcamentosParaProcedimentos.Count != 0)
                        {
                            foreach (var item in orcamentoEntrada.OrcamentosParaProcedimentos)
                            {
                                item.Procedimento = ctx.Procedimentos.Find(item.Procedimento.Id);
                                item.Orcamento = ctx.Orcamentos.Find(item.Orcamento.Id);
                                //Feito assim para conseguir alterar a chave etrangeira do ator sem maior complicaçoes
                                item.ColaboradorAlterou = ctx.Atores.Find(item.ColaboradorAlterou.Id);
                                item.ColaboradorAlterouID = item.ColaboradorAlterou.Id;

                                ctx.OrcamentosParaProcedimentos.Add(item);
                            }
                        }
                        msg = "Novo orçamento salvo";
                        //fim Caso de procedimento esteja com itens
                    } 
                    
                    // fim Para novos orçamentos
                    else // Orcamento sendo atualizado
                    {

                        var a = ctx.Orcamentos.Find(orcamentoEntrada.Id);
                        a.Obs = orcamentoEntrada.Obs;

                        //Include para nao duplicar no banco
                        foreach (var item in orcamentoEntrada.OrcamentosParaProcedimentos)
                        {
                            item.Procedimento = ctx.Procedimentos.Find(item.Procedimento.Id);
                            item.Orcamento = ctx.Orcamentos.Find(item.Orcamento.Id);
                            //Feito assim para conseguir alterar a chave etrangeira do ator sem maior complicaçoes
                            item.ColaboradorAlterou = ctx.Atores.Find(item.ColaboradorAlterou.Id);
                            item.ColaboradorAlterouID = item.ColaboradorAlterou.Id;
                        }                       

                        foreach (var itemDoBanco in ctx.OrcamentosParaProcedimentos.Where(c => c.OrcamentoID == orcamentoEntrada.Id))
                        {
                            bool flagEncontrado = false;
                            foreach (var itemDeEntrada in orcamentoEntrada.OrcamentosParaProcedimentos)
                            {
                                if (itemDeEntrada.ProcedimentoID == itemDoBanco.ProcedimentoID)
                                {
                                    flagEncontrado = true;
                                    break;
                                }
                            }
                            if (flagEncontrado == false)
                            {
                                ctx.OrcamentosParaProcedimentos.Remove(itemDoBanco);
                            }
                        }

                        if (orcamentoEntrada.OrcamentosParaProcedimentos.Count != 0)
                        {
                            foreach (var item in orcamentoEntrada.OrcamentosParaProcedimentos)
                            {
                                var teste = ctx.Atores.Find(item.ColaboradorAlterouID);
                                item.ColaboradorAlterouID = teste.Id;
                                ctx.OrcamentosParaProcedimentos.AddOrUpdate(item);
                            }
                        }
                        msg = "Orçamento alterado!";
                    }
                   
                    ctx.SaveChanges();
                    return msg;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
            }
        }

        public static void SalvarNovoOrcamento(Orcamento orcamento)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    var a = orcamento;
                    orcamento.Cliente = ctx.Clientes.Find(orcamento.Cliente.Id);
                    ctx.Orcamentos.Add(orcamento);
                    ctx.SaveChanges();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }          
        }

        public static List<OrcamentosParaProcedimentos> BuscarListaOrcamentoParaProcedimentoPorIdOrcamento(int idOrcamento)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    var orcamentosParaProcedimentos = ctx.OrcamentosParaProcedimentos.Where(c => c.OrcamentoID == idOrcamento).ToList();
                    
                    return orcamentosParaProcedimentos;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
