using Consultorio.Data;
using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.ViewModel
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

        private Produto _Produto;
        public Produto Produto
        {
            get { return _Produto; }
            set { _Produto = value; OnPropertyChanged("Produto"); }
        }

        private bool _CamposAtivos;
        public bool CamposAtivos
        {
            get { return _CamposAtivos; }
            set { _CamposAtivos = value; OnPropertyChanged("CamposAtivos"); }
        }

        private bool _BotaoBuscarIsEnabled;
        public bool BotaoBuscarIsEnabled
        {
            get { return _BotaoBuscarIsEnabled; }
            set { _BotaoBuscarIsEnabled = value; OnPropertyChanged("BotaoBuscarIsEnabled"); }
        }

        private bool _BotaoCadastrarNovoIsEnabled;
        public bool BotaoCadastrarNovoIsEnabled
        {
            get { return _BotaoCadastrarNovoIsEnabled; }
            set { _BotaoCadastrarNovoIsEnabled = value; OnPropertyChanged("BotaoCadastrarNovoIsEnabled"); }
        }

        private bool _BotaoSalvarIsEnabled;
        public bool BotaoSalvarIsEnabled
        {
            get { return _BotaoSalvarIsEnabled; }
            set { _BotaoSalvarIsEnabled = value; OnPropertyChanged("BotaoSalvarIsEnabled"); }
        }

        private bool _BotaoCancelarIsEnabled;
        public bool BotaoCancelarIsEnabled
        {
            get { return _BotaoCancelarIsEnabled; }
            set { _BotaoCancelarIsEnabled = value; OnPropertyChanged("BotaoCancelarIsEnabled"); }
        }

        public ProdutosViewModel()
        {
            Produto = new Produto();
            AtorLogado = SingletonAtorLogado.Instancia;
            CarregarTodosOsProdutos();
            BotoesAtivos(1);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********-----------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        public void DataGridSelect(int index)
        {
            SelecionarProduto(index);
            BotoesAtivos(2);
        }

        public void BotaoCancelarClick()
        {
            ResetarTela();
        }

        public string BotaoSalvarClick(out bool salvo)
        {
            StringBuilder sb = new StringBuilder();
            if (Produto.Nome == "")
            {
                sb.Append("Nome, ");
            }
            else if (Produto.Quantidade == 0 || Produto.Quantidade == null)
            {
                sb.Append("Quantidade");
            }     
            if (sb.Length > 0)
            {
                salvo = false;
                return sb.ToString();
            }
            else
            {
                string msg;
                // para novo produto
                if (Produto.Id == null)
                {
                    Produto.Id = 0;
                    msg = ProdutoData.SalvarProduto(Produto);
                }
                // para alterar produto
                else
                {
                    msg = ProdutoData.AlterarProduto(Produto);
                }
                ResetarTela();


                salvo = true;
                return msg;
            }           
        }

        public void BotaoCadastrarNovoClick()
        {
            Produto = new Produto();
            CamposAtivos = true;
            BotoesAtivos(2);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Metodos**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        private void ResetarTela()
        {
            LimparCampos();
            CamposAtivos = false;
            BotoesAtivos(1);
            CarregarTodosOsProdutos();
        }

        private void BotoesAtivos(int op)
        {
            if (op == 1)
            {
                BotaoCancelarIsEnabled = false;
                BotaoSalvarIsEnabled = false;
                BotaoCadastrarNovoIsEnabled = true;
                BotaoBuscarIsEnabled = true;
            }
            else if (op == 2)
            {
                BotaoCancelarIsEnabled = true;
                BotaoSalvarIsEnabled = true;
                BotaoCadastrarNovoIsEnabled = false;
                BotaoBuscarIsEnabled = false;
            }else if (op == 3)
            {
                BotaoCancelarIsEnabled = true;
                BotaoSalvarIsEnabled = false;
                BotaoCadastrarNovoIsEnabled = false;
                BotaoBuscarIsEnabled = true;
            }
        }

        private void CarregarTodosOsProdutos()
        {
            TodosOsProdutos = ProdutoData.ListarTodosProdutos();
        }

        private void LimparCampos()
        {
            Produto = new Produto();
        }

        /*public void ClickBotaoCancelar()
        {
            CarregarTodosOsProdutos();
            ModificaAtivacaoBotoes(1);
            LimparCampos();        
            CamposAtivos = false;
        }*/

        private void SelecionarProduto(int i)
        {
            Produto = TodosOsProdutos[i];
            CamposAtivos = true;
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
