using Consultorio.ViewModel.Clientes;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace Consultorio.View.Clientes.ClientePage
{
    /// <summary>
    /// Interação lógica para Odontograma.xam
    /// </summary>
    public partial class OdontogramaPage : Page
    {

        public CrudClienteViewModel CrudClienteViewModel { get; set; }

        public List<Label> Labels { get; set; }

        public OdontogramaPage(CrudClienteViewModel viewModel)
        {
            CrudClienteViewModel = viewModel;
            DataContext = CrudClienteViewModel;

            Labels = new List<Label>();
            InitializeComponent();
        }


        public void CriarListaDeLabel()
        {
            Labels.Add(lbdente01);
            Labels.Add(lbdente02);
            Labels.Add(lbdente03);
            Labels.Add(lbdente04);
            Labels.Add(lbdente05);
            Labels.Add(lbdente06);
            Labels.Add(lbdente07);
            Labels.Add(lbdente08);
            Labels.Add(lbdente09);
            Labels.Add(lbdente10);
            Labels.Add(lbdente11);
            Labels.Add(lbdente12);
            Labels.Add(lbdente13);
            Labels.Add(lbdente14);
            Labels.Add(lbdente15);
            Labels.Add(lbdente16);

            Labels.Add(lbdente17);
            Labels.Add(lbdente18);
            Labels.Add(lbdente19);
            Labels.Add(lbdente20);
            Labels.Add(lbdente21);
            Labels.Add(lbdente22);
            Labels.Add(lbdente23);
            Labels.Add(lbdente24);
            Labels.Add(lbdente25);
            Labels.Add(lbdente26);
            Labels.Add(lbdente27);
            Labels.Add(lbdente28);
            Labels.Add(lbdente29);
            Labels.Add(lbdente30);
            Labels.Add(lbdente31);
            Labels.Add(lbdente32);
        }

        private void AlterarForegroundLabelAoIniciar()
        {
            foreach (Label label in Labels)
            {
                MudarCorLabel(label);
            }
        }

        private string MudarConteudoLabel(string entrada)
        {
            if (entrada == "")
            {
                return "O";
            }
            else if (entrada == "O")
            {
                return "X";
            }
            return "";
        }

        private string TratarString(Label label)
        {
            if (label.Content == null)
            {
                return "";
            }
            return label.Content.ToString();
        }

        private void Lbdente_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Label label = sender as Label;
            label.Content = MudarConteudoLabel(TratarString(label));
            MudarCorLabel(label);
        }

        private void MudarCorLabel(Label label)
        {
            if (label.Content != null)
            {
                if (label.Content.ToString() == "X")
                {
                    label.Foreground = Brushes.Red;
                }
                else if (label.Content.ToString() == "O")
                {
                    label.Foreground = Brushes.Green;
                }
            }
        }

        private void BtSalvar_Click(object sender, RoutedEventArgs e)
        {
            /*string msg = CadastroDeOdontogramaViewModel.btSalvar();

            MessageBox.Show(msg, "Aviso!");*/
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CriarListaDeLabel();
            AlterarForegroundLabelAoIniciar();
        }
    }
}
