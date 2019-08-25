using Consultorio.Model;
using System;

namespace Consultorio.Data.Pagamentos
{
    static class ContaPagaData
    {
        public static string SalvarContaPaga(ContaPaga contaPaga)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    contaPaga.QuemCadastrou = ctx.Atores.Find(contaPaga.QuemCadastrou.Id);
                    ctx.ContasPagas.Add(contaPaga);
                    ctx.SaveChanges();
                    return "Conta Cadastrada com Sucesso!";
                }
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }
    }
}
