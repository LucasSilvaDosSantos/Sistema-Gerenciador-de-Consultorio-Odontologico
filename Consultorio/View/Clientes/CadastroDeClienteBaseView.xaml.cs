using Consultorio.ViewModel.Clientes;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Consultorio.View.Clientes
{
    /// <summary>
    /// Lógica interna para CadastroDeClienteBase.xaml
    /// </summary>
    public partial class CadastroDeClienteBaseView : Window
    {
        public CadastroDeClienteBaseViewModel CadastroViewModel { get; set; }

        public CadastroDeClienteBaseView()
        {
            CadastroViewModel = new CadastroDeClienteBaseViewModel();
            DataContext = CadastroViewModel;

            InitializeComponent();
            tbId.IsEnabled = false;        
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtSalvar_Click(object sender, RoutedEventArgs e)
        {
            bool valido = CadastroViewModel.ValidarCamposObrigatorios(out List<string> listaDeCamposComErro);

            if (valido == true)
            {
                SalvarClienteNoBanco();
                if (btAnamnese.Visibility == Visibility.Hidden)
                {
                    BtAnamnese_Click(sender, e);
                }
                this.Close();
            }
            else
            {
                ExibirMessagemDeCamposObrigatorios(listaDeCamposComErro);              
            }
        }

        private void BtAnamnese_Click(object sender, RoutedEventArgs e)
        {
            CadastroDeClientesAnamneseView cadastroDeClientesAnamneseView = new CadastroDeClientesAnamneseView(new CadastroDeClienteAnamneseViewModel(CadastroViewModel.Cliente));
            cadastroDeClientesAnamneseView.Show();
            this.Close();           
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        private void ExibirMessagemDeCamposObrigatorios(List<string> listaDeCampos)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string i in listaDeCampos)
            {
                sb.Append($"{i}, ");
            }
            MessageBox.Show(sb.ToString(), "Campos Obrigatorios não preenchidos");
        }

        private void SalvarClienteNoBanco()
        {
            string msg = CadastroViewModel.BtSalvar_Click();
            MessageBox.Show(msg, "Aviso!");
        }     
    }
}
