using Consultorio.Model;
using Consultorio.ViewModel;
using System.Windows;


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
            CaregarDadosNaTela(Cliente);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            ViewCadastroDeClienteBase cadastroCliente = new ViewCadastroDeClienteBase();
            cadastroCliente.IniciarComCliente(Cliente);
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

        // Carrega os dados da tela para um objeto anamnese
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

        //Carrega os campos de acordo com o objeto recebido
        private void CaregarDadosNaTela(Cliente c)
        {
            tbId.Text = c.Id.ToString();
            tbNome.Text = c.Nome;

            Anamnese anamnese = CadastroDeClienteAnamneseViewModel.CarregarAnamnese(c);

            if (anamnese != null)
            {



                //P01
                if (anamnese.P01)
                {
                    rbP01S.IsChecked = true;
                    tb0P1TelMedico.Text = anamnese.P01ComplementoTel;
                    tbP01PQ.Text = anamnese.P01ComplementoPq;
                }
                else
                {
                    rbP01N.IsChecked = true;
                }

                //P02
                if (anamnese.P02)
                {
                    rbP02S.IsChecked = true;
                    tbP02Quais.Text = anamnese.P02Complemento;
                }
                else
                {
                    rbP02N.IsChecked = true;
                }

                //P03
                if (anamnese.P03)
                {
                    rbP03S.IsChecked = true;
                    tbP03Qual.Text = anamnese.P03Complemento;
                }
                else
                {
                    rbP03N.IsChecked = true;
                }

                //P04
                if (anamnese.P04)
                {
                    rbP04S.IsChecked = true;
                    tbP04Aux.Text = anamnese.P04Complemento;
                }
                else
                {
                    rbP04N.IsChecked = true;
                }

                //P05
                if (anamnese.P05)
                {
                    rbP05S.IsChecked = true;
                    tbP05Mes.Text = anamnese.P05Complemento;
                }
                else
                {
                    rbP05N.IsChecked = true;
                }

                //P06
                if (anamnese.P06)
                {
                    rbP06S.IsChecked = true;
                }
                else
                {
                    rbP06N.IsChecked = true;
                }

                //P07
                if (anamnese.P07)
                {
                    rbP07S.IsChecked = true;
                }
                else
                {
                    rbP07N.IsChecked = true;
                }

                //P08
                if (anamnese.P08)
                {
                    rbP08S.IsChecked = true;
                }
                else
                {
                    rbP08N.IsChecked = true;
                }

                //P09
                if (anamnese.P09)
                {
                    rbP09S.IsChecked = true;
                    tbP09Aux.Text = anamnese.P09Complemento;
                }
                else
                {
                    rbP09N.IsChecked = true;
                }

                //P10
                if (anamnese.P10)
                {
                    rbP10S.IsChecked = true;
                }
                else
                {
                    rbP10N.IsChecked = true;
                }

                //P11
                if (anamnese.P11)
                {
                    rbP11S.IsChecked = true;
                }
                else
                {
                    rbP11N.IsChecked = true;
                }

                //P12
                if (anamnese.P12)
                {
                    rbP12S.IsChecked = true;
                }
                else
                {
                    rbP12N.IsChecked = true;
                }

                //P13
                if (anamnese.P13)
                {
                    rbP13S.IsChecked = true;
                }
                else
                {
                    rbP13N.IsChecked = true;
                }

                //P14
                if (anamnese.P14)
                {
                    rbP14S.IsChecked = true;
                }
                else
                {
                    rbP14N.IsChecked = true;
                }

                //P15
                if (anamnese.P15)
                {
                    rbP15S.IsChecked = true;
                }
                else
                {
                    rbP15N.IsChecked = true;
                }

                //P16
                if (anamnese.P16)
                {
                    rbP16S.IsChecked = true;
                }
                else
                {
                    rbP16N.IsChecked = true;
                }

                //P17
                if (anamnese.P17)
                {
                    rbP17S.IsChecked = true;
                    tbP17Aux.Text = anamnese.P17Complemento;
                }
                else
                {
                    rbP17N.IsChecked = true;
                }

                //P18
                if (anamnese.P18)
                {
                    rbP18S.IsChecked = true;
                }
                else
                {
                    rbP18N.IsChecked = true;
                }

                //P19
                if (anamnese.P19)
                {
                    rbP19S.IsChecked = true;
                }
                else
                {
                    rbP19N.IsChecked = true;
                }

                //P20
                if (anamnese.P20)
                {
                    rbP20S.IsChecked = true;
                }
                else
                {
                    rbP20N.IsChecked = true;
                }

                //P21
                if (anamnese.P21)
                {
                    rbP21S.IsChecked = true;
                }
                else
                {
                    rbP21N.IsChecked = true;
                }

                //P22
                if (anamnese.P22)
                {
                    rbP22S.IsChecked = true;
                }
                else
                {
                    rbP22N.IsChecked = true;
                }

                //P23
                if (anamnese.P23)
                {
                    rbP23S.IsChecked = true;
                }
                else
                {
                    rbP23N.IsChecked = true;
                }

                //P24
                if (anamnese.P24)
                {
                    rbP24S.IsChecked = true;
                }
                else
                {
                    rbP24N.IsChecked = true;
                }

                //P25
                if (anamnese.P25)
                {
                    rbP25S.IsChecked = true;
                }
                else
                {
                    rbP25N.IsChecked = true;
                }

                //P26
                if (anamnese.P26)
                {
                    rbP26S.IsChecked = true;
                }
                else
                {
                    rbP26N.IsChecked = true;
                }

                //P27
                if (anamnese.P27)
                {
                    rbP27S.IsChecked = true;
                }
                else
                {
                    rbP27N.IsChecked = true;
                }

                tbObs.Text = anamnese.Obs;
            }
        }
    }
}
