using Consultorio.Data;
using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.ViewModel
{
    class CadastroDeClienteAnamneseViewModel
    {
        public static void CadastrarAnamnese(Cliente clienteEntrada, Anamnese anamnese) {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    Cliente cliente = ctx.Clientes.Find(clienteEntrada.Id);
                    cliente.Anamnese = anamnese;
                    ctx.SaveChanges();
                }
            }
            catch
            {

            }
        }
    }
}
