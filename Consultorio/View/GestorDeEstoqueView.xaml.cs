using Consultorio.Data;
using Consultorio.Model;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Consultorio.View
{
    /// <summary>
    /// Lógica interna para GestorDeEstoque.xaml
    /// </summary>
    public partial class GestorDeEstoqueView : Window
    {

        public bool OrigemListaDeAtores { get; set; }

        public GestorDeEstoqueView()
        {
            InitializeComponent();
            tbId.IsEnabled = false;
        }

        public GestorDeEstoqueView(GestorDeEstoque gestor)
        {
            InitializeComponent();
            OrigemListaDeAtores = true;
            tbId.IsEnabled = true;
            CarregaDadosNaTela(gestor);
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
            this.Close();
            /*CadastroDeColaboradoresView colaboradores = new CadastroDeColaboradoresView();
            colaboradores.Show();
            this.Close();*/
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
                string msg;
                if (OrigemListaDeAtores)
                {
                    gestorDeEstoque.Id = int.Parse(tbId.Text);
                    msg = GestorDeEstoqueData.AlterarGestor(gestorDeEstoque);
                }
                else
                {
                    msg = GestorDeEstoqueData.CadastroDeNovoGestorDeEstoque(gestorDeEstoque);
                }
                MessageBox.Show(msg);
                Voltar();
            }
        }

        private GestorDeEstoque PegaDadosDaTela()
        {
            string senhaCod = AtoresData.GerarHashMd5(pbSenha.Password.ToString());
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

        private void CarregaDadosNaTela(GestorDeEstoque gestorDeEstoque)
        {
            tbId.Text = gestorDeEstoque.Id.ToString();
            tbNome.Text = gestorDeEstoque.Nome;
            tbEmail.Text = gestorDeEstoque.Email;
            tbCelular1.Text = gestorDeEstoque.Telefone1;
            tbCelular2.Text = gestorDeEstoque.Telefone2;
            tbLogin.Text = gestorDeEstoque.Login;
        }
    }
}
