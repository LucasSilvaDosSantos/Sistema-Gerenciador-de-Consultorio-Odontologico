using Consultorio.ViewModel;
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

namespace Consultorio.View
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

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            CrudConsultasViewModel.Calendar_SelectedDatesChanged(Convert.ToDateTime(cCalendario.SelectedDate));           
        }

        private void BtSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (tbInicio.Text == "__:__" || tbFim.Text == "__:__")
            {
                MessageBox.Show("Campos invalidos", "Aviso!");
            }
            else
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
        }

        private void TbCliente_GotFocus(object sender, RoutedEventArgs e)
        {
            CrudConsultasViewModel.AcessoAoCampoCliente(); //AbrirTelaDeCliente();
        }

        private void TbCliente_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            CrudConsultasViewModel.AcessoAoCampoCliente(); //AbrirTelaDeCliente();
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            string msg = MessageBox.Show("Deseja sair sem salvar?", "Aviso!", MessageBoxButton.OKCancel).ToString();
            if(msg == "OK")
            {
                this.Close();
            }
        }

        private void TbInicio_GotFocus(object sender, RoutedEventArgs e)
        {
            if(tbInicio.Text == "__:__")
            {
                tbInicio.Text = "";
            }             
        }

        private void TbFim_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbInicio.Text == "__:__")
            {
                tbFim.Text = "";
            }     
        }
    }
}
