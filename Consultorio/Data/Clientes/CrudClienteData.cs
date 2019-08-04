using Consultorio.Model;
using System;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Data.Clientes
{
    class CrudClienteData
    {
        public static Cliente BuscarClientePorId(int id)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    Cliente cliente = ctx.Clientes.Include(a => a.Anamnese).Include(b => b.Odontograma).First(c => c.Id == id);
                    return cliente;
                }
            }
            catch
            {
                return new Cliente();
            }
        }

        public static string SalvarCliente(Cliente cliente)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    string msg;
                    if (cliente.Anamnese != null)
                    {
                        if (cliente.Anamnese.Id != 0)
                        {
                            ctx.Entry(cliente.Anamnese).State = EntityState.Modified;
                        }
                        else
                        {
                            ctx.Anamneses.Add(cliente.Anamnese);
                        }
                    }
                    if (cliente.Id == 0)
                    {
                        ctx.Clientes.Add(cliente);
                        msg = "Novo Cliente Salvo!";
                    }
                    else
                    {
                        ctx.Entry(cliente).State = EntityState.Modified;
                        msg = "Salva Alterações no Cliente";
                    }

                    if (cliente.Odontograma.Id != 0)
                    {
                        ctx.Entry(cliente.Odontograma).State = EntityState.Modified;
                    }             
                    ctx.SaveChanges();
                    return msg;
                }
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }
    }
}
