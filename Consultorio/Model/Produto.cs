using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Consultorio.Model
{
    [Table("Produtos")]
    class Produto
    {
        //[Required] Not Null

        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Quantidade { get; set; }
        public string Descricao { get; set; }

        public DateTime? Validade { get; set; }

        public virtual ICollection<Procedimento> Procedimentos { get; set; }

        [Required]
        public bool Ativo { get; set; }

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

        /*
        public void SetValidade(string validade)
        {
            Validade = DateTime.ParseExact(validade, "dd/MM/yyyy", CultureInfo.CurrentCulture);
        }*/ //modificado para dentro do codigo
    }
}
