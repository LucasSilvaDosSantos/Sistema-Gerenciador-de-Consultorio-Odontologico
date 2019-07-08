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
    public class CadastroDeColaboradoresViewModel : INotifyPropertyChanged
    {
        public SingletonAtorLogado AtorLogado { get; set; }

        private bool _BtNovoMedicoDentistaIsEnabled;
        public bool BtNovoMedicoDentistaIsEnabled
        {
            get { return _BtNovoMedicoDentistaIsEnabled;  }
            set { _BtNovoMedicoDentistaIsEnabled = value; OnPropertyChanged("BtNovoMedicoDentistaIsEnabled"); }
        }

        private bool _BtNovaSecretariaIsEnabled;
        public bool BtNovaSecretariaIsEnabled
        {
            get { return _BtNovaSecretariaIsEnabled; }
            set { _BtNovaSecretariaIsEnabled = value; OnPropertyChanged("BtNovaSecretariaIsEnabled"); }
        }

        private bool _BtNovoGestorIsEnabled;
        public bool BtNovoGestorIsEnabled
        {
            get { return _BtNovoGestorIsEnabled; }
            set { _BtNovoGestorIsEnabled = value; OnPropertyChanged("BtNovoGestorIsEnabled"); }
        }


        public CadastroDeColaboradoresViewModel()
        {
            AtorLogado = SingletonAtorLogado.Instancia;
            ControleDeAcesso();
            CadastroDeColaboradoresView cadastroDeColaboradoresView = new CadastroDeColaboradoresView(this);
            cadastroDeColaboradoresView.ShowDialog();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        public void BtMedicoDentista_Click()
        {
            new DentistaViewModel();
        }

        public void BtSecretariaAuxiliar_Click()
        {
            //// vai mudar para abrir no view model
            SecretariaView secretaria = new SecretariaView();
            secretaria.ShowDialog();
        }

        public void BtGestorDeEstoque_Click()
        {
            //// vai mudar para abrir no view model
            new GestorDeEstoqueViewModel();
        }

        public void BtTodosOsColaboradores_Click()
        {
            //// vai mudar para abrir no view model
            ListaDeColaboradoresView colaboradores = new ListaDeColaboradoresView();
            colaboradores.Show();
        }

        public void BtVoltar_Click()
        {
            new OpcoesViewModel();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Metodo**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void ControleDeAcesso()
        {
            var atorLogadoType = AtorLogado.Ator.GetType();
            /*if (atorLogado.cont)
            if (AtorLogado.Ator)*/
            if (atorLogadoType.Name == "Dentista")
            {
                BtNovoGestorIsEnabled = true;
                BtNovoMedicoDentistaIsEnabled = true;
                BtNovaSecretariaIsEnabled = true;
            }
            else if (atorLogadoType.Name == "Secretaria")
            {
                BtNovoGestorIsEnabled = false;
                BtNovoMedicoDentistaIsEnabled = false;
                BtNovaSecretariaIsEnabled = false;
                var secretaria = (Secretaria)AtorLogado.Ator;
                if (secretaria.CrudGestoresDeEstoque == true)
                {
                    BtNovoGestorIsEnabled = true;
                }
                if (secretaria.CrudSecretarias == true)
                {
                    BtNovaSecretariaIsEnabled = true;
                }
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
