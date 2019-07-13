using System.Windows;
using System.Windows.Controls;
using Consultorio.ViewModel;

namespace Consultorio.View
{
    public partial class ConsultasView : Window
    {
        public ConsultasViewModel ConsultasViewModel { get; set; }

        public ConsultasView()
        {
            ConsultasViewModel = new ConsultasViewModel();
            DataContext = ConsultasViewModel;

            InitializeComponent();
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
            ConsultasViewModel.CarregarListaDeConsultasData();
        }

        private void BtEditar_Click(object sender, RoutedEventArgs e)
        {
            if (ConsultasViewModel.ConsultaSelecionada != null)
            {
                this.Hide();
                CrudConsultasView crudConsultasView = new CrudConsultasView(ConsultasViewModel.ConsultaSelecionadaID());
                crudConsultasView.ShowDialog();
                ConsultasViewModel.CarregarListaDeConsultasData();
                this.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Nenhuma consulta selecionada", "Aviso!");
            }
            
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