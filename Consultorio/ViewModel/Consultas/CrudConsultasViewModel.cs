using Consultorio.Data.Consultas;
using Consultorio.Model;
using Itenso.TimePeriod;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Consultorio.ViewModel.Consultas
{
    public class CrudConsultasViewModel : INotifyPropertyChanged
    {
        public bool IfNovoCliente { get; set; }

        public List<Procedimento> Procedimentos { get; set; }

        private DateTime _DataSelecionada;

        public DateTime DataSelecionada
        {
            get { return _DataSelecionada; }
            set { _DataSelecionada = value; OnPropertyChanged("DataSelecionada"); }
        }

        private Procedimento _ProcedimentoSelecionado;

        public Procedimento ProcedimentoSelecionado
        {
            get { return _ProcedimentoSelecionado; }
            set { _ProcedimentoSelecionado = value; OnPropertyChanged("ProcedimentoSelecionado"); }
        }

        private string _NomeTela;

        public string NomeTela
        {
            get { return _NomeTela; }
            set { _NomeTela = value; OnPropertyChanged("NomeTela"); }
        }

        private Consulta _Consulta;

        public Consulta Consulta
        {
            get { return _Consulta; }
            set { _Consulta = value; OnPropertyChanged("Consulta"); }
        }

        private string _HoraInicio;

        public string HoraInicio
        {
            get { return _HoraInicio; }
            set { _HoraInicio = value; OnPropertyChanged("HoraInicio"); }
        }

        private string _HoraFim;

        public string HoraFim
        {
            get { return _HoraFim; }
            set { _HoraFim = value; OnPropertyChanged("HoraFim"); }
        }

        private string _MinutoInicio;

        public string MinutoInicio
        {
            get { return _MinutoInicio; }
            set { _MinutoInicio = value; OnPropertyChanged("MinutoInicio"); }
        }

        private string _MinutoFim;

        public string MinutoFim
        {
            get { return _MinutoFim; }
            set { _MinutoFim = value; OnPropertyChanged("MinutoFim"); }
        }

        private List<string> _Horas;

        public List<string> Horas
        {
            get { return _Horas; }
            set { _Horas = value; OnPropertyChanged("Horas"); }
        }

        private List<string> _Minutos;

        public List<string> Minutos
        {
            get { return _Minutos; }
            set { _Minutos = value; OnPropertyChanged("Minutos"); }
        }

        public CrudConsultasViewModel(int idConsulta)
        {
            PreencherHorarios();

            IfNovoCliente = false;

            NomeTela = "> Editar Consulta";

            Consulta = ConsultasData.SelecionarConsulta(idConsulta);

            if (Consulta.Status == Model.Enums.StatusConsulta.Reagendada)
            {
                Consulta.Status = Model.Enums.StatusConsulta.Agendada;
                Consulta.Id = 0;
                NomeTela = "> Reagendar Consulta";
                Consulta.Obs = "";
            }
                    
            IniciarTela();
            Procedimento procedimento = Procedimentos.Find(c => c.Id == Consulta.Procedimento.Id);
            ProcedimentoSelecionado = procedimento;
            DataSelecionada = Consulta.Inicio;
           
            CarregarHoraAgendada();
        }

        public CrudConsultasViewModel()
        {
            PreencherHorarios();

            IfNovoCliente = true;

            Consulta = new Consulta();
            NomeTela = "> Cadastro Consulta";            
            IniciarTela();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void CarregarHoraAgendada()
        {
            var horaMinuto = Consulta.Inicio.ToShortTimeString();
            var lista = horaMinuto.Split(':');
            HoraInicio = lista[0];
            MinutoInicio = lista[1];

            horaMinuto = Consulta.Fim.ToShortTimeString();
            lista = horaMinuto.Split(':');
            HoraFim = lista[0];
            MinutoFim = lista[1];
        }

        private void PreencherHorarios()
        {
            Horas = new List<string>();
            Minutos = new List<string>();

            for (int i = 9; i <= 18; i++)
            {
                if (i.ToString().Count() == 1)
                {
                    Horas.Add( "0" + i.ToString());
                }
                else
                {
                    Horas.Add(i.ToString());
                }
                
            }
            for (int i = 0; i < 60; i += 5)
            {
                if (i.ToString().Count() == 1)
                {
                    Minutos.Add("0" + i.ToString());
                }
                else
                {
                    Minutos.Add(i.ToString());
                }                
            }
        }

        public void Calendar_SelectedDatesChanged(DateTime data)
        {
            DataSelecionada = data;
        }

        public string SalvarClick()
        {
            Procedimento procedimento = ProcedimentoSelecionado;
            Consulta.Procedimento = ProcedimentoSelecionado;
            Consulta.ValorConsulta = procedimento.Preco;
            Consulta.Status = Model.Enums.StatusConsulta.Agendada;
            NormalizaDataTime();
            string msg;
            if (Consulta.Id == 0)
            {
                msg = ConsultasData.SalvarNovaConsulta(Consulta);
            }
            else
            {
                msg = ConsultasData.EditarConsulta(Consulta);
            }           
            return msg;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Metodos**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        private bool HorarioDisponivel()
        {
            if (HoraInicio == null || Consulta.Fim == null || MinutoInicio == null || MinutoFim == null)
            {
                return true;
            }

            NormalizaDataTime();

            List<Consulta> listaConsulta = ConsultasData.ListaDeConsultas(Consulta.Inicio.Date);
            TimeRange timeRange1 = new TimeRange(Consulta.Inicio, Consulta.Fim);

            foreach (var itemConsulta in listaConsulta)
            {
                if (itemConsulta.Id != Consulta.Id)
                {
                    TimeRange timeRange2 = new TimeRange(itemConsulta.Inicio, itemConsulta.Fim);

                    //var a = timeRange1.GetRelation(timeRange2);

                    bool horariosSeCruzao = timeRange1.OverlapsWith(timeRange2);

                    if (horariosSeCruzao)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void NormalizaDataTime()
        {
            string data = DataSelecionada.ToShortDateString();

            string horaInicio = ($"{HoraInicio}:{MinutoInicio}:00");

            string horaFim = ($"{HoraFim}:{MinutoFim}:00");

            DateTime dataInicio = DateTime.Parse($"{data} {horaInicio}");
            DateTime dataFim = DateTime.Parse($"{data} {horaFim}");
            Consulta.Inicio = dataInicio;
            Consulta.Fim = dataFim;
        }

        public string CamposObrigatoriosPreenchidos()
        {
            Consulta.Procedimento = ProcedimentoSelecionado;
            if (HorarioDisponivel())
            {
                StringBuilder sb = new StringBuilder();
                if (Consulta.Cliente == null)
                {
                    sb.Append("Cliente\n");
                }
                if (HoraInicio == null || MinutoInicio == null)
                {
                    sb.Append("Horário de início\n");
                }
                if (HoraFim == null || MinutoFim == null)
                {
                    sb.Append("Horário de Término\n");
                }
                if (Consulta.Procedimento == null)
                {
                    sb.Append("Procedimento\n");
                }
                if (Consulta.Inicio > Consulta.Fim )
                {
                    sb.Append("Hora inicial não pode ser menor que hora final");
                }
                return sb.ToString();
            }
            else
            {
                return "Já existe uma consulta neste horário";
            } 
        }

        private void IniciarTela()
        {
            DataSelecionada = DateTime.Now;
            CarregarProcedimentos();
        }

        // Erro na hora de notificar a tela sobre alteraçao na view
        public void NotificarConsulta()
        {
            OnPropertyChanged("Consulta");
        }

        private void CarregarProcedimentos()
        {
            Procedimentos = ConsultasData.ListarTodosOsProcedimentos();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********PropertyChanged**********-----------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string NameProperty)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(NameProperty));
        }
    }
}
