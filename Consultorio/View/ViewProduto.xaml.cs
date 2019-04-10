using System;
using System.Collections.Generic;
using System.Windows;
using Consultorio.Model;
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
            InativarCampos();
            BotoesAtivados(1);
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            ViewOpcoes opcoes = new ViewOpcoes();
            opcoes.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RecarregarGrid();
        }

        private void RecarregarGrid()
        {
            dgProdutos.ItemsSource = ProdutoViewModel.ExibirProdutos();
            dgProdutos.Columns[5].Visibility = Visibility.Collapsed;
        }

        //chamada para alterar um produto
        private void BtSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (tbId.Text != "") {
                Produto produto = new Produto
                {
                    Id = int.Parse(tbId.Text),
                    Nome = tbNome.Text,
                    Quantidade = int.Parse(tbQuantidade.Text),
                    Descricao = tbDescricao.Text
                };
                if (tbValidade.Text != "")
                {
                    produto.Validade = DateTime.Parse(tbValidade.Text);
                }
                string confirmação = MessageBox.Show("Deseja salvar alteraçoes?", "Confirmação", MessageBoxButton.OKCancel).ToString();

                if (confirmação == "OK")
                {
                    var salvo = ProdutoViewModel.AlterarProduto(produto);
                }
                else
                {
                    MessageBox.Show("Operação cancelada pelo usuário", "Nenhuma alteração realizada");
                }
                RecarregarGrid();
                LimparCampos();
            }
            else
            {   
                MessageBox.Show("Nenhum produto selecionado", "Erro");
            }
        }

        private void DgProdutos_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (dgProdutos.SelectedIndex >= 0)
            {
                Produto c = (Produto)dgProdutos.Items[dgProdutos.SelectedIndex];
                tbId.Text = c.Id.ToString();
                tbNome.Text = c.Nome;
                tbQuantidade.Text = c.Quantidade.ToString();
                if (c.Validade == null)
                {
                    checkBoxValidade.IsChecked = true;
                }
                else
                {
                    tbValidade.Text = c.Validade.ToString();
                }
                tbDescricao.Text = c.Descricao;
            }
            AtivarCampos();
            BotoesAtivados(2);
        }

        private void LimparCampos()
        {
            tbId.Text = "";
            tbNome.Text = "";
            tbQuantidade.Text = "";
            tbValidade.Text = "";
            tbDescricao.Text = "";
            checkBoxValidade.IsChecked = false;
        }

        private void BtCancelar_Click(object sender, RoutedEventArgs e)
        {
            InativarCampos();
            LimparCampos();
            BotoesAtivados(1);
        }

        // função para inativar todos os campos 
        private void InativarCampos()
        {
            tbDescricao.IsEnabled = false;
            tbId.IsEnabled = false;
            tbNome.IsEnabled = false;
            tbQuantidade.IsEnabled = false;
            tbValidade.IsEnabled = false;
            checkBoxValidade.IsEnabled = false;
        }

        // função para ativar todos os campos 
        private void AtivarCampos()
        {
            tbDescricao.IsEnabled = true;
            tbId.IsEnabled = true;
            tbNome.IsEnabled = true;
            tbQuantidade.IsEnabled = true;
            tbValidade.IsEnabled = true;
            checkBoxValidade.IsEnabled = true;
        }

        private void BtCadastrarNovo_Click(object sender, RoutedEventArgs e)
        {
            LimparCampos();
            AtivarCampos();
            BotoesAtivados(2);
        }

        private void BotoesAtivados(int op)
        {
            if (op == 1)
            {
                btCancelar.IsEnabled = false;
                btSalvar.IsEnabled = false;
                btCadastrarNovo.IsEnabled = true;
                btBuscar.IsEnabled = true;
            }
            else if (op == 2){
                btCancelar.IsEnabled = true;
                btSalvar.IsEnabled = true;
                btCadastrarNovo.IsEnabled = false;
                btBuscar.IsEnabled = false;
            }
            else if (op == 3)
            {
                btCancelar.IsEnabled = true;
                btSalvar.IsEnabled = false;
                btCadastrarNovo.IsEnabled = false;
            }
            
        }

        private void Buscar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
