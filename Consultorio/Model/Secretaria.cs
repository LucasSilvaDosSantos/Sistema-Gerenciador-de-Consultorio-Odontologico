using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Model
{
    [Table("Secretarias")]
    class Secretaria : Atores
    {
        //[Required] Not Null

        public string Crosp { get; set; }
        [Required]
        public bool CrudClientes { get; set; }
        [Required]
        public bool CrudSecretarias { get; set; }
        [Required]
        public bool CrudProdutos { get; set; }
        [Required]
        public bool CrudGestoresDeEstoque { get; set; }

        public Secretaria(string nome, string sobrenome, string email, string telefone1, string telefone2, string login, string senha, string crosp,
            bool crudClientes, bool crudSecretarias, bool crudProduto, bool crudGestorDeEstoque)
            : base(nome, sobrenome, email, telefone1, telefone2, login, senha)
        {
            Crosp = crosp;
            CrudClientes = crudClientes;
            CrudSecretarias = crudSecretarias;
            CrudProdutos = crudProduto;
            CrudGestoresDeEstoque = crudGestorDeEstoque;
        }
    }
}
