using Consultorio.View.ManualDoUsuario;
using Consultorio.ViewModel.Relatorios;
using Microsoft.Reporting.WinForms;
using System.Windows;

namespace Consultorio.View.Relatorios
{
    /// <summary>
    /// Lógica interna para RelatorioReceitaMedica.xaml
    /// </summary>
    public partial class RelatorioReceitaMedicaView : Window
    {
        public RelatorioReceitaMedicaViewModel RelatorioReceitaMedicaViewModel { get; set; } = new RelatorioReceitaMedicaViewModel();
        public RelatorioReceitaMedicaView()
        {
            DataContext = RelatorioReceitaMedicaViewModel;
            InitializeComponent();
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtGerarAnotacoes_Click(object sender, RoutedEventArgs e)
        {
            RelatorioReceitaMedicaViewModel.SalvarLogAnotacoes(tbAnotacoes.Text);

            gdRelatorio.Visibility = Visibility.Visible;

            rvReceita.LocalReport.DataSources.Clear();

            rvReceita.LocalReport.ReportEmbeddedResource = "Consultorio.Relatorios.Receituario.rdlc";
            rvReceita.LocalReport.SetParameters(new ReportParameter("Anotacaos", tbAnotacoes.Text));
            rvReceita.LocalReport.SetParameters(new ReportParameter("Nome", RelatorioReceitaMedicaViewModel.AtorLogado.Nome));
            rvReceita.LocalReport.SetParameters(new ReportParameter("Crosp", RelatorioReceitaMedicaViewModel.AtorLogado.Crosp));

            rvReceita.RefreshReport();
        }

        private void BtAjuda_Click(object sender, RoutedEventArgs e)
        {
            var ajudaView = new Ajuda("RelatorioReceitaMedicaView.mp4");
            ajudaView.ShowDialog();
        }
    }
}