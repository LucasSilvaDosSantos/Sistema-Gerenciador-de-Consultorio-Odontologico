using Consultorio.Data;
using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;

namespace Consultorio.View
{
    /// <summary>
    /// Lógica interna para CadastroDeClienteBase.xaml
    /// </summary>
    public partial class CadastroDeClienteBaseView : Window
    {

        public Cliente Cliente { get; set; }
        public bool OrigemListaDeClientes { get; set; }


        public CadastroDeClienteBaseView()
        {
            InitializeComponent();
            tbId.IsEnabled = false;

            btAnamnese.Visibility = Visibility.Hidden;          
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        // botao de volta define pra qual pagina sera retornada 
        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            /*if (OrigemListaDeClientes)
            {
                ListaDeClientesView lista = new ListaDeClientesView();
                lista.Show();
                this.Close();
            }
            else
            {
                OpcoesView opcoes = new OpcoesView();
                opcoes.Show();
                this.Close();
            }       */
            this.Close();
        }

        private void BtSalvar_Click(object sender, RoutedEventArgs e)
        {
            //quando a requisição vem da tela de listagem de clientes
            if (OrigemListaDeClientes || tbId.Text != "")
            {
                List<string> ListaDeCamposComErros = ValidarCamposObrigatorios();
                if (ListaDeCamposComErros.Count == 0)
                {
                    Cliente cliente = PegarDadosDosCampos();
                    cliente.Id = int.Parse(tbId.Text);
                    var msg = CadastroDeClienteBaseData.AlterarCliente(cliente);
                    MessageBox.Show(msg, "Aviso!");
                    CadastroDeClientesAnamneseView anamnese = new CadastroDeClientesAnamneseView(cliente);
                    this.Hide();
                    anamnese.ShowDialog();
                    this.Close();
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (string i in ValidarCamposObrigatorios())
                    {
                        sb.Append($"{i}, ");
                    }
                    MessageBox.Show(sb.ToString(), "Campos Obrigatorios não preenchidos");
                }                
            }
            //quando a requisição vem da tela de cadastro
            else
            {
                List<string> ListaDeCamposComErros = ValidarCamposObrigatorios();
                if (ListaDeCamposComErros.Count == 0)
                {
                    Cliente cliente = PegarDadosDosCampos();
                    string msg = CadastroDeClienteBaseData.CadastroDeNovoCliente(cliente);
                    MessageBox.Show(msg, "Aviso!");
                    CadastroDeClientesAnamneseView anamnese = new CadastroDeClientesAnamneseView(cliente);
                    this.Hide();
                    anamnese.ShowDialog();
                    this.Close();
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (string i in ValidarCamposObrigatorios())
                    {
                        sb.Append($"{i}, ");
                    }
                    MessageBox.Show(sb.ToString(), "Campos Obrigatorios não preenchidos");
                }
                
            }
        }

        private void BtAnamnese_Click(object sender, RoutedEventArgs e)
        {
            string confirmacao = MessageBox.Show("Deseja ir para Anamnese sem salvar alterações", "Confirmação", MessageBoxButton.OKCancel).ToString();
            if (confirmacao == "OK")
            {               
                Cliente cliente = PegarDadosDosCampos();
                cliente.Id = int.Parse(tbId.Text);
                CadastroDeClientesAnamneseView anamnese = new CadastroDeClientesAnamneseView(cliente);
                this.Hide();
                anamnese.ShowDialog();
                this.Close();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------


        /// revisar a validação de clientes
        // Validação dos campos obrigatorios
        private List<string> ValidarCamposObrigatorios()
        {
            List<string> lista = new List<string>();
            if (tbNome.Text == "")
            {
                lista.Add("Nome");
            }
            if (dataPiquerNascimento.SelectedDate.ToString() == "")
            {
                lista.Add("Data de Nascimento");
            }
            if (tbCpf.Text == "___.___.___-__")
            {
                lista.Add("CPF");
            }
            if (tbCelular1.Text == "(__)_____-____")
            {
                lista.Add("Telefone 1");
            }
            return lista;
        }

        // Pega os dados da tela e carrega em um objeto Cliente
        private Cliente PegarDadosDosCampos()
        {
            Cliente cliente = new Cliente();
            cliente.Nome = tbNome.Text;
            cliente.Nascimento = DateTime.Parse(dataPiquerNascimento.SelectedDate.ToString());
            cliente.Cpf = tbCpf.Text;
            cliente.Rg = tbRg.Text;
            cliente.Email = tbEmail.Text;
            cliente.Telefone1 = tbCelular1.Text;
            cliente.Telefone2 = tbCelular2.Text;
            cliente.Endereco = tbEndereco.Text;
            cliente.Bairro = tbBairro.Text;
            cliente.Uf = tbUf.Text;
            cliente.Cidade = tbCidade.Text;
            cliente.Cep = tbCep.Text;
            cliente.Obs = tbObs.Text;

            return cliente;
        }

        // Passa um cliente para a tela
        public void IniciarComCliente(Cliente cliente)
        {
            tbId.IsEnabled = true;
            tbId.Text = cliente.Id.ToString();
            tbNome.Text = cliente.Nome;
            dataPiquerNascimento.SelectedDate = cliente.Nascimento;
            tbCpf.Text = cliente.Cpf;
            tbRg.Text = cliente.Rg;
            tbEmail.Text = cliente.Email;
            tbCelular1.Text = cliente.Telefone1;
            tbCelular2.Text = cliente.Telefone2;
            tbEndereco.Text = cliente.Endereco;
            tbBairro.Text = cliente.Bairro;
            tbUf.Text = cliente.Uf;
            tbCidade.Text = cliente.Cidade;
            tbCep.Text = cliente.Cep;
            tbObs.Text = cliente.Obs;
            btAnamnese.Visibility = Visibility.Visible;
        }        
    }
}
