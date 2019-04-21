using Consultorio.Model;
using Consultorio.ViewModel;
using System;
using System.Collections.Generic;
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
    /// Lógica interna para CadastroDeClientesAnamnese.xaml
    /// </summary>
    public partial class ViewCadastroDeClientesAnamnese : Window
    {
        public Cliente Cliente { get; set; }

        public ViewCadastroDeClientesAnamnese(Cliente c)
        {
            InitializeComponent();
            Cliente = c;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            ViewCadastroDeClienteBase cadastroCliente = new ViewCadastroDeClienteBase();
            cadastroCliente.IniciarCliente(Cliente);
            cadastroCliente.Show();
            this.Close();
        }

        private void BtSalvar_Click(object sender, RoutedEventArgs e)
        {
            bool btNaoPreencher = (bool)cbNaoPreencher.IsChecked;
            if (btNaoPreencher)
            {
               // CadastroDeClienteBaseViewModel.CadastroDeNovoCliente(Cliente);
            }
            else
            {
                Anamnese anamnese = PegarDadosDaTela();
                CadastroDeClienteAnamneseViewModel.CadastrarAnamnese(Cliente, anamnese);
                Cliente.Anamnese = anamnese;
            }
            ViewOpcoes opcoes = new ViewOpcoes();
            opcoes.Show();
            this.Close();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private Anamnese PegarDadosDaTela()
        {
            Anamnese anamnese = new Anamnese();
            //p01
            if (SimOuNao(rbP01S.IsChecked))
            {
                anamnese.P01 = true;
                anamnese.P01ComplementoPq = tbP01PQ.Text;
                anamnese.P01ComplementoTel = tb0P1TelMedico.Text;
            }
            else
            {
                anamnese.P01 = false;
            }

            //p02
            if (SimOuNao(rbP02S.IsChecked))
            {
                anamnese.P02 = true;
                anamnese.P02Complemento = tbP02Quais.Text;
            }
            else
            {
                anamnese.P02 = false;
            }

            //p03
            if (SimOuNao(rbP03S.IsChecked))
            {
                anamnese.P03 = true;
                anamnese.P03Complemento = tbP03Qual.Text;
            }
            else
            {
                anamnese.P03 = false;
            }

            //p04
            if (SimOuNao(rbP04S.IsChecked))
            {
                anamnese.P04 = true;
                anamnese.P04Complemento = tbP04Aux.Text;
            }
            else
            {
                anamnese.P04 = false;
            }

            //p05
            if (SimOuNao(rbP05S.IsChecked))
            {
                anamnese.P05 = true;
                anamnese.P05Complemento = tbP05Mes.Text;
            }
            else
            {
                anamnese.P05 = false;
            }

            //p06
            anamnese.P06 = SimOuNao(rbP06S.IsChecked);

            //p07
            anamnese.P07 = SimOuNao(rbP07S.IsChecked);

            //p08
            anamnese.P08 = SimOuNao(rbP08S.IsChecked);

            //p09
            if (SimOuNao(rbP09S.IsChecked))
            {
                anamnese.P09 = true;
                anamnese.P09Complemento = tbP09Aux.Text;
            }
            else
            {
                anamnese.P09 = false;
            }

            //p10
            anamnese.P10 = SimOuNao(rbP10S.IsChecked);

            //p11
            anamnese.P11 = SimOuNao(rbP11S.IsChecked);

            //p12
            anamnese.P12 = SimOuNao(rbP12S.IsChecked);

            //p13
            anamnese.P13 = SimOuNao(rbP13S.IsChecked);

            //p14
            anamnese.P14 = SimOuNao(rbP14S.IsChecked);

            //p15
            anamnese.P15 = SimOuNao(rbP15S.IsChecked);

            //p16
            anamnese.P16 = SimOuNao(rbP16S.IsChecked);

            //p17
            if (SimOuNao(rbP17S.IsChecked))
            {
                anamnese.P17 = true;
                anamnese.P17Complemento = tbP17Aux.Text;
            }
            else
            {
                anamnese.P17 = false;
            }

            //p18
            anamnese.P18 = SimOuNao(rbP18S.IsChecked);

            //p19
            anamnese.P19 = SimOuNao(rbP19S.IsChecked);

            //p20
            anamnese.P20 = SimOuNao(rbP20S.IsChecked);

            //p21
            anamnese.P21 = SimOuNao(rbP21S.IsChecked);

            //p22
            anamnese.P22 = SimOuNao(rbP22S.IsChecked);

            //p23
            anamnese.P23 = SimOuNao(rbP23S.IsChecked);

            //p24
            anamnese.P24 = SimOuNao(rbP24S.IsChecked);

            //p25
            anamnese.P25 = SimOuNao(rbP25S.IsChecked);

            //p26
            anamnese.P26 = SimOuNao(rbP26S.IsChecked);

            //p27
            anamnese.P27 = SimOuNao(rbP27S.IsChecked);

            //obs
            anamnese.Obs = tbObs.Text;
            return anamnese;       
        }

        // metodo para verificação de radio box
        private bool SimOuNao(bool? s)
        {
            if (s == true)
            {
                return true;
            }
            return false;
        }
    }
}
