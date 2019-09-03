using Consultorio.Model;
using Consultorio.Model.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace Consultorio.Data.Pagamentos
{
    class ContabilidadeData
    {
        static public List<ContaPaga> TodasAsContas(DateTime inicio, DateTime fim)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    var a = ctx.ContasPagas.Include(b => b.QuemCadastrou).Where(c => c.DataDePagamento >= inicio && c.DataDePagamento <= fim).ToList();
                    return a;
                }
            }
            catch
            {
                return new List<ContaPaga>();
            }
            
        }

        static public List<Consulta> TodasAsConsultasRealizadas(DateTime inicio, DateTime fim)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    //data vindo com hora zerada oque esta gerando problema, adicionado um dia para rezolução do mesmo 
                    fim = fim.AddDays(1);
                    var a = ctx.Consultas.Include(b => b.Cliente).Include(c => c.Procedimento).Where(d => d.Status == StatusConsulta.Realizada && d.Inicio >= inicio && d.Inicio <= fim).ToList();
                    return a;
                }
            }
            catch
            {
                return new List<Consulta>();
            }
        }

        static public List<ProdutoCompra> TodosOsProdutosComprados(DateTime inicio, DateTime fim)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    fim = fim.AddDays(1);
                    var a = ctx.ProdutosCompras.Include(b => b.QuemRegistrou).Include(c => c.Produto).Where(d => d.DataDeCompra >= inicio && d.DataDeCompra <= fim).ToList();
                    return a;
                }
            }
            catch
            {
                return new List<ProdutoCompra>();
            }
        }

        static public List<Pagamento> TodosOsPagamentosRecebidos(DateTime inicio, DateTime fim)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    //fim = fim.AddDays(1);
                    var a = ctx.Pagamentos.Include(b => b.Cliente).Include(c => c.Recebedor).Where(d => d.DataDePagamento >= inicio && d.DataDePagamento <= fim).ToList();
                    return a;
                }
            }
            catch
            {
                return new List<Pagamento>();
            }
        }
    }
}
