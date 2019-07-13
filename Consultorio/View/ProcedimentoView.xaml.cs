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
using Consultorio.ViewModel;

namespace Consultorio.View
{
    /// <summary>
    /// Lógica interna para Procedimento.xaml
    /// </summary>
    public partial class ProcedimentoView : Window
    {
        public bool FlagPermitirPesquisa { get; set; }

        public ProcedimentoView()
        {
            InitializeComponent();
            AtivarBotoes(1);
            AtivarCampos(1);
            FlagPermitirPesquisa = true;
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarDataGridProcedimentos();         
        }

        private void DgListaProcedimentos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SelecaoDeItemDataGrid();
            FlagPermitirPesquisa = false;
        }

        private void DgListaProcedimentos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelecaoDeItemDataGrid();
            FlagPermitirPesquisa = false;
        }

        private void BtCadastrarNovo_Click(object sender, RoutedEventArgs e)
        {
            tbPreco.Text = string.Format("{0:f2}", 0);
            tbId.Text = "";
            AtivarBotoes(4);
            AtivarCampos(2);
            tbId.IsEnabled = false;
            FlagPermitirPesquisa = false;
        }

        private void BtSalvar_Click(object sender, RoutedEventArgs e)
        {
            FlagPermitirPesquisa = false;
            var camposObrigatorios = ValidarCamposObrigatorios();
            if (camposObrigatorios.Count != 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (string i in camposObrigatorios)
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
                    msg = ProcedimentoData.CadastroDeNovoProcedimento(PegarDadosDosCampos());
                    MessageBox.Show(msg);
                    ResetarTela();                   
                }
                else
                {
                    Procedimento procedimento = PegarDadosDosCampos();
                    procedimento.Id = int.Parse(tbId.Text);
                    msg = ProcedimentoData.AlterarProcedimento(procedimento);
                    MessageBox.Show(msg);
                    ResetarTela();                                   
                }
            }             
        }

        private void BtCancelar_Click(object sender, RoutedEventArgs e)
        {
            ResetarTela();
            FlagPermitirPesquisa = true;
        }

        private void TbNome_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FlagPermitirPesquisa)
            {
                tbId.Text = "";
                Buscar();
            }       
        }

        private void TbId_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FlagPermitirPesquisa)
            {
                tbNome.Text = "";
                Buscar();
            }      
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void Buscar()
        {
            if (tbId.Text == "" && tbNome.Text == "")
            {
                tbId.IsEnabled = true;
                tbId.IsReadOnly = false;
                tbNome.IsEnabled = true;
                CarregarDataGridProcedimentos();
            }
            else
            {
                //verifica se o id é um int
                int.TryParse(tbId.Text, out int id);

                dgListaProcedimentos.ItemsSource = ProcedimentoData.BuscarProcedimento(id, tbNome.Text);
            }
            AtivarBotoes(2);
        }

        private void ResetarTela()
        {
            LimparCampos();
            AtivarBotoes(1);
            AtivarCampos(1);
            CarregarDataGridProcedimentos();
            FlagPermitirPesquisa = true;
        }
            
        private void SelecaoDeItemDataGrid()
        {
            if (dgListaProcedimentos.SelectedIndex >= 0)
            {
                LimparCampos();
                Procedimento p = (Procedimento)dgListaProcedimentos.Items[dgListaProcedimentos.SelectedIndex];
                tbId.Text = p.Id.ToString();
                tbNome.Text = p.Nome;
                tbPreco.Text = string.Format("{0:f2}", p.Preco);
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
            double.TryParse(tbPreco.Text, out double precoDouble);
            procedimento.Preco = precoDouble;
            return procedimento;
        }

        private void AtivarBotoes(int op)
        {
            if (op == 1)
            {
                btCancelar.IsEnabled = false;
                btSalvar.IsEnabled = false;
                btCadastrarNovo.IsEnabled = true;
                btCancelar.IsEnabled = false;
            }
            else if (op == 2)
            {
                btCancelar.IsEnabled = true;
                btCadastrarNovo.IsEnabled = false;
            }
            else if (op == 3)
            {
                btCadastrarNovo.IsEnabled = false;
                btSalvar.IsEnabled = true;
                btCancelar.IsEnabled = true;
            }
            else if (op == 4)
            {
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
            bool tbPrecoDouble;
            var precoSplit = tbPreco.Text.Split(' ');
            double valor;
            if (precoSplit.Count() == 1)
            {
                tbPrecoDouble = double.TryParse(precoSplit[0], out double b);
                valor = b;
            }
            else
            {
                tbPrecoDouble = double.TryParse(precoSplit[1], out double b);
                valor = b;
            }
            if ((tbPreco.Text == "") || (tbPrecoDouble == false) || valor < 0)
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
