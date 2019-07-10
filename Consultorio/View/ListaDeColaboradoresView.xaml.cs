using Consultorio.ViewModel;
using System.Windows;

namespace Consultorio.View
{
    public partial class ListaDeColaboradoresView : Window
    {
        public ListaDeColaboradoresViewModel ListaDeColaboradoresViewModel { get; set; }
        public ListaDeColaboradoresView(ListaDeColaboradoresViewModel viewModel)
        {
            ListaDeColaboradoresViewModel = viewModel;
            DataContext = ListaDeColaboradoresViewModel;
            InitializeComponent();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ListaDeColaboradoresViewModel.BtVoltar_Click();
            this.Close();
        }

        private void BtEditar_Click(object sender, RoutedEventArgs e)
        {
            if (dgListaAtores.SelectedIndex >= 0)
            {
                //this.Hide();
                bool altorizacaoDeEdicao = ListaDeColaboradoresViewModel.BtEditar_Click(dgListaAtores.SelectedIndex);                
                if (altorizacaoDeEdicao == false)
                {
                    this.Visibility = Visibility.Visible;
                    MessageBox.Show("Operação não permitida para este usuario!", "Acesso negado!");
                }
                this.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Nenhum elemento selecionado!", "Erro!");
            }
        }
        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
    }
}
