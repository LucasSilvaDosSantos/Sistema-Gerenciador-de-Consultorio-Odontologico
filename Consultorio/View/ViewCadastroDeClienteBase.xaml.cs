using Consultorio.Model;
using Consultorio.ViewModel;
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
    public partial class ViewCadastroDeClienteBase : Window
    {

        public Cliente Cliente { get; set; }
        public bool OrigemListaDeClientes { get; set; }


        public ViewCadastroDeClienteBase()
        {
            InitializeComponent();
            tbId.IsEnabled = false;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        // botao de volta define pra qual pagina sera retornada 
        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            if (OrigemListaDeClientes)
            {
                ViewListaDeClientes lista = new ViewListaDeClientes();
                lista.Show();
                this.Close();
            }
            else
            {
                ViewOpcoes opcoes = new ViewOpcoes();
                opcoes.Show();
                this.Close();
            }       
        }

        private void BtSalvar_Click(object sender, RoutedEventArgs e)
        {
            //quando a requisição vem da tela de listagem de clientes
            if (OrigemListaDeClientes || tbId.Text != "")
            {
                string confirmacao = MessageBox.Show("Deseja salvar alteraçoes?", "Confirmação", MessageBoxButton.OKCancel).ToString();
                if (confirmacao == "OK")
                {
                    List<string> ListaDeCamposComErros =  ValidarCamposObrigatorios();
                    if (ListaDeCamposComErros.Count == 0)
                    {
                        Cliente cliente = PegarDadosDosCampos();
                        cliente.Id = int.Parse(tbId.Text);
                        CadastroDeClienteBaseViewModel.AlterarCliente(cliente);
                        ViewCadastroDeClientesAnamnese anamnese = new ViewCadastroDeClientesAnamnese(cliente);
                        anamnese.Show();
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
            //quando a requisição vem da tela de cadastro
            else
            {
                string confirmacao = MessageBox.Show("Deseja salvar novo paciente?", "Confirmação", MessageBoxButton.OKCancel).ToString();
                if (confirmacao == "OK")
                {
                    List<string> ListaDeCamposComErros = ValidarCamposObrigatorios();
                    if (ListaDeCamposComErros.Count == 0)
                    { 
                        Cliente cliente = PegarDadosDosCampos();
                        CadastroDeClienteBaseViewModel.CadastroDeNovoCliente(cliente);
                        ViewCadastroDeClientesAnamnese anamnese = new ViewCadastroDeClientesAnamnese(cliente);
                        anamnese.Show();
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
        }

        private void BtAnamnese_Click(object sender, RoutedEventArgs e)
        {
            string confirmacao = MessageBox.Show("Deseja ir para Anamnese sem salvar alterações", "Confirmação", MessageBoxButton.OKCancel).ToString();
            if (confirmacao == "OK")
            {               
                Cliente cliente = PegarDadosDosCampos();
                cliente.Id = int.Parse(tbId.Text);
                ViewCadastroDeClientesAnamnese anamnese = new ViewCadastroDeClientesAnamnese(cliente);
                anamnese.Show();
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
            DateTime.TryParse(tbDataDeNascimento.Text, out DateTime data);
            if (data.Equals("") || tbDataDeNascimento.Text == "")
            {
                lista.Add("Data de Nascimento");
            }
            if (tbCpf.Text == "")
            {
                lista.Add("CPF");
            }
            if (tbCelular1.Text == "")
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
            cliente.Nascimento = DateTime.ParseExact(tbDataDeNascimento.Text, "dd/MM/yyyy", CultureInfo.CurrentCulture);
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
            //teste.Text = cliente.Anamnese.Id.ToString();
            tbId.Text = cliente.Id.ToString();
            tbNome.Text = cliente.Nome;
            tbDataDeNascimento.Text = string.Format("{0:dd/MM/yyyy}", cliente.Nascimento);
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

            //cliente.Nascimento = DateTime.ParseExact(tbDataDeNascimento.Text, "dd/MM/yyyy", CultureInfo.CurrentCulture);
        }        
    }
}
