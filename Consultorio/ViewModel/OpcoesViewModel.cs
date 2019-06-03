﻿using Consultorio.Data;
using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.ViewModel
{
    public class OpcoesViewModel : INotifyPropertyChanged
    {
        private bool _CrudClientes;
        private bool _CrudProdutos;
        private bool _Consultas;
        private bool _ClientesLista;
        private bool _NovoPagamento;
        private bool _Procedimentos;
        private bool _CadastroDeColaboradores;

        public bool CrudClientes
        {
            get { return _CrudClientes; }
            set { _CrudClientes = value; OnPropertyChanged("CrudClientes"); }
        }
        public bool CrudProdutos
        {
            get { return _CrudProdutos; }
            set { _CrudProdutos = value; OnPropertyChanged("CrudProdutos"); }
        }
        public bool Consultas
        {
            get { return _Consultas; }
            set { _Consultas = value; OnPropertyChanged("Consultas"); }
        }
        public bool ClientesLista
        {
            get { return _ClientesLista; }
            set { _ClientesLista = value; OnPropertyChanged("ClientesLista"); }
        }
        public bool NovoPagamento
        {
            get { return _NovoPagamento; }
            set { _NovoPagamento = value; OnPropertyChanged("NovoPagamento"); }
        }
        public bool Procedimentos
        {
            get { return _Procedimentos; }
            set { _Procedimentos = value; OnPropertyChanged("Procedimentos"); }
        }
        public bool CadastroDeColaboradores
        {
            get { return _CadastroDeColaboradores; }
            set { _CadastroDeColaboradores = value; OnPropertyChanged("CadastroDeColaboradores"); }
        }


        public SingletonAtorLogado AtorLogado { get; set; }

        public OpcoesViewModel()
        {
            AtorLogado = SingletonAtorLogado.Instancia;
            AutorizacaoDeAcesso();
        }

        public void AutorizacaoDeAcesso()
        {
            int tipoDoAtor = TipoDoAtor();
            if (tipoDoAtor == 1)
            {
                CrudClientes = true;
                CrudProdutos = true;
                Consultas = true;
                ClientesLista = true;
                NovoPagamento = true;
                Procedimentos = true;
                CadastroDeColaboradores = true;
            }
            else if (tipoDoAtor == 2)
            {
                Secretaria secretaria = (Secretaria)AtorLogado.Ator;
                CrudClientes = secretaria.CrudClientes;
                CrudProdutos = secretaria.CrudProdutos;
                Consultas = true;
                ClientesLista = true;
                NovoPagamento = true;
                Procedimentos = false;
                CadastroDeColaboradores = true;
            }
            else if (tipoDoAtor == 3)
            {
                CrudClientes = false;
                CrudProdutos = true;
                Consultas = false;
                ClientesLista = false;
                NovoPagamento = false;
                Procedimentos = false;
                CadastroDeColaboradores = false;
            }
        }

        public int TipoDoAtor()
        {
            if (AtorLogado.Ator.GetType().ToString() == "Consultorio.Model.Dentista")
            {
                return 1;
            }
            else if (AtorLogado.Ator.GetType().ToString() == "Consultorio.Model.Secretaria")
            {
                return 2;
            }
            else if (AtorLogado.Ator.GetType().ToString() == "Consultorio.Model.GestorDeEstoque")
            {
                return 3;
            }
            return 0;
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