using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consultorio.Model
{
    [Table("ContasPagas")]
    public class ContaPaga
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Ator QuemCadastrou { get; set; }
        public double Valor { get; set; }
        public DateTime DataDePagamento { get; set; }
        public string Obs { get; set; }

        public ContaPaga()
        {
        }
    }
}
