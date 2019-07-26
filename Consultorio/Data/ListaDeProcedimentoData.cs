using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Consultorio.Data
{
    class ListaDeProcedimentoData
    {
        public static List<Procedimento> ListarTodosProcedimentos()
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    var lista = ctx.Procedimentos.ToList();

                    return lista;
                }
            }
            catch (Exception)
            {
                List<Procedimento> lista = null;
                return lista;
            }
        }

        public static List<Procedimento> BuscarProcedimentos(int id, string nome)
        {
            List<Procedimento> lista = new List<Procedimento>();
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    if (id != 0)
                    {
                        lista = ctx.Procedimentos.Where(p => p.Id == id).ToList();
                        return lista;
                    }
                    else if (nome != "")
                    {
                        lista = ctx.Procedimentos.Where(p => p.Nome.Contains(nome)).ToList();
                        return lista;
                    }
                    return lista;
                }
            }
            catch (Exception)
            {
                return lista;
            }
        }

        public static Procedimento CarregarProdutosDoProcedimento(Procedimento procedimento)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    procedimento = ctx.Procedimentos.Include(p => p.Produtos).Single(p => p.Id == procedimento.Id);// Where(a => a.Id == id).FirstOrDefault();
                    return procedimento;
                }
            }
            catch (Exception)
            {
                return null;
            }           
        }
    }
}