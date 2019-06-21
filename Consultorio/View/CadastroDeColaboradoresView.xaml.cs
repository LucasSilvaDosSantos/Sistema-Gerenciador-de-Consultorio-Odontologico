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
    /// Lógica interna para CadastroDeColaboradores.xaml
    /// </summary>
    public partial class CadastroDeColaboradoresView : Window
    {

        public SingletonAtorLogado AtorLogado { get; set; }

        public CadastroDeColaboradoresView()
        {
            AtorLogado = SingletonAtorLogado.Instancia;

            InitializeComponent();
            ControleDeAcesso();
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            OpcoesView opcoesView = new OpcoesView();
            opcoesView.Show();
            this.Close();
        }

        private void BtMedicoDentista_Click(object sender, RoutedEventArgs e)
        {
            DentistaView dentista = new DentistaView();
            this.Hide();
            dentista.ShowDialog();
            this.Visibility = Visibility.Visible;
        }

        private void BtSecretariaAuxiliar_Click(object sender, RoutedEventArgs e)
        {
            SecretariaView secretaria = new SecretariaView();
            this.Hide();
            secretaria.ShowDialog();
            this.Visibility = Visibility.Visible;
        }

        private void BtGestorDeEstoque_Click(object sender, RoutedEventArgs e)
        {
            GestorDeEstoqueView estoque = new GestorDeEstoqueView();
            this.Hide();
            estoque.ShowDialog();
            this.Visibility = Visibility.Visible;
        }

        private void BtTodosOsColaboradores_Click(object sender, RoutedEventArgs e)
        {
            ListaDeColaboradoresView colaboradores = new ListaDeColaboradoresView();
            /*this.Hide();
            colaboradores.ShowDialog();
            this.Visibility = Visibility.Visible;*/
            colaboradores.Show();
            this.Close();
        }

        private void ControleDeAcesso()
        {
            var atorLogadoType = AtorLogado.Ator.GetType();
            /*if (atorLogado.cont)
            if (AtorLogado.Ator)*/
            if (atorLogadoType.Name == "Dentista")
            {
                btGestorDeEstoque.IsEnabled = true;
                btMedicoDentista.IsEnabled = true;
                btSecretariaAuxiliar.IsEnabled = true;
            }
            else if (atorLogadoType.Name == "Secretaria")
            {
                btGestorDeEstoque.IsEnabled = false;
                btMedicoDentista.IsEnabled = false;
                btSecretariaAuxiliar.IsEnabled = false;
                var secretaria = (Secretaria)AtorLogado.Ator;
                if (secretaria.CrudGestoresDeEstoque == true)
                {
                    btGestorDeEstoque.IsEnabled = true;
                }
                if (secretaria.CrudSecretarias == true)
                {
                    btSecretariaAuxiliar.IsEnabled = true;
                }                
            }          
        }
    }
}
