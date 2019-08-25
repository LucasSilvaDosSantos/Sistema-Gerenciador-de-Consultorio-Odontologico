using Consultorio.Data.Pagamentos;
using Consultorio.Model;
using Consultorio.ViewModel.Atores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.ViewModel.Pagamentos
{
    public class ContaPagaViewModel : INotifyPropertyChanged
    {
        public ContaPaga ContaPaga{ get; set; }

        public List<string> ListaDeNome { get; set; }

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
            if (ContaPaga.Nome == "" || ContaPaga.Nome == null)
            {
                sb.Append("O nome não pode ficar em branco!\n");
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
            ListaDeNome = new List<string>
            {
                "Água",
                "Luz",
                "Aluguel",
                "Funcionário",
                "Produtos de Limpeza",
                "Internet",
                "Outros"
            };
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
