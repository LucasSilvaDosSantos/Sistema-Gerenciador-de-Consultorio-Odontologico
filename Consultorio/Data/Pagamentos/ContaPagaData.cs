using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Linq;

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
                    contaPaga.Tipo = ctx.TiposDeContasPagas.Find(contaPaga.Tipo.Id);
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

        public static List<TipoDeContaPaga> TiposDeContaPaga()
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    return ctx.TiposDeContasPagas.ToList();   
                }
            }
            catch
            {
                return new List<TipoDeContaPaga>();
            }
        }

        public static bool NovoTipoDeConta(string novoTipoString)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    
                    ctx.TiposDeContasPagas.Add(new TipoDeContaPaga { Tipo = novoTipoString });
                    ctx.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
