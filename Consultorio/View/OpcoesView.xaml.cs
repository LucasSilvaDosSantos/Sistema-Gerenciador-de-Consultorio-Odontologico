using Consultorio.ViewModel;
using System.Windows;

namespace Consultorio.View
{
    /// <summary>
    /// Lógica interna para Opcoes.xaml
    /// Responsavel por manter a tela de menu
    /// </summary>
    public partial class OpcoesView : Window
    {
        public OpcoesViewModel OpcoesViewModel { get; set; }

        public OpcoesView()
        {
            OpcoesViewModel = new OpcoesViewModel();
            DataContext = OpcoesViewModel;
            InitializeComponent();
        }

        private void BtCadastroDeColaboradores_Click(object sender, RoutedEventArgs e)
        {
            CadastroDeColaboradoresView cadastroDeColaboradoresView = new CadastroDeColaboradoresView();
            cadastroDeColaboradoresView.Show();
            this.Close();
        }

        private void BtProdutos_Click(object sender, RoutedEventArgs e)
        {
            ProdutoView produto = new ProdutoView();
            produto.Show();
            this.Close();
        }

        private void BtCadastroDeProduto_Click(object sender, RoutedEventArgs e)
        {
            ProcedimentoView procedimentos = new ProcedimentoView();
            procedimentos.Show();
            this.Close();
        }

        private void BtClientes_Click(object sender, RoutedEventArgs e)
        {
            ListaDeClientesView listaDeClientesView = new ListaDeClientesView();
            listaDeClientesView.Show();
            this.Close();
        }

        private void BtCadastroDeClientes_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CadastroDeClienteBaseView cadastroDeClienteBaseView = new CadastroDeClienteBaseView();
            cadastroDeClienteBaseView.ShowDialog();
            this.Visibility = Visibility.Visible;
        }

        private void BtConsultas_Click(object sender, RoutedEventArgs e)
        {
            ConsultasView consultas = new ConsultasView();
            consultas.Show();
            this.Close();
        }

        private void BtNovoPagamento_Click(object sender, RoutedEventArgs e)
        {
            PagamentoView pagamento = new PagamentoView();
            pagamento.Show();
            this.Close();
        }
    }
}
