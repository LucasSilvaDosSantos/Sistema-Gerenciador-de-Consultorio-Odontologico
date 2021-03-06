﻿using Consultorio.Model;
using Consultorio.ViewModel.Atores;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Consultorio.Data.Consultas
{
    class FinalizarConsultaData
    {
        public static bool SalvarFinalizacaoDeConsulta(Consulta consultaEntrada, ICollection<ProdutoUtilizadoEmConsulta> listaDeProdutosUtilizados)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    var consultaParaSalvar = ctx.Consultas.Find(consultaEntrada.Id);

                    if (listaDeProdutosUtilizados != null)
                    {
                        foreach (var item in listaDeProdutosUtilizados)
                        {
                            item.Produto = ctx.Produtos.Find(item.Produto.Id);
                            item.Consulta = ctx.Consultas.Find(item.Consulta.Id);
                            item.Produto.Quantidade -= item.QtdProdutoUtilizado;

                            ctx.ProdutoUtilizadoEmConsultas.Add(item);
                        }
                    }
                    var orcamentoParaProcedimento = ctx.OrcamentosParaProcedimentos.SingleOrDefault(_ => _.Procedimento.Id == consultaEntrada.Procedimento.Id);
                    if (orcamentoParaProcedimento != null)
                    {
                        if (orcamentoParaProcedimento.QtdDeProcedimentos > 1)
                            orcamentoParaProcedimento.QtdDeProcedimentos -= 1;
                        else
                        {
                            ctx.OrcamentosParaProcedimentos.Remove(orcamentoParaProcedimento);
                        }
                    }

                    consultaParaSalvar.QuemRealizou = ctx.Atores.Find(SingletonAtorLogado.Instancia.Ator.Id);
                    consultaParaSalvar.Procedimento = ctx.Procedimentos.Find(consultaEntrada.Procedimento.Id);
                    consultaParaSalvar.Cliente = ctx.Clientes.Find(consultaEntrada.Cliente.Id);
                    consultaParaSalvar.Status = Model.Enums.StatusConsulta.Realizada;
                    consultaParaSalvar.Fim = consultaEntrada.Fim;
                    consultaParaSalvar.Inicio = consultaEntrada.Inicio;
                    consultaParaSalvar.Obs = consultaEntrada.Obs;

                    ctx.SaveChanges();

                    return true;
                }
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
