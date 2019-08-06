using Consultorio.Data.Clientes;
using Consultorio.Data.Pagamentos;
using Consultorio.Model;
using Consultorio.ViewModel.Atores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Consultorio.ViewModel.Procedimentos
{
    public class PagamentosViewModel : INotifyPropertyChanged
    {
        private string _DataAtual;
        private double _ValorPagamento;
        private Cliente _Cliente;
        private string _FormaDePagamento;
        private string _Obs;
        private double _ValorDevidoPorCliente;

        public SingletonAtorLogado AtorLogado { get; set; }

        public double ValorDevidoPorCliente
        {
            get { return _ValorDevidoPorCliente; }
            set { _ValorDevidoPorCliente = value; OnPropertyChanged("ValorDevidoPorCliente"); }
        }

        public string Obs
        {
            get { return _Obs; }
            set { _Obs = value; OnPropertyChanged("Obs"); }
        }

        private List<string> _ListaFormaDePagamento;

        public List<string> ListaFormaDePagamento
        {
            get { return _ListaFormaDePagamento; }
            set { _ListaFormaDePagamento = value; OnPropertyChanged("ListaFormaDePagamento"); }
        }

        public string FormaDePagamento
        {
            get { return _FormaDePagamento; }
            set { _FormaDePagamento = value; OnPropertyChanged("FormaDePagamento"); }
        }

        public Cliente Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; OnPropertyChanged("Cliente"); }
        }

        public string DataAtual
        {
            get { return _DataAtual; }
            set { _DataAtual = value; OnPropertyChanged("DataAtual"); }
        }

        public double ValorPagamento
        {
            get { return _ValorPagamento; }
            set { _ValorPagamento = value; OnPropertyChanged("ValorPagamento"); }
        }

        public PagamentosViewModel()
        {
            AtorLogado = SingletonAtorLogado.Instancia;
            ListaFormaDePagamento = CarregarListaFormaPagamento();
            DataAtual = DateTime.Now.ToString("dd/MM/yyyy");
            CarregarListaFormaPagamento();
        }

        private List<string> CarregarListaFormaPagamento()
        {
            List<string> lista = new List<string>();
            lista.Add("Dinheiro");
            lista.Add("Cartão de Crédito");
            lista.Add("Cartão de Débito");
            return lista;
        }

        /*public void AtualizarDivida()
        {
            
            //lista

            var aux = istaClienteViewModel.Cliente;
            if (aux != null && aux.Id > 0 )
            {
                Cliente = aux;
                CarregarValorDevido();
            }*
        }*/

        public string SalvarNovoPagamento(out bool semErros)
        {
            Pagamento pag = new Pagamento();
            pag.Recebedor = AtorLogado.Ator;
            pag.Cliente = Cliente;
            pag.DataDePagamento = DateTime.Parse(DataAtual);
            pag.Valor = ValorPagamento;
            pag.FormaDePagamento = FormaDePagamento;
            pag.Obs = Obs;

            var camposObrigatorios = ValidarCamposObrigatorios(pag);
            if (camposObrigatorios.Count != 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (string i in camposObrigatorios)
                {
                    sb.Append($"{i}, ");
                }
                semErros = true;
                return sb.ToString();
            }
            else
            {
                string msg = PagamentosData.CadastrarNovoPagamento(pag);
                semErros = false;
                return msg;
            }            
        }

        public List<string> ValidarCamposObrigatorios(Pagamento pagamento)
        {
            List<string> lista = new List<string>();
            if (pagamento.Cliente == null)
            {
                lista.Add("Cliente");
            }
            if (pagamento.FormaDePagamento == null)
            {
                lista.Add("Forma de Pagamento");
            }
            if (pagamento.Valor <= 0)
            {
                lista.Add("Valor");
            }
            return lista;
        }

        public void CarregarValorDevido()
        {
            var pagamentos = HistoricoDoClienteData.ListarPagamentosPorCliente(Cliente.Id);
            var consultas = HistoricoDoClienteData.ListarConsultaPorCliente(Cliente.Id);

            double somaPagamentos = 0;
            double somaConsultas = 0;


            foreach (var i in pagamentos)
            {
                somaPagamentos += i.Valor;
            }

            foreach (var i in consultas)
            {
                if (i.Realizada == true)
                {
                    somaConsultas += i.ValorConsulta;
                }
            }

            ValorDevidoPorCliente = (somaConsultas - somaPagamentos);

            /*double soma = 0;
            var lista = HistoricoDoClienteData.ListarConsultaPorCliente(Cliente.Id);
            foreach(var i in lista)
            {
                soma += i.ValorConsulta;
            }
            ValorDevidoPorCliente = soma;*/
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
