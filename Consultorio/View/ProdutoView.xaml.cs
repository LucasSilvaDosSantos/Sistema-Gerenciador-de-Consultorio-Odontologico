using System;
using System.Collections.Generic;
using System.Windows;
using Consultorio.Data;
using Consultorio.Model;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Controls;
using Consultorio.ViewModel;

namespace Consultorio.View
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
            OpcoesViewModel opcoesView = new OpcoesViewModel();
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
            CrudProdutoView.ShowDialog();
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
            CrudProdutoView crudProdutoView = new CrudProdutoView(idProduto);
            crudProdutoView.ShowDialog();
            ProdutosViewModel.RecarregarGrid();
            ProdutosViewModel.ResetarTela();
        }
    }
}
