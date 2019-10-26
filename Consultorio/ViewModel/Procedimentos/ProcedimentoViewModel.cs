using Consultorio.Data.Procedimentos;
using Consultorio.Data.Produtos;
using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Consultorio.ViewModel.Procedimentos
{
    public class ProcedimentoViewModel : INotifyPropertyChanged
    {
        public List<string> Horas { get; set; } = new List<string> { "00", "01", "02", "03", "04" };
        public List<string> Minutos { get; set; } = new List<string> { "00", "05", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55" };

        private string _HoraSelecionada;
        public string HoraSelecionada
        {
            get { return _HoraSelecionada; }
            set { _HoraSelecionada = value; OnPropertyChanged("HoraSelecionada"); }
        }

        private string _MinutoSelecionado;
        public string MinutoSelecionado
        {
            get { return _MinutoSelecionado; }
            set { _MinutoSelecionado = value; OnPropertyChanged("MinutoSelecionado"); }
        }

        private string _NomeDaTela;
        public string NomeDaTela
        {
            get { return _NomeDaTela; }
            set { _NomeDaTela = value; OnPropertyChanged("NomeDaTela"); }
        }

        private Procedimento _Procedimento;
        public Procedimento Procedimento
        {
            get { return _Procedimento; }
            set { _Procedimento = value; OnPropertyChanged("Procedimento"); }
        }

        private Produto _ProdutoSelecionadoParaRemover = new Produto();
        public Produto ProdutoSelecionadoParaRemover
        {
            get { return _ProdutoSelecionadoParaRemover; }
            set { _ProdutoSelecionadoParaRemover = value; OnPropertyChanged("ProdutoSelecionadoParaRemover"); }
        }

        private Produto _ProdutoSelecionadoParaAdd = new Produto();
        public Produto ProdutoSelecionadoParaAdd
        {
            get { return _ProdutoSelecionadoParaAdd; }
            set { _ProdutoSelecionadoParaAdd = value; OnPropertyChanged("ProdutoSelecionadoParaAdd"); }
        }

        private ObservableCollection<Produto> _ListaDeProdutosAdd = new ObservableCollection<Produto>();
        public ObservableCollection<Produto> ListaDeProdutosAdd
        {
            get { return _ListaDeProdutosAdd; }
            set { _ListaDeProdutosAdd = value; OnPropertyChanged("ListaDeProdutosAdd"); }
        }

        private ObservableCollection<Produto> _ProdutosForaLista = new ObservableCollection<Produto>();
        public ObservableCollection<Produto> ProdutosForaLista
        {
            get { return _ProdutosForaLista; }
            set { _ProdutosForaLista = value; OnPropertyChanged("ProdutosForaLista"); }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Construtor******--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        public ProcedimentoViewModel()
        {
            NomeDaTela = "> Novo Procedimento";
            Procedimento = new Procedimento();
    
            //CarregarListaProdutosFora();

            HoraSelecionada = "00";

            MinutoSelecionado = "00";
        }

        public ProcedimentoViewModel(int id)
        {
            Procedimento = ProcedimentoData.PegarProcedimento(id);

            ListaDeProdutosAdd = new ObservableCollection<Produto>(Procedimento.Produtos);

            NomeDaTela = "> Editar Procedimento";

            CarregarHoraAgendada();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        public void BuscarPorIdProdutos(string id)
        {
            bool parceOk = int.TryParse(id, out int idInt);
            if (parceOk)
            {
                ProdutosForaLista = new ObservableCollection<Produto>(ProdutoData.BuscarProdutosId(id, out bool encontrado));
            }
            else
            {
                ProdutosForaLista = new ObservableCollection<Produto>();
            }
        }

        public void BuscarPorNomeProdutos(string nome)
        {
            if ((nome != "" || nome != null) && nome.Length >= 3 )
            {
                ProdutosForaLista = new ObservableCollection<Produto>(ProdutoData.BuscarProdutosNome(nome, out bool encontrado));
            }
            else
            {
                 ProdutosForaLista = new ObservableCollection<Produto>();                
            }
        }

        public string SalvarProcedimento(out bool salvo)
        {
            string msg;
            Procedimento.Produtos = ListaDeProdutosAdd;
            
            NormalizaDataTime();

            if (NomeValido() == false)
            {
                msg = "Nome do procedimento invalido!";
                salvo = false;
                return msg;
            }

            if (Procedimento.Id == 0)
            {
                msg = ProcedimentoData.CadastroDeNovoProcedimento(Procedimento);
                salvo = true;
            }
            else
            {
                msg = ProcedimentoData.AlterarProcedimento(Procedimento);
                salvo = true;
            }            
            return msg;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Metodos**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        private void NormalizaDataTime()
        {
            string data = "0001 - 01 - 01";

            string tempoRecomendado = ($"{HoraSelecionada}:{MinutoSelecionado}:00");

            Procedimento.TempoRecomendado = DateTime.Parse($"{data} {tempoRecomendado}"); 
        }

        private void CarregarHoraAgendada()
        {
            var horaMinuto = Procedimento.TempoRecomendado.ToShortTimeString();
            var lista = horaMinuto.Split(':');
            HoraSelecionada = lista[0];
            MinutoSelecionado = lista[1];
        }

        private bool NomeValido()
        {
            if  (Procedimento.Nome == null || Procedimento.Nome == "")
            {
                return false;
            }
            return true;
        }


        public void DeletarItemDaLista()
        {
            ListaDeProdutosAdd.Remove(ProdutoSelecionadoParaRemover);
        }

        public void AddProduto()
        {
            foreach (var p in ListaDeProdutosAdd)
            {
                if (p.Id == ProdutoSelecionadoParaAdd.Id)
                {
                    return;
                }
            }

            ListaDeProdutosAdd.Add(ProdutoSelecionadoParaAdd);
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
