using Consultorio.View.ManualDoUsuario;
using Consultorio.ViewModel.Atores;
using System.Windows;

namespace Consultorio.View.Atores
{
    /// <summary>
    /// Lógica interna para ListaDeAtoresView.xaml
    /// </summary>
    public partial class ListaDeAtoresView : Window
    {
        public ListaDeAtoresViewModel ListaDeAtoresViewModel { get; set; }

        public ListaDeAtoresView()
        {
            ListaDeAtoresViewModel = new ListaDeAtoresViewModel();
            DataContext = ListaDeAtoresViewModel;

            InitializeComponent();
        }

        private void BtEditar_Click(object sender, RoutedEventArgs e)
        {
            if (ListaDeAtoresViewModel.ExisteAtorSelecionado())
            {
                CrudAtorView crudAtorView = new CrudAtorView(ListaDeAtoresViewModel.AtorSelecionado.Id);
                ConfiguracoesDeView.ConfigurarWindow(this, crudAtorView);
                this.Hide();
                crudAtorView.ShowDialog();
                ConfiguracoesDeView.ConfigurarWindow(crudAtorView, this);
                RecarregarDataGrid();
                this.Visibility = Visibility.Visible;               
            }
            else
            {
                MessageBox.Show("Nenhum colaborador selecionado!", "Aviso!");
            }
        }

        private void BtCadastrarNovo_Click(object sender, RoutedEventArgs e)
        {
            CrudAtorView crudAtorView = new CrudAtorView();
            ConfiguracoesDeView.ConfigurarWindow(this, crudAtorView);
            this.Hide();
            crudAtorView.ShowDialog();
            ConfiguracoesDeView.ConfigurarWindow(crudAtorView, this);
            RecarregarDataGrid();
            this.Visibility = Visibility.Visible;
            
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            OpcoesView opcoes = new OpcoesView();
            ConfiguracoesDeView.ConfigurarWindow(this, opcoes);
            opcoes.Show();
            this.Close();
        }

        private void RecarregarDataGrid()
        {
            ListaDeAtoresViewModel.RecarregarDataGrid();
        }

        private void BtAjuda_Click(object sender, RoutedEventArgs e)
        {
            var ajudaView = new Ajuda("ListaDeAtoresView.mp4");
            ajudaView.ShowDialog();
        }
    }
}
