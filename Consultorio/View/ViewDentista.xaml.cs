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
    /// Lógica interna para Dentista.xaml
    /// </summary>
    public partial class ViewDentista : Window
    {
        public ViewDentista()
        {
            InitializeComponent();
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            ViewCadastroDeColaboradores viewColaboradores = new ViewCadastroDeColaboradores();
            viewColaboradores.Show();
            this.Close();
        }
    }
}
