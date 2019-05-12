using Consultorio.Model;
using Consultorio.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Lógica interna para Secretaria.xaml
    /// </summary>
    public partial class SecretariaView : Window
    {

        public bool OrigemListaDeAtores { get; set; }

        public SecretariaView()
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
        public void IniciarComSecretaria(Secretaria secretaria)
        {
            tbId.IsEnabled = true;
            CarregaDadosNaTela(secretaria);
        }

        private void Voltar()
        {
            if (OrigemListaDeAtores)
            {
                ListaDeColaboradoresView viewListaDeColaboradores = new ListaDeColaboradoresView();
                viewListaDeColaboradores.Show();
                this.Close();
            }
            else
            {
                CadastroDeColaboradoresView viewColaboradores = new CadastroDeColaboradoresView();
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
                Secretaria secretaria = PegaDadosDaTela();
                string msg;
                if (OrigemListaDeAtores)
                {
                    secretaria.Id = int.Parse(tbId.Text);
                    msg = SecretariaViewModel.AlterarSecretaria(secretaria);
                }
                else
                {
                    msg = SecretariaViewModel.CadastroDeNovaSecretaria(secretaria);
                }
                MessageBox.Show(msg);
                Voltar();
            }
        }

        private Secretaria PegaDadosDaTela()
        {
            string senhaCod = AtoresViewModel.GerarHashMd5(pbSenha.Password.ToString());
            Secretaria secretaria = new Secretaria(tbNome.Text, tbEmail.Text, tbCelular1.Text, tbCelular2.Text, tbCROSP.Text, tbLogin.Text, senhaCod, 
                VerificaCheckBox(cbEdicaoCliente.IsChecked), VerificaCheckBox(cbEdicaoSecretaria.IsChecked), VerificaCheckBox(cbEdicaoProduto.IsChecked), VerificaCheckBox(cbEdicaoGestoresDeEstoque.IsChecked));

            return secretaria;
        }

        // verifica se os check box estão preenchidos
        private bool VerificaCheckBox(bool? entrada)
        {
            if (entrada == true)
            {
                return true;
            }
            return false;
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

        private void CarregaDadosNaTela(Secretaria secretaria)
        {
            tbId.Text = secretaria.Id.ToString();
            tbNome.Text = secretaria.Nome;
            tbEmail.Text = secretaria.Email;
            tbCelular1.Text = secretaria.Telefone1;
            tbCelular2.Text = secretaria.Telefone2;
            tbCROSP.Text = secretaria.Crosp;
            tbLogin.Text = secretaria.Login;
            //////////////////////////////////////////////////////////// falta os check box fazer com urgencia maxima 
        }
    }
}
