using Consultorio.Data;
using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.ViewModel
{
    class ListaColaboradoresViewModel
    {
        static public List<Atores> ListarAtores()
        {
            List<Atores> listaAtores = new List<Atores>();
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    List<Dentista> listaDentistas = ctx.Dentistas.ToList();
                    foreach (var i in listaDentistas)
                    {
                        listaAtores.Add(i);
                    }

                    List<Secretaria> listaSecretaria = ctx.Secretarias.ToList();
                    foreach (var i in listaSecretaria)
                    {
                        listaAtores.Add(i);
                    }

                    List<GestorDeEstoque> listaGestorEstoque = ctx.GestoresDeEstoque.ToList();
                    foreach (var i in listaGestorEstoque)
                    {
                        listaAtores.Add(i);
                    }

                    return listaAtores;
                }
            }
            catch (Exception)
            {
                return listaAtores;
            }
        }
    }
}
