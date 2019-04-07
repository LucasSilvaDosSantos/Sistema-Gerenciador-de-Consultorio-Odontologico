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
    /// Lógica interna para Secretaria.xaml
    /// </summary>
    public partial class ViewSecretaria : Window
    {
        public ViewSecretaria()
        {
            InitializeComponent();
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            ViewCadastroDeColaboradores opcoes = new ViewCadastroDeColaboradores();
            opcoes.Show();
            this.Close();
        }
    }
}
