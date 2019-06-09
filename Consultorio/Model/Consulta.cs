using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Model
{
    public class Consulta
    {
        //[Required] Not Null

        public int Id { get; set; }
        [Required]
        public Cliente Cliente { get; set; }
        [Required]
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public Procedimento Procedimento { get; set; }
        public string Dente { get; set; }
        [Required]
        public bool Realizada { get; set; }

        public Consulta()
        {
        }

        public Consulta(Cliente cliente, DateTime inicio, DateTime fim, Procedimento procedimento)
        {
            Cliente = cliente;
            Inicio = inicio;
            Fim = fim;
            Procedimento = procedimento;
            Realizada = false;
        }
    }
}
