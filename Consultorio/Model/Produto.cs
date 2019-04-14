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
        public DateTime? Validade { get; private set; }

        /*public DateTime? Validade {
            get { return Validade; }
            private set { SetValidade(value); }
        }*/

        public virtual ICollection<ProdutosParaProcedimentos> ListaProdutoProcedimento { get; set; }

        public Produto()
        {
        }

        public Produto(string nome, int quantidade, string descricao)
        {
            Nome = nome;
            Quantidade = quantidade;
            Descricao = descricao;

            ListaProdutoProcedimento = new HashSet<ProdutosParaProcedimentos>();
        }

        public void SetValidade(string validade)
        {
            Validade = DateTime.ParseExact(validade, "dd/MM/yyyy", CultureInfo.CurrentCulture);
        }

        public DateTime GetValidade()
        {
            string d = Validade.ToString();
            return DateTime.ParseExact(d, "dd/MM/yyyy", CultureInfo.CurrentCulture);
        }
    }
}
