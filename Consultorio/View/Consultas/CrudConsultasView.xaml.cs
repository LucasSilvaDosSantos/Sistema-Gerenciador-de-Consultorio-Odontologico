using Consultorio.View.Clientes;
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
            CrudConsultasViewModel = new CrudConsultasViewModel(idConsulta);
            DataContext = CrudConsultasViewModel;

            InitializeComponent();
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

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            CrudConsultasViewModel.Calendar_SelectedDatesChanged(Convert.ToDateTime(cCalendario.SelectedDate));           
        }

        private void BtSalvar_Click(object sender, RoutedEventArgs e)
        {
         
            string campos = CrudConsultasViewModel.CamposObrigatoriosPreenchidos();
            if (campos == "")
            {
                string msg = CrudConsultasViewModel.SalVarClick();
                MessageBox.Show(msg, "Aviso!");
                this.Close();
            }
            else
            {
                MessageBox.Show(campos, "Aviso! Campos obrigatórios não preenchidos");
            }
                      
        }

        private void TbCliente_GotFocus(object sender, RoutedEventArgs e)
        {
            SelecionarCliente();

            //CrudConsultasViewModel.AcessoAoCampoCliente(); //AbrirTelaDeCliente();
        }

        private void TbCliente_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SelecionarCliente();

            //CrudConsultasViewModel.AcessoAoCampoCliente(); //AbrirTelaDeCliente();
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            string msg = MessageBox.Show("Deseja sair sem salvar?", "Aviso!", MessageBoxButton.OKCancel).ToString();
            if(msg == "OK")
            {
                this.Close();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void SelecionarCliente()
        {
            this.Hide();
            SelecaoDeClienteView selecaoDeClienteView = new SelecaoDeClienteView();
            selecaoDeClienteView.ShowDialog();

            CrudConsultasViewModel.Consulta.Cliente = selecaoDeClienteView.SelecaoDeClienteViewModel.ClienteSelecionado;
            CrudConsultasViewModel.NotificarConsulta();
            this.Visibility = Visibility.Visible;
        }
    }
}
