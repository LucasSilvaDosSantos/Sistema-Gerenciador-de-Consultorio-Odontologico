using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Consultorio.Model
{
    [Table("Pagamentos")]
    public class Pagamento
    {
        //[Required] Not Null

        public int Id { get; set; }
        [Required]
        public Ator Recebedor { get; set; }
        [Required]
        public string FormaDePagamento { get; set; }
        [Required]
        public DateTime DataDePagamento { get; set; }
        [Required]
        public double Valor { get; set; }
        [Required]
        public Cliente Cliente { get; set; }
        public string Obs { get; set; }

        public Pagamento()
        {

        }

        public Pagamento(Ator recebedor, string formaDePagamento, DateTime dataDePagamento, double valor, Cliente cliente)
        {
            Recebedor = recebedor;
            FormaDePagamento = formaDePagamento;
            DataDePagamento = dataDePagamento;
            Valor = valor;
            Cliente = cliente;
        }
    }
}
