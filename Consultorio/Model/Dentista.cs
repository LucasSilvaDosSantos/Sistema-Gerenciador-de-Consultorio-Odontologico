using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Model
{
    [Table("Dentistas")]
    public class Dentista : Atores
    {
        //[Required] Not Null

        [Required]
        public string Crosp { get; set; }

        public Dentista()
        {
        }

        public Dentista(string nome, string email, string telefone1, string telefone2, string crosp, string login, string senha) :
            base(nome, email, telefone1, telefone2, login, senha)
        {
            Crosp = crosp;
        }
    }
}
