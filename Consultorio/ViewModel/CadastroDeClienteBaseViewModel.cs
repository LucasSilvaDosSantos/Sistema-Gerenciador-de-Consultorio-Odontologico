using Consultorio.Data;
using Consultorio.Model;
using Consultorio.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Consultorio.ViewModel
{
    public class CadastroDeClienteBaseViewModel : INotifyPropertyChanged
    {

        private Cliente _Cliente;

        public Cliente Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; OnPropertyChanged("Cliente"); }
        }

        private string _VisibilidadeBtAnamnese;

        public string VisibilidadeBtAnamnese
        {
            get { return _VisibilidadeBtAnamnese; }
            set { _VisibilidadeBtAnamnese = value; OnPropertyChanged("VisibilidadeBtAnamnese"); }
        }

        public CadastroDeClienteBaseViewModel(Cliente cliente)
        {
            Cliente = cliente;
            CadastroDeClienteBaseView cadastroDeClienteBaseView = new CadastroDeClienteBaseView(this);
            cadastroDeClienteBaseView.ShowDialog();
        }

        public CadastroDeClienteBaseViewModel()
        {
            VisibilidadeBtAnamnese = "Hidden";
            Cliente = new Cliente();
            Cliente.Nascimento = DateTime.Now;
            CadastroDeClienteBaseView cadastroDeClienteBaseView = new CadastroDeClienteBaseView(this);
            cadastroDeClienteBaseView.ShowDialog();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        public string BtSalvar_Click()
        {
            if (Cliente.Id == 0)
            {
                string msg = CadastroDeClienteBaseData.CadastroDeNovoCliente(Cliente);
                return msg;
            }
            else
            {
                var msg = CadastroDeClienteBaseData.AlterarCliente(Cliente);
                return msg;
            }
        }

        public void BtAnamnese_Click()
        {
            CadastroDeClienteAnamneseViewModel anamneseViewModel = new CadastroDeClienteAnamneseViewModel(Cliente);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Metodo**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        public bool ValidarCamposObrigatorios(out List<string> lista)
        {
            lista = new List<string>();
            if (Cliente.Nome == "" || Cliente.Nome == null)
            {
                lista.Add("Nome");
            }
            if (Cliente.Nascimento.ToShortDateString() == DateTime.Now.ToShortDateString())
            {
                lista.Add("Data de Nascimento");
            }
            if (Cliente.Cpf == "___.___.___-__" || Cliente.Cpf == null)
            {
                lista.Add("CPF");
            }
            if (Cliente.Telefone1 == "(__)_____-____" || Cliente.Telefone1 == null)
            {
                lista.Add("Telefone 1");
            }
            if (lista.Count != 0)
            {
                lista[lista.Count - 1] = lista[lista.Count - 1].Remove(lista[lista.Count - 1].Length - 1);
                return false;
            }
            return true;
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
