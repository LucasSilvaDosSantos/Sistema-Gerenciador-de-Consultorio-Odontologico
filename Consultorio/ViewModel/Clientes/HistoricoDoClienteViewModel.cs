using Consultorio.Data.Clientes;
using Consultorio.Model;
using System.Collections.Generic;
using System.ComponentModel;

namespace Consultorio.ViewModel.Clientes
{
    public class HistoricoDoClienteViewModel : INotifyPropertyChanged
    {
        private double _ValorDevido;

        public double ValorDevido
        {
            get { return _ValorDevido; }
            set { _ValorDevido = value; OnPropertyChanged("ValorDevido"); }
        }

        private Cliente _Cliente;
        public Cliente Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; OnPropertyChanged("Cliente"); }
        }

        private List<Pagamento> _ListaDePagamentos;

        public List<Pagamento> ListaDePagamentos
        {
            get { return _ListaDePagamentos; }
            set { _ListaDePagamentos = value; OnPropertyChanged("ListaDePagamentos"); }
        }

        private List<Consulta> _ListaDeConsultas;

        public List<Consulta> ListaDeConsultas
        {
            get { return _ListaDeConsultas; }
            set { _ListaDeConsultas = value; OnPropertyChanged("ListaDeConsultas"); }
        }

        public HistoricoDoClienteViewModel()
        {

        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Metodo**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        public void IniciarViewModel(Cliente cliente)
        {
            Cliente = cliente;

            ListaDeConsultas = HistoricoDoClienteData.ListarConsultaPorCliente(Cliente.Id);

            ListaDePagamentos = HistoricoDoClienteData.ListarPagamentosPorCliente(Cliente.Id);

            double somaPagamentos = 0;
            double somaConsultas = 0;


            foreach (var i in ListaDePagamentos)
            {
                somaPagamentos += i.Valor;
            }

            foreach (var i in ListaDeConsultas)
            {
                if (i.Realizada == true)
                {
                    somaConsultas += i.ValorConsulta;
                }
            }

            ValorDevido = somaConsultas - somaPagamentos;
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
