﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consultorio.Model
{
    [Table("Procedimentos")]
    public class Procedimento
    {
        //[Required] Not Null

        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [Required]
        public double Preco { get; set; }
        public DateTime TempoRecomendado { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
        public virtual ICollection<OrcamentosParaProcedimentos> OrcamentosParaProcedimentos { get; set; }


        //public bool Ativo { get; set; }

        public Procedimento()
        {
        }
    }
}
