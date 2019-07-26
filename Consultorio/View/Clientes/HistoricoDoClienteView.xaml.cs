using Consultorio.ViewModel.Clientes;
using System.Windows;

namespace Consultorio.View.Clientes
{
    /// <summary>
    /// Lógica interna para HistoricoDoCliente.xaml
    /// </summary>
    public partial class HistoricoDoClienteView : Window
    {
        public HistoricoDoClienteViewModel HistoricoDoClienteViewModel { get; set; }

        public HistoricoDoClienteView()
        {
            HistoricoDoClienteViewModel = new HistoricoDoClienteViewModel();
            DataContext = HistoricoDoClienteViewModel;
            InitializeComponent();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            ListaDeClientesView listaDeClientesView = new ListaDeClientesView();
            listaDeClientesView.Show();
            this.Close();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
    }
}