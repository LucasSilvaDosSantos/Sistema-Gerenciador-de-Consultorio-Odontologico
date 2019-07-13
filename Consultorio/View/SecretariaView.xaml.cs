using System.Windows;
using Consultorio.ViewModel;

namespace Consultorio.View
{
    /// <summary>
    /// Lógica interna para Secretaria.xaml
    /// </summary>
    public partial class SecretariaView : Window
    {
        public SecretariaViewModel SecretariaViewModel { get; set; }

        public SecretariaView()
        {
            SecretariaViewModel = new SecretariaViewModel();
            DataContext = SecretariaViewModel;
            InitializeComponent();  
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------


        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            Voltar();
        }

        private void BtSalvar_Click(object sender, RoutedEventArgs e)
        {
            SalvarUsuario();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void Voltar()
        {
            this.Close();
        }

        private void SalvarUsuario()
        {
            bool salvo = SecretariaViewModel.BtSalvar_Click(pbSenha.Password, pbSenhaConfirma.Password, out string msg);

            if (salvo == false)
            {
                MessageBox.Show(msg, "Campos Obrigatorios não preenchidos");
            }
            else
            {
                MessageBox.Show(msg, "Aviso!");
                Voltar();
            }
        }
    }
}
