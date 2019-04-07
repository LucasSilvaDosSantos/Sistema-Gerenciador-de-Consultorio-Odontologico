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
    public partial class ViewOpcoes : Window
    {
        public ViewOpcoes()
        {
            InitializeComponent();
        }

        private void BtCadastroDeColaboradores_Click(object sender, RoutedEventArgs e)
        {
            ViewCadastroDeColaboradores cadastroDeColaboradores = new ViewCadastroDeColaboradores();
            cadastroDeColaboradores.Show();
            this.Close();
        }

        private void BtProdutos_Click(object sender, RoutedEventArgs e)
        {
            ViewProduto produto = new ViewProduto();
            produto.Show();
            this.Close();
        }

        private void BtCadastroDeProduto_Click(object sender, RoutedEventArgs e)
        {
            ViewProcedimento procedimentos = new ViewProcedimento();
            procedimentos.Show();
            this.Close();
        }

        private void BtClientes_Click(object sender, RoutedEventArgs e)
        {
            ViewListaDeClientes listaDeClientes = new ViewListaDeClientes();
            listaDeClientes.Show();
            this.Close();
        }

        private void BtCadastroDeClientes_Click(object sender, RoutedEventArgs e)
        {
            ViewCadastroDeClienteBase cadastroDeClienteBase = new ViewCadastroDeClienteBase();
            cadastroDeClienteBase.Show();
            this.Close();
        }

        private void BtConsultas_Click(object sender, RoutedEventArgs e)
        {
            ViewConsultas consultas = new ViewConsultas();
            consultas.Show();
            this.Close();
        }
    }
}
