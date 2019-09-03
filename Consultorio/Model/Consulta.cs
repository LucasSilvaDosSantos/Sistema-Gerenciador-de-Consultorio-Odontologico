using Consultorio.Model.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Consultorio.Model
{
    public class Consulta
    {
        //[Required] Not Null

        public int Id { get; set; }
        [Required]
        public Cliente Cliente { get; set; }
        [Required]
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public Procedimento Procedimento { get; set; }
        public string Dente { get; set; }
        [Required]
        public double ValorConsulta { get; set; }
        public Ator QuemRealizou { get; set; }
        [Required]
        public StatusConsulta Status { get; set; }

        public Consulta()
        {
        }
    }
}
