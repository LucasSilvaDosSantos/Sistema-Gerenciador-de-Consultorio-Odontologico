using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Model
{
    [Table("GestoresDeEstoque")]
    class GestorDeEstoque : Atores
    {
        public GestorDeEstoque()
        {
        }
         
        public GestorDeEstoque(string nome, string sobrenome, string email, string telefone1, string telefone2, string login, string senha) :
            base(nome, sobrenome, email, telefone1, telefone2, login, senha)
        {

        }
    }
}
