using Consultorio.ViewModel.Clientes;
using System.Windows;


namespace Consultorio.View.Clientes
{
    /// <summary>
    /// Lógica interna para CadastroDeClientesAnamnese.xaml
    /// </summary>
    public partial class CadastroDeClientesAnamneseView : Window
    {
        public CadastroDeClienteAnamneseViewModel CadastroViewModel { get; set; }

        //public Cliente Cliente { get; set; }

        public CadastroDeClientesAnamneseView(CadastroDeClienteAnamneseViewModel viewModel)
        {        
            CadastroViewModel = viewModel;
            DataContext = CadastroViewModel;

            InitializeComponent();

            if (cbNaoPreencher.IsChecked == false)
            {
                CarregarRadioButtonNao();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            string confirmacao = MessageBox.Show("Deseja sair sem salvar?", "Confirmação", MessageBoxButton.OKCancel).ToString();
            if (confirmacao == "OK")
            {
                this.Close();
            }
        }

        private void BtSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (cbNaoPreencher.IsChecked == false)
            {
                string msg = CadastroViewModel.BtSalvar_Click();
                MessageBox.Show(msg, "Aviso!");
            }           
            this.Close();                  
        }

        private void Rectangle_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            cbNaoPreencher.IsChecked = false;
        }
        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Metodo**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void CarregarRadioButtonNao()
        {
            if ((bool)!rbP01S.IsChecked)
            {
                rbP01N.IsChecked = true;
            }

            if ((bool)!rbP02S.IsChecked)
            {
                rbP02N.IsChecked = true;
            }

            if ((bool)!rbP03S.IsChecked)
            {
                rbP03N.IsChecked = true;
            }

            if ((bool)!rbP04S.IsChecked)
            {
                rbP04N.IsChecked = true;
            }

            if ((bool)!rbP05S.IsChecked)
            {
                rbP05N.IsChecked = true;
            }

            if ((bool)!rbP06S.IsChecked)
            {
                rbP06N.IsChecked = true;
            }

            if ((bool)!rbP07S.IsChecked)
            {
                rbP07N.IsChecked = true;
            }

            if ((bool)!rbP08S.IsChecked)
            {
                rbP08N.IsChecked = true;
            }

            if ((bool)!rbP09S.IsChecked)
            {
                rbP09N.IsChecked = true;
            }

            if ((bool)!rbP10S.IsChecked)
            {
                rbP10N.IsChecked = true;
            }

            if ((bool)!rbP11S.IsChecked)
            {
                rbP11N.IsChecked = true;
            }

            if ((bool)!rbP12S.IsChecked)
            {
                rbP12N.IsChecked = true;
            }

            if ((bool)!rbP13S.IsChecked)
            {
                rbP13N.IsChecked = true;
            }

            if ((bool)!rbP14S.IsChecked)
            {
                rbP14N.IsChecked = true;
            }

            if ((bool)!rbP15S.IsChecked)
            {
                rbP15N.IsChecked = true;
            }

            if ((bool)!rbP16S.IsChecked)
            {
                rbP16N.IsChecked = true;
            }

            if ((bool)!rbP17S.IsChecked)
            {
                rbP17N.IsChecked = true;
            }

            if ((bool)!rbP18S.IsChecked)
            {
                rbP18N.IsChecked = true;
            }

            if ((bool)!rbP19S.IsChecked)
            {
                rbP19N.IsChecked = true;
            }

            if ((bool)!rbP20S.IsChecked)
            {
                rbP20N.IsChecked = true;
            }

            if ((bool)!rbP21S.IsChecked)
            {
                rbP21N.IsChecked = true;
            }

            if ((bool)!rbP22S.IsChecked)
            {
                rbP22N.IsChecked = true;
            }

            if ((bool)!rbP23S.IsChecked)
            {
                rbP23N.IsChecked = true;
            }

            if ((bool)!rbP24S.IsChecked)
            {
                rbP24N.IsChecked = true;
            }

            if ((bool)!rbP25S.IsChecked)
            {
                rbP25N.IsChecked = true;
            }

            if ((bool)!rbP26S.IsChecked)
            {
                rbP26N.IsChecked = true;
            }

            if ((bool)!rbP27S.IsChecked)
            {
                rbP27N.IsChecked = true;
            }           
        }       
    }
}
