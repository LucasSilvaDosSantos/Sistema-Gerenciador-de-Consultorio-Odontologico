using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consultorio.Model
{
    [Table("ProdutosCompras")]
    public class ProdutoCompra
    {       
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public double PrecoCompra { get; set; }
        public int QuantidaDeComprada { get; set; }
        public DateTime DataDeCompra { get; set; }
        public Ator QuemRegistrou { get; set; }
        public string Obs { get; set; }

        public ProdutoCompra()
        {
        }
    }
}
