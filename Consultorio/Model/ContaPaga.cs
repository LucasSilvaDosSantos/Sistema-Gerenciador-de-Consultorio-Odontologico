using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consultorio.Model
{
    [Table("ContasPagas")]
    public class ContaPaga
    {
        public int Id { get; set; }
        [Required]
        public TipoDeContaPaga Tipo { get; set; }
        public Ator QuemCadastrou { get; set; }
        public double Valor { get; set; }
        public DateTime DataDePagamento { get; set; }
        public string Obs { get; set; }

        public ContaPaga()
        {
        }
    }
}
