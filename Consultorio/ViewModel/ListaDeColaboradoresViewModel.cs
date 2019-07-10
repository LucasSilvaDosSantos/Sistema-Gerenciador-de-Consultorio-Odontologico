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
            ListaDeColaboradoresView listaDeColaboradoresView = new ListaDeColaboradoresView(this);
            listaDeColaboradoresView.ShowDialog();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        public void BtVoltar_Click()
        {
            new CadastroDeColaboradoresViewModel();
        }

        public bool BtEditar_Click(int index)
        {
            Atores atorSelecionado = ListaDeAtores[index];
            string atorSelecionadoGetType = atorSelecionado.GetType().ToString();

            if (atorSelecionadoGetType == "Consultorio.Model.Dentista")
            {
                return EdicaoDentista((Dentista)atorSelecionado);   
            }

            else if (atorSelecionadoGetType == "Consultorio.Model.Secretaria")
            {
                return EdicaoSecretaria((Secretaria)atorSelecionado);
            }

            else if (atorSelecionadoGetType == "Consultorio.Model.GestorDeEstoque")
            {
                return EdicaoGestorDeEstoque((GestorDeEstoque)atorSelecionado);   
            }
            return false;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        private bool AltorizacaoDeAcesso(string tipoDeAtorParaEdicao)
        {
            string atorLogadoGetType = AtorLogado.Ator.GetType().Name.ToString();

            // altorizações para secretarias
            if (atorLogadoGetType == "Secretaria")
            {
                Secretaria secretaria = (Secretaria)AtorLogado.Ator;

                if (tipoDeAtorParaEdicao == "Dentista")
                {
                    return false;
                }

                else if (tipoDeAtorParaEdicao == "GestorDeEstoque")
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

                else if (tipoDeAtorParaEdicao == "Secretaria")
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

        private bool EdicaoDentista(Dentista dentista)
        {
            bool altorizacao = AltorizacaoDeAcesso("Dentista");

            if (altorizacao == false)
            {
                return false;
            }
            else
            {
                new DentistaViewModel(dentista);
                return true;
            }
        }

        private bool EdicaoSecretaria(Secretaria secretaria)
        {
            bool altorizacao = AltorizacaoDeAcesso("Secretaria");

            if (altorizacao == false)
            {
                return false;
            }
            else
            {
                new SecretariaViewModel(secretaria);
                return true;
            }
        }

        private bool EdicaoGestorDeEstoque(GestorDeEstoque gestorDeEstoque)
        {
            bool altorizacao = AltorizacaoDeAcesso("GestorDeEstoque");

            if (altorizacao == false)
            {
                return false;
            }
            else
            {
                new GestorDeEstoqueViewModel(gestorDeEstoque);
                return true;
            }
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
