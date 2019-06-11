using Consultorio.Data;
using Consultorio.Model;
using Consultorio.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.ViewModel
{
    public class CrudConsultasViewModel : INotifyPropertyChanged
    {
        public bool IfNovoCliente { get; set; }

        public List<Procedimento> Procedimentos { get; set; }

        public SingletonAtorLogado AtorLogado { get; set; }

        private DateTime _DataSelecionada;

        public DateTime DataSelecionada
        {
            get { return _DataSelecionada; }
            set { _DataSelecionada = value; OnPropertyChanged("DataSelecionada"); }
        }

        private int _ProcedimentoSelecionado;

        public int ProcedimentoSelecionado
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

        public CrudConsultasViewModel(int idConsulta)
        {
            IfNovoCliente = false;

            Consulta = ConsultasData.SelecionarConsulta(idConsulta);
            
            NomeTela = "> Editar Consulta";           
            IniciarTela();
            int indexPos = Procedimentos.FindIndex(c => c.Id == Consulta.Procedimento.Id);
            ProcedimentoSelecionado = indexPos;
            DataSelecionada = Consulta.Inicio;
        }

        public CrudConsultasViewModel()
        {
            IfNovoCliente = true;

            Consulta = new Consulta();
            NomeTela = "> Cadastro Consulta";            
            IniciarTela();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        public void Calendar_SelectedDatesChanged(DateTime data)
        {
            DataSelecionada = data;
        }

        public string SalVarClick()
        {
            Consulta.Procedimento = Procedimentos[ProcedimentoSelecionado];

            string msg;
            if (IfNovoCliente == true)
            {
                NormalizandoDateTime();
                msg = ConsultasData.SalvarNovaConsulta(Consulta);
            }
            else
            {
                NormalizandoDateTime();
                msg = ConsultasData.EditarConsulta(Consulta);
            }           
            return msg;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Metodos**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void NormalizandoDateTime()
        {
            string data = DataSelecionada.ToShortDateString();

            string horaInicio = Consulta.Inicio.ToLongTimeString();

            string horaFim = Consulta.Fim.ToLongTimeString();

            DateTime dataInicio = DateTime.Parse($"{data} {horaInicio}");
            DateTime dataFim = DateTime.Parse($"{data} {horaFim}");
            Consulta.Inicio = dataInicio;
            Consulta.Fim = dataFim;
        }

        public string CamposObrigatoriosPreenchidos()
        {
            Consulta.Procedimento = Procedimentos[ProcedimentoSelecionado];
            StringBuilder sb = new StringBuilder();
            if (Consulta.Cliente == null)
            {
                sb.Append("Cliente, ");
            }
            if (Consulta.Inicio.ToShortTimeString() == "00:00")
            {
                sb.Append("Horário de início, ");
            }
            if (Consulta.Fim.ToShortTimeString() == "00:00" || Consulta.Fim <= Consulta.Inicio)
            {
                sb.Append("Horário de Término, ");
            }
            if (Consulta.Procedimento == null)
            {
                sb.Append("Procedimento, ");
            }
           
            return sb.ToString();
        }

        private void IniciarTela()
        {
            AtorLogado = SingletonAtorLogado.Instancia;
            DataSelecionada = DateTime.Now;
            CarregarProcedimentos();
        }

        public void AcessoAoCampoCliente()
        {
            if (IfNovoCliente)
            {
                SelecaoDeClientesView listaCliente = new SelecaoDeClientesView();

                listaCliente.ShowDialog();
                Cliente clienteEntrada = listaCliente.Cliente;

                //SetCliente(clienteEntrada.Id);

                if (clienteEntrada.Id >= 0)
                {
                    Consulta.Cliente = clienteEntrada;
                    OnPropertyChanged("Consulta");
                }
            }                
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
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(NameProperty));
            }
        }
    }
}
