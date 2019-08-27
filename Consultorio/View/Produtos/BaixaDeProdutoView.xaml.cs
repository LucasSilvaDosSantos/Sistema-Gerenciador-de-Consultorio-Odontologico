using Consultorio.ViewModel.Produtos;
using System.Text;
using System.Windows;

namespace Consultorio.View.Produtos
{
    /// <summary>
    /// Lógica interna para BaixaDeProdutoView.xaml
    /// </summary>
    public partial class BaixaDeProdutoView : Window
    {
        public BaixaDeProdutoViewModel BaixaDeProdutoViewModel { get; set; }

        public BaixaDeProdutoView(int id)
        {
            BaixaDeProdutoViewModel = new BaixaDeProdutoViewModel(id);
            DataContext = BaixaDeProdutoViewModel;
            InitializeComponent();
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtSalvar_Click(object sender, RoutedEventArgs e)
        {
            var lista = BaixaDeProdutoViewModel.VerificarCamposObrigatorios(out bool ok);
            if (ok)
            {
                string msg = BaixaDeProdutoViewModel.SalvarBaixa();
                MessageBox.Show(msg, "Aviso!");
                this.Close();
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach(var item in lista)
                {
                    sb.Append($"{item}\n");
                }
                MessageBox.Show(sb.ToString(), "Aviso!");
            }
        }
    }
}
