using Consultorio.Data.Atores;
using Consultorio.Model;
using System.Collections.Generic;
using System.ComponentModel;

namespace Consultorio.ViewModel.Atores
{
    public class CrudAtorViewModel : INotifyPropertyChanged
    {
        private bool _AltararDadosDeLogin;

        public bool AltararDadosDeLogin
        {
            get { return _AltararDadosDeLogin; }
            set { _AltararDadosDeLogin = value; OnPropertyChanged("AltararDadosDeLogin"); }
        }

        private string _TituloTela;

        public string TituloTela
        {
            get { return _TituloTela; }
            set { _TituloTela = value; OnPropertyChanged("TituloTela"); }
        }

        private string _NomeBtSenha;

        public string NomeBtSenha
        {
            get { return _NomeBtSenha; }
            set { _NomeBtSenha = value; OnPropertyChanged("NomeBtSenha"); }
        }

        private Ator _Ator;
        public Ator Ator
        {
            get { return _Ator; }
            set { _Ator = value; OnPropertyChanged("Ator"); }
        }

        public CrudAtorViewModel()
        {
            AltararDadosDeLogin = true;
            NomeBtSenha = "Cadastrar Senha";
            TituloTela = "> Novo Colaborador";
            Ator = new Ator();
        }

        public CrudAtorViewModel(int idColaborador)
        {
            AltararDadosDeLogin = false;
            NomeBtSenha = "Modificar Senha";
            TituloTela = "> Editar Colaborador";
            Ator = AtorData.BuscaAtorPorId(idColaborador);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        public string SalvarAtor()
        {
            return OperacaoDeSalvar();
        }

        public string SalvarAtor(string senha)
        {
            Ator.Senha = AtorData.GerarHashMd5(senha);
            return OperacaoDeSalvar();
        }

        private string OperacaoDeSalvar()
        {
            string msg = AtorData.CadastroDeAtor(Ator);
            return msg;
        }

        public bool CamposObrigatoriosOk(out List<string> lista, string senha, string confirmacaoDeSenha)
        {
            
            lista = new List<string>();          
            if (Ator.Nome == "" || Ator.Nome == null)
            {
                lista.Add("Nome");
            }
            if (Ator.Email == "" || Ator.Email == null)
            {
                lista.Add("Email");
            }
            if (Ator.Telefone1 == "" || Ator.Telefone1 == null)
            {
                lista.Add("Telefone 1");
            }
            if (Ator.Login == "" || Ator.Login == null)
            {
                lista.Add("Usuário");
            }

            if (AltararDadosDeLogin)
            {
                if (!(senha != null && senha != ""))
                {
                    lista.Add("Senha");
                }else if (!(senha == confirmacaoDeSenha))
                {
                    lista.Add("Senha e confirmação de senha não são iguais!");
                }
            }
            else
            {
                if (Ator.Senha == "" || Ator.Senha == null)
                {
                    lista.Add("Senha");
                }
            }

            if (Ator.Clinicar)
            {
                if (Ator.Crosp == "" || Ator.Crosp == null)
                {
                    lista.Add("Em caso de autorização para atuar na áreaclinica, deve ser preenchido o crosp do colaborador");
                }
            }
                        
            if (lista.Count == 0)
            {
                return true;
            }
            else
            {
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
