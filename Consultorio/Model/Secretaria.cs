﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Model
{
    [Table("Secretarias")]
    public class Secretaria : Atores
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

        public Secretaria()
        {
        }

        public Secretaria(string nome, string email, string telefone1, string telefone2, string crosp, string login, string senha, 
            bool crudClientes, bool crudSecretarias, bool crudProduto, bool crudGestorDeEstoque)
            : base(nome, email, telefone1, telefone2, login, senha)
        {
            Crosp = crosp;
            CrudClientes = crudClientes;
            CrudSecretarias = crudSecretarias;
            CrudProdutos = crudProduto;
            CrudGestoresDeEstoque = crudGestorDeEstoque;
        }
    }
}
