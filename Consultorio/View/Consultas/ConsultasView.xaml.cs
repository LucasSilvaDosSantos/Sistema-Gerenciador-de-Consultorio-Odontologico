using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Consultorio.Model.Enums;
using Consultorio.ViewModel.Consultas;
using Brush = System.Windows.Media.Brush;

namespace Consultorio.View.Consultas
{
    public partial class ConsultasView : Window
    {
        public Label[,] ArrayLabel { get; set; } = new Label[10, 12];

        public ConsultasViewModel ConsultasViewModel { get; set; }

        public ConsultasView()
        {
            ConsultasViewModel = new ConsultasViewModel();
            DataContext = ConsultasViewModel;

            InitializeComponent();

            IniciarArray();

            CarregarCoresDeDisponibilidade();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        private void BtEditar_Click(object sender, RoutedEventArgs e)
        {
            if (ConsultasViewModel.ConsultaSelecionada != null)
            {
                if (ConsultasViewModel.ConsultaSelecionada.Status != StatusConsulta.Agendada)
                {
                    MessageBox.Show("Não é possível editar esta consulta", "Aviso!");
                }
                else
                {
                    //this.Hide();
                
                    CrudConsultasView crudConsultasView = new CrudConsultasView(ConsultasViewModel.ConsultaSelecionada.Id);
                    ConfiguracoesDeView.ConfigurarWindow(this, crudConsultasView);
                
                    //crudConsultasView.ShowDialog();

                    crudConsultasView.Show();
                
                    //ConsultasViewModel.CarregarListaDeConsultasData();
                    //ConfiguracoesDeView.ConfigurarWindow(crudConsultasView, this);
                    //this.Visibility = Visibility.Visible;

                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Nenhuma consulta selecionada", "Aviso!");
            }
        }

        private void BtCadastrarNovo_Click(object sender, RoutedEventArgs e)
        {
            //this.Hide();

            CrudConsultasView crudConsultasView = new CrudConsultasView();
            ConfiguracoesDeView.ConfigurarWindow(this, crudConsultasView);
            //crudConsultasView.ShowDialog();
            crudConsultasView.Show();
            //ConfiguracoesDeView.ConfigurarWindow(crudConsultasView, this);
            //this.Visibility = Visibility.Visible;
            //ConsultasViewModel.CarregarListaDeConsultasData();
            this.Close();
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            OpcoesView opcoesView = new OpcoesView();
            ConfiguracoesDeView.ConfigurarWindow(this, opcoesView);
            opcoesView.Show();
            this.Close();
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            ConsultasViewModel.CarregarListaDeConsultasData();

            if (ArrayLabel[0,0] != null)
            {
                CarregarCoresDeDisponibilidade();
            }         
        }

        private void TbId_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbClienteNome.Text = "";
            IsEnabledSelecaoDeTela(tbClienteId.Text);
            ConsultasViewModel.BuscarConsultaId(tbClienteId.Text);
        }

        private void TbClienteNome_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbClienteId.Text = "";
            IsEnabledSelecaoDeTela(tbClienteNome.Text);
            ConsultasViewModel.BuscarConsultaCliente(tbClienteNome.Text);
            
        }

        private void IsEnabledSelecaoDeTela(string entrada)
        {
            if (entrada == "")
            {
                cbSelecao.IsEnabled = true;
            }
            else
            {
                cbSelecao.IsEnabled = false;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Métodos**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void CarregarCoresDeDisponibilidade()
        {
            IniciarArray();

            int[,] arrayCores = ConsultasViewModel.ArrayDisponibilidadeDeHorario;

            Brush corVerde = (Brush)(new BrushConverter().ConvertFrom("#80009500"));
            Brush corVermelho = (Brush)(new BrushConverter().ConvertFrom("#80ff0000"));
            Brush corAmarela = (Brush)(new BrushConverter().ConvertFrom("#80ebeb00"));

            for (int i = 0; i <= 9; i++)
            {
                for(int j = 0; j < 12; j++)
                {
                    if(arrayCores[i,j] == 0)
                    {
                        ArrayLabel[i, j].Background = corVerde;                        
                    }
                    else if(arrayCores[i, j] > 0)
                    {
                        ArrayLabel[i, j].Background = corVermelho;
                    }
                    else if(arrayCores[i, j] < 0)
                    {
                        ArrayLabel[i, j].Background = corAmarela;
                    }
                }
            }
        }

        private void IniciarArray()
        {
            ArrayLabel[0, 0] = h09m00;
            ArrayLabel[0, 1] = h09m05;
            ArrayLabel[0, 2] = h09m10;
            ArrayLabel[0, 3] = h09m15;
            ArrayLabel[0, 4] = h09m20;
            ArrayLabel[0, 5] = h09m25;
            ArrayLabel[0, 6] = h09m30;
            ArrayLabel[0, 7] = h09m35;
            ArrayLabel[0, 8] = h09m40;
            ArrayLabel[0, 9] = h09m45;
            ArrayLabel[0, 10] =h09m50;
            ArrayLabel[0, 11] =h09m55;

            ArrayLabel[1, 0] = h10m00;
            ArrayLabel[1, 1] = h10m05;
            ArrayLabel[1, 2] = h10m10;
            ArrayLabel[1, 3] = h10m15;
            ArrayLabel[1, 4] = h10m20;
            ArrayLabel[1, 5] = h10m25;
            ArrayLabel[1, 6] = h10m30;
            ArrayLabel[1, 7] = h10m35;
            ArrayLabel[1, 8] = h10m40;
            ArrayLabel[1, 9] = h10m45;
            ArrayLabel[1, 10] =h10m50;
            ArrayLabel[1, 11] =h10m55;

            ArrayLabel[2, 0] = h11m00;
            ArrayLabel[2, 1] = h11m05;
            ArrayLabel[2, 2] = h11m10;
            ArrayLabel[2, 3] = h11m15;
            ArrayLabel[2, 4] = h11m20;
            ArrayLabel[2, 5] = h11m25;
            ArrayLabel[2, 6] = h11m30;
            ArrayLabel[2, 7] = h11m35;
            ArrayLabel[2, 8] = h11m40;
            ArrayLabel[2, 9] = h11m45;
            ArrayLabel[2, 10] =h11m50;
            ArrayLabel[2, 11] =h11m55;

            ArrayLabel[3, 0] = h12m00;
            ArrayLabel[3, 1] = h12m05;
            ArrayLabel[3, 2] = h12m10;
            ArrayLabel[3, 3] = h12m15;
            ArrayLabel[3, 4] = h12m20;
            ArrayLabel[3, 5] = h12m25;
            ArrayLabel[3, 6] = h12m30;
            ArrayLabel[3, 7] = h12m35;
            ArrayLabel[3, 8] = h12m40;
            ArrayLabel[3, 9] = h12m45;
            ArrayLabel[3, 10] =h12m50;
            ArrayLabel[3, 11] =h12m55;

            ArrayLabel[4, 0] = h13m00;
            ArrayLabel[4, 1] = h13m05;
            ArrayLabel[4, 2] = h13m10;
            ArrayLabel[4, 3] = h13m15;
            ArrayLabel[4, 4] = h13m20;
            ArrayLabel[4, 5] = h13m25;
            ArrayLabel[4, 6] = h13m30;
            ArrayLabel[4, 7] = h13m35;
            ArrayLabel[4, 8] = h13m40;
            ArrayLabel[4, 9] = h13m45;
            ArrayLabel[4, 10] =h13m50;
            ArrayLabel[4, 11] =h13m55;

            ArrayLabel[5, 0] = h14m00;
            ArrayLabel[5, 1] = h14m05;
            ArrayLabel[5, 2] = h14m10;
            ArrayLabel[5, 3] = h14m15;
            ArrayLabel[5, 4] = h14m20;
            ArrayLabel[5, 5] = h14m25;
            ArrayLabel[5, 6] = h14m30;
            ArrayLabel[5, 7] = h14m35;
            ArrayLabel[5, 8] = h14m40;
            ArrayLabel[5, 9] = h14m45;
            ArrayLabel[5, 10] =h14m50;
            ArrayLabel[5, 11] =h14m55;

            ArrayLabel[6, 0] = h15m00;
            ArrayLabel[6, 1] = h15m05;
            ArrayLabel[6, 2] = h15m10;
            ArrayLabel[6, 3] = h15m15;
            ArrayLabel[6, 4] = h15m20;
            ArrayLabel[6, 5] = h15m25;
            ArrayLabel[6, 6] = h15m30;
            ArrayLabel[6, 7] = h15m35;
            ArrayLabel[6, 8] = h15m40;
            ArrayLabel[6, 9] = h15m45;
            ArrayLabel[6, 10] =h15m50;
            ArrayLabel[6, 11] =h15m55;

            ArrayLabel[7, 0] = h16m00;
            ArrayLabel[7, 1] = h16m05;
            ArrayLabel[7, 2] = h16m10;
            ArrayLabel[7, 3] = h16m15;
            ArrayLabel[7, 4] = h16m20;
            ArrayLabel[7, 5] = h16m25;
            ArrayLabel[7, 6] = h16m30;
            ArrayLabel[7, 7] = h16m35;
            ArrayLabel[7, 8] = h16m40;
            ArrayLabel[7, 9] = h16m45;
            ArrayLabel[7, 10] =h16m50;
            ArrayLabel[7, 11] =h16m55;

            ArrayLabel[8, 0] = h17m00;
            ArrayLabel[8, 1] = h17m05;
            ArrayLabel[8, 2] = h17m10;
            ArrayLabel[8, 3] = h17m15;
            ArrayLabel[8, 4] = h17m20;
            ArrayLabel[8, 5] = h17m25;
            ArrayLabel[8, 6] = h17m30;
            ArrayLabel[8, 7] = h17m35;
            ArrayLabel[8, 8] = h17m40;
            ArrayLabel[8, 9] = h17m45;
            ArrayLabel[8, 10] =h17m50;
            ArrayLabel[8, 11] =h17m55;

            ArrayLabel[9, 0] = h18m00;
            ArrayLabel[9, 1] = h18m05;
            ArrayLabel[9, 2] = h18m10;
            ArrayLabel[9, 3] = h18m15;
            ArrayLabel[9, 4] = h18m20;
            ArrayLabel[9, 5] = h18m25;
            ArrayLabel[9, 6] = h18m30;
            ArrayLabel[9, 7] = h18m35;
            ArrayLabel[9, 8] = h18m40;
            ArrayLabel[9, 9] = h18m45;
            ArrayLabel[9, 10] =h18m50;
            ArrayLabel[9, 11] =h18m55;
        }

        private void BtIniciarConsulta_Click(object sender, RoutedEventArgs e)
        {
            if (ConsultasViewModel.ConsultaSelecionada != null)
            {
                if (ConsultasViewModel.ConsultaSelecionada.Status == StatusConsulta.Realizada)
                {
                    MessageBox.Show("Esta consulta já foi realizada e por isso não pode ser iniciada", "Aviso!");
                }
                else if (ConsultasViewModel.ConsultaSelecionada.Status == StatusConsulta.Iniciada)
                {
                    MessageBox.Show("Esta consulta já foi iniciada e por isso não pode ser iniciada novamente", "Aviso!");
                }
                else
                {
                    bool iniciada = ConsultasViewModel.IniciarConsulta();
                    if (iniciada)
                    {
                        MessageBox.Show("Consulta Iniciada!", "Aviso!");
                        ConsultasViewModel.CarregarListaDeConsultasData();
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro por favor tente novamente", "Aviso!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Nenhuma consulta selecionada", "Aviso!");
            }
        }

        private void BtFinalizarConsulta_Click(object sender, RoutedEventArgs e)
        {
            if (ConsultasViewModel.ConsultaSelecionada != null)
            {
                if (ConsultasViewModel.ConsultaSelecionada.Status == StatusConsulta.Agendada)
                {
                    MessageBox.Show("A consulta selecionada ainda não foi Iniciada e nao pode ser finalizada", "Aviso");
                }
                else if (ConsultasViewModel.ConsultaSelecionada.Status == StatusConsulta.Realizada)
                {
                    MessageBox.Show("A consulta selecionada já foi finalizada", "Aviso");
                }
                else
                {
                    FinalizacaoConsultaView finalizacaoConsultaView = new FinalizacaoConsultaView(ConsultasViewModel.ConsultaSelecionada.Id);
                    this.Hide();
                    ConfiguracoesDeView.ConfigurarWindow(this, finalizacaoConsultaView);
                    finalizacaoConsultaView.ShowDialog();
                    ConsultasViewModel.CarregarListaDeConsultasData();
                    ConfiguracoesDeView.ConfigurarWindow(finalizacaoConsultaView, this);
                    this.Visibility = Visibility.Visible;
                }
            }
            else
            {
                MessageBox.Show("Nenhuma consulta selecionada", "Aviso!");
            }
        }

        private void BtCancelar_Click(object sender, RoutedEventArgs e)
        {
            if (ConsultasViewModel.ConsultaSelecionada != null)
            {
                if ((ConsultasViewModel.ConsultaSelecionada.Status != StatusConsulta.Agendada || ConsultasViewModel.ConsultaSelecionada.Status == StatusConsulta.Iniciada))
                {
                    MessageBox.Show("A consulta selecionada não pode ser cancelada!", "Aviso");
                }
                else
                {
                    CancelarConsultaView cancelarConsultaView = new CancelarConsultaView(ConsultasViewModel.ConsultaSelecionada.Id);
                    cancelarConsultaView.ShowDialog();

                    if (cancelarConsultaView.ConsultaParaReagendar)
                    {



                        if (ConsultasViewModel.ConsultaSelecionada != null)
                        {
                            if (ConsultasViewModel.ConsultaSelecionada.Status != StatusConsulta.Agendada && ConsultasViewModel.ConsultaSelecionada.Status != StatusConsulta.Iniciada)
                            {
                                MessageBox.Show("Não é possível editar esta consulta", "Aviso!");
                            }
                            else
                            {
                                //this.Hide();

                                /*ConsultasViewModel.CarregarListaDeConsultasData();
                                ConsultasViewModel.ConsultaSelecionada = */

                                CrudConsultasView crudConsultasView = new CrudConsultasView(ConsultasViewModel.ConsultaSelecionada.Id);
                                ConfiguracoesDeView.ConfigurarWindow(this, crudConsultasView);

                                //crudConsultasView.ShowDialog();

                                crudConsultasView.Show();

                                //ConsultasViewModel.CarregarListaDeConsultasData();
                                //ConfiguracoesDeView.ConfigurarWindow(crudConsultasView, this);
                                //this.Visibility = Visibility.Visible;

                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Nenhuma consulta selecionada", "Aviso!");
                        }






                    }
                }
            }
            else
            {
                MessageBox.Show("Nenhuma consulta selecionada", "Aviso!");
            }
            ConsultasViewModel.CarregarListaDeConsultasData();
        }
    }
}