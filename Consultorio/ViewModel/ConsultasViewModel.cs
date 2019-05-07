using Consultorio.Data;
using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.ViewModel
{
    class ConsultasViewModel
    {
        public static List<Consulta> ListaDeConsultas()
        {
            List<Consulta> consultas = new List<Consulta>();
            try {              
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    consultas = ctx.Consultas.ToList();
                    return consultas;
                }
            }catch (Exception)
            {
                return consultas;
            }
        }
    }
}