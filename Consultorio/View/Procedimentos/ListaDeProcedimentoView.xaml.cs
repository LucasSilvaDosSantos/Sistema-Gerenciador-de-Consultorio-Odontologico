using Consultorio.ViewModel.Procedimentos;
using System.Windows;
using System.Windows.Controls;

namespace Consultorio.View.Procedimentos
{
    /// <summary>
    /// Lógica interna para Procedimento.xaml
    /// </summary>
    public partial class ListaDeProcedimentoView : Window
    {
        public ListaDeProcedimentoViewModel ListaDeProcedimentoViewModel { get; set; }

        public ListaDeProcedimentoView()
        {
            ListaDeProcedimentoViewModel = new ListaDeProcedimentoViewModel();

            DataContext = ListaDeProcedimentoViewModel;

            InitializeComponent();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            OpcoesView opcoesView = new OpcoesView();
            opcoesView.Show();
            this.Close();
        }

        private void BtEditar_Click(object sender, RoutedEventArgs e)
        {
            int idProcedimento = ListaDeProcedimentoViewModel.GetIdProcedimento();
            if (idProcedimento <= 0)
            {
                MessageBox.Show("Nenhum Procedimento Selecionado", "Aviso!");
            }
            else
            {
                this.Hide();
                ProcedimentoView procedimentoView = new ProcedimentoView(idProcedimento);
                procedimentoView.ShowDialog();
                RecarregarLista();
                this.Visibility = Visibility.Visible;
            }            
        }

        private void BtCadastrarNovo_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ProcedimentoView procedimentoView = new ProcedimentoView();
            procedimentoView.ShowDialog();
            RecarregarLista();
            this.Visibility = Visibility.Visible;
        }        

        private void TbNomeBusca_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbIdBusca.Text = "";
            ListaDeProcedimentoViewModel.BuscarProcedimento(tbIdBusca.Text, tbNomeBusca.Text);
        }

        private void TbIdBusca_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbNomeBusca.Text = "";
            ListaDeProcedimentoViewModel.BuscarProcedimento(tbIdBusca.Text, tbNomeBusca.Text);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void RecarregarLista()
        {
            ListaDeProcedimentoViewModel.RecarregarProdutos();
        }       
    }
}
