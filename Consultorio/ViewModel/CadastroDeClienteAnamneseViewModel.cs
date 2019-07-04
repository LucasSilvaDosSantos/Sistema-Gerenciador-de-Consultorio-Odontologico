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
    public class CadastroDeClienteAnamneseViewModel : INotifyPropertyChanged
    {
        private Cliente _Cliente;

        public Cliente Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; OnPropertyChanged("Cliente"); }
        }

        private bool _NaoPreenchido;

        public bool NaoPreenchido
        {
            get { return _NaoPreenchido; }
            set { _NaoPreenchido = value; OnPropertyChanged("NaoPreenchido"); }
        }

        private string _VisibilidadeNaoPreencher;
        public string VisibilidadeNaoPreencher
        {
            get { return _VisibilidadeNaoPreencher; }
            set { _VisibilidadeNaoPreencher = value; OnPropertyChanged("VisibilidadeNaoPreencher"); }
        }


        public CadastroDeClienteAnamneseViewModel(Cliente cliente)
        {
            cliente.Anamnese = CadastroDeClienteAnamneseData.CarregarAnamnese(cliente);
            Cliente = cliente;          
            if (Cliente.Anamnese == null)
            {
                NaoPreenchido = true;
                Cliente.Anamnese = new Anamnese();
            }
            else
            {
                VisibilidadeNaoPreencher = "Hidden";
            }
            IniciarView();
        }

        public CadastroDeClienteAnamneseViewModel()
        {
            IniciarView();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        public string BtSalvar_Click()
        {
            string msg = CadastroDeClienteAnamneseData.CadastrarOuAlterarAnamnese(Cliente, Cliente.Anamnese);
            return msg;   
        }


        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Metodo**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void IniciarView()
        {
            CadastroDeClientesAnamneseView cadastroDeClientesAnamneseView = new CadastroDeClientesAnamneseView(this);
            cadastroDeClientesAnamneseView.ShowDialog();
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
