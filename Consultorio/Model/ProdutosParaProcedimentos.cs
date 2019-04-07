using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// criar chave composta se for presciso 

namespace Consultorio.Model
{
    class ProdutosParaProcedimentos
    {
        //[Required] Not Null

        [Required]
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int QuantidadeProduto { get; set; }
        public virtual Produto Produto { get; set; }
        public int ProcedimentoId { get; set; }
        public virtual Procedimento Procedimento { get; set; }

        public ProdutosParaProcedimentos(Produto produto, Procedimento procedimento)
        {
            Produto = produto;
            Procedimento = procedimento;
        }
    }
}
