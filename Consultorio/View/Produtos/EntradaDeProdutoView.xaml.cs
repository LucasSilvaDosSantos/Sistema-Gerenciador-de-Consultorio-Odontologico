using Consultorio.ViewModel.Produtos;
using System.Windows;

namespace Consultorio.View.Produtos
{
    /// <summary>
    /// Lógica interna para EntradaESaidaDeProdutoView.xaml
    /// </summary>
    public partial class EntradaDeProdutoView : Window
    {
        public EntradaDeProdutoViewModel EntradaDeProdutoViewModel { get; set; }
        public EntradaDeProdutoView(int id)
        {
            EntradaDeProdutoViewModel = new EntradaDeProdutoViewModel(id);
            DataContext = EntradaDeProdutoViewModel;
            InitializeComponent();
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtSalvar_Click(object sender, RoutedEventArgs e)
        {
            string msg = EntradaDeProdutoViewModel.SalvarCompra();
            MessageBox.Show(msg, "Aviso!");
            this.Close();
        }
    }
}
