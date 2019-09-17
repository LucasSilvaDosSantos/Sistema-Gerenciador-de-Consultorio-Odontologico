using Consultorio.ViewModel.Consultas;
using System.Collections.Generic;
using System.Windows;

namespace Consultorio.View.Consultas
{
    /// <summary>
    /// Lógica interna para CancelarConsultaView.xaml
    /// </summary>
    public partial class CancelarConsultaView : Window
    {
        public bool ConsultaParaReagendar { get; set; } = false;
        private List<string> OpcoesCancelamento{ get; } = new List<string>() { "Cliente faltou", "Dentista faltou", "Cliente pediu", "Dentista pediu" };
        public CancelarConsultaViewModel CancelarConsultaViewModel { get; set; }
        public CancelarConsultaView(int id)
        {
            CancelarConsultaViewModel = new CancelarConsultaViewModel(id);
            DataContext = CancelarConsultaViewModel;
            InitializeComponent();
            ComboBoxIniciar();
        }

        private void ComboBoxIniciar()
        {
            cbMotivoCancelamento.ItemsSource = OpcoesCancelamento;
            cbMotivoCancelamento.SelectedItem = OpcoesCancelamento[0];
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtCancelarEReagendar_Click(object sender, RoutedEventArgs e)
        {
            if (CancelarConsultaViewModel.SalvarCancelamentoDeConsulta(true))
            {
                MessageBox.Show("Consulta Cancelada!", "Aviso");
                ConsultaParaReagendar = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocorreu um erro por favor tente novamente!", "Aviso");
            }            
        }

        private void BtCancelar_Click(object sender, RoutedEventArgs e)
        {
            if (CancelarConsultaViewModel.SalvarCancelamentoDeConsulta(false))
            {
                MessageBox.Show("Consulta Cancelada!", "Aviso");
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocorreu um erro por favor tente novamente!", "Aviso");
            }            
        }
    }
}
