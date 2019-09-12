using Consultorio.ViewModel.Clientes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Consultorio.View.Clientes
{
    /// <summary>
    /// Lógica interna para OrcamentoView.xaml
    /// </summary>
    public partial class OrcamentoView : Window
    {
        public OrcamentoViewModel OrcamentoViewModel { get; set; }

        /*public OrcamentoView()
        {
            OrcamentoViewModel = new OrcamentoViewModel();
            DataContext = OrcamentoViewModel;

            InitializeComponent();             
        }*/

        public OrcamentoView(int idCliente)
        {
            OrcamentoViewModel = new OrcamentoViewModel(idCliente);
            DataContext = OrcamentoViewModel;

            InitializeComponent();
        }

        private void BtSalvar_Click(object sender, RoutedEventArgs e)
        {
            string msg = OrcamentoViewModel.SalvarOrcamento();
            MessageBox.Show(msg, "Aviso!");
            this.Close();
        }

        private void BtAdicionarProduto_Click(object sender, RoutedEventArgs e)
        {
            OrcamentoViewModel.AdicionarProcedimento();
            dataGrid1.Items.Refresh();
        }

        private void BtRemoverProduto_Click(object sender, RoutedEventArgs e)
        {
            OrcamentoViewModel.RemoverProcedimento();
            dataGrid1.Items.Refresh();
        }

        private void TbIdBusca_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbNomeBusca.Text = "";
            OrcamentoViewModel.BuscarProcedimento(tbIdBusca.Text.ToString(), tbNomeBusca.Text.ToString());
        }

        private void TbNomeBusca_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbIdBusca.Text = "";
            OrcamentoViewModel.BuscarProcedimento(tbIdBusca.Text.ToString(), tbNomeBusca.Text.ToString());
                    
        }

        private void TbIdBusca_GotFocus(object sender, RoutedEventArgs e)
        {
            tbNomeBusca.Text = "";
        }

        private void TbNomeBusca_GotFocus(object sender, RoutedEventArgs e)
        {
            tbIdBusca.Text = "";
        }

        private void TbDesconto_TextChanged(object sender, TextChangedEventArgs e)
        {
            var flagDescontovalido = double.TryParse(tbDesconto.Text, out double desconto);
            if (tbDesconto.Text == "")
            {
                tbDesconto.Background = Brushes.Transparent;
            }
            if(flagDescontovalido && 100 >= desconto && desconto >= 0)
            {
                tbDesconto.Background = Brushes.Transparent;
                OrcamentoViewModel.CalculoDeDesconto(tbDesconto.Text);
                dataGrid1.Items.Refresh();
            }
            else
            {
                OrcamentoViewModel.CalculoDeDesconto("0");
                dataGrid1.Items.Refresh();
                if (tbDesconto.Text == "")
                {
                    tbDesconto.Background = Brushes.Transparent;
                }
                else
                {
                    tbDesconto.Background = Brushes.LightSalmon;
                }               
            }
        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbDesconto.Text = OrcamentoViewModel.GetDescontoEmProcentagem().ToString();            
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
