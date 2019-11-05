using System.Windows;
using Consultorio.View;
using Consultorio.View.Clientes;
using Consultorio.View.Clientes.ClientePage;
using Consultorio.View.ManualDoUsuario;
using Consultorio.ViewModel;

namespace Consultorio
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public LoginViewModel LoginViewModel { get; set; }

        public MainWindow()
        {
            LoginViewModel = new LoginViewModel();
            DataContext = LoginViewModel;
            InitializeComponent();
        }
       
        private void BtEntrar_Click(object sender, RoutedEventArgs e)
        {
            LoginViewModel.Senha = boxSenha.Password;
            bool loginValido = LoginViewModel.VerificarEntrar();
            if (loginValido)
            {
                OpcoesView opcoesView = new OpcoesView();

                ConfiguracoesDeView.ConfigurarWindow(this, opcoesView);
                
                opcoesView.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Verifique os dados", "Login Inválido!");
                boxSenha.Password = "";
            }
        }

        private void BtAjuda_Click(object sender, RoutedEventArgs e)
        {
            var ajudaView = new Ajuda("Gravar_2019_11_04_21_10_20_262.mp4");
            ajudaView.ShowDialog();
        }
    }
}
