﻿using System.Windows;
using System.Windows.Controls;
using Consultorio.View.ManualDoUsuario;
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

            tbBuscaPorQtd.Text = "5";
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
            tbBuscaPorQtd.Text = null;
            ProdutosViewModel.BuscarNome(tbNome.Text);
        }

        private void TbId_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbNome.Text = "";
            tbBuscaPorQtd.Text = null;
            ProdutosViewModel.BuscarId(tbId.Text);
        }

        private void TbBuscaPorQtd_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbNome.Text = "";
            tbId.Text = null;
            ProdutosViewModel.BuscaQtdEstoque(tbBuscaPorQtd.Text);
        }

        private void BtCadastrarNovo_Click(object sender, RoutedEventArgs e)
        {
            CrudProdutoView CrudProdutoView = new CrudProdutoView();
            this.Hide();
            ConfiguracoesDeView.ConfigurarWindow(this, CrudProdutoView);
            CrudProdutoView.ShowDialog();
            ConfiguracoesDeView.ConfigurarWindow(CrudProdutoView, this);
            this.Visibility = Visibility.Visible;

            ProdutosViewModel.BuscaQtdEstoque(tbBuscaPorQtd.Text);//ProdutosViewModel.RecarregarGrid();
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
                ProdutosViewModel.BuscaQtdEstoque(tbBuscaPorQtd.Text);//ProdutosViewModel.RecarregarGrid();
                //ProdutosViewModel.ResetarTela();
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
                ProdutosViewModel.BuscaQtdEstoque(tbBuscaPorQtd.Text);//.RecarregarGrid();
                //ProdutosViewModel.ResetarTela();
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
                ProdutosViewModel.BuscaQtdEstoque(tbBuscaPorQtd.Text);//ProdutosViewModel.RecarregarGrid();
                //ProdutosViewModel.ResetarTela();
            }
        }

        private void BtAjuda_Click(object sender, RoutedEventArgs e)
        {
            var ajudaView = new Ajuda("ProdutoView.mp4");
            ajudaView.ShowDialog();
        }
    }
}
