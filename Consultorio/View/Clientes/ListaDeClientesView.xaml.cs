using Consultorio.View.Clientes.ClientePage;
using Consultorio.View.ManualDoUsuario;
using Consultorio.ViewModel.Clientes;
using System.Windows;
using System.Windows.Controls;

namespace Consultorio.View.Clientes
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
            OpcoesView opcoesView = new OpcoesView();
            ConfiguracoesDeView.ConfigurarWindow(this, opcoesView);
            opcoesView.Show();
            this.Close();
        }

        private void DgListaDeClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListaDeClientesViewModel.DgListaDeClientes_SelectionChanged();
        }

        private void BtAlterar_Click(object sender, RoutedEventArgs e)
        {
            if (dgListaDeClientes.SelectedIndex >= 0)
            {
                bool altorizacao = ListaDeClientesViewModel.AltorizacaoDeEdicao();

                if (altorizacao == true)
                {
                    this.Hide();

                    WindowCliente windowCliente = new WindowCliente(ListaDeClientesViewModel.ClienteSelecionado.Id);
                    ConfiguracoesDeView.ConfigurarWindow(this, windowCliente);
                    windowCliente.ShowDialog();

                    BuscaCliente();//ListaDeClientesViewModel.ListarTodosOsClientes();
                    ConfiguracoesDeView.ConfigurarWindow(windowCliente, this);
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

        private void BtHistorico_Click(object sender, RoutedEventArgs e)
        {
            if (dgListaDeClientes.SelectedIndex >= 0)
            {
                HistoricoDoClienteView historicoDoClienteView = new HistoricoDoClienteView();
                historicoDoClienteView.HistoricoDoClienteViewModel.IniciarViewModel(ListaDeClientesViewModel.ClienteSelecionadoNaLista(dgListaDeClientes.SelectedIndex));
                ConfiguracoesDeView.ConfigurarWindow(this, historicoDoClienteView);
                historicoDoClienteView.Show();
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
            tbCpf.Text = "";
            BuscaCliente();
        }

        private void TbId_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbNome.Text = "";
            tbCpf.Text = "";
            BuscaCliente();
        }

        private void TbCpf_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbId.Text = "";
            tbNome.Text = "";
            BuscaCliente();
        }

        private void BuscaCliente()
        {
            ListaDeClientesViewModel.BuscarCliente(tbId.Text, tbNome.Text, tbCpf.Text);
        }

        private void BtOrcamento_Click(object sender, RoutedEventArgs e)
        {
            if (dgListaDeClientes.SelectedIndex >= 0)
            {

                OrcamentoView orcamento = new OrcamentoView(ListaDeClientesViewModel.ClienteSelecionado.Id);
                ConfiguracoesDeView.ConfigurarWindow(this, orcamento);
                this.Hide();
                orcamento.ShowDialog();              
                this.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Nenhum Cliente Selecionado", "Aviso!");
            }
        }

        private void BtAjuda_Click(object sender, RoutedEventArgs e)
        {
            var ajudaView = new Ajuda("ListaDeClientesView.mp4");
            ajudaView.ShowDialog();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
    }
}
