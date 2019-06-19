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
using System.Globalization;

namespace Consultorio.View
{
    /// <summary>
    /// Lógica interna para Procedimento.xaml
    /// </summary>
    public partial class ProcedimentoView : Window
    {
        public ProcedimentoView()
        {
            InitializeComponent();
            AtivarBotoes(1);
            AtivarCampos(1);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            OpcoesView opcoes = new OpcoesView();
            opcoes.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarDataGridProcedimentos();         
        }

        private void DgListaProcedimentos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SelecaoDeItemDataGrid();
        }

        private void DgListaProcedimentos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelecaoDeItemDataGrid();
        }

        private void Buscar_Click(object sender, RoutedEventArgs e)
        {
            if (tbId.Text == "" && tbNome.Text == "")
            {
                btBuscar.IsEnabled = true;

                tbId.IsEnabled = true;
                tbId.IsReadOnly = false;
                tbNome.IsEnabled = true;
            }
            else
            {
                //verifica se o id é um int
                int.TryParse(tbId.Text, out int id);

                dgListaProcedimentos.ItemsSource = ProcedimentoData.BuscarProcedimento(id, tbNome.Text);
            }
            AtivarBotoes(2);
        }

        private void BtCadastrarNovo_Click(object sender, RoutedEventArgs e)
        {
            tbPreco.Text = string.Format("{0:c}", 0);
            tbId.Text = "";
            AtivarBotoes(4);
            AtivarCampos(2);
            tbId.IsEnabled = false;
        }

        private void BtSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarCamposObrigatorios().Count != 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (string i in ValidarCamposObrigatorios())
                {
                    sb.Append($"{i}, ");
                }
                MessageBox.Show(sb.ToString(), "Campos Obrigatorios não preenchidos");
                return;
            }
            else
            {
                string msg;
                if (tbId.Text == "")
                {
                    string confirmacao = MessageBox.Show("Deseja salvar novo procedimento?", "Confirmação", MessageBoxButton.OKCancel).ToString();
                    if (confirmacao.Equals("OK"))
                    {
                        msg = ProcedimentoData.CadastroDeNovoProcedimento(PegarDadosDosCampos());
                        MessageBox.Show(msg);
                        ResetarTela();
                    }
                    else
                    {
                        MessageBox.Show("Operação cancelada pelo usuário", "Nenhuma alteração realizada");
                    }
                }
                else
                {
                    string confirmacao = MessageBox.Show("Deseja alterar procedimento?", "Confirmação", MessageBoxButton.OKCancel).ToString();
                    if (confirmacao.Equals("OK"))
                    {
                        Procedimento procedimento = PegarDadosDosCampos();
                        procedimento.Id = int.Parse(tbId.Text);
                        msg = ProcedimentoData.AlterarProcedimento(procedimento);
                        MessageBox.Show(msg);
                        ResetarTela();
                    }
                    else
                    {
                        MessageBox.Show("Operação cancelada pelo usuário", "Nenhuma alteração realizada");
                    }                   
                }
            }          
        }

        private void BtCancelar_Click(object sender, RoutedEventArgs e)
        {
            ResetarTela();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void ResetarTela()
        {
            LimparCampos();
            AtivarBotoes(1);
            AtivarCampos(1);
            CarregarDataGridProcedimentos();
        }
            
        private void SelecaoDeItemDataGrid()
        {
            if (dgListaProcedimentos.SelectedIndex >= 0)
            {
                LimparCampos();
                Procedimento p = (Procedimento)dgListaProcedimentos.Items[dgListaProcedimentos.SelectedIndex];
                tbId.Text = p.Id.ToString();
                tbNome.Text = p.Nome;
                tbPreco.Text = string.Format("{0:c}", p.Preco);
                tbObs.Text = p.Descricao;

                AtivarBotoes(3);
                AtivarCampos(2);

                //ainda nao implementado
                //CarregarDataGridProdutosDoProcedimento();
            }
        }

        private void CarregarDataGridProcedimentos()
        {
            dgListaProcedimentos.ItemsSource = ProcedimentoData.ListarTodosProcedimentos();
        }


        private void LimparCampos()
        {
            tbId.Text = "";
            tbNome.Text = "";
            tbPreco.Text = "";
            tbObs.Text = "";
        }

        private Procedimento PegarDadosDosCampos()
        {
            Procedimento procedimento = new Procedimento();
            procedimento.Nome = tbNome.Text;
            procedimento.Preco = double.Parse(tbPreco.Text);
            return procedimento;
        }

        private void AtivarBotoes(int op)
        {
            if (op == 1)
            {
                btCancelar.IsEnabled = false;
                btSalvar.IsEnabled = false;
                btCadastrarNovo.IsEnabled = true;
                btBuscar.IsEnabled = true;
                btCancelar.IsEnabled = false;
            }
            else if (op == 2)
            {
                btCancelar.IsEnabled = true;
                btCadastrarNovo.IsEnabled = false;
            }
            else if (op == 3)
            {
                btBuscar.IsEnabled = false;
                btCadastrarNovo.IsEnabled = false;
                btSalvar.IsEnabled = true;
                btCancelar.IsEnabled = true;
            }
            else if (op == 4)
            {
                btBuscar.IsEnabled = false;
                btCadastrarNovo.IsEnabled = false;
                btSalvar.IsEnabled = true;
                btCancelar.IsEnabled = true;
            }
        }

        private void AtivarCampos(int op)
        {
            if (op == 1)
            {
                tbPreco.IsEnabled = false;
                tbObs.IsEnabled = false;
                tbId.IsEnabled = true;
                tbId.IsReadOnly = false;
            }
            else if (op == 2)
            {
                tbId.IsEnabled = true;
                tbId.IsReadOnly = true;
                tbPreco.IsEnabled = true;
                tbObs.IsEnabled = true;
            }
        }

        private List<string> ValidarCamposObrigatorios()
        {
            List<string> lista = new List<string>();
            if (tbNome.Text == "")
            {
                lista.Add("Nome");
            }         
            if (tbPreco.Text == "")
            {
                lista.Add("Preço");
            }
            string teste = tbId.Text;

            if (teste.Contains(","))
            {
                lista.Add("Formatação de preço incorreta");
            }

            double.TryParse(tbPreco.Text, out double n);
            if (n < 0)
            {
                lista.Add("Preço");
            }
            return lista;
        }
    }
}
