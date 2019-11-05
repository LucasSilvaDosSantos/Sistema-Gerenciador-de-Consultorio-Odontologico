using Consultorio.View.Clientes;
using Consultorio.View.ManualDoUsuario;
using Consultorio.ViewModel.Consultas;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Consultorio.View.Consultas
{
    /// <summary>
    /// Lógica interna para CrudConsultasView.xaml
    /// </summary>
    public partial class CrudConsultasView : Window
    {
        public CrudConsultasViewModel CrudConsultasViewModel { get; set; }

        public CrudConsultasView(int idConsulta)
        {
            CrudConsultasViewModel = new CrudConsultasViewModel(idConsulta, out bool procedimentoDaListaDeOrcamento, out string procedimentoSelecionadoNome);
            DataContext = CrudConsultasViewModel;

            InitializeComponent();

            if (procedimentoDaListaDeOrcamento == true)
            {
                rbTodosProcedimentos.IsChecked = false;
                rbProcedimentosOrcamento.IsChecked = true;
            }
            else
            {
                rbTodosProcedimentos.IsChecked = true;
                rbProcedimentosOrcamento.IsChecked = false;
            }

            comboBoxProcedimento.SelectedItem = CrudConsultasViewModel.ProcedimentoSelecionadoCarregar(procedimentoSelecionadoNome);
        }

        public CrudConsultasView()
        {
            CrudConsultasViewModel = new CrudConsultasViewModel();
            DataContext = CrudConsultasViewModel;

            InitializeComponent();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        private void RbTodosProcedimentos_Checked(object sender, RoutedEventArgs e)
        {
            CarregarProcedimentos();
            //CrudConsultasViewModel.AlterarListaProdutosOrcamento(false);
        }

        private void RbProcedimentosOrcamento_Checked(object sender, RoutedEventArgs e)
        {
            CarregarProcedimentos();
            //CrudConsultasViewModel.AlterarListaProdutosOrcamento(true);
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            CrudConsultasViewModel.Calendar_SelectedDatesChanged(Convert.ToDateTime(cCalendario.SelectedDate));           
        }

        private void BtSalvar_Click(object sender, RoutedEventArgs e)
        {
         
            string campos = CrudConsultasViewModel.CamposObrigatoriosPreenchidos();
            if (campos == "")
            {
                string msg = CrudConsultasViewModel.SalvarClick();
                MessageBox.Show(msg, "Aviso!");

                ConsultasView consultasView = new ConsultasView();
                ConfiguracoesDeView.ConfigurarWindow(this, consultasView);
                consultasView.Show();
                this.Close();
            }
            else if (campos == "Já existe uma consulta neste horário")
            {
                MessageBox.Show(campos, "Aviso! Horário inválido");
            }
            else
            {
                MessageBox.Show(campos, "Aviso! Campos obrigatórios não preenchidos ou inválidos");
            }
                      
        }

        private void TbCliente_GotFocus(object sender, RoutedEventArgs e)
        {
            SelecionarCliente();
        }

        private void TbCliente_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SelecionarCliente();
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            ConsultasView consultasView = new ConsultasView();
            ConfiguracoesDeView.ConfigurarWindow(this, consultasView);
            consultasView.Show();
            this.Close();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void CarregarProcedimentos()
        {
            if (rbProcedimentosOrcamento != null)
                CrudConsultasViewModel.AlterarListaProcedimentos((bool)rbProcedimentosOrcamento.IsChecked);
            else
                CrudConsultasViewModel.AlterarListaProcedimentos(false);
        }

        private void SelecionarCliente()
        {
            this.Hide();
            SelecaoDeClienteView selecaoDeClienteView = new SelecaoDeClienteView();
            ConfiguracoesDeView.ConfigurarWindow(this, selecaoDeClienteView);
            selecaoDeClienteView.ShowDialog();

            CrudConsultasViewModel.Consulta.Cliente = selecaoDeClienteView.SelecaoDeClienteViewModel.ClienteSelecionado;
            CarregarProcedimentos();
            CrudConsultasViewModel.NotificarConsulta();
            CrudConsultasViewModel.ProcedimentosParaAlterarCliente();
            ConfiguracoesDeView.ConfigurarWindow(selecaoDeClienteView, this);
            this.Visibility = Visibility.Visible;
        }

        private void Comboboxprocedimento_selectionchanged(object sender, SelectionChangedEventArgs e)
        {
            if (rbProcedimentosOrcamento != null)
                CrudConsultasViewModel.CalcularValorDaConsulta((bool)rbProcedimentosOrcamento.IsChecked);
            else
                CrudConsultasViewModel.CalcularValorDaConsulta(false);
        }

        private void BtAjuda_Click(object sender, RoutedEventArgs e)
        {
            var ajudaView = new Ajuda("CrudConsultasView.mp4");
            ajudaView.ShowDialog();
        }
    }
}
