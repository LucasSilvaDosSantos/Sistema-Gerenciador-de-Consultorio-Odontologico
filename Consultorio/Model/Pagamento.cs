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
    class Pagamento
    {
        //[Required] Not Null

        [Required]
        public int Id { get; set; }
        public Atores Recebedor { get; set; }
        [Required]
        public string FormaDePagamento { get; set; }
        [Required]
        public DateTime DataDePagamento { get; set; }
        [Required]
        public double Valor { get; set; }
        public Cliente Cliente { get; set; }

        public Pagamento()
        {

        }

        public Pagamento(Atores recebedor, string formaDePagamento, DateTime dataDePagamento, double valor, Cliente cliente)
        {
            Recebedor = recebedor;
            FormaDePagamento = formaDePagamento;
            DataDePagamento = dataDePagamento;
            Valor = valor;
            Cliente = cliente;
        }
    }
}
