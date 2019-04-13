using System;
using System.Collections.Generic;
using System.Windows;
using Consultorio.Data;
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

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            ViewOpcoes opcoes = new ViewOpcoes();
            opcoes.Show();
            this.Close();
        }
        
        //chamada para alterar um produto
        private void BtSalvar_Click(object sender, RoutedEventArgs e)
        {
            // executa quando o salvar vem de uma alteração;
            if (tbId.Text != "")
            {
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
                InativarCampos();
            }
            else
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    Produto p = new Produto();
                    p.Nome = tbNome.Text;
                    p.Descricao = tbDescricao.Text;
                    p.Quantidade = int.Parse(tbQuantidade.Text);
                    p.Descricao = tbDescricao.Text;

                    if (tbValidade.Text != "")
                    {
                        p.Validade = DateTime.Parse(tbValidade.Text);
                    }

                    ctx.Produtos.Add(p);
                    ctx.SaveChanges();
                    RecarregarGrid();
                    LimparCampos();
                    InativarCampos();
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RecarregarGrid();
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

        private void BtCancelar_Click(object sender, RoutedEventArgs e)
        {
            InativarCampos();
            LimparCampos();
            BotoesAtivados(1);
            RecarregarGrid();
        }

        private void BtCadastrarNovo_Click(object sender, RoutedEventArgs e)
        {
            LimparCampos();
            AtivarCampos();
            BotoesAtivados(2);
            tbId.IsReadOnly = true;
            RecarregarGrid();
        }

        private void Buscar_Click(object sender, RoutedEventArgs e)
        {
            if (tbId.Text == "" && tbNome.Text == "")
            {
                InativarCampos();
                BotoesAtivados(3);
                btBuscar.IsEnabled = true;
                tbId.IsEnabled = true;
                tbNome.IsEnabled = true;
                tbId.IsReadOnly = false;
            }
            else
            {
                //verifica se o id é um int
                int.TryParse(tbId.Text, out int id);
                ProdutoViewModel.BuscarProdutos(id, tbNome.Text);

                dgProdutos.ItemsSource = ProdutoViewModel.BuscarProdutos(id, tbNome.Text);
                dgProdutos.Columns[5].Visibility = Visibility.Collapsed;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void RecarregarGrid()
        {
            dgProdutos.ItemsSource = ProdutoViewModel.ExibirProdutos();
            dgProdutos.Columns[5].Visibility = Visibility.Collapsed;
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

        private void InativarCampos()
        {
            tbDescricao.IsEnabled = false;
            btBuscar.IsEnabled = true;
            tbId.IsEnabled = true;
            tbId.IsReadOnly = false;
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
    }
}
