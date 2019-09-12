using Consultorio.Data.Consultas;
using Consultorio.Model;
using System.Collections.Generic;
using System.ComponentModel;

namespace Consultorio.ViewModel.Clientes
{
    public class SelecaoDeClienteViewModel : INotifyPropertyChanged
    {

        private List<Cliente> _ListaDeClientes;
        public List<Cliente> ListaDeClientes
        {
            get { return _ListaDeClientes; }
            set { _ListaDeClientes = value; OnPropertyChanged("ListaDeClientes"); }
        }

        public Cliente ClienteSelecionado { get; set; }

        public SelecaoDeClienteViewModel()
        {
            LimparListaDeCliente();
        }


        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        public void BtSelecionar_Click(int index)
        {
            SelecionarCliente(index);
        }

        public void BtCancelar_Click()
        {
            ClienteSelecionado = null;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        public void BuscarCliente(string id, string nome)
        {
            int.TryParse(id, out int idInt);
            if (idInt != 0 || (nome != "" && nome.Length >= 3))
            {
                ListaDeClientes = ListaDeClienteParaConsultaData.BuscarCliente(idInt, nome);
            }
            else
            {
                LimparListaDeCliente();
            }
        }

        private void SelecionarCliente(int index)
        {
            ClienteSelecionado = ListaDeClientes[index];
        }

        private void LimparListaDeCliente()
        {
            ListaDeClientes = new List<Cliente>();
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
