using System.Windows;
using System.Windows.Controls;
using Consultorio.View.ManualDoUsuario;
using Consultorio.ViewModel.Clientes;

namespace Consultorio.View.Clientes
{
    /// <summary>
    /// Lógica interna para ListaDeClientesParaConsulta.xaml
    /// </summary>
    public partial class SelecaoDeClienteView : Window
    {

        public SelecaoDeClienteViewModel SelecaoDeClienteViewModel{ get; set; }

        public SelecaoDeClienteView()
        {
            SelecaoDeClienteViewModel = new SelecaoDeClienteViewModel();
            DataContext = SelecaoDeClienteViewModel;
            InitializeComponent();
        }


        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void BtCancelar_Click(object sender, RoutedEventArgs e)
        {
            SelecaoDeClienteViewModel.BtCancelar_Click();
            this.Close();
        }

        private void BtSelecionar_Click(object sender, RoutedEventArgs e)
        {
            if (dgListaDeClientes.SelectedIndex >= 0)
            {
                SelecaoDeClienteViewModel.BtSelecionar_Click(dgListaDeClientes.SelectedIndex);
                this.Close();
            }
            else
            {
                MessageBox.Show("Nenhum Cliente Selecionado", "Aviso!");
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void TbNome_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbId.Text = "";
            SelecaoDeClienteViewModel.BuscarCliente(tbId.Text, tbNome.Text);
        }

        private void TbId_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbNome.Text = "";
            SelecaoDeClienteViewModel.BuscarCliente(tbId.Text, tbNome.Text);
        }

        private void BtAjuda_Click(object sender, RoutedEventArgs e)
        {
            var ajudaView = new Ajuda("SelecaoDeClienteView.mp4");
            ajudaView.ShowDialog();
        }
    }
}
