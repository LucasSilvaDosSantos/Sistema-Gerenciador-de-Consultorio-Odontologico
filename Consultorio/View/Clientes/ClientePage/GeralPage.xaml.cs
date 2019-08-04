using Consultorio.ViewModel.Clientes;
using System.Windows.Controls;

namespace Consultorio.View.Clientes.ClientePage
{
    /// <summary>
    /// Interação lógica para Geral.xam
    /// </summary>
    public partial class GeralPage : Page
    {
        public CrudClienteViewModel CrudClienteViewModel { get; set; }
        public GeralPage(CrudClienteViewModel viewModel)
        {
            CrudClienteViewModel = viewModel;
            DataContext = CrudClienteViewModel;

            InitializeComponent();
        }

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
