using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using Consultorio.Model;
using System.Text;
using Consultorio.Data;
using Consultorio.ViewModel;

namespace Consultorio.View
{
    /// <summary>
    /// Lógica interna para ViewConsultas.xaml
    /// </summary>
    public partial class ConsultasView : Window
    {
        public ConsultasViewModel ConsultasViewModel { get; set; }

        public Cliente Cliente { get; set; }

        public ConsultasView()
        {
            ConsultasViewModel = new ConsultasViewModel();
            DataContext = ConsultasViewModel;

            InitializeComponent();
            Cliente = new Cliente();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void BtCadastrarNovo_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            CrudConsultasView crudConsultasView = new CrudConsultasView();
            crudConsultasView.ShowDialog();

            this.Visibility = Visibility.Visible;
            ConsultasViewModel.CarregarListaDeConsultasData();
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            OpcoesView opcoes = new OpcoesView();
            opcoes.Show();
            this.Close();
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            ConsultasViewModel.Calendar_SelectedDatesChanged(Convert.ToDateTime(cCalendario.SelectedDate));
        }

        private void BtEditar_Click(object sender, RoutedEventArgs e)
        {
            if (ConsultasViewModel.ConsultaSelecionada != null)
            {
                ConsultasViewModel.CrudConsuta();
            }
            else
            {
                MessageBox.Show("Nenhuma consulta selecionada", "Aviso!");
            }
            
        }

        private void DgConsultas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ConsultasViewModel.DataGridSelect(dgConsultas.SelectedIndex);
        }

        private void TbId_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbClienteNome.Text = "";
            ConsultasViewModel.BuscarConsultaId(tbClienteId.Text);
        }

        private void TbClienteNome_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbClienteId.Text = "";
            ConsultasViewModel.BuscarConsultaCliente(tbClienteNome.Text);
        }


        /*private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {

            ConsultasViewModel.Calendar_SelectedDatesChanged(Convert.ToDateTime(cCalendario.SelectedDate));
            //var dia = Convert.ToDateTime(cCalendario.SelectedDate);
            
            //GerarDgConsultas(dia);
        }

        private void BtSalvar_Click(object sender, RoutedEventArgs e)
        {
            List<string> lista = ValidarCamposObrigatorios();
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
                if (tbId.Text != "")
                {
                    AlterarConsulta();        
                }
                else
                {
                    CadastrarNovaConsulta();
                }
                var data = Convert.ToDateTime(cCalendario.SelectedDate);
                GerarDgConsultas(data);
            }
        }

        private void BtCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimparTela();
            CamposAtivados(1);
        }

        

        private void BtBuscar_Click(object sender, RoutedEventArgs e)
        {
            BuscarConsultas();
        }

        private void TbData_TextChanged(object sender, TextChangedEventArgs e)
        {
            BuscarConsultas();
        }

        private void BtCadastrarNovo_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ConsultasViewModel.CadastrarNovoClick();
            this.Visibility = Visibility.Visible;
            /*foreach (var a in ConsultasData.ListarTodosOsProcedimentos())
            {
                comboBoxProcedimento.Items.Add(a);
            }
            CamposAtivados(2);
            comboBoxProcedimento.DisplayMemberPath = "Nome";
            btCadastrarNovo.IsEnabled = false;
        }*/

        /*private void TbCliente_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            AcessoAoCampoCliente();
        }

        private void TbCliente_GotFocus(object sender, RoutedEventArgs e)
        {
            AcessoAoCampoCliente();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void AlterarConsulta()
        {
            string confirmacao = MessageBox.Show("Deseja salvar alteraçoes?", "Confirmação", MessageBoxButton.OKCancel).ToString();

            if (confirmacao.Equals("OK"))
            {
                Consulta consulta = PegarDadosDaTela();

                string msg = ConsultasData.AlterarConsulta(consulta);
                MessageBox.Show(msg, "Aviso");
                LimparTela();
                CamposAtivados(1);
            }
            else
            {
                MessageBox.Show("Operação cancelada pelo usuario", "Aviso");
            }
        }

        private void CadastrarNovaConsulta()
        {
            string confirmacao = MessageBox.Show("Deseja salvar nova consulta?", "Confirmação", MessageBoxButton.OKCancel).ToString();

            if (confirmacao.Equals("OK"))
            {
                Consulta c = PegarDadosDaTela();

                string msg = ConsultasData.SalvarNovaConsulta(c);
                MessageBox.Show(msg, "Aviso");
                LimparTela();
                CamposAtivados(1);
            }
            else
            {
                MessageBox.Show("Operação cancelada pelo usuário");
            }
        }

        private void LimparTela()
        {
            tbId.Text = "";
            tbDente.Text = "";
            tbFim.Text = "";
            tbInicio.Text = "";
            comboBoxProcedimento.Items.Clear();
            tbCliente.Text = "";
        }

        private void GerarDgConsultas(DateTime dia)
        {
            dgConsultas.ItemsSource = ConsultasData.ListaDeConsultas(dia);
            //tbData.Text = dia.ToShortDateString();//"dd/MM/yyyy"
        }*/

        /*private Consulta PegarDadosDaTela()
        {
            Consulta c = new Consulta();
            if (tbId.Text != "")
            {
                c.Id = int.Parse(tbId.Text);
            }
            c.Inicio = DateTime.Parse(tbData.Text + " " + tbInicio.Text);
            c.Fim = DateTime.Parse(tbData.Text + " " + tbFim.Text);
            c.Dente = tbDente.Text;
            c.Cliente = Cliente;

            if (cbRealizada.IsChecked == true)
            {
                c.Realizada = true;
            }
            else
            {
                c.Realizada = false;
            }
            if (comboBoxProcedimento.SelectedItem != null)
            {
                c.Procedimento = ConsultasData.BuscarProcedimento((Procedimento)comboBoxProcedimento.SelectedItem);
            }
            return c; 
        }*/

        /*private void CamposAtivados(int op)
        {
            
            if (op == 1)
            { 
                tbId.IsEnabled = false;
                tbData.IsReadOnly = false;
                comboBoxProcedimento.IsEnabled = false;
                tbInicio.IsEnabled = false;
                tbFim.IsEnabled = false;
                tbDente.IsEnabled = false;
                cbRealizada.IsEnabled = false;
                tbCliente.IsEnabled = false;
            }
            else if(op == 2)
            {
                tbId.IsEnabled = true;
                tbId.IsReadOnly = true;
                comboBoxProcedimento.IsEnabled = true;
                tbInicio.IsEnabled = true;
                tbFim.IsEnabled = true;
                tbDente.IsEnabled = true;
                cbRealizada.IsEnabled = true;
                tbCliente.IsEnabled = true;
            }
            BotoesAtivados(op);
        }

        private void BotoesAtivados(int op)
        {
            if (op == 1)
            {
                btSalvar.IsEnabled = false;
                btCancelar.IsEnabled = false;
                btBuscar.IsEnabled = true;
                btCadastrarNovo.IsEnabled = true;
            }
            else if (op == 2)
            {
                btCancelar.IsEnabled = true;
                btSalvar.IsEnabled = true;
                btBuscar.IsEnabled = false;
                btCadastrarNovo.IsEnabled = false;
            }
        }

        private void BuscarConsultas()
        {
            if (tbData.Text != "")
            {
                try
                {
                    dgConsultas.ItemsSource = ConsultasData.BuscarConsultas(DateTime.Parse(tbData.Text));
                    cCalendario.SelectedDate = DateTime.Parse(tbData.Text);
                    GerarDgConsultas(DateTime.Parse(tbData.Text));
                }
                catch (Exception)
                {

                }              
            }
        }

        private void AcessoAoCampoCliente()
        {
            SelecaoDeClientesView listaCliente = new SelecaoDeClientesView();

            listaCliente.ShowDialog();
            Cliente = listaCliente.Cliente;

            if (Cliente.Id > 0)
            {
                tbCliente.Text = Cliente.Nome;
            }
        }

        private List<string> ValidarCamposObrigatorios()
        {
            List<string> lista = new List<string>();
            if (tbCliente.Text.Equals(""))
            {
                lista.Add("Cliente");
            }
            if (tbData.Text.Equals("__/__/____"))
            {
                lista.Add("Data da consulta");
            }
            if (tbInicio.Text.Equals("__:__"))
            {
                lista.Add("Hora de inicio");
            }
            if (tbFim.Text.Equals("__:__"))
            {
                lista.Add("Hora de termino");
            }

            return lista;
        }*/
    }
}