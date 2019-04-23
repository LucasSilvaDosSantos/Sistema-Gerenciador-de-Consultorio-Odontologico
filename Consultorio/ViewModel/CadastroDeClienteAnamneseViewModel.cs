using Consultorio.Data;
using Consultorio.Model;
using System;
using System.Data.Entity;
using System.Linq;

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

        public static Anamnese CarregarAnamnese(Cliente clienteEntrada)
        {
            try
            {
                using(ConsultorioContext ctx = new ConsultorioContext())
                {

                    // include para o paciente pegar os dados de cliente referentes a anamnese
                    var cliente = ctx.Clientes.Where(c => c.Id == clienteEntrada.Id).Include(c => c.Anamnese).FirstOrDefault();

                    Anamnese anamnese = cliente.Anamnese;

                    return anamnese;
                }
            }
            catch (Exception)
            {
                Anamnese anamnese = new Anamnese();
                return anamnese;
            }           
        }
    }
}
