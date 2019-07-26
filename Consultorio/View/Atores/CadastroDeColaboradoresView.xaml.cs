using Consultorio.ViewModel.Ator;
using System.Windows;

namespace Consultorio.View.Atores
{
    /// <summary>
    /// Lógica interna para CadastroDeColaboradores.xaml
    /// </summary>
    public partial class CadastroDeColaboradoresView : Window
    {
        public CadastroDeColaboradoresViewModel CadastroViewModel { get; set; }

        public CadastroDeColaboradoresView()
        {
            CadastroViewModel = new CadastroDeColaboradoresViewModel();
            DataContext = CadastroViewModel;
            InitializeComponent();
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            OpcoesView opcoesView = new OpcoesView();
            opcoesView.Show();
            this.Close();
        }
        private void BtMedicoDentista_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            DentistaView dentistaView = new DentistaView();
            dentistaView.ShowDialog();
            this.Visibility = Visibility.Visible;
        }

        private void BtSecretariaAuxiliar_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            SecretariaView secretariaView = new SecretariaView();
            secretariaView.ShowDialog();
            this.Visibility = Visibility.Visible;
        }

        private void BtGestorDeEstoque_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            GestorDeEstoqueView gestorDeEstoqueView = new GestorDeEstoqueView();
            gestorDeEstoqueView.ShowDialog();
            this.Visibility = Visibility.Visible;
        }

        private void BtTodosOsColaboradores_Click(object sender, RoutedEventArgs e)
        {
            ListaDeColaboradoresView listaDeColaboradoresView = new ListaDeColaboradoresView();
            listaDeColaboradoresView.Show();
            this.Close();
        }
    }
}
