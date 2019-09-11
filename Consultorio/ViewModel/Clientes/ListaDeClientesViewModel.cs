using Consultorio.Data.Clientes;
using Consultorio.Model;
using Consultorio.ViewModel.Atores;
using System.Collections.Generic;
using System.ComponentModel;

namespace Consultorio.ViewModel.Clientes
{
    public class ListaDeClientesViewModel : INotifyPropertyChanged
    {
        private Cliente _clienteSelecionado;
        public Cliente ClienteSelecionado
        {
            get { return _clienteSelecionado; }
            set { _clienteSelecionado = value; OnPropertyChanged("ClienteSelecionado"); }
        }

        public SingletonAtorLogado AtorLogado { get; set; }

        private bool _BtCancelarIsEnabled;
        public bool BtCancelarIsEnabled
        {
            get { return _BtCancelarIsEnabled; }
            set { _BtCancelarIsEnabled = value; OnPropertyChanged("BtCancelarIsEnabled"); }
        }

        private bool _BtEnabled;
        public bool BtEnabled
        {
            get { return _BtEnabled; }
            set { _BtEnabled = value; OnPropertyChanged("BtEnabled"); }
        }

        private List<Cliente> _ListaDeClientes;
        public List<Cliente> ListaDeClientes
        {
            get { return _ListaDeClientes; }
            set { _ListaDeClientes = value; OnPropertyChanged("ListaDeClientes"); }
        }

        public ListaDeClientesViewModel()
        {
            AtorLogado = SingletonAtorLogado.Instancia;

            ListarTodosOsClientes();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        public void DgListaDeClientes_SelectionChanged()
        {
            BtEnabled = true;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------


        public bool AltorizacaoDeEdicao()
        {
            Ator atorLogado = AtorLogado.Ator;
            return atorLogado.CrudClientes;
        }

        public void ListarTodosOsClientes()
        {
            ListaDeClientes = new List<Cliente>(); //ListaDeClienteData.TodosClientes();
            BtEnabled = false;
        }

        public Cliente ClienteSelecionadoNaLista(int index)
        {
            return ListaDeClientes[index];
        }

        public void BuscarCliente(string id, string nome, string cpf)
        {
            int.TryParse(id, out int idInt);
            if (nome.Length >= 3 || cpf.Length >= 3 || idInt > 0)
            {
                if (idInt != 0 || nome != "" || cpf != "")
                {
                    ListaDeClientes = ListaDeClienteData.BuscarCliente(idInt, nome, cpf);
                    BtCancelarIsEnabled = true;
                }
            }           
            else
            {
                ListarTodosOsClientes();
                BtCancelarIsEnabled = false;
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
