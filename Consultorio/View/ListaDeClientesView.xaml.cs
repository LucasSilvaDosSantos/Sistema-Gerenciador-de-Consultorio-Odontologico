using Consultorio.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace Consultorio.View
{
    public partial class ListaDeClientesView : Window
    {
        public ListaDeClientesViewModel ListaDeClientesViewModel { get; set; }
        public ListaDeClientesView()
        {
            ListaDeClientesViewModel = new ListaDeClientesViewModel();
            DataContext = ListaDeClientesViewModel;
            InitializeComponent();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            ListaDeClientesViewModel.BtVoltar_Click();
            this.Close();
        }

        private void DgListaDeClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListaDeClientesViewModel.DgListaDeClientes_SelectionChanged();
        }

        private void BtCancelar_Click(object sender, RoutedEventArgs e)
        {
            ListaDeClientesViewModel.BtCancelar_Click();
            tbId.Text = "";
            tbNome.Text = "";
        }

        private void BtAlterar_Click(object sender, RoutedEventArgs e)
        {
            AlterarCliente();
        }

        private void BtHistorico_Click(object sender, RoutedEventArgs e)
        {
            if (dgListaDeClientes.SelectedIndex >= 0)
            {
                this.Hide();
                ListaDeClientesViewModel.BtHistorico_Click(dgListaDeClientes.SelectedIndex);
                this.Close();
            }
            else
            {
                MessageBox.Show("Nenhum Cliente Selecionado", "Aviso!");
            }
        }

        private void TbNome_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbId.Text = "";
            ListaDeClientesViewModel.BuscarCliente(tbId.Text, tbNome.Text);
        }

        private void TbId_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbNome.Text = "";
            ListaDeClientesViewModel.BuscarCliente(tbId.Text, tbNome.Text);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        private void AlterarCliente()
        {
            if (dgListaDeClientes.SelectedIndex >= 0)
            {
                bool altorizacao = ListaDeClientesViewModel.AltorizacaoDeEdicao();

                if (altorizacao == true)
                {
                    this.Hide();

                    CadastroDeClienteBaseView cadastroDeClienteBaseView = new CadastroDeClienteBaseView();

                    ListaDeClientesViewModel.AlteracaoDeCliente(dgListaDeClientes.SelectedIndex, cadastroDeClienteBaseView.CadastroViewModel);

                    cadastroDeClienteBaseView.ShowDialog();

                    ListaDeClientesViewModel.ListarTodosOsClientes();

                    this.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("Você não tem altorização para editar clientes", "Acesso Negado!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Nenhum Cliente Selecionado", "Aviso!");
            }
        }
    }
}
