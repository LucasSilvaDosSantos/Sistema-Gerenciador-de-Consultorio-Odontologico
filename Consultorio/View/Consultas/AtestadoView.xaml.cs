using Consultorio.Data.Consultas;
using Consultorio.View.Relatorios;
using Consultorio.ViewModel.Consultas;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;

namespace Consultorio.View.Consultas
{
    /// <summary>
    /// Lógica interna para AtestadoView.xaml
    /// </summary>
    public partial class AtestadoView : Window
    {
        public AtestadoViewModel AtestadoViewModel { get; set; } = new AtestadoViewModel();
        public AtestadoView()
        {
            DataContext = AtestadoViewModel;
            InitializeComponent();

            dpDiaDoAtestado.SelectedDate = DateTime.Now;
            dtDia.SelectedDate = DateTime.Now;
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void IniciarTela()
        {
            tbEnd.Text = AtestadoViewModel.MontarEnd();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void BtGerarAtestado_Click(object sender, RoutedEventArgs e)
        {
            var existemCamposInvalidos = ExistemCamposInvalidos(out List<string> listaCamposInvalidos);
            if (existemCamposInvalidos == false)
            {
                DataTable dataTableAtor = AtestadoViewModel.CarregarDentista();
                DataTable dataTableCliente = AtestadoViewModel.CarregarDataCliente();

                ReportDataSource dataSourceAtor = new ReportDataSource("Dentista", dataTableAtor);
                ReportDataSource dataSourceCliente = new ReportDataSource("Cliente", dataTableCliente);

                List<ReportDataSource> listaDatasource = new List<ReportDataSource>() { dataSourceAtor, dataSourceCliente };

                List<string> listaDeParametros = new List<string>()
                {
                    tbAtestadoParaFim.Text,
                    tbHorarioInicio.Text,
                    tbHorarioFim.Text,
                    dpDiaDoAtestado.SelectedDate.ToString(),
                    tbDiasDeRepousoNumero.Text,
                    tbDiasDeRepousoExtenso.Text,
                    dtDia.SelectedDate.ToString(),
                    tbCid.Text
                };

                var dicionario = new Dictionary<string, string>();
                dicionario.Add("Id", AtestadoViewModel.Consulta.Cliente.Id.ToString());
                dicionario.Add("Finalidade", tbAtestadoParaFim.Text);
                dicionario.Add("Inicio", tbHorarioInicio.Text);
                dicionario.Add("Fim", tbHorarioFim.Text);
                dicionario.Add("Data", dpDiaDoAtestado.SelectedDate.ToString());
                dicionario.Add("AfastamentoDias", tbDiasDeRepousoNumero.Text);
                dicionario.Add("Cid", tbCid.Text);

                AtestadoViewModel.SalvarLog(dicionario);

                CarregarRelatorio(listaDatasource, listaDeParametros);
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (var i in listaCamposInvalidos)
                {
                    sb.Append($"{i} \n");
                }
                MessageBox.Show(sb.ToString(), "Aviso!");
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Metodos**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        private void CarregarRelatorio(List<ReportDataSource> listaDeDataSources, List<string> listaDeParametros)
        {
            RelatorioAtestadoView relatorioAtestadoView = new RelatorioAtestadoView(listaDeDataSources, listaDeParametros);
            ConfiguracoesDeView.ConfigurarWindow(this, relatorioAtestadoView);
            relatorioAtestadoView.ShowDialog();
        }

        private bool ExistemCamposInvalidos(out List<string> CamposInvalidos)
        {
            CamposInvalidos = new List<string>();
            if (tbAtestadoParaFim == null || tbAtestadoParaFim.Text == "")
                CamposInvalidos.Add("O campo após (atesto para fim de:) não pode ficar vazio.");
            if (AtestadoViewModel.Cliente == null || AtestadoViewModel.Cliente.Id == 0)
                CamposInvalidos.Add("Um cliente deve ser selecionado.");
            if (string.IsNullOrWhiteSpace(tbHorarioInicio.Text) || string.IsNullOrWhiteSpace(tbHorarioFim.Text))
                CamposInvalidos.Add("Os horarios devem ser preenchidos.");    
            var inicio = DateTime.Parse(tbHorarioInicio.Text);
            var fim = DateTime.Parse(tbHorarioFim.Text);
            if(inicio > fim)
                CamposInvalidos.Add("A hora inicial não pode ser menor que a hora final");
            if (dpDiaDoAtestado.SelectedDate == null)
                CamposInvalidos.Add("A data da consulta deve ser selecionada.");
            if (tbDiasDeRepousoNumero.Text == "" || tbDiasDeRepousoNumero.Text == null || tbDiasDeRepousoExtenso.Text == "" || tbDiasDeRepousoExtenso.Text == null)
                CamposInvalidos.Add("Os dias de repouso devem ser preenchidas.");
            if (dtDia.SelectedDate == null)
                CamposInvalidos.Add("A data de preenchimento do atestado deve ser selecionada.");
            if (tbCid == null || tbCid.Text == "")
                CamposInvalidos.Add("O C.I.D deve ser preenchido.");

            if (CamposInvalidos.Count == 0)
            {
                return false;
            }
            return true;
        }

        private void ListaDeHorario(out List<string> listaHorasEntrada, out List<string> listaMinutosEntrada)
        {
            listaHorasEntrada = new List<string>();
            listaMinutosEntrada = new List<string>();
            for (int i = 9; i <= 18; i++)
            {
                if (i.ToString().Count() == 1)
                {
                    listaHorasEntrada.Add("0" + i.ToString());
                }
                else
                {
                    listaHorasEntrada.Add(i.ToString());
                }

            }
            for (int i = 0; i < 60; i += 5)
            {
                if (i.ToString().Count() == 1)
                {
                    listaMinutosEntrada.Add("0" + i.ToString());
                }
                else
                {
                    listaMinutosEntrada.Add(i.ToString());
                }
            }
        }
    }
}
