using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consultorio.Model
{
    [Table("Orcamentos")]
    public class Orcamento
    {
        public int Id { get; set; }
        [Required]
        public Cliente Cliente { get; set; }
                
        public string Obs { get; set; }

        public virtual ICollection<OrcamentosParaProcedimentos> OrcamentosParaProcedimentos { get; set; }

        public Orcamento()
        {
        }
    }
}
