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

        private Ator _AtorLogado;
        public Ator AtorLogado
        {
            get { return _AtorLogado; }
            set { _AtorLogado = value; OnPropertyChanged("AtorLogado"); }
        }

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
