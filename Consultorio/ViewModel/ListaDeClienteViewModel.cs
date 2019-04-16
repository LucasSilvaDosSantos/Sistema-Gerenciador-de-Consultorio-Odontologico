using Consultorio.Data;
using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.ViewModel
{
    class ListaDeClienteViewModel
    {
        // lista todos os clientes do banco
        public static List<Cliente> ExibirCliente()
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    var clientes = ctx.Clientes.ToList();
                    return clientes;
                }
            }
            catch (Exception)
            {
                List<Cliente> clientes = new List<Cliente>();
                return clientes;
            }
        }

        // lista todos os clientes por id ou nome
        public static List<Cliente> BuscarCliente(int id, string nome)
        {
            List<Cliente> lista = new List<Cliente>();
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    if (id != 0)
                    {
                        lista = ctx.Clientes.Where(c => c.Id == id).ToList();
                        return lista;
                    }
                    else if (nome != "")
                    {
                        lista = ctx.Clientes.Where(c => c.Nome.Contains(nome)).ToList();
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
    }
}
