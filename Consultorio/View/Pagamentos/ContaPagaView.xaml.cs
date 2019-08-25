using Consultorio.ViewModel.Pagamentos;
using System.Windows;

namespace Consultorio.View.Pagamentos
{
    /// <summary>
    /// Lógica interna para ContaPagaView.xaml
    /// </summary>
    public partial class ContaPagaView : Window
    {
        public ContaPagaViewModel ContaPagaViewModel{ get; set; }
        public ContaPagaView()
        {
            ContaPagaViewModel = new ContaPagaViewModel();
            DataContext = ContaPagaViewModel;
            InitializeComponent();
        }

        private void BtCancelar_Click(object sender, RoutedEventArgs e)
        {
            SairDaTela();
        }

        private void BtSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (!ContaPagaViewModel.TodosOsCamposValidos(out string camposInvalidos))
            {
                MessageBox.Show(camposInvalidos, "Aviso!");
            }
            else
            {
                string msg = ContaPagaViewModel.SalvarContaPaga();
                MessageBox.Show(msg, "Aviso!");
                SairDaTela();
            }
        }

        private void SairDaTela()
        {
            OpcoesView opcoesView = new OpcoesView();
            ConfiguracoesDeView.ConfigurarWindow(this, opcoesView);
            opcoesView.Show();
            this.Close();
        }
    }
}
