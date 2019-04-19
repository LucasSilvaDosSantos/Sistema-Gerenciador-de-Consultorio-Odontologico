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
    /// Lógica interna para CadastroDeClientesAnamnese.xaml
    /// </summary>
    public partial class ViewCadastroDeClientesAnamnese : Window
    {
        public Cliente Cliente { get; set; }

        public ViewCadastroDeClientesAnamnese(Cliente c)
        {
            InitializeComponent();
            Cliente = c;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            ViewCadastroDeClienteBase opcoes = new ViewCadastroDeClienteBase();
            opcoes.IniciarCliente(Cliente);
            opcoes.Show();
            this.Close();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        /*private Anamnese PegarDadosDaTela()
        {
            Anamnese anamnese = new Anamnese();
            anamnese.P01 = cbP10S.IsChecked.Value;
            return
        }

        private bool SimOuNão(bool s)
        {
            if (s)
            {
                return true;
            }
            return false;
        }*/
    }
}
