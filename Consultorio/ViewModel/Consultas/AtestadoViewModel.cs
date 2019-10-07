using Consultorio.Data.Consultas;
using Consultorio.Model;
using Consultorio.ViewModel.Atores;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace Consultorio.ViewModel.Consultas
{
    public class AtestadoViewModel : INotifyPropertyChanged
    {
        private Cliente _Cliente;
        public Cliente Cliente{
            get { return _Cliente; }
            set { _Cliente = value; OnPropertyChanged("Cliente"); }
        }

        public Consulta Consulta { get; set; }

        public Ator AtorLogado { get; set; } = SingletonAtorLogado.Instancia.Ator;

        public AtestadoViewModel()
        {

        }

        public void SetConsulta(Consulta consulta)
        {
            Consulta = consulta;
            Cliente = consulta.Cliente;
            OnPropertyChanged("Cliente");
            OnPropertyChanged("Consulta");
        }


        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********metodos**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        public void SalvarLog(Dictionary<string, string> dictionary)
        {
            ConsultasData.SalvarLogDeAtestadosGerados(dictionary);
        }

        public string MontarEnd()
        {
            string end = ($"{Cliente.Endereco}, {Cliente.Bairro}, {Cliente.Cidade}-{Cliente.Uf}");
            return end;
        }

        public DataTable CarregarDataCliente()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("Nome");
            dataTable.Columns.Add("Rg");
            dataTable.Columns.Add("Endereco");
            dataTable.Columns.Add("Bairro");
            dataTable.Columns.Add("Cidade");
            dataTable.Columns.Add("Uf"); 

            dataTable.Rows.Add(Cliente.Nome, Cliente.Rg, Cliente.Endereco, Cliente.Bairro, Cliente.Cidade, Cliente.Uf);

            return dataTable;
        }

        public DataTable CarregarDentista()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("Nome");
            dataTable.Columns.Add("Crosp");

            dataTable.Rows.Add(AtorLogado.Nome, AtorLogado.Crosp);

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
