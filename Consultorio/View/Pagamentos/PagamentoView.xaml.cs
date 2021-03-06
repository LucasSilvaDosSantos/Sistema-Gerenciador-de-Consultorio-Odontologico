﻿using Consultorio.View.Clientes;
using Consultorio.View.ManualDoUsuario;
using Consultorio.ViewModel.Procedimentos;
using System.Windows;

namespace Consultorio.View.Pagamentos
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
            this.Hide();
            SelecaoDeClienteView selecaoDeClienteView = new SelecaoDeClienteView();
            ConfiguracoesDeView.ConfigurarWindow(this, selecaoDeClienteView);
            selecaoDeClienteView.ShowDialog();

            PagamentosViewModel.Cliente = selecaoDeClienteView.SelecaoDeClienteViewModel.ClienteSelecionado;
            ConfiguracoesDeView.ConfigurarWindow(selecaoDeClienteView, this);
            this.Visibility = Visibility.Visible;

            PagamentosViewModel.CarregarValorDevido();
        }

        private void BtCancelar_Click(object sender, RoutedEventArgs e)
        {
            OpcoesView opcoesView = new OpcoesView();
            ConfiguracoesDeView.ConfigurarWindow(this, opcoesView);
            opcoesView.Show();
            this.Close();
        }

        private void BtSalvar_Click(object sender, RoutedEventArgs e)
        {
            string msg = PagamentosViewModel.SalvarNovoPagamento(out bool camposEmBranco);
            if (camposEmBranco)
            {
                MessageBox.Show(msg, "Campos Obrigatorios não preenchidos!");
            }
            else
            {
                MessageBox.Show(msg, "Aviso!");
                OpcoesView opcoesView = new OpcoesView();
                ConfiguracoesDeView.ConfigurarWindow(this, opcoesView);
                opcoesView.Show();
                this.Close();
            }
        }

        private void BtAjuda_Click(object sender, RoutedEventArgs e)
        {
            var ajudaView = new Ajuda("PagamentoView.mp4");
            ajudaView.ShowDialog();
        }
    }
}
