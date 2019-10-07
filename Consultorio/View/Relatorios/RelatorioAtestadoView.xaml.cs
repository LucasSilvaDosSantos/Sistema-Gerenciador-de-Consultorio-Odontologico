using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Consultorio.View.Relatorios
{
    /// <summary>
    /// Lógica interna para RelatorioAtestadoView.xaml
    /// </summary>
    public partial class RelatorioAtestadoView : Window
    {
        public RelatorioAtestadoView(List<ReportDataSource> listaDeDataSources, List<string> listaDeParametros)
        {
            InitializeComponent();

            CarregarRelatorio(listaDeDataSources, listaDeParametros);
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CarregarRelatorio(List<ReportDataSource> listaDeDataSources, List<string> listaDeParametros)
        {
            rvAtestado.LocalReport.DataSources.Clear();

            foreach (var item in listaDeDataSources)
            {
                rvAtestado.LocalReport.DataSources.Add(item);
            }

            rvAtestado.LocalReport.ReportEmbeddedResource = "Consultorio.Relatorios.Atestado.rdlc";

            CarregarParametros(listaDeParametros);

            rvAtestado.RefreshReport();
        }

        private void CarregarParametros(List<string> listaDeParametros)
        {
            rvAtestado.LocalReport.SetParameters(new ReportParameter("atestoParaFim", listaDeParametros[0]));
            rvAtestado.LocalReport.SetParameters(new ReportParameter("inicioHora", listaDeParametros[1]));
            rvAtestado.LocalReport.SetParameters(new ReportParameter("fimHora", listaDeParametros[2]));
            rvAtestado.LocalReport.SetParameters(new ReportParameter("dataAtendimento", listaDeParametros[3]));
            rvAtestado.LocalReport.SetParameters(new ReportParameter("diaNumerico", listaDeParametros[4]));
            rvAtestado.LocalReport.SetParameters(new ReportParameter("diasExtenso", listaDeParametros[5]));
            rvAtestado.LocalReport.SetParameters(new ReportParameter("dia", listaDeParametros[6]));
            rvAtestado.LocalReport.SetParameters(new ReportParameter("cid", listaDeParametros[7]));
        }
    }
}
