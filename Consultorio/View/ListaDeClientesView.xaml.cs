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
    public partial class ListaDeClientesView : Window
    {
        public SingletonAtorLogado AtorLogado { get; set; }

        public ListaDeClientesView()
        {
            AtorLogado = SingletonAtorLogado.Instancia;
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

        private void BtCancelar_Click(object sender, RoutedEventArgs e)
        {
            ResetarTela();
        }

        private void BtAlterar_Click(object sender, RoutedEventArgs e)
        {
            AlterarCliente();
            ListarTodosOsCliente();
        }

        private void BtHistorico_Click(object sender, RoutedEventArgs e)
        {
            HistoricoCliente();
        }

        private void TbNome_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbId.Text = "";
            Buscar();
        }

        private void TbId_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbNome.Text = "";
            Buscar();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        private void Buscar()
       {
            int.TryParse(tbId.Text, out int id);

            if (id != 0 || tbNome.Text != "")
            {
                dgListaDeClientes.ItemsSource = ListaDeClienteData.BuscarCliente(id, tbNome.Text);
                TratamentoDoGrid();
                btCancelar.IsEnabled = true;
            }
            else
            {
                ResetarTela();
                btCancelar.IsEnabled = false;
            }
       }
            
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
                var atorLogadoType = AtorLogado.Ator.GetType().Name;
                if (atorLogadoType == "Secretaria")
                {
                    Secretaria secretaria = (Secretaria)AtorLogado.Ator;
                    if (secretaria.CrudClientes == true)
                    {
                        AlteracaoDeCliente();
                    }
                    else
                    {
                        MessageBox.Show("Você não tem altorização para editar clientes", "Acesso Negado!");
                        return;
                    }
                }
                else
                {
                    AlteracaoDeCliente();
                }            
            }
        }

        private void AlteracaoDeCliente()
        {
            Cliente c = (Cliente)dgListaDeClientes.Items[dgListaDeClientes.SelectedIndex];

            CadastroDeClienteBaseView clienteBase = new CadastroDeClienteBaseView();
            clienteBase.OrigemListaDeClientes = true;
            clienteBase.IniciarComCliente(c);
            this.Hide();
            clienteBase.ShowDialog();
            this.Visibility = Visibility.Visible;
            //this.Close();
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
