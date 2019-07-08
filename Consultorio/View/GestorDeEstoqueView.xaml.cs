using Consultorio.Data;
using Consultorio.Model;
using Consultorio.ViewModel;
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
        public GestorDeEstoqueViewModel GestorDeEstoqueViewModel { get; set; }

        public GestorDeEstoqueView(GestorDeEstoqueViewModel gestorDeEstoqueViewModel)
        {
            GestorDeEstoqueViewModel = gestorDeEstoqueViewModel;
            DataContext = GestorDeEstoqueViewModel;
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
            bool salvo = GestorDeEstoqueViewModel.BtSalvar_Click(pbSenha.Password, pbSenhaConfirma.Password, out string msg);

            if (salvo == false)
            {
                MessageBox.Show(msg, "Campos Obrigatorios não preenchidos");
            }
            else
            {
                MessageBox.Show(msg, "Aviso!");
                Voltar();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void Voltar()
        {
            this.Close();
        }
    }
}
