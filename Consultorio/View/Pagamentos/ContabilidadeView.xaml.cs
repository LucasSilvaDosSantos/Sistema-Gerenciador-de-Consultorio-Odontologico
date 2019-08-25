using Consultorio.ViewModel.Pagamentos;
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

namespace Consultorio.View.Pagamentos
{
    /// <summary>
    /// Lógica interna para ListaDeContasPagasView.xaml
    /// </summary>
    public partial class ContabilidadeView : Window
    {
        public ContabilidadeViewModel ContabilidadeViewModel { get; set; }
        public ContabilidadeView()
        {
            ContabilidadeViewModel = new ContabilidadeViewModel();
            DataContext = ContabilidadeViewModel;
            InitializeComponent();
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
