using Consultorio.Model;
using Consultorio.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Consultorio.View
{
    /// <summary>
    /// Lógica interna para Dentista.xaml
    /// </summary>
    public partial class ViewDentista : Window
    {

        public bool OrigemListaDeAtores { get; set; }

        public ViewDentista()
        {
            InitializeComponent();
            tbId.IsEnabled = false;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            Voltar();
        }

        private void BtSalvar_Click(object sender, RoutedEventArgs e)
        {
            SalvarUsuario();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        public void IniciarComDentista(Dentista dentista)
        {
            tbId.IsEnabled = true;
            CarregaDadosNaTela(dentista);
        }

        private void Voltar()
        {
            if (OrigemListaDeAtores)
            {
                ViewListaDeColaboradores viewListaDeColaboradores = new ViewListaDeColaboradores();
                viewListaDeColaboradores.Show();
                this.Close();
            }
            else
            {
                ViewCadastroDeColaboradores viewColaboradores = new ViewCadastroDeColaboradores();
                viewColaboradores.Show();
                this.Close();              
            }
        }

        private void SalvarUsuario()
        {
            var lista = ValidarCamposObrigatorios();
            if (lista.Count != 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (string i in ValidarCamposObrigatorios())
                {
                    sb.Append($"{i}, ");
                }
                MessageBox.Show(sb.ToString(), "Campos Obrigatorios não preenchidos");
            }
            else
            {
                Dentista dentista = PegaDadosDaTela();
                string msg;
                if (OrigemListaDeAtores)
                {
                    dentista.Id = int.Parse(tbId.Text);
                    msg = DentistaViewModel.AlterarDentista(dentista);
                }
                else
                {
                    msg = DentistaViewModel.CadastroDeNovoDentista(dentista);
                }                
                MessageBox.Show(msg);
                Voltar();
            }
        }

        private Dentista PegaDadosDaTela()
        {
            string senhaCod = AtoresViewModel.GerarHashMd5(pbSenha.Password.ToString());
            Dentista dentista = new Dentista(tbNome.Text, tbEmail.Text, tbCelular1.Text, tbCelular2.Text, tbCROSP.Text, tbLogin.Text, senhaCod);
            return dentista;
        }

        //Valida Campos Obrigatorios
        private List<string> ValidarCamposObrigatorios()
        {
            List<string> lista = new List<string>();
            if (tbNome.Text.Equals(""))
            {
                lista.Add("Nome");
            }
            if (tbEmail.Text.Equals(""))
            {
                lista.Add("Email");
            }
            if (tbCelular1.Text.Equals("(__)_____-____"))
            {
                lista.Add("Celular 1");
            }
            if (tbCROSP.Text.Equals(""))
            {
                lista.Add("Crosp");
            }
            if (tbLogin.Text.Equals(""))
            {
                lista.Add("Login");
            }
            if (pbSenha.Password.ToString().Equals(""))
            {
                lista.Add("Senha");
            }
            if (pbSenhaConfirma.Password.ToString().Equals(""))
            {
                lista.Add("Confirmação de Senha");
            }
            if (!ValidacaoDeSenha(pbSenha.Password.ToString(), pbSenhaConfirma.Password.ToString()))
            {
                lista.Add("Senhas não coincidem");
            }
            return lista;
        }

        //Verificação se campos de senhas (senha e confirmar senha) são iguais 
        private bool ValidacaoDeSenha(string senha, string confirmaSenha)
        {
            if (senha == "")
            {
                return false;
            }
            else
            {
                if (senha != confirmaSenha)
                {
                    return false;
                }
            }
            return true;
        }

        private void CarregaDadosNaTela(Dentista dentista)
        {
            tbId.Text = dentista.Id.ToString();
            tbNome.Text = dentista.Nome;
            tbEmail.Text = dentista.Email;
            tbCelular1.Text = dentista.Telefone1;
            tbCelular2.Text = dentista.Telefone2;
            tbCROSP.Text = dentista.Crosp;
            tbLogin.Text = dentista.Login;
        }
    }
}
