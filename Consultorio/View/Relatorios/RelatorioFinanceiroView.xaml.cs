using Consultorio.View.ManualDoUsuario;
using Consultorio.ViewModel.Relatorios;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows;

namespace Consultorio.View.Relatorios
{
    /// <summary>
    /// Lógica interna para RelatorioFinanceiroView.xaml
    /// </summary>
    public partial class RelatorioFinanceiroView : Window
    {
        public RelatorioFinanceiroViewModel RelatorioFinanceiroViewModel { get; set; } = new RelatorioFinanceiroViewModel();
        public RelatorioFinanceiroView()
        {
            InitializeComponent();
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            RelatoriosView relatoriosView = new RelatoriosView();
            ConfiguracoesDeView.ConfigurarWindow(this, relatoriosView);
            relatoriosView.Show();
            this.Close();           
        }

        private void BtGerarRelatorio_Click(object sender, RoutedEventArgs e)
        {
            if (dtInicio.SelectedDate != null && dtFim.SelectedDate != null && dtInicio.SelectedDate <= dtFim.SelectedDate)
            {

                DataTable dataTableContasPagas = RelatorioFinanceiroViewModel.CarregaDataTableContasPagas((DateTime)dtInicio.SelectedDate, (DateTime)dtFim.SelectedDate);
                DataTable dataTableProdutosComprados = RelatorioFinanceiroViewModel.CarregaDataTableProdutosComprados((DateTime)dtInicio.SelectedDate, (DateTime)dtFim.SelectedDate);
                DataTable dataTablePagamentosRecebidos = RelatorioFinanceiroViewModel.CarregaDataTablePagamentosRecebidos((DateTime)dtInicio.SelectedDate, (DateTime)dtFim.SelectedDate);

                ReportDataSource dataSourceContasPagas = new ReportDataSource("ContasPagas", dataTableContasPagas);
                ReportDataSource dataSourceProdutosComprados = new ReportDataSource("ProdutosComprados", dataTableProdutosComprados);
                ReportDataSource dataSourcePagamentosRecebidos = new ReportDataSource("PagamentosRecebidos", dataTablePagamentosRecebidos);

                rvFinanceiro.LocalReport.DataSources.Clear();
                rvFinanceiro.LocalReport.DataSources.Add(dataSourceContasPagas);
                rvFinanceiro.LocalReport.DataSources.Add(dataSourceProdutosComprados);
                rvFinanceiro.LocalReport.DataSources.Add(dataSourcePagamentosRecebidos);

                rvFinanceiro.LocalReport.ReportEmbeddedResource = "Consultorio.Relatorios.Financeiro.rdlc";

                CarregarParametros();
                TratarECarregarDatas();

                rvFinanceiro.RefreshReport();
            }
            else
            {
                MessageBox.Show("Os campos de data devem ser preenchidos!", "Aviso!");
            }
        }

        private void TratarECarregarDatas()
        {
            var dataInicio = (DateTime)dtInicio.SelectedDate;
            var inicioString = dataInicio.ToShortDateString();

            var dataFim = (DateTime)dtFim.SelectedDate;
            var fimString = dataFim.ToShortDateString();

            rvFinanceiro.LocalReport.SetParameters(new ReportParameter("inicio", inicioString));
            rvFinanceiro.LocalReport.SetParameters(new ReportParameter("fim", fimString));
        }

        private void CarregarParametros()
        {
            rvFinanceiro.LocalReport.SetParameters(new ReportParameter("totalGastosComProdutos", RelatorioFinanceiroViewModel.TotalGastosComProdutos.ToString()));

            rvFinanceiro.LocalReport.SetParameters(new ReportParameter("usuario", RelatorioFinanceiroViewModel.AtorLogado.Nome));
        }

        private void BtAjuda_Click(object sender, RoutedEventArgs e)
        {
            var ajudaView = new Ajuda("RelatorioFinanceiroView.mp4");
            ajudaView.ShowDialog();
        }
    }
}
