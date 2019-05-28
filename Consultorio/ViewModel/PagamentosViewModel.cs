using Consultorio.Data;
using Consultorio.Model;
using Consultorio.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Globalization;

namespace Consultorio.ViewModel
{
    public class PagamentosViewModel : INotifyPropertyChanged
    {
        private string _DataAtual;
        private double _ValorPagamento;
        private Cliente _Cliente;
        private string _FormaDePagamento;
        private string _Obs;

        public string Obs
        {
            get { return _Obs; }
            set { _Obs = value; OnPropertyChanged("Obs"); }
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
            DataAtual = DateTime.Now.ToString("dd/MM/yyyy");
        }

        public void SelecionarCliente()
        {
            SelecaoDeClientesView listaCliente = new SelecaoDeClientesView();
            listaCliente.ShowDialog();

            var aux = listaCliente.Cliente;
            if (aux.Id > 0)
            {
                Cliente = aux;
            }
        }

        public string SalvarNovoPagamento(out bool semErros)
        {
            Pagamento pag = new Pagamento();
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
            if (pagamento.Valor == 0)
            {
                lista.Add("Valor");
            }
            return lista;
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
