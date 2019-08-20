using Consultorio.Data.Atores;
using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Consultorio.ViewModel.Atores
{
    public class ListaDeAtoresViewModel : INotifyPropertyChanged
    {
        private List<Ator> _ListaDeAtores;

        public List<Ator> ListaDeAtores 
        {
            get { return _ListaDeAtores; }
            set { _ListaDeAtores = value; OnPropertyChanged("ListaDeAtores"); }
        }

        private Ator _AtorSelecionado;

        public Ator AtorSelecionado
        {
            get { return _AtorSelecionado; }
            set { _AtorSelecionado = value; OnPropertyChanged("AtorSelecionado"); }
        }

        public ListaDeAtoresViewModel()
        {
            ListaDeAtores = AtorData.TodosOsAtores();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        public bool ExisteAtorSelecionado()
        {
            if (AtorSelecionado == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void RecarregarDataGrid()
        {
            ListaDeAtores = AtorData.TodosOsAtores();
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
