using Consultorio.Data;
using Consultorio.Model;
using Consultorio.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.ViewModel
{
    public class ConsultasViewModel : INotifyPropertyChanged
    {
        public SingletonAtorLogado AtorLogado { get; set; }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Atributos**********-----------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------


        private bool _CalendarioAtivo;

        public bool CalendarioAtivo
        {
            get { return _CalendarioAtivo; }
            set { _CalendarioAtivo = value; OnPropertyChanged("CalendarioAtivo"); }
        }

        private List<Consulta> _ListaDeConsultas;

        public List<Consulta> ListaDeConsultas
        {
            get { return _ListaDeConsultas; }
            set { _ListaDeConsultas = value; OnPropertyChanged("ListaDeConsultas"); }
        }

        private DateTime _DataSelecionada;

        public DateTime DataSelecionada
        {
            get { return _DataSelecionada; }
            set { _DataSelecionada = value; OnPropertyChanged("DataSelecionada"); }
        }

        public Consulta ConsultaSelecionada { get; set; }

        public ConsultasViewModel()
        {
            CalendarioAtivo = true;
            AtorLogado = SingletonAtorLogado.Instancia;
            DataSelecionada = DateTime.Now;
            CarregarListaDeConsultasData();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        public void Calendar_SelectedDatesChanged(DateTime data)
        {
            DataSelecionada = data;
            CarregarListaDeConsultasData();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Metodos**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        public void CarregarListaDeConsultasData()
        {
            ListaDeConsultas = ConsultasData.ListaDeConsultas(DataSelecionada);
        }

        public void DataGridSelect(int index)
        {
            if (index >= 0)
            {
                SelecionarConsulta(index);
            }
        }

        private void SelecionarConsulta(int index)
        {
            ConsultaSelecionada = ListaDeConsultas[index];
        }

        public void CrudConsuta()
        {
            if (ConsultaSelecionada != null)
            {
                CrudConsultasView crudConsultasView = new CrudConsultasView(ConsultaSelecionada.Id);
                crudConsultasView.ShowDialog();

                CarregarListaDeConsultasData();
            }
        }

        public void BuscarConsultaId(string id)
        {

            if (id == "")
            {
                DataSelecionada = DateTime.Now;
                CarregarListaDeConsultasData();
                CalendarioAtivo = true;
                return;
            }
            var teste = int.TryParse(id, out int idInt);
            if (teste == true)
            {
                CalendarioAtivo = false;
                ListaDeConsultas = ConsultasData.BuscarConsultaPorClienteId(idInt);
            }            
        }

        public void BuscarConsultaCliente(string nome)
        {
            if(nome == "")
            {
                DataSelecionada = DateTime.Now;  
                CarregarListaDeConsultasData();
                CalendarioAtivo = true;
                return;
            }
            CalendarioAtivo = false;
            ListaDeConsultas = ConsultasData.BuscarConsultaPorClienteNome(nome);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********PropertyChanged**********-----------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string NameProperty)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(NameProperty));
            }
        }
    }
}
