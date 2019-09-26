using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Consultorio.Data.Pagamentos
{
    class PagamentosData
    {
        public static string CadastrarNovoPagamento(Pagamento pagamento)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    pagamento.Recebedor = ctx.Atores.Find(pagamento.Recebedor.Id);
                    pagamento.Cliente = ctx.Clientes.Find(pagamento.Cliente.Id);                    
                    ctx.Pagamentos.Add(pagamento);
                    ctx.SaveChanges();
                    return ("Salvo novo Pagamento");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return ("error" + e.Message);
            }
        }

        public static List<Pagamento> CarragarPagamentosporDataECliente(int id, DateTime inicio, DateTime fim)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    fim = fim.AddDays(1);
                    var listaPagamentos = ctx.Pagamentos.Include(b => b.Recebedor).Where(a => a.Cliente.Id == id && (a.DataDePagamento >= inicio && a.DataDePagamento <= fim)).ToList();

                    return listaPagamentos;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Pagamento>();
            }
        }
    }
}
