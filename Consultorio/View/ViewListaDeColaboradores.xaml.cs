using Consultorio.Data;
using Consultorio.Model;
using Consultorio.ViewModel;
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
using System.Windows.Shapes;

namespace Consultorio.View
{
    /// <summary>
    /// Lógica interna para ViewListaDeColaboradores.xaml
    /// </summary>
    public partial class ViewListaDeColaboradores : Window
    {
        public ViewListaDeColaboradores()
        {
            InitializeComponent();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            ViewCadastroDeColaboradores cadastroDeColaboradores = new ViewCadastroDeColaboradores();
            cadastroDeColaboradores.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgListaAtores.ItemsSource = ColaboradoresViewModel.ListarAtores();
            //Login
            dgListaAtores.Columns[5].Visibility = Visibility.Collapsed;
            //Senha
            dgListaAtores.Columns[6].Visibility = Visibility.Collapsed;
            //Ativo
            dgListaAtores.Columns[7].Visibility = Visibility.Collapsed;
        }

        private void DgListaAtores_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgListaAtores.SelectedIndex >= 0)
            {
                var a = (Atores)dgListaAtores.Items[dgListaAtores.SelectedIndex];

                if (a.GetType().ToString() == "Consultorio.Model.Dentista")
                {
                    ViewDentista viewDentista = new ViewDentista();
                    viewDentista.OrigemListaDeAtores = true;
                    viewDentista.IniciarComDentista((Dentista)a);
                    viewDentista.Show();
                    this.Close();
                }
                else if (a.GetType().ToString() == "Consultorio.Model.Secretaria")
                {

                }
                else if (a.GetType().ToString() == "Consultorio.Model.GestorDeEstoque")
                {

                }
                /*clienteBase = new ViewCadastroDeClienteBase();
                clienteBase.OrigemListaDeClientes = true;
                clienteBase.IniciarComCliente(a);
                clienteBase.Show();
                this.Close();*/
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
    }
}
