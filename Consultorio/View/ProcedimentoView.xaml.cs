using Consultorio.ViewModel;
using System.Windows;

namespace Consultorio.View
{
    /// <summary>
    /// Lógica interna para ProcedimentoView.xaml
    /// </summary>
    public partial class ProcedimentoView : Window
    {
        public ProcedimentoViewModel ProcedimentoViewModel { get; set; }
        public ProcedimentoView()
        {
            ProcedimentoViewModel = new ProcedimentoViewModel();
            IniciarTela();
        }

        public ProcedimentoView(int id)
        {
            ProcedimentoViewModel = new ProcedimentoViewModel(id);
            IniciarTela();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void BtDelete_Click(object sender, RoutedEventArgs e)
        {
            ProcedimentoViewModel.DeletarItemDaLista();
        }

        private void BtAdicionarProduto_Click(object sender, RoutedEventArgs e)
        {
            ProcedimentoViewModel.AddProduto();
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
        private void IniciarTela()
        {
            DataContext = ProcedimentoViewModel;

            InitializeComponent();
        }

        private void BuscaProdutoPorId()
        {
            tbNomeBusca.Text = null;
            ProcedimentoViewModel.BuscarIdTodosOsProdutos(tbIdBusca.Text);
        }

        private void BuscaProdutoPorNome()
        {
            tbIdBusca.Text = null;
            ProcedimentoViewModel.BuscarNomeTodosOsProdutos(tbNomeBusca.Text);
        }

        private void BtSalvar_Click(object sender, RoutedEventArgs e)
        {
            string msg = ProcedimentoViewModel.SalvarProcedimento(out bool salvo);
            MessageBox.Show(msg, "Aviso!");
            if (salvo)
            {
                this.Close();
            }
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
