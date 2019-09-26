using Consultorio.Data.Consultas;
using Consultorio.Data.Pagamentos;
using Consultorio.Model;
using Consultorio.ViewModel.Atores;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace Consultorio.ViewModel.Relatorios
{
    public class RelatorioHistoricoDoClienteViewModel : INotifyPropertyChanged
    {
        public Ator AtorLogado { get; set; } = SingletonAtorLogado.Instancia.Ator;

        public double SomaConsultaRealizada { get; set; }

        private Cliente _Cliente;
        public Cliente Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; OnPropertyChanged("Cliente"); }
        }

        public RelatorioHistoricoDoClienteViewModel()
        {
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********MetodosDataTable**********----------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        public DataTable CarregarDataCliente()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Nome");
            dataTable.Columns.Add("Telefone1");
            dataTable.Columns.Add("Telefone2");
            dataTable.Columns.Add("Email");

            dataTable.Rows.Add(Cliente.Id, Cliente.Nome, Cliente.Telefone1, Cliente.Telefone2, Cliente.Email);

            return dataTable;
        }

        public DataTable CarregarConsultas(DateTime inicio, DateTime fim)
        {
            fim = fim.AddDays(1);
            var listaDeConsutas = ConsultasData.BuscarConsultaPorClienteId(Cliente.Id);
            listaDeConsutas = listaDeConsutas.Where(a => a.Inicio >= inicio && a.Fim <= fim).ToList();

            var datatable = new DataTable();
            datatable.Columns.Add("Id");
            datatable.Columns.Add("Inicio", typeof(DateTime));
            datatable.Columns.Add("Fim", typeof(DateTime));
            datatable.Columns.Add("Procedimento");
            datatable.Columns.Add("Status");
            datatable.Columns.Add("ValorConsulta", typeof(double));

            SomaConsultaRealizada = 0;

            foreach (var item in listaDeConsutas)
            {
                datatable.Rows.Add(item.Id, item.Inicio, item.Fim, item.Procedimento.Nome, item.Status, item.ValorConsulta);
                if (item.Status == Model.Enums.StatusConsulta.Realizada)
                {
                    SomaConsultaRealizada += item.ValorConsulta;
                }
            }

            return datatable;
        }

        public DataTable CarregarPagamentos(DateTime inicio, DateTime fim)
        {
            var listaDePagamentos = PagamentosData.CarragarPagamentosporDataECliente(Cliente.Id, inicio, fim);

            var dataTable = new DataTable();
            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("DataDePagamento", typeof(DateTime));
            dataTable.Columns.Add("FormaDePagamento");
            dataTable.Columns.Add("Valor", typeof(double));
            dataTable.Columns.Add("Recebedor");
            dataTable.Columns.Add("Obs");

            foreach(var item in listaDePagamentos)
            {
                dataTable.Rows.Add(item.Id, item.DataDePagamento, item.FormaDePagamento, item.Valor, item.Recebedor.Nome, item.Obs);
            }
            return dataTable;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********PropertyChanged**********-----------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string NameProperty)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(NameProperty));
        }
    }
}