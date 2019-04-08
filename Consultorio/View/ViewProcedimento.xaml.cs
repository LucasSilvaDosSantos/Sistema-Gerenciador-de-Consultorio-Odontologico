﻿using Consultorio.Data;
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
    /// Lógica interna para Procedimento.xaml
    /// </summary>
    public partial class ViewProcedimento : Window
    {
        public ViewProcedimento()
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
            dgListaProcedimentos.ItemsSource = ProcedimentoViewModel.ExibirProcedimentos();
            dgListaProcedimentos.Columns[4].Visibility = Visibility.Collapsed;
        }
    }
}
