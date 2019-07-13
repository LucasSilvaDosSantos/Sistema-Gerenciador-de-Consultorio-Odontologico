﻿using Consultorio.ViewModel;
using System.Windows;

namespace Consultorio.View
{
    /// <summary>
    /// Lógica interna para CadastroDeColaboradores.xaml
    /// </summary>
    public partial class CadastroDeColaboradoresView : Window
    {
        public CadastroDeColaboradoresViewModel CadastroViewModel { get; set; }

        public CadastroDeColaboradoresView()
        {
            CadastroViewModel = new CadastroDeColaboradoresViewModel();
            DataContext = CadastroViewModel;
            InitializeComponent();
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            CadastroViewModel.BtVoltar_Click();
            this.Close();
        }
        private void BtMedicoDentista_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CadastroViewModel.BtMedicoDentista_Click();
            this.Visibility = Visibility.Visible;
        }

        private void BtSecretariaAuxiliar_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CadastroViewModel.BtSecretariaAuxiliar_Click();
            this.Visibility = Visibility.Visible;
        }

        private void BtGestorDeEstoque_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CadastroViewModel.BtGestorDeEstoque_Click();
            this.Visibility = Visibility.Visible;
        }

        private void BtTodosOsColaboradores_Click(object sender, RoutedEventArgs e)
        {
            ListaDeColaboradoresView listaDeColaboradoresView = new ListaDeColaboradoresView();
            listaDeColaboradoresView.Show();
            this.Close();
        }
    }
}
