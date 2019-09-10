using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consultorio.Model
{
    [Table("Produtos")]
    public class Produto
    {
        //[Required] Not Null

        //[Required]
        public int? Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public int? Quantidade { get; set; }
        public string Descricao { get; set; }

        public int MinimoDeEstoque { get; set; }

        public virtual ICollection<Procedimento> Procedimentos { get; set; }
        public virtual ICollection<ProdutoUtilizadoEmConsulta> ProdutoUtilizadoEmConsulta { get; set; }

        /*
        public bool Ativo { get; set; }*/

        public Produto()
        {
        }

        public Produto(string nome, int quantidade, string descricao)
        {
            Nome = nome;
            Quantidade = quantidade;
            Descricao = descricao;

            Procedimentos = new HashSet<Procedimento>();
        }
    }
}
