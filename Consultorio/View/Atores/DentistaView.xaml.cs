using Consultorio.ViewModel.Atores;
using System.Windows;

namespace Consultorio.View.Atores
{
    /// <summary>
    /// Lógica interna para Dentista.xaml
    /// </summary>
    public partial class DentistaView : Window
    {
        public DentistaViewModel DentistaViewModel { get; set; }

        public DentistaView()
        {
            DentistaViewModel = new DentistaViewModel();
            DataContext = DentistaViewModel;

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
            /*bool salvo = DentistaViewModel.BtSalvar_Click(pbSenha.Password, pbSenhaConfirma.Password, out string msg);

            if (salvo == false)
            {
                MessageBox.Show(msg, "Campos Obrigatorios não preenchidos");
            }
            else
            {
                MessageBox.Show(msg, "Aviso!");
                Voltar();
            }   */
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
