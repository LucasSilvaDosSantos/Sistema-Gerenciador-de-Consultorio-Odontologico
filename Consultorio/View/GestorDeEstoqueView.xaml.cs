using Consultorio.ViewModel;
using System.Windows;

namespace Consultorio.View
{
    /// <summary>
    /// Lógica interna para GestorDeEstoque.xaml
    /// </summary>
    public partial class GestorDeEstoqueView : Window
    {
        public GestorDeEstoqueViewModel GestorDeEstoqueViewModel { get; set; }

        public GestorDeEstoqueView()
        {
            GestorDeEstoqueViewModel = new GestorDeEstoqueViewModel();
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
