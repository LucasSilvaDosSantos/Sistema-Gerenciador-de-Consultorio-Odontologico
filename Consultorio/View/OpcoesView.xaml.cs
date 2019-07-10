using Consultorio.Data;
using Consultorio.ViewModel;
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
    /// Lógica interna para Opcoes.xaml
    /// </summary>
    public partial class OpcoesView : Window
    {
        public OpcoesViewModel OpcoesViewModel { get; set; }

        public OpcoesView(OpcoesViewModel opcoesViewModel)
        {
            OpcoesViewModel = opcoesViewModel;
            DataContext = OpcoesViewModel;
            InitializeComponent();
        }

        private void BtCadastroDeColaboradores_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CadastroDeColaboradoresViewModel cadastroDeColaboradoresViewModel = new CadastroDeColaboradoresViewModel();
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
            this.Hide();
            new ListaDeClientesViewModel();
            this.Close();
        }

        private void BtCadastroDeClientes_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CadastroDeClienteBaseViewModel cadastroDeClienteBase = new CadastroDeClienteBaseViewModel();
            this.Visibility = Visibility.Visible;

            /*CadastroDeClienteBaseView cadastroDeClienteBase = new CadastroDeClienteBaseView();
            this.Hide();
            cadastroDeClienteBase.ShowDialog();
            this.Visibility = Visibility.Visible;*/
            //this.Close();
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
            this.Hide();
            pagamento.ShowDialog();
            this.Visibility = Visibility.Visible;
        }
    }
}
