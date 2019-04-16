using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Lógica interna para CadastroDeClienteBase.xaml
    /// </summary>
    public partial class ViewCadastroDeClienteBase : Window
    {
        public ViewCadastroDeClienteBase()
        {
            InitializeComponent();
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            ViewOpcoes opcoes = new ViewOpcoes();
            opcoes.Show();
            this.Close();
        }

        private void BtSalvar_Click(object sender, RoutedEventArgs e)
        {
            ViewCadastroDeClientesAnamnese anamnese = new ViewCadastroDeClientesAnamnese();
            anamnese.Show();
            this.Close();
        }

        private void PegarDadosDaTela()
        {
            Cliente cliente = new Cliente();
            cliente.Nome = tbNome.Text;
            cliente.Nascimento = DateTime.ParseExact(tbDataDeNascimento.Text, "dd/MM/yyyy", CultureInfo.CurrentCulture);
        }
    }
}
