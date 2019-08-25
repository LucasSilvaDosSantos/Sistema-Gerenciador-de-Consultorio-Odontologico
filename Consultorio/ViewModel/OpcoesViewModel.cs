using Consultorio.Model;
using Consultorio.ViewModel.Atores;
using System.ComponentModel;

namespace Consultorio.ViewModel
{
    public class OpcoesViewModel : INotifyPropertyChanged
    {
        private string _Saudacao;
        public string Saudacao
        {
            get { return _Saudacao; }
            set { _Saudacao = value; OnPropertyChanged("Saudacao"); }
        }

        /*private bool _CrudClientes;
        private bool _CrudProdutos;
        private bool _Consultas;
        private bool _ClientesLista;
        private bool _NovoPagamento;
        private bool _Procedimentos;
        private bool _CadastroDeColaboradores;
        
        public bool CrudClientes
        {
            get { return _CrudClientes; }
            set { _CrudClientes = value; OnPropertyChanged("CrudClientes"); }
        }
        public bool CrudProdutos
        {
            get { return _CrudProdutos; }
            set { _CrudProdutos = value; OnPropertyChanged("CrudProdutos"); }
        }
        public bool Consultas
        {
            get { return _Consultas; }
            set { _Consultas = value; OnPropertyChanged("Consultas"); }
        }
        public bool ClientesLista
        {
            get { return _ClientesLista; }
            set { _ClientesLista = value; OnPropertyChanged("ClientesLista"); }
        }
        public bool NovoPagamento
        {
            get { return _NovoPagamento; }
            set { _NovoPagamento = value; OnPropertyChanged("NovoPagamento"); }
        }
        public bool Procedimentos
        {
            get { return _Procedimentos; }
            set { _Procedimentos = value; OnPropertyChanged("Procedimentos"); }
        }
        public bool CadastroDeColaboradores
        {
            get { return _CadastroDeColaboradores; }
            set { _CadastroDeColaboradores = value; OnPropertyChanged("CadastroDeColaboradores"); }
        }*/

        private Ator _AtorLogado;
        public Ator AtorLogado
        {
            get { return _AtorLogado; }
            set { _AtorLogado = value; OnPropertyChanged("AtorLogado"); }
        }

        //public SingletonAtorLogado AtorLogado { get; set; }

        public OpcoesViewModel()
        {
            AtorLogado = SingletonAtorLogado.Instancia.Ator;

            MensagemDeBoasVindas();
        }

        private void MensagemDeBoasVindas()
        {
            var list = AtorLogado.Nome.Split(' ');
            Saudacao = "Bem Vindo " + list[0] + "!";
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
