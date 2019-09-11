using Consultorio.Data.Produtos;
using Consultorio.Model;
using Consultorio.ViewModel.Atores;
using System.Collections.Generic;
using System.ComponentModel;

namespace Consultorio.ViewModel.Produtos
{
    public class ProdutosViewModel : INotifyPropertyChanged
    {


        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Atributos**********-----------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        public SingletonAtorLogado AtorLogado { get; set; }

        private List<Produto> _TodosOsProdutos;
        public List<Produto> TodosOsProdutos
        {
            get { return _TodosOsProdutos; }
            set { _TodosOsProdutos = value; OnPropertyChanged("TodosOsProdutos"); }
        }

        private Produto _ProdutoSelecionado;
        public Produto ProdutoSelecionado
        {
            get { return _ProdutoSelecionado; }
            set { _ProdutoSelecionado = value; OnPropertyChanged("ProdutoSelecionado"); }
        }

        public ProdutosViewModel()
        {
            ProdutoSelecionado = new Produto();
            AtorLogado = SingletonAtorLogado.Instancia;

            BuscaQtdEstoque("5");
            //LimparListaDeProdutos();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        public int RetornaIdProdutoSelecionado()
        {
            if (ProdutoSelecionado != null && ProdutoSelecionado.Id != null)
            {
                int.TryParse(ProdutoSelecionado.Id.ToString(), out int id);
                if (id != 0)
                {
                    return id;
                }
            }           
            return 0;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Metodos**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        public void ResetarTela()
        {
            LimparCampos();
        }

        public void BuscaQtdEstoque(string qtd)
        {
            var parceOk = int.TryParse(qtd, out int qtdInt);

            if (parceOk)
            {
                TodosOsProdutos = ProdutoData.BuscarProdutosEstoqueAbaixoDe(qtdInt);
            }
            else
            {
                LimparListaDeProdutos();
            }           
        }

        private void LimparListaDeProdutos()
        {           
            TodosOsProdutos = new List<Produto>(); //ProdutoData.ListarTodosProdutos();
        }

        private void LimparCampos()
        {
            ProdutoSelecionado = new Produto();
        }

        public void BuscarNome(string nome)
        {
            if (nome == "" || nome.Length < 3)
            {
                LimparListaDeProdutos();
                return;
            }
            List<Produto> lista = ProdutoData.BuscarProdutosNome(nome, out bool encontrado);
            if (encontrado)
            {               
                TodosOsProdutos = lista;
            }
            else
            {
                TodosOsProdutos = null;
            }
        }

        public void BuscarId(string id)
        {
            if (id == "")
            {
                LimparListaDeProdutos();
                return;
            }
            List<Produto> lista = ProdutoData.BuscarProdutosId(id, out bool encontrado);
            if (encontrado)
            {
                TodosOsProdutos = lista;
            }
            else
            {
                TodosOsProdutos = null;
            }
        }

        public void RecarregarGrid()
        {
            LimparListaDeProdutos();
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
