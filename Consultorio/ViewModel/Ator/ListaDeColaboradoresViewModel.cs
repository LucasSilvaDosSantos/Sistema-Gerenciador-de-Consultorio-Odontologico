using Consultorio.Data.Ator;
using Consultorio.Model;
using System.Collections.Generic;
using System.ComponentModel;

namespace Consultorio.ViewModel.Ator
{
    public class ListaDeColaboradoresViewModel : INotifyPropertyChanged
    {
        private List<Atores> _ListaDeAtores;
        public List<Atores> ListaDeAtores
        {
            get { return _ListaDeAtores;  }
            set { _ListaDeAtores = value; OnPropertyChanged("ListaDeAtores"); }
        }

        public SingletonAtorLogado AtorLogado { get; set; }

        public ListaDeColaboradoresViewModel()
        {
            ListaDeAtores = ColaboradoresData.ListarAtores();
            AtorLogado = SingletonAtorLogado.Instancia;
        }

        public Atores _AtorSelecionado { get; set; }

        public Atores AtorSelecionado
        {
            get { return _AtorSelecionado; }
            set { _AtorSelecionado = value; OnPropertyChanged("AtorSelecionado"); }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        public string TipoDeAtorSelecionado()
        {
            return AtorSelecionado.GetType().Name.ToString();          
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        public bool AltorizacaoDeAcesso()
        {
            string atorLogadoGetType = AtorLogado.Ator.GetType().Name.ToString();

            // altorizações para secretarias
            if (atorLogadoGetType == "Secretaria")
            {
                Secretaria secretaria = (Secretaria)AtorLogado.Ator;

                if (AtorSelecionado.GetType().Name == "Dentista")
                {
                    return false;
                }

                else if (AtorSelecionado.GetType().Name == "GestorDeEstoque")
                {
                    if (secretaria.CrudGestoresDeEstoque == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                else if (AtorSelecionado.GetType().Name == "Secretaria")
                {
                    if (secretaria.CrudSecretarias == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            else if (atorLogadoGetType == "Dentista")
            {
                return true;
            }

            else if (atorLogadoGetType == "GestorDeEstoque")
            {
                return false;
            }

            return false;
        }

        public Dentista EdicaoDentista()
        {
            return (Dentista)AtorSelecionado;
        }

        public Secretaria EdicaoSecretaria()
        {
            return (Secretaria)AtorSelecionado;
        }

        public GestorDeEstoque EdicaoGestorDeEstoque()
        {
            return (GestorDeEstoque)AtorSelecionado;
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
