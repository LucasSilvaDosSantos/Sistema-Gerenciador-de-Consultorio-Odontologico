using Consultorio.Data.Consultas;
using Consultorio.Model;
using Consultorio.ViewModel.Atores;
using System;
using System.Data;
using System.Linq;

namespace Consultorio.ViewModel.Relatorios
{
    public class RelatorioConsultaPeriodoViewModel
    {
        public Ator AtorLogado { get; set; } = SingletonAtorLogado.Instancia.Ator;

        public int QtdConsultasRealizadas { get; set; }
        public int QtdConsultasReagendadas { get; set; }
        public int QtdConsultasCanceladas { get; set; }
        public int QtdTotalDeConsultas{ get; set; }
        public int QtdConsultasAgendadas { get; set; }

        public RelatorioConsultaPeriodoViewModel()
        {
        }

        public DataTable CarregaDataTable(DateTime inicio, DateTime fim, string orderBy, bool[] filtros)
        {
            QtdConsultasRealizadas = 0;
            QtdConsultasReagendadas = 0;
            QtdConsultasCanceladas = 0;
            QtdTotalDeConsultas = 0;
            QtdConsultasAgendadas = 0;

            var listaConsulta = ConsultasData.BuscarConsultaPorPeriodo(inicio, fim);

            if (filtros[0] == false)
            {
                listaConsulta = listaConsulta.Where(a => a.Status != Model.Enums.StatusConsulta.Agendada).ToList();
            }
            if (filtros[1] == false)
            {
                listaConsulta = listaConsulta.Where(a => a.Status != Model.Enums.StatusConsulta.Cancelada).ToList();
            }
            if (filtros[2] == false)
            {
                listaConsulta = listaConsulta.Where(a => a.Status != Model.Enums.StatusConsulta.Reagendada).ToList();
            }
            if (filtros[3] == false)
            {
                listaConsulta = listaConsulta.Where(a => a.Status != Model.Enums.StatusConsulta.Realizada).ToList();
            }

            var listOrdenada = listaConsulta;
            if (orderBy == "Id")
            {
                listOrdenada = listaConsulta.OrderBy(c => c.Id).ToList();
            }
            else if (orderBy == "Data")
            {
                listOrdenada = listaConsulta.OrderBy(c => c.Inicio.Date).ToList();
            }
            else if (orderBy == "Status")
            {
                listOrdenada = listaConsulta.OrderBy(c => c.Status).ToList();
            }
            else if (orderBy == "Cliente")
            {
                listOrdenada = listaConsulta.OrderBy(c => c.Cliente.Nome).ToList();
            }
            else if (orderBy == "Procedimento")
            {
                listOrdenada = listaConsulta.OrderBy(c => c.Procedimento.Nome).ToList();
            }

            var t1 = new DataTable();
            t1.Columns.Add("Id");
            t1.Columns.Add("Inicio");
            t1.Columns.Add("Cliente");
            t1.Columns.Add("Status");
            t1.Columns.Add("Procedimento");
            t1.Columns.Add("QuemRealizou");

            foreach (var item in listOrdenada)
            {
                if (item.Status != Model.Enums.StatusConsulta.Iniciada)
                {
                    string quemRealizou = "";
                    if (item.QuemRealizou != null)
                    {
                        quemRealizou = item.QuemRealizou.Nome;
                    }

                    t1.Rows.Add(item.Id, item.Inicio.ToShortDateString(), item.Cliente.Nome, item.Status.ToString(), item.Procedimento.Nome, quemRealizou);

                    QtdTotalDeConsultas += 1;
                    if (item.Status == Model.Enums.StatusConsulta.Realizada)
                    {
                        QtdConsultasRealizadas += 1;
                    }
                    else if(item.Status == Model.Enums.StatusConsulta.Reagendada)
                    {
                        QtdConsultasReagendadas += 1;
                    }
                    else if (item.Status == Model.Enums.StatusConsulta.Cancelada)
                    {
                        QtdConsultasCanceladas += 1;
                    }
                    else if(item.Status == Model.Enums.StatusConsulta.Agendada)
                    {
                        QtdConsultasAgendadas += 1;
                    }
                }
            }
            return t1;
        }
    }
}
