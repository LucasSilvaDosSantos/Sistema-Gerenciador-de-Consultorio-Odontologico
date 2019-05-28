using Consultorio.ViewModel;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using Xceed.Wpf.Toolkit.Core;

namespace Consultorio.View
{
    /// <summary>
    /// Lógica interna para PagamentoView.xaml
    /// </summary>
    public partial class PagamentoView : Window
    {
        public PagamentosViewModel PagamentosViewModel { get; set; }

        public PagamentoView()
        {
            PagamentosViewModel = new PagamentosViewModel();
            DataContext = PagamentosViewModel;
            InitializeComponent();
        }

        private void TbNome_GotFocus(object sender, RoutedEventArgs e)
        {
            SelecionarCliente();
        }

        private void TbNome_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SelecionarCliente();
        }

        private void SelecionarCliente()
        {
            PagamentosViewModel.SelecionarCliente();
        }

        private void BtCancelar_Click(object sender, RoutedEventArgs e)
        {
            string confirmação = MessageBox.Show("Deseja sair sem salvar?", "Aviso!", MessageBoxButton.OKCancel).ToString();

            if (confirmação.Equals("OK"))
            {
                this.Close();
            }
        }

        private void BtSalvar_Click(object sender, RoutedEventArgs e)
        {
            string confirmação = MessageBox.Show("Deseja cadastrar novo pagamento?", "Aviso!", MessageBoxButton.OKCancel).ToString();
            if (confirmação.Equals("OK"))
            {
                string msg = PagamentosViewModel.SalvarNovoPagamento(out bool camposEmBranco);
                if(camposEmBranco)
                {
                    MessageBox.Show(msg, "Campos Obrigatorios não preenchidos!");
                }
                else
                {
                    MessageBox.Show(msg, "Aviso!");
                    this.Close();
                }
            }
        }
    }
}
