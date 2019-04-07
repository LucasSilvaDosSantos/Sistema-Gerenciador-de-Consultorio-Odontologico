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
    class Dentista : Atores
    {
        //[Required] Not Null

        [Required]
        public string Crosp { get; set; }

        public Dentista(string nome, string sobrenome, string email, string telefone1, string telefone2, string login, string senha, string crosp) :
            base(nome, sobrenome, email, telefone1, telefone2, login, senha)
        {
            Crosp = crosp;
        }
    }
}
