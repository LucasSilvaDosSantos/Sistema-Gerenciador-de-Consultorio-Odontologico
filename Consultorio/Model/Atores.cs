using System.ComponentModel.DataAnnotations;

namespace Consultorio.Model
{
    public abstract class Atores
    {
        //[Required] Not Null

        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Telefone1 { get; set; }

        public string Telefone2 { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Senha { get; set; }

        /*[Required]
        public bool Ativo { get; set; }*/

        protected Atores()
        {
        }

        protected Atores(string nome, string email, string telefone1, string telefone2, string login, string senha)
        {
            Nome = nome;
            Email = email;
            Telefone1 = telefone1;
            Telefone2 = telefone2;
            Login = login;
            Senha = senha;
            //Ativo = true;
        }
    }
}
