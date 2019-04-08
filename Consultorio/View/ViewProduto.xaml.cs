using System.Windows;
using Consultorio.ViewModel;

namespace Consultorio.View
{
    /// <summary>
    /// Lógica interna para Produto.xaml
    /// </summary>
    public partial class ViewProduto : Window
    {
        public ViewProduto()
        {
            InitializeComponent();
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            ViewOpcoes opcoes = new ViewOpcoes();
            opcoes.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgProdutos.ItemsSource = ProdutoViewModel.ExibirProdutos();
            dgProdutos.Columns[5].Visibility = Visibility.Collapsed;
        }

        private void BtSalvar_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
