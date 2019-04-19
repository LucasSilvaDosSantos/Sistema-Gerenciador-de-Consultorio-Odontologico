using Consultorio.Data;
using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.ViewModel
{
    class CadastroDeClienteBaseViewModel
    {
        public static void CadastroDeNovoCliente(Cliente cliente)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    ctx.Clientes.Add(cliente);
                    ctx.SaveChanges();
                }
            }
            catch{

            }
        }
    }
}
