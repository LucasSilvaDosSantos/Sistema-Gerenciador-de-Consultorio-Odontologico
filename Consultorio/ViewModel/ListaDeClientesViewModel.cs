using Consultorio.Data;
using Consultorio.Model;
using Consultorio.View;
using System.Collections.Generic;
using System.ComponentModel;

namespace Consultorio.ViewModel
{
    public class ListaDeClientesViewModel : INotifyPropertyChanged
    {
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

            ListaDeClientesView listaDeClientesView = new ListaDeClientesView(this);
            listaDeClientesView.Show();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        public void BtVoltar_Click()
        {
            new OpcoesViewModel();
        }

        public void DgListaDeClientes_SelectionChanged()
        {
            BtAlterarIsEnabled = true;
            BtHistoricoIsEnabled = true;
        }

        public void BtCancelar_Click()
        {
            ResetarTela();
        }

        public void BtHistorico_Click(int index)
        {
            HistoricoDoCliente(index);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        public bool AltorizacaoDeEdicao()
        {
            string atorLogadoType = AtorLogado.Ator.GetType().Name;
            if (atorLogadoType == "Secretaria")
            {
                Secretaria secretaria = (Secretaria)AtorLogado.Ator;
                if (secretaria.CrudClientes == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public void AlteracaoDeCliente(int index)
        {
            Cliente cliente = ListaDeClientes[index];
            new CadastroDeClienteBaseViewModel(cliente);
            ResetarTela();
        }

        private void ResetarTela()
        {
            ListarTodosOsClientes();
        }

        private void ListarTodosOsClientes()
        {
            ListaDeClientes = ListaDeClienteData.TodosClientes();
            BtCancelarIsEnabled = false;
            BtHistoricoIsEnabled = false;
            BtAlterarIsEnabled = false;
        }

        private void HistoricoDoCliente(int index)
        {
            // alterar para viewModel quando for feito 
            Cliente cliente = ListaDeClientes[index];
            HistoricoDoClienteView historicoDoClienteView = new HistoricoDoClienteView();
            historicoDoClienteView.IniciarCliente(cliente);
            historicoDoClienteView.Show();
            ResetarTela();
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
                ResetarTela();
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
