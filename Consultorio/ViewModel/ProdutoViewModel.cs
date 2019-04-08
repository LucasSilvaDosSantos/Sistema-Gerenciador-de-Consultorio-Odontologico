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
    class ProdutoViewModel
    {
        public static List<Produto> ExibirProdutos()
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    var teste = ctx.Produtos.ToList();
                    return teste;
                }
            }
            catch (Exception)
            {
                List<Produto> teste = null;
                return teste;
            }            
        }
    }
}
