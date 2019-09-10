using Consultorio.View.Atores;
using Consultorio.View.Clientes;
using Consultorio.View.Clientes.ClientePage;
using Consultorio.View.Consultas;
using Consultorio.View.Pagamentos;
using Consultorio.View.Procedimentos;
using Consultorio.View.Produtos;
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
            ListaDeAtoresView listaDeAtoresView = new ListaDeAtoresView();
            ConfiguracoesDeView.ConfigurarWindow(this, listaDeAtoresView);
            listaDeAtoresView.Show();
            this.Close();
        }

        private void BtProdutos_Click(object sender, RoutedEventArgs e)
        {
            ProdutoView produto = new ProdutoView();
            ConfiguracoesDeView.ConfigurarWindow(this, produto);
            produto.Show();
            this.Close();
        }

        private void BtCadastroDeProduto_Click(object sender, RoutedEventArgs e)
        {
            ListaDeProcedimentoView procedimentos = new ListaDeProcedimentoView();
            ConfiguracoesDeView.ConfigurarWindow(this, procedimentos);
            procedimentos.Show();
            this.Close();
        }

        private void BtClientes_Click(object sender, RoutedEventArgs e)
        {
            ListaDeClientesView listaDeClientesView = new ListaDeClientesView();
            ConfiguracoesDeView.ConfigurarWindow(this, listaDeClientesView);
            listaDeClientesView.Show();
            this.Close();
        }

        private void BtCadastroDeClientes_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            WindowCliente windowCliente = new WindowCliente();
            ConfiguracoesDeView.ConfigurarWindow(this, windowCliente);
            windowCliente.ShowDialog();
            ConfiguracoesDeView.ConfigurarWindow(windowCliente, this);
            this.Visibility = Visibility.Visible;
        }

        private void BtConsultas_Click(object sender, RoutedEventArgs e)
        {
            ConsultasView consultas = new ConsultasView();
            ConfiguracoesDeView.ConfigurarWindow(this, consultas);
            consultas.Show();
            this.Close();
        }

        private void BtNovoPagamento_Click(object sender, RoutedEventArgs e)
        {
            PagamentoView pagamento = new PagamentoView();
            ConfiguracoesDeView.ConfigurarWindow(this, pagamento);
            pagamento.Show();
            this.Close();
        }

        private void BtContasPagas_Click(object sender, RoutedEventArgs e)
        {
            ContaPagaView contaPagaView = new ContaPagaView();
            ConfiguracoesDeView.ConfigurarWindow(this, contaPagaView);
            contaPagaView.Show();
            this.Close();
        }

        private void BtFinanceiro_Click(object sender, RoutedEventArgs e)
        {
            FinanceiroView financeiroView = new FinanceiroView();
            ConfiguracoesDeView.ConfigurarWindow(this, financeiroView);
            this.Hide();
            financeiroView.ShowDialog();
            ConfiguracoesDeView.ConfigurarWindow(financeiroView, this);
            this.Visibility = Visibility.Visible;
        }
    }
}
