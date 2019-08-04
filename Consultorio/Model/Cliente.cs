using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Model
{
    public class Cliente
    {
        //[Required] Not Null

        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public DateTime Nascimento { get; set; }

        [Required]
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Email { get; set; }

        [Required]
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Uf { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public string Obs { get; set; }
        public Anamnese Anamnese { get; set; }

        public Odontograma Odontograma { get; set; }

        public Cliente()
        {
        }

        public Cliente(string nome, DateTime nascimento, string cpf, string rg, string email, string telefone1,
            string telefone2, string endereco, string bairro, string uf, string cidade, string cep)
        {
            Nome = nome;
            Nascimento = nascimento;
            Cpf = cpf;
            Rg = rg;
            Email = email;
            Telefone1 = telefone1;
            Telefone2 = telefone2;
            Endereco = endereco;
            Bairro = bairro;
            Uf = uf;
            Cidade = cidade;
            Cep = cep;
        }
    }
}
