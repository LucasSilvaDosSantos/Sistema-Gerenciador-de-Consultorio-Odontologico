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

        private bool _BtHistoricoIsEnabled;
        public bool BtHistoricoIsEnabled
        {
            get { return _BtHistoricoIsEnabled; }
            set { _BtHistoricoIsEnabled = value; OnPropertyChanged("BtHistoricoIsEnabled"); }
        }

        private bool _BtAlterarIsEnabled;
        public bool BtAlterarIsEnabled
        {
            get { return _BtAlterarIsEnabled; }
            set { _BtAlterarIsEnabled = value; OnPropertyChanged("BtAlterarIsEnabled"); }
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
            BtAlterarIsEnabled = true;
            BtHistoricoIsEnabled = true;
        }

        public void BtCancelar_Click()
        {
            ListarTodosOsClientes();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------


        public bool AltorizacaoDeEdicao()
        {
            Ator atorLogado = AtorLogado.Ator;
            return atorLogado.CrudClientes;
        }

        /*public void AlteracaoDeCliente(int index, CadastroDeClienteBaseViewModel cadastroDeClienteBaseViewModel)
        {
            Cliente cliente = ListaDeClientes[index];

            cadastroDeClienteBaseViewModel.Cliente = cliente;
        }*/

        public void ListarTodosOsClientes()
        {
            ListaDeClientes = ListaDeClienteData.TodosClientes();
            BtCancelarIsEnabled = false;
            BtHistoricoIsEnabled = false;
            BtAlterarIsEnabled = false;
        }

        public Cliente ClienteSelecionadoNaLista(int index)
        {
            return ListaDeClientes[index];
        }

        public void BuscarCliente(string id, string nome)
        {
            int.TryParse(id, out int idInt);
            if (idInt != 0 || nome != "" )
            {
                ListaDeClientes = ListaDeClienteData.BuscarCliente(idInt, nome);
                BtCancelarIsEnabled = true;
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
