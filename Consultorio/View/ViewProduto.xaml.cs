using System;
using System.Collections.Generic;
using System.Windows;
using Consultorio.Data;
using Consultorio.Model;
using Consultorio.ViewModel;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Controls;

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

        // volta a tela anterior
        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            ViewOpcoes opcoes = new ViewOpcoes();
            opcoes.Show();
            this.Close();
        }
        
        //chamada para alterar ou salvar um produto
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
                    produto.Validade = DateTime.ParseExact(tbValidade.Text, "dd/MM/yyyy", CultureInfo.CurrentCulture);
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
                BotoesAtivados(1);
            }
            // executa quando o salvar vem de um novo produto
            else if (tbNome.Text != "")
            {
                if (tbNome.Text != "" && tbQuantidade.Text != "")
                {
                    Produto p = new Produto();
                    p.Nome = tbNome.Text;
                    p.Descricao = tbDescricao.Text;
                    p.Quantidade = int.Parse(tbQuantidade.Text);
                    p.Descricao = tbDescricao.Text;

                    if (tbValidade.Text != "")
                    {
                        p.Validade = DateTime.ParseExact(tbValidade.Text, "dd/MM/yyyy", CultureInfo.CurrentCulture);
                    }

                    string confirmação = MessageBox.Show("Deseja salvar novo produto?", "Confirmação", MessageBoxButton.OKCancel).ToString();

                    if (confirmação == "OK")
                    {
                        ProdutoViewModel.SalvarProduto(p);
                    }
                    else
                    {
                        MessageBox.Show("Operação cancelada pelo usuário", "Nenhuma alteração realizada");
                    }

                    RecarregarGrid();
                    LimparCampos();
                    InativarCampos();
                    BotoesAtivados(1);
                }                  
                else
                {
                    ErroDeCampoEmBranco();
                }                                                
            }
            else{
                ErroDeCampoEmBranco();
            }
        }

        //Inicia a tabela de produtos ja cadastrados
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RecarregarGrid();
        }

        // seleciona um porduto da tabela 
        private void DgProdutos_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (dgProdutos.SelectedIndex >= 0)
            {
                LimparCampos();
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
                    /*var teste = c.Validade.ToString().Split(' ');                    
                    tbValidade.Text = teste[0];*/

                    // metodo mais simples para solucionar o problema de mostrar a hora no textBox
                    tbValidade.Text = string.Format("{0:dd/MM/yyyy}", c.Validade);
                }
                tbDescricao.Text = c.Descricao;
            }
            AtivarCampos();
            BotoesAtivados(2);
        }

        // cancela as opçoes selecionadas
        private void BtCancelar_Click(object sender, RoutedEventArgs e)
        {
            InativarCampos();
            LimparCampos();
            BotoesAtivados(1);
            RecarregarGrid();
        }

        // inicia um novo cadastro de produto
        private void BtCadastrarNovo_Click(object sender, RoutedEventArgs e)
        {
            LimparCampos();
            AtivarCampos();
            BotoesAtivados(2);
            tbId.IsReadOnly = true;
            RecarregarGrid();
        }

        // busca por um produto (id ou nome)
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

                dgProdutos.ItemsSource = ProdutoViewModel.BuscarProdutos(id, tbNome.Text);
                TratamentoDoGrid();
            }
            BotoesAtivados(1);
            btCancelar.IsEnabled = true;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        // Recarrega o grid e o atualiza
        private void RecarregarGrid()
        {
            dgProdutos.ItemsSource = ProdutoViewModel.ExibirProdutos();
            TratamentoDoGrid();
        }

        // limpa todos os campos que o usuario tem acesso de preencher
        private void LimparCampos()
        {
            tbId.Text = "";
            tbNome.Text = "";
            tbQuantidade.Text = "";
            tbValidade.Text = "";
            tbDescricao.Text = "";
            checkBoxValidade.IsChecked = false;
        }

        // Inativa todos os campos 
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

        //Ativa e desativa os campos de acordo com a opção de entrada 
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

        // Erro por campo faltando
        private void ErroDeCampoEmBranco()
        {
            MessageBox.Show("Campos obrigatórios não preenchidos", "Erro Informações Faltando");
        }

        // todas as partes para tratar o grid para eibição correta
        private void TratamentoDoGrid()
        {
            dgProdutos.Columns[5].Visibility = Visibility.Collapsed;
            (dgProdutos.Columns[4] as DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy";
        }

    }
}
