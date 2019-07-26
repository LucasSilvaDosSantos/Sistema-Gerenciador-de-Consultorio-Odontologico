using Consultorio.Data.Ator;
using Consultorio.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Consultorio.ViewModel.Ator
{
    public class GestorDeEstoqueViewModel : INotifyPropertyChanged
    {
        private GestorDeEstoque _GestorDeEstoque;

        public GestorDeEstoque GestorDeEstoque
        {
            get { return _GestorDeEstoque; }
            set { _GestorDeEstoque = value; OnPropertyChanged("GestorDeEstoque"); }
        }

        private bool _TbIdIsEnable;

        public bool TbIdIsEnable
        {
            get { return _TbIdIsEnable; }
            set { _TbIdIsEnable = value; OnPropertyChanged("TbIdIsEnable"); }
        }

        public GestorDeEstoqueViewModel()
        {
            GestorDeEstoque = new GestorDeEstoque();
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
                GestorDeEstoque.Senha = senha;
                if (GestorDeEstoque.Id != 0)
                {
                    msg = GestorDeEstoqueData.AlterarGestor(GestorDeEstoque);
                }
                else
                {
                    msg = GestorDeEstoqueData.CadastroDeNovoGestorDeEstoque(GestorDeEstoque);
                }
                return true;
            }
        }

        private List<string> ValidarCamposObrigatorios(string senha, string senhaConfirmacao)
        {
            List<string> lista = new List<string>();
            if (GestorDeEstoque.Nome == null || GestorDeEstoque.Nome.Equals(""))
            {
                lista.Add("Nome");
            }
            if (GestorDeEstoque.Email == null || GestorDeEstoque.Email.Equals(""))
            {
                lista.Add("Email");
            }
            if (GestorDeEstoque.Telefone1 == null || GestorDeEstoque.Telefone1.Equals("(__)_____-____"))
            {
                lista.Add("Celular 1");
            }
            if (GestorDeEstoque.Login == null || GestorDeEstoque.Login.Equals(""))
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
