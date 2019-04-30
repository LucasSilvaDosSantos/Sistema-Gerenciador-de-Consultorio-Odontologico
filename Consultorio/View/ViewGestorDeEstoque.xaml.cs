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
    /// Lógica interna para GestorDeEstoque.xaml
    /// </summary>
    public partial class ViewGestorDeEstoque : Window
    {
        public ViewGestorDeEstoque()
        {
            InitializeComponent();
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

        private void Voltar()
        {
            ViewCadastroDeColaboradores colaboradores = new ViewCadastroDeColaboradores();
            colaboradores.Show();
            this.Close();
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
                GestorDeEstoque gestorDeEstoque = PegaDadosDaTela();
                string msg = GestorDeEstoqueViewModel.CadastroDeNovoGestorDeEstoque(gestorDeEstoque);
                MessageBox.Show(msg);
                Voltar();
            }
        }

        private GestorDeEstoque PegaDadosDaTela()
        {
            string senhaCod = AtoresViewModel.GerarHashMd5(pbSenha.Password.ToString());
            GestorDeEstoque gestorDeEstoque = new GestorDeEstoque(tbNome.Text, tbEmail.Text, tbCelular1.Text, tbCelular2.Text, tbLogin.Text, senhaCod);

            return gestorDeEstoque;
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

        
    }
}
