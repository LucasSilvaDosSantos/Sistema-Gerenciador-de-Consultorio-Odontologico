using Consultorio.Model;
using Consultorio.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Lógica interna para CadastroDeClienteBase.xaml
    /// </summary>
    public partial class ViewCadastroDeClienteBase : Window
    {

        public Cliente Cliente { get; set; }


        public ViewCadastroDeClienteBase()
        {
            InitializeComponent();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            ViewOpcoes opcoes = new ViewOpcoes();
            opcoes.Show();
            this.Close();
        }

        private void BtProximo_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = PegarDadosDaTela();
            CadastroDeClienteBaseViewModel.CadastroDeNovoCliente(cliente);
            ViewCadastroDeClientesAnamnese anamnese = new ViewCadastroDeClientesAnamnese(cliente);
            anamnese.Show();
            this.Close();       
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------


        private Cliente PegarDadosDaTela()
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

        public void IniciarCliente(Cliente cliente)
        {
            tbNome.Text = cliente.Nome;
            tbDataDeNascimento.Text = cliente.Nascimento.ToString();
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
