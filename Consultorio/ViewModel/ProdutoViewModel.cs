﻿using Consultorio.Data;
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
                    var lista = ctx.Produtos.ToList();
                    return lista;
                }
            }
            catch (Exception)
            {
                List<Produto> lista = null;
                return lista;
            }            
        }
    }
}
