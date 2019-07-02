using Consultorio.Data;
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
    public partial class CadastroDeClienteBaseView : Window
    {

        public CadastroDeClienteBaseViewModel CadastroDeClienteBaseViewModel { get; set; }

        public Cliente Cliente { get; set; }
        public bool OrigemListaDeClientes { get; set; }

        public CadastroDeClienteBaseViewModel CadastroViewModel { get; set; }

        public CadastroDeClienteBaseView(CadastroDeClienteBaseViewModel cadastroDeClienteBaseViewModel)
        {
            CadastroViewModel = cadastroDeClienteBaseViewModel;
            DataContext = cadastroDeClienteBaseViewModel;

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
            this.Close();
        }

        private void BtSalvar_Click(object sender, RoutedEventArgs e)
        {
            bool valido = CadastroViewModel.ValidarCamposObrigatorios(out List<string> listaDeCamposComErro);

            if (valido == true)
            {
                SalvarClienteNoBanco();             
            }
            else
            {
                ExibirMessagemDeCamposObrigatorios(listaDeCamposComErro);              
            }
        }

        private void BtAnamnese_Click(object sender, RoutedEventArgs e)
        {              
            this.Hide();
            CadastroViewModel.BtAnamnese_Click();
            this.Close();           
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        private void ExibirMessagemDeCamposObrigatorios(List<string> listaDeCampos)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string i in listaDeCampos)
            {
                sb.Append($"{i}, ");
            }
            MessageBox.Show(sb.ToString(), "Campos Obrigatorios não preenchidos");
        }

        private void SalvarClienteNoBanco()
        {
            string msg = CadastroViewModel.BtSalvar_Click();
            MessageBox.Show(msg, "Aviso!");
            this.Close();
        }     
    }
}
