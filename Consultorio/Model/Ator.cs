﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public bool VisualizarContabilidade { get; set; }
        [Required]
        public bool ReceberDeClientes { get; set; }
        [Required]
        public bool CrudAtores { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Senha { get; set; }

        public Ator(string nome, string email, string telefone1, string telefone2, string crosp, bool clinicar, bool crudClientes, bool crudConsultas, 
            bool crudProdutos, bool cadastroDeContasPagas, bool visualizarContabilidade, bool receberDeClientes, bool crudAtores, string login, string senha)
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
            VisualizarContabilidade = visualizarContabilidade;
            ReceberDeClientes = receberDeClientes;
            CrudAtores = crudAtores;
            Login = login;
            Senha = senha;
        }

        public Ator()
        {
        }
    }
}
