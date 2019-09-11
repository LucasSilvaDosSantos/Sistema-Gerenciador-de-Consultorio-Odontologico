using Consultorio.ViewModel.Produtos;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Consultorio.View.Produtos
{
    /// <summary>
    /// Lógica interna para ProdutoEdicaoView.xaml
    /// </summary>
    public partial class CrudProdutoView : Window
    {
        public CrudProdutoViewModel CrudProdutoViewModel { get; set; }

        public CrudProdutoView()
        {
            CrudProdutoViewModel = new CrudProdutoViewModel();
            DataContext = CrudProdutoViewModel;
            InitializeComponent();
        }

        public CrudProdutoView(int idProduto)
        {
            CrudProdutoViewModel = new CrudProdutoViewModel(idProduto);
            DataContext = CrudProdutoViewModel;
            InitializeComponent();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        private void BtSalvar_Click(object sender, RoutedEventArgs e)
        {
            bool camposObrigatoriosPreenchidos = CrudProdutoViewModel.VerificaCamposObrigatoriosPreenchidos(out List<string> lista);
            if (camposObrigatoriosPreenchidos == false)
            {
                StringBuilder sb = new StringBuilder();
                foreach(string i in lista)
                {
                    sb.Append($"{i}\n ");
                }
                string msg = sb.ToString();
                MessageBox.Show(msg, "O campo não pode ficar em branco!");
            }
            else
            {
                string msg = CrudProdutoViewModel.BotaoSalvarClick();
                MessageBox.Show(msg, "Aviso!");

                bool telaResetada = CrudProdutoViewModel.ResetarTela();

                if (telaResetada == false)
                {
                    this.Close();
                }
            } 
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
