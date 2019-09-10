using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consultorio.Model
{
    [Table("ProdutosUtilizadosEmconsultas")]
    public class ProdutoUtilizadoEmConsulta
    {
        [Key, Column(Order = 0)]
        public int ConsultaID { get; set; }
        [Key, Column(Order = 1)]
        public int ProdutoID { get; set; }

        public virtual Consulta Consulta { get; set; }
        public virtual Produto Produto { get; set; }

        public int QtdProdutoUtilizado { get; set; }

        public ProdutoUtilizadoEmConsulta()
        {
        }
    }
}
