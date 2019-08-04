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
    public class CrudClienteViewModel : INotifyPropertyChanged
    {
        private bool _AnamneseNaoPrenchida;

        public bool AnamneseNaoPrenchida
        {
            get { return _AnamneseNaoPrenchida; }
            set { _AnamneseNaoPrenchida = value; OnPropertyChanged("AnamneseNaoPrenchida"); }
        }

        private Cliente _Cliente;

        public Cliente Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; OnPropertyChanged("Cliente"); }
        }

        private bool _VisibilidadeBtAnamnese;

        public bool VisibilidadeBtAnamnese
        {
            get { return _VisibilidadeBtAnamnese; }
            set { _VisibilidadeBtAnamnese = value; OnPropertyChanged("VisibilidadeBtAnamnese"); }
        }

        public CrudClienteViewModel()
        {
            Cliente = new Cliente();
            CarregarClienteOdontograma();
            VerificarSeExisteAnamnese();
        }

        public CrudClienteViewModel(int id)
        {
            Cliente = CrudClienteData.BuscarClientePorId(id);
            CarregarClienteOdontograma();
            VerificarSeExisteAnamnese();
        }

        public string SalvarCliente()
        {
            if (AnamneseNaoPrenchida == true)
            {
                Cliente.Anamnese = null;
            }
            return CrudClienteData.SalvarCliente(Cliente);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        public bool ExisteCamposObrigatoriosEmBranco(out List<string> camposEmBranco)
        {
            camposEmBranco = new List<string>();
            if (Cliente.Nome == null || Cliente.Nome == "")
            {
                camposEmBranco.Add("Nome");
            }
            if (Cliente.Cpf == null || Cliente.Cpf == "___.___.___-__")
            {
                camposEmBranco.Add("CPF");
            }
            if (Cliente.Telefone1 == "(__)_____-____" || Cliente.Telefone1 == null)
            {
                camposEmBranco.Add("Telefone 1");
            }

            if (camposEmBranco.Count > 0)
            {
                return true;
            }
            return false;
        }

        private void CarregarClienteOdontograma()
        {
            if (Cliente.Odontograma == null)
            {
                Cliente.Odontograma = new Odontograma();
            }
        }

        private void VerificarSeExisteAnamnese()
        {
            if (Cliente.Anamnese == null)
            {
                AnamneseNaoPrenchida = true;
                VisibilidadeBtAnamnese = true;
                Cliente.Anamnese = new Anamnese();
            }
            else
            {
                AnamneseNaoPrenchida = false;
                VisibilidadeBtAnamnese = false;
            }
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
