using Consultorio.Data.Consultas;
using Consultorio.Model;
using System.ComponentModel;

namespace Consultorio.ViewModel.Consultas
{
    public class CancelarConsultaViewModel : INotifyPropertyChanged
    {
        private string _MotivoDoCancelamento;

        public string MotivoDoCancelamento
        {
            get { return _MotivoDoCancelamento; }
            set { _MotivoDoCancelamento = value; OnPropertyChanged("MotivoDoCancelamento"); }
        }

        private Consulta _Consulta;

        public Consulta Consulta
        {
            get { return _Consulta; }
            set { _Consulta = value; OnPropertyChanged("Consulta"); }
        }

        public CancelarConsultaViewModel(int id)
        {
            Consulta = ConsultasData.SelecionarConsulta(id);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        public bool SalvarCancelamentoDeConsulta(bool reagendada)
        {
            if (reagendada)
            {
                Consulta.Status = Model.Enums.StatusConsulta.Reagendada;
            }
            else
            {
                Consulta.Status = Model.Enums.StatusConsulta.Cancelada;
            }
            
            Consulta.Obs = ($"Motivo do cancelamento: {MotivoDoCancelamento.ToLower()}.\n{Consulta.Obs}");
            
            return ConsultasData.SalvarStatusDeConsulta(Consulta);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

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
