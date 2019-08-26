using Consultorio.Data.Produtos;
using Consultorio.Model;
using Consultorio.ViewModel.Atores;
using System;
using System.ComponentModel;

namespace Consultorio.ViewModel.Produtos
{
    public class EntradaDeProdutoViewModel : INotifyPropertyChanged
    {
        public SingletonAtorLogado AtorLogado { get; set; }

        private ProdutoCompra _ProdutoCompra;
        public ProdutoCompra ProdutoCompra
        {
            get { return _ProdutoCompra; }
            set { _ProdutoCompra = value; OnPropertyChanged("ProdutoCompra"); }
        }

        public EntradaDeProdutoViewModel(int id)
        {
            AtorLogado = SingletonAtorLogado.Instancia;
            IniciarProduto(id);           
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Metodos**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        public string SalvarCompra()
        {
            return ProdutoData.CadastrarCompra(ProdutoCompra);
        }

        private void IniciarProduto(int id)
        {
            ProdutoCompra = new ProdutoCompra();
            ProdutoCompra.Produto = ProdutoData.SelecionarProduto(id);
            ProdutoCompra.QuemRegistrou = AtorLogado.Ator;
            ProdutoCompra.DataDeCompra = DateTime.Now;
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
