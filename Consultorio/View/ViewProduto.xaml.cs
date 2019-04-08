using Consultorio.Data;
using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using Consultorio.ViewModel;
using System.Linq;
using System.Collections.ObjectModel;

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
