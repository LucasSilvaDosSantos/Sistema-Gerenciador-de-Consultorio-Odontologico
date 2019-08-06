using Consultorio.Data.Atores;
using Consultorio.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Consultorio.ViewModel.Atores
{
    public class SecretariaViewModel : INotifyPropertyChanged
    {
        private Secretaria _Secretaria;

        public Secretaria Secretaria
        {
            get { return _Secretaria; }
            set { _Secretaria = value; OnPropertyChanged("Secretaria"); }
        }

        private bool _TbIdIsEnable;

        public bool TbIdIsEnable
        {
            get { return _TbIdIsEnable; }
            set { _TbIdIsEnable = value; OnPropertyChanged("TbIdIsEnable"); }
        }

        public SecretariaViewModel()
        {
            Secretaria = new Secretaria();
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
                Secretaria.Senha = senha;
                if (Secretaria.Id != 0)
                {
                    msg = SecretariaData.AlterarSecretaria(Secretaria);
                }
                else
                {
                    msg = SecretariaData.CadastroDeNovaSecretaria(Secretaria);
                }
                return true;
            }
        }

        private List<string> ValidarCamposObrigatorios(string senha, string senhaConfirmacao)
        {
            List<string> lista = new List<string>();
            if (Secretaria.Nome == null || Secretaria.Nome.Equals(""))
            {
                lista.Add("Nome");
            }
            if (Secretaria.Email == null || Secretaria.Email.Equals(""))
            {
                lista.Add("Email");
            }
            if (Secretaria.Telefone1 == null || Secretaria.Telefone1.Equals("(__)_____-____"))
            {
                lista.Add("Celular 1");
            }
            if (Secretaria.Crosp == null || Secretaria.Crosp.Equals(""))
            {
                lista.Add("Crosp");
            }
            if (Secretaria.Login == null || Secretaria.Login.Equals(""))
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
