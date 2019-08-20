using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consultorio.Model
{
    public class OrcamentosParaProcedimentos
    {
        [Key, Column(Order = 0)]
        public int OrcamentoID { get; set; }
        [Key, Column(Order = 1)]
        public int ProcedimentoID { get; set; }
        

        public virtual Orcamento Orcamento { get; set; }
        public virtual Procedimento Procedimento { get; set; }
        public int ColaboradorAlterouID { get; set; }

        public Ator ColaboradorAlterou { get; set; }

        public  int QtdDeProcedimentos { get; set; }

        public DateTime DataDeAdicao { get; set; }

        public double ValorTotalDoProcedimento { get; set; }

        public double DescontoEmProcentagem { get; set; }


        public OrcamentosParaProcedimentos()
        {
            //QtdDeProcedimentos = 1;
        }
    }
}
