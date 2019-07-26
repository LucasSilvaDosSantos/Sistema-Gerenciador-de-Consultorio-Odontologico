using Consultorio.Model;
using System;

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
                    string tipoDeAtor = pagamento.Recebedor.GetType().Name;
                    if (tipoDeAtor == "Dentista")
                    {
                        pagamento.Recebedor = ctx.Dentistas.Find(pagamento.Recebedor.Id);
                    }
                    else if (tipoDeAtor == "Secretaria")
                    {
                        pagamento.Recebedor = ctx.Secretarias.Find(pagamento.Recebedor.Id);
                    }
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
    }
}
