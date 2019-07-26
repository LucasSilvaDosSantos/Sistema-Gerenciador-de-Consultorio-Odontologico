using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Consultorio.Data.Clientes
{
    class HistoricoDoClienteData
    {
        public static List<Pagamento> ListarPagamentosPorCliente(int id)
        {
            List<Pagamento> pagamentos = new List<Pagamento>();
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    pagamentos = ctx.Pagamentos.Where(p => p.Cliente.Id == id).Include(r => r.Recebedor).ToList();

                    return pagamentos;
                }
            }
            catch (Exception)
            {
                return pagamentos;
            }
        }

        public static List<Consulta> ListarConsultaPorCliente(int id)
        {
            List<Consulta> consultas = new List<Consulta>();
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    consultas = ctx.Consultas.Where(p => p.Cliente.Id == id).Include(i => i.Procedimento).ToList();

                    return consultas;
                }
            }
            catch (Exception)
            {
                return consultas;
            }
        }
    }
}
