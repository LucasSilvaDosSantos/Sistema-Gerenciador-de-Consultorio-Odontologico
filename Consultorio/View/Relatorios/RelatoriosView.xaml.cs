﻿using System.Windows;

namespace Consultorio.View.Relatorios
{
    /// <summary>
    /// Lógica interna para RelatoriosView.xaml
    /// </summary>
    public partial class RelatoriosView : Window
    {
        public RelatoriosView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RelatorioConsultaPeriodoView relatorioConsultaPeriodo = new RelatorioConsultaPeriodoView();
            ConfiguracoesDeView.ConfigurarWindow(this, relatorioConsultaPeriodo);
            relatorioConsultaPeriodo.Show();
            this.Close();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            OpcoesView opcoesView = new OpcoesView();
            ConfiguracoesDeView.ConfigurarWindow(this, opcoesView);
            opcoesView.Show();
            this.Close();
        }
    }
}
