using Consultorio.Data;
using Consultorio.Model;
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
    public partial class ListaDeColaboradoresView : Window
    {
        public ListaDeColaboradoresView()
        {
            InitializeComponent();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            CadastroDeColaboradoresView cadastroDeColaboradores = new CadastroDeColaboradoresView();
            cadastroDeColaboradores.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgListaAtores.ItemsSource = ColaboradoresData.ListarAtores();
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
                var ator = (Atores)dgListaAtores.Items[dgListaAtores.SelectedIndex];

                if (ator.GetType().ToString() == "Consultorio.Model.Dentista")
                {
                    DentistaView viewDentista = new DentistaView();
                    viewDentista.OrigemListaDeAtores = true;
                    viewDentista.IniciarComDentista((Dentista)ator);
                    viewDentista.Show();
                    this.Close();
                }
                else if (ator.GetType().ToString() == "Consultorio.Model.Secretaria")
                {
                    SecretariaView viewSecretaria = new SecretariaView();
                    viewSecretaria.OrigemListaDeAtores = true;
                    viewSecretaria.IniciarComSecretaria((Secretaria)ator);
                    viewSecretaria.Show();
                    this.Close();
                }
                else if (ator.GetType().ToString() == "Consultorio.Model.GestorDeEstoque")
                {
                    GestorDeEstoqueView viewGestorDeEstoque = new GestorDeEstoqueView();
                    viewGestorDeEstoque.OrigemListaDeAtores = true;
                    viewGestorDeEstoque.IniciarComGestorDeEstoque((GestorDeEstoque)ator);
                    viewGestorDeEstoque.Show();
                    this.Close();
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
