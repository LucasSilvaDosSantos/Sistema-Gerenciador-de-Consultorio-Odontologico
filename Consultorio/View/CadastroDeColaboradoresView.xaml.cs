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

        public int AtorLogado { get; set; }
        public int AltorizacaoDeAcesso { get; set; }

        public bool AltorizacaoMedico { get; set; }
        public bool AltorizacaoSecretaria { get; set; }
        public bool AltorizacaoGestor { get; set; }

        public CadastroDeColaboradoresView()
        {
            //AtorLogado = idLogin;
            InitializeComponent();

        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtMedicoDentista_Click(object sender, RoutedEventArgs e)
        {
            DentistaView dentista = new DentistaView();
            this.Hide();
            dentista.ShowDialog();
            this.Show();
        }

        private void BtSecretariaAuxiliar_Click(object sender, RoutedEventArgs e)
        {
            SecretariaView secretaria = new SecretariaView();
            this.Hide();
            secretaria.ShowDialog();
            this.Show();
        }

        private void BtGestorDeEstoque_Click(object sender, RoutedEventArgs e)
        {
            GestorDeEstoqueView estoque = new GestorDeEstoqueView();
            this.Hide();
            estoque.ShowDialog();
            this.Show();
        }

        private void BtTodosOsColaboradores_Click(object sender, RoutedEventArgs e)
        {
            ListaDeColaboradoresView colaboradores = new ListaDeColaboradoresView();
            this.Hide();
            colaboradores.ShowDialog();
            this.Show();
        }
    }
}
