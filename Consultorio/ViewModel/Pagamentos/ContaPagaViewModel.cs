using Consultorio.Data.Pagamentos;
using Consultorio.Model;
using Consultorio.ViewModel.Atores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Consultorio.ViewModel.Pagamentos
{
    public class ContaPagaViewModel : INotifyPropertyChanged
    {
        public ContaPaga ContaPaga{ get; set; }

        private List<TipoDeContaPaga> _ListaDeTipo;

        public List<TipoDeContaPaga> ListaDeTipo
        {
            get { return _ListaDeTipo; }
            set { _ListaDeTipo = value; OnPropertyChanged("ListaDeTipo"); }
        }


        public ContaPagaViewModel()
        {
            ContaPaga = new ContaPaga{ DataDePagamento = DateTime.Now, QuemCadastrou = SingletonAtorLogado.Instancia.Ator };

            IniciarListaDeNome();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Metodos**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        public string SalvarContaPaga()
        {
            if (TodosOsCamposValidos(out _))
            {
                return ContaPagaData.SalvarContaPaga(ContaPaga); 
            }
            return "Campos Invalidos!";
        }

        public bool TodosOsCamposValidos(out string msg)
        {
            StringBuilder sb = new StringBuilder();
            if (ContaPaga.Tipo == null)
            {
                sb.Append("O tipo não pode ficar em branco!\n");
            }
            if (ContaPaga.DataDePagamento > DateTime.Now)
            {
                sb.Append("A conta não pode ser cadastrada com data de pagamento para o futuro!");
            }
            msg = sb.ToString();

            if (msg == "" || msg == null)
            {
                return true;
            }
            return false;
        }

        private void IniciarListaDeNome()
        {
            ListaDeTipo = ContaPagaData.TiposDeContaPaga();
        }

        public bool AdicionarNovoTipoDeDeConta(string novoTipo)
        {
            bool valido = VerificarCadastroDeNomeDoNovoTipoValido(novoTipo);
            if (valido == true)
            {
                var salvo = ContaPagaData.NovoTipoDeConta(novoTipo);
                IniciarListaDeNome();
                return salvo;
            }
            return false;
        }

        public bool VerificarCadastroDeNomeDoNovoTipoValido(string nomeNovotipo)
        {
            foreach (var item in ListaDeTipo)
            {
                if (item.Tipo == nomeNovotipo)
                {
                    return false;
                }
            }         
            return true;
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
