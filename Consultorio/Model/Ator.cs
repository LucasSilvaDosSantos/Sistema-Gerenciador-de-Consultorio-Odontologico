using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consultorio.Model
{
    [Table ("Atores")]
    public class Ator
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public string Telefone1 { get; set; }

        public string Telefone2 { get; set; }
        public string Crosp { get; set; }


        [Required]
        public bool Clinicar { get; set; }
        [Required]
        public bool CrudClientes { get; set; }
        [Required]
        public bool CrudConsultas { get; set; }
        [Required]
        public bool CrudProdutos { get; set; }
        [Required]
        public bool CadastroDeContasPagas { get; set; }
        [Required]
        public bool VisualizarFinanceiro { get; set; }
        [Required]
        public bool ReceberDeClientes { get; set; }
        [Required]
        public bool CrudAtores { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        public bool Ativo{ get; set; }

        public Ator(string nome, string email, string telefone1, string telefone2, string crosp, bool clinicar, bool crudClientes, bool crudConsultas, 
            bool crudProdutos, bool cadastroDeContasPagas, bool visualizarFinanceiro, bool receberDeClientes, bool crudAtores, string login, string senha, bool ativo)
        {
            Nome = nome;
            Email = email;
            Telefone1 = telefone1;
            Telefone2 = telefone2;
            Crosp = crosp;
            Clinicar = clinicar;
            CrudClientes = crudClientes;
            CrudConsultas = crudConsultas;
            CrudProdutos = crudProdutos;
            CadastroDeContasPagas = cadastroDeContasPagas;
            VisualizarFinanceiro = VisualizarFinanceiro;
            ReceberDeClientes = receberDeClientes;
            CrudAtores = crudAtores;
            Login = login;
            Senha = senha;
            Ativo = ativo;
        }

        public Ator()
        {
        }
    }
}
