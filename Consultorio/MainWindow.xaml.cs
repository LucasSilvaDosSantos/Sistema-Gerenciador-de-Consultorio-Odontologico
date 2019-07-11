using System.Windows;
using Consultorio.View;
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
                opcoesView.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Verifique os dados", "Login Inválido!");
                boxSenha.Password = "";
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
