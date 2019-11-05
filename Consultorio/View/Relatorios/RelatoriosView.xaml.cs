using Consultorio.View.ManualDoUsuario;
using Consultorio.ViewModel.Relatorios;
using System.Windows;

namespace Consultorio.View.Relatorios
{
    /// <summary>
    /// Lógica interna para RelatoriosView.xaml
    /// </summary>
    public partial class RelatoriosView : Window
    {
        public RelatoriosViewModel RelatoriosViewModel{ get; set; }
        public RelatoriosView()
        {
            RelatoriosViewModel = new RelatoriosViewModel();
            DataContext = RelatoriosViewModel;
            InitializeComponent();
        }

        private void BtConsultasPorPeriodo_Click(object sender, RoutedEventArgs e)
        {
            RelatorioConsultaPeriodoView relatorioConsultaPeriodo = new RelatorioConsultaPeriodoView();
            ConfiguracoesDeView.ConfigurarWindow(this, relatorioConsultaPeriodo);
            relatorioConsultaPeriodo.Show();
            this.Close();
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            OpcoesView opcoesView = new OpcoesView();
            ConfiguracoesDeView.ConfigurarWindow(this, opcoesView);
            opcoesView.Show();
            this.Close();
        }

        private void BtFinanceiro_Click(object sender, RoutedEventArgs e)
        {
            RelatorioFinanceiroView relatorioFinanceiroView = new RelatorioFinanceiroView();
            ConfiguracoesDeView.ConfigurarWindow(this, relatorioFinanceiroView);
            relatorioFinanceiroView.Show();
            this.Close();
        }

        private void BtCliente_Click(object sender, RoutedEventArgs e)
        {
            RelatorioHistoricoDoClienteView relatorioHistoricoDoClienteView= new RelatorioHistoricoDoClienteView();
            ConfiguracoesDeView.ConfigurarWindow(this, relatorioHistoricoDoClienteView);
            relatorioHistoricoDoClienteView.Show();
            this.Close();
        }

        private void BtAjuda_Click(object sender, RoutedEventArgs e)
        {
            var ajudaView = new Ajuda("RelatoriosView.mp4");
            ajudaView.ShowDialog();
        }
    }
}
