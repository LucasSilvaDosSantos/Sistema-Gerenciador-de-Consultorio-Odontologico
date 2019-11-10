using Consultorio.View.ManualDoUsuario;
using Consultorio.ViewModel.Clientes;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Consultorio.View.Clientes.ClientePage
{
    /// <summary>
    /// Lógica interna para WindowCliente.xaml
    /// </summary>
    public partial class WindowCliente : Window
    {
        public CrudClienteViewModel CrudClienteViewModel { get; set; }

        public GeralPage GeralPage { get; set; }
        public AnamnesePage AnamnesePage { get; set; }
        public OdontogramaPage OdontogramaPage { get; set; }

        public WindowCliente()
        {
            CrudClienteViewModel = new CrudClienteViewModel();          
            IniciarTela();
        }

        public WindowCliente(int id)
        {
            CrudClienteViewModel = new CrudClienteViewModel(id);
            IniciarTela();
        }

        private void IniciarTela()
        {
            DataContext = CrudClienteViewModel;
            OdontogramaPage = new OdontogramaPage(CrudClienteViewModel);
            GeralPage = new GeralPage(CrudClienteViewModel);
            AnamnesePage = new AnamnesePage(CrudClienteViewModel);

            InitializeComponent();
            frameCliente.Navigate(GeralPage);
        }
        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void BtGeral_Click(object sender, RoutedEventArgs e)
        {
            frameCliente.Navigate(GeralPage);
        }

        private void BtAnamnese_Click(object sender, RoutedEventArgs e)
        {
            frameCliente.Navigate(AnamnesePage);
        }

        private void BtOrtodongrama_Click(object sender, RoutedEventArgs e)
        {
            frameCliente.Navigate(OdontogramaPage);
        }

        private void BtSalvar_Click(object sender, RoutedEventArgs e)
        {
            bool camposEmBranco = CrudClienteViewModel.ExisteCamposObrigatoriosEmBranco(out List<string> listaCamposEmBranco);

            string confirmacao = "OK";

            if (CrudClienteViewModel.AnamneseNaoPrenchida == true)
            {
                confirmacao = MessageBox.Show("Deseja proseguir sem salvar Anamnese?", "AVISO!", MessageBoxButton.OKCancel).ToString();
            }

            if (confirmacao == "OK")
            {
                if (camposEmBranco == true)
                {
                    MessagemDeCamposEmBrancos(listaCamposEmBranco);
                }
                else
                {
                    string msg = CrudClienteViewModel.SalvarCliente();
                    MessageBox.Show(msg, "Aviso!");
                    this.Close();
                }
            }                      
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Metodo**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void MessagemDeCamposEmBrancos(List<string> listaCamposEmBranco)
        {
            StringBuilder sb = new StringBuilder();

            foreach (string palavra in listaCamposEmBranco)
            {
                sb.Append($"{palavra}\n");
            }
            MessageBox.Show(sb.ToString(), "Estes campos não podem ficar em branco!");
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtAjuda_Click(object sender, RoutedEventArgs e)
        {
            var ajudaView = new Ajuda("CrudClienteView.mp4");
            ajudaView.ShowDialog();
        }
    }
}
