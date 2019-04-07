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
    public partial class ViewCadastroDeColaboradores : Window
    {
        public ViewCadastroDeColaboradores()
        {
            InitializeComponent();
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            ViewOpcoes opcoes = new ViewOpcoes();
            opcoes.Show();
            this.Close();
        }

        private void BtMedicoDentista_Click(object sender, RoutedEventArgs e)
        {
            ViewDentista dentista = new ViewDentista();
            dentista.Show();
            this.Close();
        }

        private void BtSecretariaAuxiliar_Click(object sender, RoutedEventArgs e)
        {
            ViewSecretaria secretaria = new ViewSecretaria();
            secretaria.Show();
            this.Close();
        }

        private void BtGestorDeEstoque_Click(object sender, RoutedEventArgs e)
        {
            ViewGestorDeEstoque estoque = new ViewGestorDeEstoque();
            estoque.Show();
            this.Close();
        }

        private void BtTodosOsColaboradores_Click(object sender, RoutedEventArgs e)
        {
            ViewListaDeColaboradores colaboradores = new ViewListaDeColaboradores();
            colaboradores.Show();
            this.Close();
        }
    }
}
