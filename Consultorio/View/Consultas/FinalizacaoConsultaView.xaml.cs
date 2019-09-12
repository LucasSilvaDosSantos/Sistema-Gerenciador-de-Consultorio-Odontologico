using Consultorio.ViewModel.Consultas;
using System.Windows;

namespace Consultorio.View.Consultas
{
    /// <summary>
    /// Lógica interna para FinalizacaoConsultaView.xaml
    /// </summary>
    public partial class FinalizacaoConsultaView : Window
    {
        public FinalizacaoConsultaViewModel FinalizacaoConsultaViewModel{ get; set; }

        public FinalizacaoConsultaView(int idConsulta)
        {
            FinalizacaoConsultaViewModel = new FinalizacaoConsultaViewModel(idConsulta);

            DataContext = FinalizacaoConsultaViewModel;

            InitializeComponent();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        private void BtDelete_Click(object sender, RoutedEventArgs e)
        {
            FinalizacaoConsultaViewModel.DeletarItemDaLista();
        }

        private void BtAdicionarProduto_Click(object sender, RoutedEventArgs e)
        {
            FinalizacaoConsultaViewModel.AddProduto();
        }

        private void TbIdBusca_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            BuscaProdutoPorId();
        }

        private void TbNomeBusca_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            BuscaProdutoPorNome();
        }

        private void TbIdBusca_GotFocus(object sender, RoutedEventArgs e)
        {
            BuscaProdutoPorId();
        }

        private void TbNomeBusca_GotFocus(object sender, RoutedEventArgs e)
        {
            BuscaProdutoPorNome();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Metodos**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void BuscaProdutoPorId()
        {
            tbNomeBusca.Text = null;
            FinalizacaoConsultaViewModel.BuscarIdTodosOsProdutos(tbIdBusca.Text);
        }

        private void BuscaProdutoPorNome()
        {
            tbIdBusca.Text = null;
            FinalizacaoConsultaViewModel.BuscarNomeTodosOsProdutos(tbNomeBusca.Text);
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtSalvar_Click(object sender, RoutedEventArgs e)
        {
            bool consultaSalva = FinalizacaoConsultaViewModel.SalvarConsulta();

            if (consultaSalva == true)
            {
                MessageBox.Show("Consulta Finalizada!", "Aviso!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Erro ao salvar finalização de consulta!", "Aviso!");
            }
        }

        private void ComboBoxProcedimento_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            FinalizacaoConsultaViewModel.AlterarValorDaConsulta();
        }
    }
}
