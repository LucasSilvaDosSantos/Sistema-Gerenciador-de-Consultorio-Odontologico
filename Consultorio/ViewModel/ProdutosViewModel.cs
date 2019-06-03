﻿using Consultorio.Data;
using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.ViewModel
{
    public class ProdutosViewModel : INotifyPropertyChanged
    {


        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Atributos**********-----------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        
        public SingletonAtorLogado AtorLogado { get; set; }

        private List<Produto> _TodosOsProdutos;
        public List<Produto> TodosOsProdutos
        {
            get { return _TodosOsProdutos; }
            set { _TodosOsProdutos = value; OnPropertyChanged("TodosOsProdutos"); }
        }

        private Produto _Produto;
        public Produto Produto
        {
            get { return _Produto; }
            set { _Produto = value; OnPropertyChanged("Produto"); }
        }

        public ProdutosViewModel()
        {
            Produto = new Produto();
            AtorLogado = SingletonAtorLogado.Instancia;
            CarregarTodosOsProdutos();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        public void DataGridSelect(int index)
        {
            if (index > 0)
            {
                SelecionarProduto(index);
            }
        }

        public int EditarProduto()
        {
            int.TryParse(Produto.Id.ToString(), out int id);
            if (id != 0)
            {
                return id;
            }
            return 0;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Metodos**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        public void ResetarTela()
        {
            LimparCampos();
        }

        private void CarregarTodosOsProdutos()
        {
            TodosOsProdutos = ProdutoData.ListarTodosProdutos();
        }

        private void LimparCampos()
        {
            Produto = new Produto();
        }

        private void SelecionarProduto(int i)
        {
            Produto = TodosOsProdutos[i];
        }

        public void BuscarNome(string nome)
        {
            if (nome == "")
            {
                CarregarTodosOsProdutos();
                return;
            }
            List<Produto> lista = ProdutoData.BuscarProdutosNome(nome, out bool encontrado);
            if (encontrado)
            {               
                TodosOsProdutos = lista;
            }
            else
            {
                TodosOsProdutos = null;
            }
        }

        public void BuscarId(string id)
        {
            if (id == "" || id == null)
            {
                CarregarTodosOsProdutos();
                return;
            }
            List<Produto> lista = ProdutoData.BuscarProdutosId(id, out bool encontrado);
            if (encontrado)
            {
                TodosOsProdutos = lista;
            }
            else
            {
                TodosOsProdutos = null;
            }
        }

        public void RecarregarGrid()
        {
            CarregarTodosOsProdutos();
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