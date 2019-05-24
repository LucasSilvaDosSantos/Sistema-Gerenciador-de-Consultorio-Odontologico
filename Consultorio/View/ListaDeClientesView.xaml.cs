using Consultorio.Data;
using Consultorio.Model;
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
    /// Lógica interna para ViewListaDeClientes.xaml
    /// </summary>
    public partial class ListaDeClientesView : Window
    {
        public ListaDeClientesView()
        {
            InitializeComponent();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        // volta a tela anterior
        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            OpcoesView opcoes = new OpcoesView();
            opcoes.Show();
            this.Close();
        }

        // inicia a tela juntamente com o datagrid
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ListarTodosOsCliente();
        }

        private void DgListaDeClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btAlterar.IsEnabled = true;
            btHistorico.IsEnabled = true;
        }

        // função do botao buscar
        private void Buscar_Click(object sender, RoutedEventArgs e)
        {
            //verifica se o id é um int
            int.TryParse(tbId.Text, out int id);

            dgListaDeClientes.ItemsSource = ListaDeClienteData.BuscarCliente(id, tbNome.Text);
            TratamentoDoGrid();

            btCancelar.IsEnabled = true;
            btHistorico.IsEnabled = false;
            btAlterar.IsEnabled = false;
        }

        private void BtCancelar_Click(object sender, RoutedEventArgs e)
        {
            ResetarTela();
        }

        private void BtAlterar_Click(object sender, RoutedEventArgs e)
        {
            AlterarCliente();
        }

        private void BtHistorico_Click(object sender, RoutedEventArgs e)
        {
            HistoricoCliente();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        // todas as partes para tratar o grid para eibição correta
        private void TratamentoDoGrid()
        {
            dgListaDeClientes.Columns[14].Visibility = Visibility.Collapsed;
            (dgListaDeClientes.Columns[2] as DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy";
        }

        private void ListarTodosOsCliente()
        {
            dgListaDeClientes.ItemsSource = ListaDeClienteData.ExibirCliente();
            TratamentoDoGrid();
            btCancelar.IsEnabled = false;
            btHistorico.IsEnabled = false;
            btAlterar.IsEnabled = false;
        }
        
        private void ResetarTela()
        {
            ListarTodosOsCliente();
            tbId.Text = "";
            tbNome.Text = "";          
        }

        private void AlterarCliente()
        {
            if (dgListaDeClientes.SelectedIndex >= 0)
            {
                Cliente c = (Cliente)dgListaDeClientes.Items[dgListaDeClientes.SelectedIndex];

                CadastroDeClienteBaseView clienteBase = new CadastroDeClienteBaseView();
                clienteBase.OrigemListaDeClientes = true;
                clienteBase.IniciarComCliente(c);
                clienteBase.Show();
                this.Close();
            }
        }

        private void HistoricoCliente()
        {
            if (dgListaDeClientes.SelectedIndex >= 0)
            {
                Cliente c = (Cliente)dgListaDeClientes.Items[dgListaDeClientes.SelectedIndex];

                HistoricoDoClienteView historicoDoCliente = new HistoricoDoClienteView();
                historicoDoCliente.IniciarCliente(c);
                historicoDoCliente.Show();
                this.Close();
            }
        }
    }
}
