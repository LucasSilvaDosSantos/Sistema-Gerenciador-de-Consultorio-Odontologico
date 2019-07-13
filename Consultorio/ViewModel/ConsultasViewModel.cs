﻿using Consultorio.Data;
using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;

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

        private Consulta _ConsultaSelecionada;

        public Consulta ConsultaSelecionada
        {
            get { return _ConsultaSelecionada; }
            set { _ConsultaSelecionada = value; OnPropertyChanged("ConsultaSelecionada"); }
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

        /*public void Calendar_SelectedDatesChanged(DateTime data)
        {
            DataSelecionada = data;
            CarregarListaDeConsultasData();
        }*/

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Metodos**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        public void CarregarListaDeConsultasData()
        {
            ListaDeConsultas = ConsultasData.ListaDeConsultas(DataSelecionada);
        }

        public int ConsultaSelecionadaID()
        {
            return ConsultaSelecionada.Id;
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
