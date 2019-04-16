using Consultorio.Data;
using Consultorio.Model;
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
    /// Lógica interna para ViewListaDeClientes.xaml
    /// </summary>
    public partial class ViewListaDeClientes : Window
    {
        public ViewListaDeClientes()
        {
            InitializeComponent();
        }

        // volta a tela anterior
        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            ViewOpcoes opcoes = new ViewOpcoes();
            opcoes.Show();
            this.Close();
        }

        // inicia a tela juntamente com o datagrid
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgListaDeClientes.ItemsSource = ListaDeClienteViewModel.ExibirCliente();
            dgListaDeClientes.Columns[14].Visibility = Visibility.Collapsed;
        }

        // duplo click no dataGrid deve abrir outra tela para a edição de cliente
        private void DgListaDeClientes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //duplo click deve abrir outra tela
            /*if (dgListaDeClientes.SelectedIndex >= 0)
            {
                LimparCampos();
                Cliente c = (Cliente)dgListaDeClientes.Items[dgListaDeClientes.SelectedIndex];
                tbId.Text = c.Id.ToString();
                tbNome.Text = c.Nome;
            }*/
            /*AtivarCampos();
            BotoesAtivados(2);*/
        }

        // função do botao buscar
        private void Buscar_Click(object sender, RoutedEventArgs e)
        {
            //verifica se o id é um int
            int.TryParse(tbId.Text, out int id);

            dgListaDeClientes.ItemsSource = ListaDeClienteViewModel.BuscarCliente(id, tbNome.Text);
            dgListaDeClientes.Columns[14].Visibility = Visibility.Collapsed;

            /*dgProdutos.ItemsSource = ProdutoViewModel.BuscarProdutos(id, tbNome.Text);
            dgProdutos.Columns[5].Visibility = Visibility.Collapsed;*/

        }
    }
}
