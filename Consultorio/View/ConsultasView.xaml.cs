using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using Consultorio.Model;
using System.Text;
using Consultorio.Data;
using Consultorio.ViewModel;

namespace Consultorio.View
{
    public partial class ConsultasView : Window
    {
        public ConsultasViewModel ConsultasViewModel { get; set; }

        public Cliente Cliente { get; set; }

        public ConsultasView()
        {
            ConsultasViewModel = new ConsultasViewModel();
            DataContext = ConsultasViewModel;

            InitializeComponent();
            Cliente = new Cliente();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void BtCadastrarNovo_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            CrudConsultasView crudConsultasView = new CrudConsultasView();
            crudConsultasView.ShowDialog();

            this.Visibility = Visibility.Visible;
            ConsultasViewModel.CarregarListaDeConsultasData();
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            new OpcoesViewModel();
            this.Close();
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            ConsultasViewModel.Calendar_SelectedDatesChanged(Convert.ToDateTime(cCalendario.SelectedDate));
        }

        private void BtEditar_Click(object sender, RoutedEventArgs e)
        {
            if (ConsultasViewModel.ConsultaSelecionada != null)
            {
                ConsultasViewModel.CrudConsuta();
            }
            else
            {
                MessageBox.Show("Nenhuma consulta selecionada", "Aviso!");
            }
            
        }

        private void DgConsultas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ConsultasViewModel.DataGridSelect(dgConsultas.SelectedIndex);
        }

        private void TbId_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbClienteNome.Text = "";
            ConsultasViewModel.BuscarConsultaId(tbClienteId.Text);
        }

        private void TbClienteNome_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbClienteId.Text = "";
            ConsultasViewModel.BuscarConsultaCliente(tbClienteNome.Text);
        }       
    }
}