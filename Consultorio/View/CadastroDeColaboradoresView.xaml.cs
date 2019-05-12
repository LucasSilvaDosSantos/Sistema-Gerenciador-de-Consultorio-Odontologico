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
        public CadastroDeColaboradoresView()
        {
            InitializeComponent();
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            OpcoesView opcoes = new OpcoesView();
            opcoes.Show();
            this.Close();
        }

        private void BtMedicoDentista_Click(object sender, RoutedEventArgs e)
        {
            DentistaView dentista = new DentistaView();
            dentista.Show();
            this.Close();
        }

        private void BtSecretariaAuxiliar_Click(object sender, RoutedEventArgs e)
        {
            SecretariaView secretaria = new SecretariaView();
            secretaria.Show();
            this.Close();
        }

        private void BtGestorDeEstoque_Click(object sender, RoutedEventArgs e)
        {
            GestorDeEstoqueView estoque = new GestorDeEstoqueView();
            estoque.Show();
            this.Close();
        }

        private void BtTodosOsColaboradores_Click(object sender, RoutedEventArgs e)
        {
            ListaDeColaboradoresView colaboradores = new ListaDeColaboradoresView();
            colaboradores.Show();
            this.Close();
        }
    }
}
