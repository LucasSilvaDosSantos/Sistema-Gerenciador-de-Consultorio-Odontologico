using Consultorio.Data;
using Consultorio.Model;
using System.Collections.Generic;
using System.ComponentModel;

namespace Consultorio.ViewModel
{
    public class CrudProdutoViewModel : INotifyPropertyChanged
    {
        private Produto _Produto;
        public Produto Produto
        {
            get { return _Produto; }
            set { _Produto = value; OnPropertyChanged("Produto"); }
        }

        private bool _IdIsEnabled;
        public bool IdIsEnabled
        {
            get { return _IdIsEnabled; }
            set { _IdIsEnabled = value; OnPropertyChanged("IdIsEnabled"); }
        }

        private string _NomeTela;
        public string NomeTela
        {
            get { return _NomeTela; }
            set { _NomeTela = value; OnPropertyChanged("NomeTela"); }
        }

        public CrudProdutoViewModel(int idProduto)
        {          
            Produto = ProdutoData.SelecionarProduto(idProduto);
            NomeTela = "> Editar Produto";
            IdIsEnabled = true;
        }

        public CrudProdutoViewModel()
        {
            Produto = new Produto();
            NomeTela = "> Novo Produto";
            IdIsEnabled = false;
        }


        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        public string BotaoSalvarClick()
        {
            string msg;
            if (Produto.Id == 0 || Produto.Id == null)
            {
                Produto.Id = 0;
                msg = ProdutoData.SalvarProduto(Produto);
            }
            else
            {
                msg = ProdutoData.AlterarProduto(Produto);
            }
            return msg;
        }


        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Funçoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        public bool VerificaCamposObrigatoriosPreenchidos(out List<string> lista)
        {
            lista = new List<string>();
            if(Produto.Nome == "" || Produto.Nome == null)
            {
                lista.Add("Nome");
            }
            if (Produto.Quantidade == 0 || Produto.Quantidade == null)
            {
                lista.Add("Quantidade");
            }

            if (lista.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
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
