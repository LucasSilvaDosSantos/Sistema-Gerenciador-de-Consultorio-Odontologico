using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Consultorio.Data.Consultas
{
    class ListaDeClienteParaConsultaData
    {
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
