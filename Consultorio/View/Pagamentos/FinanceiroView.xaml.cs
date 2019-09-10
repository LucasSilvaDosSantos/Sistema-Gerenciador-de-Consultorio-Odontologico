using Consultorio.ViewModel.Pagamentos;
using System.Windows;

namespace Consultorio.View.Pagamentos
{
    /// <summary>
    /// Lógica interna para ListaDeContasPagasView.xaml
    /// </summary>
    public partial class FinanceiroView : Window
    {
        public FinanceiroViewModel FinanceiroViewModel { get; set; }
        public FinanceiroView()
        {
            FinanceiroViewModel = new FinanceiroViewModel();
            DataContext = FinanceiroViewModel;
            InitializeComponent();
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
