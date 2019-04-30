using Consultorio.Data;
using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.ViewModel
{
    class GestorDeEstoqueViewModel
    {
        public static string CadastroDeNovoGestorDeEstoque(GestorDeEstoque gestorDeEstoque)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    ctx.GestoresDeEstoque.Add(gestorDeEstoque);
                    ctx.SaveChanges();
                    return ("Salvo novo Gestor de Estoque");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return ("error" + e.Message);
            }
        }
    }
}
