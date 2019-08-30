using Consultorio.Data.Consultas;
using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Consultorio.ViewModel.Consultas
{
    public class ConsultasViewModel : INotifyPropertyChanged
    {
        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Atributos**********-----------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        public int[,] ArrayDisponibilidadeDeHorario { get; set; } = new int[10, 12];

        private bool _DgListaIsVisible;

        public bool DgListaIsVisible
        {
            get { return _DgListaIsVisible; }
            set { _DgListaIsVisible = value; OnPropertyChanged("DgListaIsVisible"); }
        }

        private string _ItemEscolhidoParaExibicao;

        public string ItemEscolhidoParaExibicao
        {
            get { return _ItemEscolhidoParaExibicao; }
            set { _ItemEscolhidoParaExibicao = value; OnPropertyChanged("ItemEscolhidoParaExibicao"); MudarTela(); }
        }

        private List<string> _OpcoesDeVisualizacao;

        public List<string> OpcoesDeVisualizacao
        {
            get { return _OpcoesDeVisualizacao; }
            set { _OpcoesDeVisualizacao = value; OnPropertyChanged("OpcoesDeVisualizacao"); }
        }

        private bool _CalendarioAtivo;

        public bool CalendarioAtivo
        {
            get { return _CalendarioAtivo; }
            set { _CalendarioAtivo = value; OnPropertyChanged("CalendarioAtivo"); }
        }

        private Consulta _ConsultaSelecionada;

        public Consulta ConsultaSelecionada
        {
            get { return _ConsultaSelecionada; }
            set { _ConsultaSelecionada = value; OnPropertyChanged("ConsultaSelecionada"); }
        }

        private List<Consulta> _ListaDeConsultas;

        public List<Consulta> ListaDeConsultas
        {
            get { return _ListaDeConsultas; }
            set { _ListaDeConsultas = value; OnPropertyChanged("ListaDeConsultas"); CarregarDadosArray(); }
        }

        private DateTime _DataSelecionada;

        public DateTime DataSelecionada
        {
            get { return _DataSelecionada; }
            set { _DataSelecionada = value; OnPropertyChanged("DataSelecionada"); }
        }

        public ConsultasViewModel()
        {
            CalendarioAtivo = true;
            DataSelecionada = DateTime.Now;
            CarregarListaDeConsultasData();

            IniciarTela();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Metodos**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        private void MudarTela()
        {
            if (ItemEscolhidoParaExibicao == "Disponibilidade Diária")
            {
                DgListaIsVisible = false;
            }
            else if (ItemEscolhidoParaExibicao == "Consultas")
            {
                DgListaIsVisible = true;
            }
        }

        public void IniciarTela()
        {
            OpcoesDeVisualizacao = new List<string>();
            OpcoesDeVisualizacao.Add("Disponibilidade Diária");
            OpcoesDeVisualizacao.Add("Consultas");
            ItemEscolhidoParaExibicao = OpcoesDeVisualizacao[1];
        }

        public void CarregarListaDeConsultasData()
        {
            ListaDeConsultas = ConsultasData.ListaDeConsultas(DataSelecionada);
        }

        public int ConsultaSelecionadaID()
        {
            return ConsultaSelecionada.Id;
        }

        public void BuscarConsultaId(string id)
        {

            if (id == "")
            {
                DataSelecionada = DateTime.Now;
                CarregarListaDeConsultasData();
                CalendarioAtivo = true;
                return;
            }
            var teste = int.TryParse(id, out int idInt);
            if (teste == true)
            {
                CalendarioAtivo = false;
                ListaDeConsultas = ConsultasData.BuscarConsultaPorClienteId(idInt);
            }            
        }

        public void BuscarConsultaCliente(string nome)
        {
            if(nome == "")
            {
                DataSelecionada = DateTime.Now;  
                CarregarListaDeConsultasData();
                CalendarioAtivo = true;
                return;
            }
            CalendarioAtivo = false;
            ListaDeConsultas = ConsultasData.BuscarConsultaPorClienteNome(nome);
        }

        private void CarregarDadosArray()
        {
            ArrayDisponibilidadeDeHorario = new int[10, 12];
            if (ListaDeConsultas != null)
            {
                //Almoço
                for (int j = 0; j < 12; j++)
                {
                    ArrayDisponibilidadeDeHorario[3, j] = -1;
                }
                for (int j = 0; j <= 5; j++)
                {
                    ArrayDisponibilidadeDeHorario[4, j] = -1;
                }

                foreach (var item in ListaDeConsultas)
                {
                    var horaInicio = item.Inicio.Hour;
                    var minutoInicio = item.Inicio.Minute;
                    var horafim = item.Fim.Hour;
                    var minutoFim = item.Fim.Minute;

                    TratarPosicaoArray(horaInicio, minutoInicio, out int horaSaidaInicio, out int minutoSaidaInicio);
                    TratarPosicaoArray(horafim, minutoFim, out int horaSaidaFim, out int minutoSaidaFim);

                    for (int i = horaSaidaInicio; i <= horaSaidaFim; i++)
                    {
                        if (i == horaSaidaFim)
                        {
                            if (i == horaSaidaInicio)
                            {
                                for (int j = minutoSaidaInicio; j < minutoSaidaFim; j++)
                                {
                                    ArrayDisponibilidadeDeHorario[i, j] = item.Cliente.Id;
                                }
                            }
                            else
                            {
                                for (int j = 0; j < minutoSaidaFim; j++)
                                {
                                    ArrayDisponibilidadeDeHorario[i, j] = item.Cliente.Id;
                                }
                            }
                        }
                        else if (i == horaSaidaInicio)
                        {
                            //hora igual a inicial
                            for (int j = minutoSaidaInicio; j < 12; j++)
                            {
                                ArrayDisponibilidadeDeHorario[i, j] = item.Cliente.Id;
                            }
                        }
                        else if (i < horaSaidaFim)
                        {
                            for (int j = 0; j < 12; j++)
                            {
                                ArrayDisponibilidadeDeHorario[i, j] = item.Cliente.Id;
                            }
                        }
                    }
                    //PrintArray(ArrayDisponibilidadeDeHorario);
                }
            }
        }

        private void TratarPosicaoArray(int hora, int minuto, out int horaSaida, out int minutoSaida)
        {
            horaSaida = (hora - 9);
            minutoSaida = (minuto / 5);
        }

        /*private void PrintArray(int[,] array)
        {
            Console.Write("*****");
            for (int j = 0; j < 12; j++)
            {
                Console.Write($"{(j * 5)}* ");
            }
            Console.Write("\n");
            for (int i = 0; i <= 9; i++)
            {
                Console.Write($"{(i+9)}** ");

                for (int j = 0; j < 12; j++)
                {
                    Console.Write($"{array[i, j]}   ");
                }
                Console.Write("\n");
            }
        }*/

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********PropertyChanged**********-----------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string NameProperty)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(NameProperty));
            }
        }
    }
}
