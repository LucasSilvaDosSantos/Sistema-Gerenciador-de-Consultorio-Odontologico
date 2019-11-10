using Consultorio.Data.Atores;
using Consultorio.Model;
using Consultorio.ViewModel.Atores;
using System.ComponentModel;

namespace Consultorio.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public string Senha { get; set; }

        public SingletonAtorLogado AtorLogado { get; set; }

        private string _Login;

        public string Login
        {
            get { return _Login; }
            set { _Login = value; OnPropertyChanged("Login"); }
        }

        public LoginViewModel()
        {
            AtorLogado = SingletonAtorLogado.Instancia;
        }

        public bool VerificarEntrar()
        {
            Ator atorRetorno = LoginData.BuscarAtores(Login, out bool atorEncontrado);
            if (atorEncontrado)
            {
                string senhaCripitografada = AtorData.GerarHashMd5(Senha);
                if(atorRetorno.Senha.Equals(senhaCripitografada) && atorRetorno.Ativo){
                    AtorLogado.Ator = atorRetorno;
                    return true;                  
                }
            }
            return false;
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
