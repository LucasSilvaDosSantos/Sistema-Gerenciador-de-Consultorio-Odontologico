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
            ConfiguracoesDeView.ConfigurarWindow(this, opcoesView);
            opcoesView.Show();
            this.Close();
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
            ConfiguracoesDeView.ConfigurarWindow(this, CrudProdutoView);
            CrudProdutoView.ShowDialog();
            ConfiguracoesDeView.ConfigurarWindow(CrudProdutoView, this);
            this.Visibility = Visibility.Visible;
            ProdutosViewModel.RecarregarGrid();
        }

        private void BtEditar_Click(object sender, RoutedEventArgs e)
        {
            int idProduto = ProdutosViewModel.RetornaIdProdutoSelecionado();
            if (idProduto <= 0)
            {
                MessageBox.Show("Selecione um produto", "Aviso!");
                return;
            }
            else
            {
                this.Hide();
                CrudProdutoView crudProdutoView = new CrudProdutoView(idProduto);
                ConfiguracoesDeView.ConfigurarWindow(this, crudProdutoView);
                crudProdutoView.ShowDialog();
                ConfiguracoesDeView.ConfigurarWindow(crudProdutoView, this);
                this.Visibility = Visibility.Visible;
                ProdutosViewModel.RecarregarGrid();
                ProdutosViewModel.ResetarTela();
            }            
        }

        private void BtCompra_Click(object sender, RoutedEventArgs e)
        {
            int idProduto = ProdutosViewModel.RetornaIdProdutoSelecionado();
            if (idProduto <= 0)
            {
                MessageBox.Show("Selecione um produto", "Aviso!");
                return;
            }
            else
            {
                this.Hide();

                EntradaDeProdutoView entradaDeProdutoView = new EntradaDeProdutoView(idProduto);
                ConfiguracoesDeView.ConfigurarWindow(this, entradaDeProdutoView);
                entradaDeProdutoView.ShowDialog();
                ConfiguracoesDeView.ConfigurarWindow(entradaDeProdutoView, this);
                this.Visibility = Visibility.Visible;
                ProdutosViewModel.RecarregarGrid();
                ProdutosViewModel.ResetarTela();
            }
        }

        private void BtRetirarProduto_Click(object sender, RoutedEventArgs e)
        {
            int idProduto = ProdutosViewModel.RetornaIdProdutoSelecionado();
            if (idProduto <= 0)
            {
                MessageBox.Show("Selecione um produto", "Aviso!");
                return;
            }
            else
            {
                this.Hide();

                BaixaDeProdutoView baixaDeProdutoView = new BaixaDeProdutoView(idProduto);
                ConfiguracoesDeView.ConfigurarWindow(this, baixaDeProdutoView);
                baixaDeProdutoView.ShowDialog();
                ConfiguracoesDeView.ConfigurarWindow(baixaDeProdutoView, this);
                this.Visibility = Visibility.Visible;
                ProdutosViewModel.RecarregarGrid();
                ProdutosViewModel.ResetarTela();
            }
        }
    }
}
