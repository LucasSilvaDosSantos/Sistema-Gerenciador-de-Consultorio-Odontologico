using Consultorio.ViewModel.Atores;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Consultorio.View.Atores
{
    /// <summary>
    /// Lógica interna para CrudAtorView.xaml
    /// </summary>
    public partial class CrudAtorView : Window
    {
        public CrudAtorViewModel CrudAtorViewModel { get; set; }
        public CrudAtorView()
        {
            CrudAtorViewModel = new CrudAtorViewModel();
            DataContext = CrudAtorViewModel;

            InitializeComponent();
        }

        public CrudAtorView(int idColaborador)
        {
            CrudAtorViewModel = new CrudAtorViewModel(idColaborador);
            DataContext = CrudAtorViewModel;

            InitializeComponent();
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (CrudAtorViewModel.CamposObrigatoriosOk(out List<string> lista, pbSenha.Password.ToString(), pbConfirmarSenha.Password.ToString()))
            {
                string msg = "Erro!";

                if (cbSenhaEnabled.IsChecked == true)
                {
                    if (pbSenha.Password.ToString().Equals(pbConfirmarSenha.Password.ToString()))
                    {
                        msg = CrudAtorViewModel.SalvarAtor(pbSenha.Password.ToString());
                    }
                }
                else
                {
                    msg = CrudAtorViewModel.SalvarAtor();
                }

                MessageBox.Show(msg, "Aviso!");
                this.Close();
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (string s in lista)
                {
                    sb.Append($"{s}\n");
                }
                MessageBox.Show(sb.ToString(), "Este(s) campo(s) não podem fcar em branco!");
            }
        }
    }
}
