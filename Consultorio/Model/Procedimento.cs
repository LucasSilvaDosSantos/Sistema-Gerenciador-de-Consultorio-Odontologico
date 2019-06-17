using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Model
{
    [Table("Procedimentos")]
    public class Procedimento
    {
        //[Required] Not Null

        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [Required]
        public double Preco { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }

        public bool Ativo { get; set; }

        public Procedimento()
        {
        }

        public Procedimento(string nome, string descricao, double preco)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;

            Produtos = new HashSet<Produto>();
        }
    }
}
