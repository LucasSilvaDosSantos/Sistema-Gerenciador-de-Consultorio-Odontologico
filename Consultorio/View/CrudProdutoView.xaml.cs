using Consultorio.ViewModel;
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
                    sb.Append($"{i}, ");
                }
                string msg = sb.ToString();
                MessageBox.Show(msg, "Campos não podem ficar em branco!");
            }
            else
            {
                string confirmacao = MessageBox.Show("Deseja salvar a operação?", "Alerta!", MessageBoxButton.OKCancel).ToString();
                if (confirmacao == "OK")
                {
                    string msg = CrudProdutoViewModel.BotaoSalvarClick();
                    MessageBox.Show(msg, "Aviso!");
                    this.Close();
                }
            } 
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            string confirmacao = MessageBox.Show("Deseja cancelar a operação?", "Alerta!", MessageBoxButton.OKCancel).ToString();
            if (confirmacao == "OK")
            {
                this.Close();
            }
        }
    }
}
