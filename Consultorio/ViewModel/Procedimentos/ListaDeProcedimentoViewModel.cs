using Consultorio.Data.Procedimentos;
using Consultorio.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Consultorio.ViewModel.Procedimentos
{
    public class ListaDeProcedimentoViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Procedimento> _ListaDeProcedimentos = new ObservableCollection<Procedimento>(ListaDeProcedimentoData.ListarTodosProcedimentos());
        public ObservableCollection<Procedimento> ListaDeProcedimentos
        {
            get { return _ListaDeProcedimentos; }
            set { _ListaDeProcedimentos = value; OnPropertyChanged("ListaDeProcedimentos"); }
        }

        private Procedimento _ProcedimentoSelecionado = new Procedimento();
        public Procedimento ProcedimentoSelecionado
        {
            get { return _ProcedimentoSelecionado; }
            set { _ProcedimentoSelecionado = value; OnPropertyChanged("ProcedimentoSelecionado"); CarregarListaDeProdutos(); }
        }

        private ObservableCollection<Produto> _ListaDeProdutosParaExibir = new ObservableCollection<Produto>();
        public ObservableCollection<Produto> ListaDeProdutosParaExibir
        {
            get { return _ListaDeProdutosParaExibir; }
            set { _ListaDeProdutosParaExibir = value; OnPropertyChanged("ListaDeProdutosParaExibir"); }
        }
        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Construtor******--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        public ListaDeProcedimentoViewModel()
        {

        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Metodos**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        private void CarregarListaDeProdutos()
        {
            if (ProcedimentoSelecionado != null)
            {
                Procedimento procedimentoSelecionadoComProdutos = ListaDeProcedimentoData.CarregarProdutosDoProcedimento(ProcedimentoSelecionado);

                ListaDeProdutosParaExibir = new ObservableCollection<Produto>(procedimentoSelecionadoComProdutos.Produtos);
            }            
        }

        public void BuscarProcedimento(string id, string nome)
        {
            bool parceOk = int.TryParse(id, out int idInt);

            if (parceOk)
            {
                ListaDeProcedimentos.Clear();
                ListaDeProcedimentos = new ObservableCollection<Procedimento>(ListaDeProcedimentoData.BuscarProcedimentos(idInt, nome));
            }
            else if(id == "")
            {
                ListaDeProcedimentos.Clear();
                ListaDeProcedimentos = new ObservableCollection<Procedimento>(ListaDeProcedimentoData.BuscarProcedimentos(idInt, nome));
            }
            if (id == "" && nome == "")
            {
                RecarregarProdutos();
            }
        }

        public int GetIdProcedimento()
        {
            if (ProcedimentoSelecionado == null)
            {
                return -1;
            }
            return ProcedimentoSelecionado.Id;
        }

        public void RecarregarProdutos()
        {
            ListaDeProcedimentos.Clear();
            ListaDeProcedimentos = new ObservableCollection<Procedimento>(ListaDeProcedimentoData.ListarTodosProcedimentos());
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
