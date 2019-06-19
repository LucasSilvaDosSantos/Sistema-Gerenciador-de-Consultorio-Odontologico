using Consultorio.Model;
using Consultorio.Data;
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
    /// Lógica interna para HistoricoDoCliente.xaml
    /// </summary>
    public partial class HistoricoDoClienteView : Window
    {
        

        public HistoricoDoClienteView()
        {
            InitializeComponent();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------



        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            ListaDeClientesView listaDeClientes = new ListaDeClientesView();
            listaDeClientes.Show();
            this.Close();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        public void IniciarCliente(Cliente cliente)
        {
            tbId.Text = cliente.Id.ToString();
            tbNome.Text = cliente.Nome;

            GerarDGPagamentos(cliente.Id);
            GerarDGProcedimentos(cliente.Id);

            var pagamentos = HistoricoDoClienteData.ListarPagamentosPorCliente(cliente.Id);
            var consultas = HistoricoDoClienteData.ListarConsultaPorCliente(cliente.Id);

            double somaPagamentos = 0;
            double somaConsultas = 0;


            foreach(var i in pagamentos)
            {
                somaPagamentos += i.Valor;
            }

            foreach(var i in consultas)
            {
                if (i.Realizada == true)
                {
                    somaConsultas += i.ValorConsulta;
                }               
            }

            tbTotalDevido.Text = (somaConsultas - somaPagamentos).ToString("c");
        }

        private void GerarDGPagamentos(int id)
        {
            dgPagamentos.ItemsSource = HistoricoDoClienteData.ListarPagamentosPorCliente(id);
            (dgPagamentos.Columns[3] as DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy";
        }

        private void GerarDGProcedimentos(int id)
        {
            dgProcedimentos.ItemsSource = HistoricoDoClienteData.ListarConsultaPorCliente(id);
            (dgProcedimentos.Columns[1] as DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy";
            (dgProcedimentos.Columns[2] as DataGridTextColumn).Binding.StringFormat = "HH:mm";
            (dgProcedimentos.Columns[3] as DataGridTextColumn).Binding.StringFormat = "HH:mm";
        }
    }
}