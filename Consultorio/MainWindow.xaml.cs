using Consultorio.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Consultorio.View;
using Consultorio.ViewModel;
using MySqlX.XDevAPI;

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
                OpcoesView opcoes = new OpcoesView();
                opcoes.Show();
                this.Close();//para fechar
                            //this.Hide(); //para esconder
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
