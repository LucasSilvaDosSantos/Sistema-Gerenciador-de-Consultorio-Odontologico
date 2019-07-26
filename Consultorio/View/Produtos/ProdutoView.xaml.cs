using System.Windows;
using System.Windows.Controls;
using Consultorio.ViewModel.Produtos;

namespace Consultorio.View.Produtos
{
    /// <summary>
    /// Lógica interna para Produto.xaml
    /// </summary>
    public partial class ProdutoView : Window
    {

        public ProdutosViewModel ProdutosViewModel { get; set; }
        public ProdutoView()
        {
            ProdutosViewModel = new ProdutosViewModel();
            DataContext = ProdutosViewModel;

            InitializeComponent();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            OpcoesView opcoesView = new OpcoesView();
            opcoesView.Show();
            this.Close();
        }

        private void DgProdutos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProdutosViewModel.DataGridSelect(dgProdutos.SelectedIndex);
        }

        private void TbNome_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbId.Text = null;
            ProdutosViewModel.BuscarNome(tbNome.Text);
        }

        private void TbId_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbNome.Text = "";
            ProdutosViewModel.BuscarId(tbId.Text);
        }

        private void BtCadastrarNovo_Click(object sender, RoutedEventArgs e)
        {
            CrudProdutoView CrudProdutoView = new CrudProdutoView();
            this.Hide();
            CrudProdutoView.ShowDialog();
            this.Visibility = Visibility.Visible;
            ProdutosViewModel.RecarregarGrid();
        }

        private void BtEditar_Click(object sender, RoutedEventArgs e)
        {
            int idProduto = ProdutosViewModel.EditarProduto();
            if (idProduto <= 0)
            {
                MessageBox.Show("Selecione um produto", "Aviso!");
                return;
            }
            this.Hide();
            CrudProdutoView crudProdutoView = new CrudProdutoView(idProduto);
            crudProdutoView.ShowDialog();
            this.Visibility = Visibility.Visible;
            ProdutosViewModel.RecarregarGrid();
            ProdutosViewModel.ResetarTela();
        }
    }
}
