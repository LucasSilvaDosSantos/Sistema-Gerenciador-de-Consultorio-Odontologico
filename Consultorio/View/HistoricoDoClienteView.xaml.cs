﻿using System;
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
    /// Lógica interna para HistoricoDoCliente.xaml
    /// </summary>
    public partial class HistoricoDoClienteView : Window
    {
        public HistoricoDoClienteView()
        {
            InitializeComponent();
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            OpcoesView opcoes = new OpcoesView();
            opcoes.Show();
            this.Close();
        }
    }
}