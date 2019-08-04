using Consultorio.Data.Clientes;
using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.ViewModel.Clientes
{
    public class CadastroDeOdontogramaViewModel : INotifyPropertyChanged
    {
        public Cliente Cliente { get; set; }

        private Odontograma _odontograma;
         
        public Odontograma Odontograma
        {
            get { return _odontograma; }
            set { _odontograma = value; OnPropertyChanged("Odontograma"); }
        }

        public CadastroDeOdontogramaViewModel(int idCliente)
        {
            Cliente = ClienteOdontogramaData.CarregarOdontograma(idCliente);
            Odontograma = Cliente.Odontograma;

            IniciarOdontograma();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        public string btSalvar()
        {
            return SalvarOdontograma();
        }
        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Metodo**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        private string SalvarOdontograma()
        {
            return ClienteOdontogramaData.SalvarOdontograma(Cliente, Odontograma);    
        }

        private void IniciarOdontograma()
        {
            if (Cliente.Odontograma != null)
            {
                Odontograma = Cliente.Odontograma;
            }
            else
            {
                Odontograma = new Odontograma();
            }
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
