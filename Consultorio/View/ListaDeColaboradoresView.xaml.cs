using Consultorio.ViewModel;
using System.Windows;

namespace Consultorio.View
{
    public partial class ListaDeColaboradoresView : Window
    {
        public ListaDeColaboradoresViewModel ListaDeColaboradoresViewModel { get; set; }
        public ListaDeColaboradoresView()
        {
            ListaDeColaboradoresViewModel = new ListaDeColaboradoresViewModel();
            DataContext = ListaDeColaboradoresViewModel;
            InitializeComponent();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            CadastroDeColaboradoresView cadastroDeColaboradoresView = new CadastroDeColaboradoresView();
            cadastroDeColaboradoresView.Show();
            this.Close();
        }

        private void BtEditar_Click(object sender, RoutedEventArgs e)
        {
            if (dgListaAtores.SelectedIndex >= 0)
            {
                bool altorizacaoDeEdicao = ListaDeColaboradoresViewModel.AltorizacaoDeAcesso();
              
                if (altorizacaoDeEdicao == false)
                {
                    MessageBox.Show("Operação não permitida para este usuario!", "Acesso negado!");
                }
                else
                {
                    EdicaoDeAtores();
                }
            }
            else
            {
                MessageBox.Show("Nenhum colaborador selecionado!", "Erro!");
            }
        }
        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void EdicaoDeAtores()
        {
            string tipoDeAtorSelecionado = ListaDeColaboradoresViewModel.TipoDeAtorSelecionado();

            this.Hide();
            if (tipoDeAtorSelecionado == "Dentista")
            {
                EditarDentista();
            }
            else if (tipoDeAtorSelecionado == "Secretaria")
            {
                EditarSecretaria();
            }
            else if (tipoDeAtorSelecionado == "GestorDeEstoque")
            {
                EditarGestor();
            }
            this.Visibility = Visibility.Visible;
        }

        private void EditarDentista()
        {
            DentistaView dentistaView = new DentistaView();
            dentistaView.DentistaViewModel.Dentista = ListaDeColaboradoresViewModel.EdicaoDentista();
            dentistaView.ShowDialog();
        }

        private void EditarSecretaria()
        {
            SecretariaView secretariaView = new SecretariaView();
            secretariaView.SecretariaViewModel.Secretaria = ListaDeColaboradoresViewModel.EdicaoSecretaria();
            secretariaView.ShowDialog();
        }

        private void EditarGestor()
        {
            GestorDeEstoqueView gestorDeEstoqueView = new GestorDeEstoqueView();
            gestorDeEstoqueView.GestorDeEstoqueViewModel.GestorDeEstoque = ListaDeColaboradoresViewModel.EdicaoGestorDeEstoque();
            gestorDeEstoqueView.ShowDialog();
        }
    }
}
