using Consultorio.Data.Ator;
using Consultorio.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Consultorio.ViewModel.Ator
{
    public class DentistaViewModel : INotifyPropertyChanged
    {
        private Dentista _Dentista;

        public Dentista Dentista
        {
            get { return _Dentista; }
            set { _Dentista = value; OnPropertyChanged("Dentista"); }
        }

        private bool _TbIdIsEnable;

        public bool TbIdIsEnable
        {
            get { return _TbIdIsEnable; }
            set { _TbIdIsEnable = value; OnPropertyChanged("TbIdIsEnable"); }
        }

        public DentistaViewModel()
        {
            Dentista = new Dentista();
            TbIdIsEnable = false;
        }


        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        public bool BtSalvar_Click(string senha, string senhaConfirmacao, out string msgSaida)
        {
            bool salvo = SalvarUsuario(senha, senhaConfirmacao, out string msg);
            msgSaida = msg;
            return salvo;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private bool SalvarUsuario(string senha, string senhaConfirmacao, out string msg)
        {
            ValidarCamposObrigatorios(senha, senhaConfirmacao);

            var lista = ValidarCamposObrigatorios(senha, senhaConfirmacao);
            if (lista.Count != 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (string i in lista)
                {
                    sb.Append($"{i}, ");
                }
                msg = sb.ToString();
                return false;
            }
            else
            {
                Dentista.Senha = senha;
                if (Dentista.Id != 0)
                {
                    msg = DentistaData.AlterarDentista(Dentista);
                }
                else
                {
                    msg = DentistaData.CadastroDeNovoDentista(Dentista);
                }
                return true;
            }
        }

        private List<string> ValidarCamposObrigatorios(string senha, string senhaConfirmacao)
        {
            List<string> lista = new List<string>();
            if (Dentista.Nome == null || Dentista.Nome.Equals(""))
            {
                lista.Add("Nome");
            }
            if (Dentista.Email == null || Dentista.Email.Equals(""))
            {
                lista.Add("Email");
            }
            if (Dentista.Telefone1 == null || Dentista.Telefone1.Equals("(__)_____-____"))
            {
                lista.Add("Celular 1");
            }
            if (Dentista.Crosp == null || Dentista.Crosp.Equals(""))
            {
                lista.Add("Crosp");
            }
            if (Dentista.Login == null || Dentista.Login.Equals(""))
            {
                lista.Add("Login");
            }
            if (ValidarSenha(senha, senhaConfirmacao, out string msg) == false)
            {
                lista.Add(msg);
            }
            return lista;
        }

        private bool ValidarSenha(string senha, string senhaConfirmacao, out string msg)
        {
            if (senha.Equals("") || senhaConfirmacao.Equals(""))
            {
                msg = "Campo de senha não pode ficar em branco";
                return false;
            }
            else if (senha.Equals(senhaConfirmacao))
            {
                msg = "";
                return true;
            }
            else
            {
                msg = "Campos de senha não coincidem";
                return false;
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
