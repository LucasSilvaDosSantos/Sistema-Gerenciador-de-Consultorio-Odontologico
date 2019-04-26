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
    /// Lógica interna para ViewConsultas.xaml
    /// </summary>
    public partial class ViewConsultas : Window
    {
        public ViewConsultas()
        {
            InitializeComponent();
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            ViewOpcoes opcoes = new ViewOpcoes();
            opcoes.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (ConsultorioContext ctx = new ConsultorioContext())
                {
                    var consulta = ctx.Consultas;
                    dgConsultas.ItemsSource = consulta.ToList();
                }
            }
            catch (Exception ex)
            {
                tbNome.Text = (ex.Message);
            }

        }
    }
}
