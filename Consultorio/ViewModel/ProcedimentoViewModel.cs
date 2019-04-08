using Consultorio.Data;
using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.ViewModel
{
    class ProcedimentoViewModel
    {
        public static List<Procedimento> ExibirProcedimentos()
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
    }
}
