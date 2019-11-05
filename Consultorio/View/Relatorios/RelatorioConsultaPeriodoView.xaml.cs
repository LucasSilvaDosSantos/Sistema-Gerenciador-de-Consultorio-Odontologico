using Consultorio.View.ManualDoUsuario;
using Consultorio.ViewModel.Relatorios;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;

namespace Consultorio.View.Relatorios
{
    /// <summary>
    /// Lógica interna para RelatorioConsultaPeriodoView.xaml
    /// </summary>
    public partial class RelatorioConsultaPeriodoView : Window
    {
        public RelatorioConsultaPeriodoViewModel RelatorioConsultaPeriodoViewModel { get; set; } = new RelatorioConsultaPeriodoViewModel();

        public RelatorioConsultaPeriodoView()
        {
            InitializeComponent();
        }

        private void BtGerarRelatorio_Click(object sender, RoutedEventArgs e)
        {
            if (dtInicio.SelectedDate != null && dtFim.SelectedDate != null && dtInicio.SelectedDate <= dtFim.SelectedDate)
            {
                bool[] filtros = new bool[4] {(bool)cbAgendada.IsChecked, (bool)cbCancelada.IsChecked, (bool)cbReagendada.IsChecked, (bool)cbRealizada.IsChecked};

                DataTable dataTableConsultas = RelatorioConsultaPeriodoViewModel.CarregaDataTable((DateTime)dtInicio.SelectedDate, (DateTime)dtFim.SelectedDate, filtros);

                ReportDataSource dataSourceConsulta = new ReportDataSource("Consultas", dataTableConsultas);

                rvConsultas.LocalReport.DataSources.Clear();
                rvConsultas.LocalReport.DataSources.Add(dataSourceConsulta);

                rvConsultas.LocalReport.ReportEmbeddedResource = "Consultorio.Relatorios.ConsultasPorData.rdlc";

                CarregarParametros();

                TratarECarregarDatas();

                rvConsultas.RefreshReport();
            }
            else
            {
                MessageBox.Show("Os campos de data devem ser preenchidos!","Aviso!");
            }
        }

        private void CarregarParametros()
        {

            rvConsultas.LocalReport.SetParameters(new ReportParameter("textoFiltroStatus", ConstruirTextoDeFiltro()));

            rvConsultas.LocalReport.SetParameters(new ReportParameter("qtdtotalDeConsultas", RelatorioConsultaPeriodoViewModel.QtdTotalDeConsultas.ToString()));
            rvConsultas.LocalReport.SetParameters(new ReportParameter("qtdConsultasReagendadas", RelatorioConsultaPeriodoViewModel.QtdConsultasReagendadas.ToString()));
            rvConsultas.LocalReport.SetParameters(new ReportParameter("qtdConsultasRealizadas", RelatorioConsultaPeriodoViewModel.QtdConsultasRealizadas.ToString()));
            rvConsultas.LocalReport.SetParameters(new ReportParameter("qtdConsultasCanceladas", RelatorioConsultaPeriodoViewModel.QtdConsultasCanceladas.ToString()));
            rvConsultas.LocalReport.SetParameters(new ReportParameter("qtdConsultasAgendadas", RelatorioConsultaPeriodoViewModel.QtdConsultasAgendadas.ToString()));

            rvConsultas.LocalReport.SetParameters(new ReportParameter("usuario", RelatorioConsultaPeriodoViewModel.AtorLogado.Nome));
        }

        private string ConstruirTextoDeFiltro()
        {
            //var textoFiltros = "";

            StringBuilder sb = new StringBuilder();
            sb.Append("Filtros selecionados para status de consulta: ");

            if (cbAgendada.IsChecked == true)
            {
                sb.Append("agendada");
            }
            if (cbCancelada.IsChecked == true)
            {
                sb.Append(", cancelada");
            }
            if (cbReagendada.IsChecked == true)
            {
                sb.Append(", reagendada");
            }
            if (cbRealizada.IsChecked == true)
            {
                sb.Append(", realizada");
            }
            sb.Append(".");

            return sb.ToString();
        }

        private void TratarECarregarDatas()
        {
            var dataInicio = (DateTime)dtInicio.SelectedDate;
            var inicioString = dataInicio.ToShortDateString();

            var dataFim = (DateTime)dtFim.SelectedDate;
            var fimString = dataFim.ToShortDateString();

            rvConsultas.LocalReport.SetParameters(new ReportParameter("inicio", inicioString));
            rvConsultas.LocalReport.SetParameters(new ReportParameter("fim", fimString));
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            RelatoriosView relatoriosView = new RelatoriosView();
            ConfiguracoesDeView.ConfigurarWindow(this, relatoriosView);
            relatoriosView.Show();
            this.Close();
        }

        private void BtAjuda_Click(object sender, RoutedEventArgs e)
        {
            var ajudaView = new Ajuda("RelatorioConsultaPeriodoView.mp4");
            ajudaView.ShowDialog();
        }
    }
}
