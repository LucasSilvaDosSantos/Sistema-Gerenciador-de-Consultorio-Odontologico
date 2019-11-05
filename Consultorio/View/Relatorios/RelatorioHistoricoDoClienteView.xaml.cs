using Consultorio.View.Clientes;
using Consultorio.View.ManualDoUsuario;
using Consultorio.ViewModel.Relatorios;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows;

namespace Consultorio.View.Relatorios
{
    /// <summary>
    /// Lógica interna para RelatorioHistoricoDoClienteView.xaml
    /// </summary>
    public partial class RelatorioHistoricoDoClienteView : Window
    {
        public RelatorioHistoricoDoClienteViewModel RelatorioHistoricoDoClienteViewModel { get; set; } = new RelatorioHistoricoDoClienteViewModel();

        public RelatorioHistoricoDoClienteView()
        {
            DataContext = RelatorioHistoricoDoClienteViewModel;
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
                if (tbCliente != null && tbCliente.Text != "")
                {
                    DataTable dataTableCliente = RelatorioHistoricoDoClienteViewModel.CarregarDataCliente();
                    DataTable dataTableConsultas = RelatorioHistoricoDoClienteViewModel.CarregarConsultas((DateTime)dtInicio.SelectedDate, (DateTime)dtFim.SelectedDate);
                    DataTable dataTablePagamentos = RelatorioHistoricoDoClienteViewModel.CarregarPagamentos((DateTime)dtInicio.SelectedDate, (DateTime)dtFim.SelectedDate);

                    ReportDataSource dataSourceCliente = new ReportDataSource("Cliente", dataTableCliente);
                    ReportDataSource dataSourceProdutosConsultas = new ReportDataSource("Consultas", dataTableConsultas);
                    ReportDataSource dataSourcePagamentos = new ReportDataSource("Pagamentos", dataTablePagamentos);

                    rvCliente.LocalReport.DataSources.Clear();
                    rvCliente.LocalReport.DataSources.Add(dataSourceCliente);
                    rvCliente.LocalReport.DataSources.Add(dataSourceProdutosConsultas);
                    rvCliente.LocalReport.DataSources.Add(dataSourcePagamentos);

                    rvCliente.LocalReport.ReportEmbeddedResource = "Consultorio.Relatorios.Cliente.rdlc";

                    TratarECarregarDatas();
                    CarregarParametros();
                    rvCliente.RefreshReport();
                }
                else
                {
                    MessageBox.Show("Um cliente deve ser selecionado!", "Aviso!");
                }  
            }
            else
            {
                MessageBox.Show("Os campos de data devem ser preenchidos!", "Aviso!");
            }
        }

        private void TratarECarregarDatas()
        {
            var dataInicio = (DateTime)dtInicio.SelectedDate;
            //var inicioString = dataInicio.ToShortDateString();  

            var dataFim = (DateTime)dtFim.SelectedDate;
            //var fimString = dataFim.ToShortDateString();

            rvCliente.LocalReport.SetParameters(new ReportParameter("inicio", dataInicio.ToString()));
            rvCliente.LocalReport.SetParameters(new ReportParameter("fim", dataFim.ToString()));
        }

        private void CarregarParametros()
        {
            rvCliente.LocalReport.SetParameters(new ReportParameter("usuario", RelatorioHistoricoDoClienteViewModel.AtorLogado.Nome));
            rvCliente.LocalReport.SetParameters(new ReportParameter("somaConsultaRealizada", RelatorioHistoricoDoClienteViewModel.SomaConsultaRealizada.ToString()));
        }

        private void TbCliente_GotFocus(object sender, RoutedEventArgs e)
        {
            SelecionarCliente();
        }

        private void TbCliente_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SelecionarCliente();
        }

        private void SelecionarCliente()
        {
            this.Hide();
            SelecaoDeClienteView selecaoDeClienteView = new SelecaoDeClienteView();
            ConfiguracoesDeView.ConfigurarWindow(this, selecaoDeClienteView);
            selecaoDeClienteView.ShowDialog();

            RelatorioHistoricoDoClienteViewModel.Cliente = selecaoDeClienteView.SelecaoDeClienteViewModel.ClienteSelecionado;           
            ConfiguracoesDeView.ConfigurarWindow(selecaoDeClienteView, this);
            this.Visibility = Visibility.Visible;
        }

        private void BtAjuda_Click(object sender, RoutedEventArgs e)
        {
            var ajudaView = new Ajuda("RelatorioHistoricoDoClienteView.mp4");
            ajudaView.ShowDialog();
        }
    }
}