using Consultorio.Model;
using Consultorio.Data;
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
    /// Lógica interna para ListaDeClientesParaConsulta.xaml
    /// </summary>
    public partial class ListaDeClientesParaConsultaView : Window
    {

        public Cliente Cliente { get; set; }

        public ListaDeClientesParaConsultaView()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ListarTodosOsCliente();
            Cliente = new Cliente();
            Cliente.Id = -1;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void DgListaDeClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelecionarCliente();
        }

        private void DgListaDeClientes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SelecionarCliente();
        }

        private void BtCancelar_Click(object sender, RoutedEventArgs e)
        {
            Cliente.Id = -1;
            this.Close();
        }

        private void BtSelecionar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void TratamentoDoGrid()
        {
            dgListaDeClientes.Columns[14].Visibility = Visibility.Collapsed;
            (dgListaDeClientes.Columns[2] as DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy";
        }

        private void ListarTodosOsCliente()
        {
            dgListaDeClientes.ItemsSource = ListaDeClienteParaConsultaData.ExibirCliente();
            TratamentoDoGrid();
        }

        private void SelecionarCliente()
        {
            if (dgListaDeClientes.SelectedIndex >= 0)
            {
                Cliente = (Cliente)dgListaDeClientes.Items[dgListaDeClientes.SelectedIndex];
            }
        }

        private void TbNome_TextChanged(object sender, TextChangedEventArgs e)
        {
            BuscarCliente();
        }

        private void TbId_TextChanged(object sender, TextChangedEventArgs e)
        {
            BuscarCliente();
        }

        private void BuscarCliente()
        {
            int.TryParse(tbId.Text, out int idInt);
            if (idInt == 0 && tbId.Text == "")
            {
                ListarTodosOsCliente();
            }
            dgListaDeClientes.ItemsSource = ListaDeClienteParaConsultaData.BuscarCliente(idInt, tbNome.Text);
            TratamentoDoGrid();            
        }
    }
}
