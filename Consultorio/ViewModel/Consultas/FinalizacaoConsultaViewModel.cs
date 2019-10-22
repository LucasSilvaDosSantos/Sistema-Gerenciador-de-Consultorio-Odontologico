using Consultorio.Data.Clientes;
using Consultorio.Data.Consultas;
using Consultorio.Data.Produtos;
using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Consultorio.ViewModel.Consultas
{
    public class FinalizacaoConsultaViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Produto> _ListaDeProdutos = new ObservableCollection<Produto>();
        public ObservableCollection<Produto> ListaDeProdutos
        {
            get { return _ListaDeProdutos; }
            set { _ListaDeProdutos = value; OnPropertyChanged("ListaDeProdutos"); }
        }

        private Consulta _Consulta;
        public Consulta Consulta
        {
            get { return _Consulta; }
            set { _Consulta = value; OnPropertyChanged("Consulta"); }
        }

        private double _ValorDaConsulta;
        public double ValorDaConsulta
        {
            get { return _ValorDaConsulta; }
            set { _ValorDaConsulta = value; OnPropertyChanged("ValorDaConsulta"); }
        }

        private List<OrcamentosParaProcedimentos> OrcamentoProcedimentos;

        private List<Procedimento> _TodosOsProcedimentos;
        public List<Procedimento> TodosOsProcedimentos
        {
            get { return _TodosOsProcedimentos; }
            set { _TodosOsProcedimentos = value; OnPropertyChanged("TodosOsProcedimentos"); }
        }

        private List<Procedimento> _ProcedimentosEmOrcamento;
        public List<Procedimento> ProcedimentosEmOrcamento
        {
            get { return _ProcedimentosEmOrcamento; }
            set { _ProcedimentosEmOrcamento = value; OnPropertyChanged("ProcedimentosEmOrcamento"); }
        }

        private ObservableCollection<Procedimento> _Procedimentos;
        public ObservableCollection<Procedimento> Procedimentos
        {
            get { return _Procedimentos; }
            set { _Procedimentos = value; OnPropertyChanged("Procedimentos"); }
        }

        private ProdutoUtilizadoEmConsulta _ProdutoSelecionadoParaRemover;
        public ProdutoUtilizadoEmConsulta ProdutoSelecionadoParaRemover
        {
            get { return _ProdutoSelecionadoParaRemover; }
            set { _ProdutoSelecionadoParaRemover = value; OnPropertyChanged("ProdutoSelecionadoParaRemover"); }
        }

        private Produto _ProdutoSelecionadoParaAdd;
        public Produto ProdutoSelecionadoParaAdd
        {
            get { return _ProdutoSelecionadoParaAdd; }
            set { _ProdutoSelecionadoParaAdd = value; OnPropertyChanged("ProdutoSelecionadoParaAdd"); }
        }

        private ObservableCollection<ProdutoUtilizadoEmConsulta> _ListaProdutosUtilizadoNaConsulta;
        public ObservableCollection<ProdutoUtilizadoEmConsulta> ListaProdutosUtilizadoNaConsulta
        {
            get { return _ListaProdutosUtilizadoNaConsulta; }
            set { _ListaProdutosUtilizadoNaConsulta = value; OnPropertyChanged("ListaProdutosUtilizadoNaConsulta"); }
        }

        private Procedimento _ProcedimentoSelecionado;
        public Procedimento ProcedimentoSelecionado
        {
            get { return _ProcedimentoSelecionado; }
            set { _ProcedimentoSelecionado = value; OnPropertyChanged("ProcedimentoSelecionado"); Consulta.Procedimento = value; }
        }

        public FinalizacaoConsultaViewModel(int idConsulta, out bool procedimentoDaListaDeOrcamento, out string procedimentoDaListaDeOrcamentoNome)
        {

            TodosOsProcedimentos = ConsultasData.ListarTodosOsProcedimentos();
            Consulta = ConsultasData.SelecionarConsulta(idConsulta);

            var idProcedimentoDaConsulta = Consulta.Procedimento.Id;
            Consulta.Fim = DateTime.Now;

            

            ProcedimentosEmOrcamento = CarregarProcedimentosDeOrcamento();

            ListaProdutosUtilizadoNaConsulta = new ObservableCollection<ProdutoUtilizadoEmConsulta>();

            CarregarProdutosDaConsulta();

            ProcedimentoSelecionado = ProcedimentosEmOrcamento.FirstOrDefault(a => a.Id == idProcedimentoDaConsulta);
            procedimentoDaListaDeOrcamento = false;
            if (ProcedimentoSelecionado != null)
            {
                procedimentoDaListaDeOrcamento = true;
            }
            else
            {
                ProcedimentoSelecionado = TodosOsProcedimentos.First(_ => _.Id == idProcedimentoDaConsulta);
            }
            procedimentoDaListaDeOrcamentoNome = ProcedimentoSelecionado.Nome;
            LimparlistaDeProdutos();
        }



        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Metodos**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        

        private List<Procedimento> CarregarProcedimentosDeOrcamento()
        {
            var orcamento = OrcamentoData.BuscarOrcamentoPorIdCliente(Consulta.Cliente.Id);

            var lista = new List<Procedimento>();

            if (orcamento != null)
            {

                OrcamentoProcedimentos = OrcamentoData.BuscarListaOrcamentoParaProcedimentoPorIdOrcamento(orcamento.Id);

                foreach (var item in OrcamentoProcedimentos)
                {
                    lista.Add(item.Procedimento);
                }
            }

            return lista;
        }

        public void CalcularValorProcedimentoSelecionado(bool procedimentoDaListaDeOrcamento)
        {
            if (ProcedimentoSelecionado != null && OrcamentoProcedimentos != null)
            {
                var orcamentoProcedimento = OrcamentoProcedimentos.FirstOrDefault(_ => _.Procedimento.Id == ProcedimentoSelecionado.Id);
                if (procedimentoDaListaDeOrcamento)
                {
                    ValorDaConsulta = (orcamentoProcedimento.ValorTotalDoProcedimento / orcamentoProcedimento.QtdDeProcedimentos);
                }
                else
                {
                    ValorDaConsulta = ProcedimentoSelecionado.Preco;
                }
            }
        }

        public void AlterarListaProcedimentos(bool produtosOrcamento)
        {
            if (produtosOrcamento)
            {
                CarregarProcedimentosPelaListaDeOrcamento();
            }
            else
            {
                CarregarProcedimentosPelaListaDeTodos();
            }
        }

        public void CarregarProcedimentosPelaListaDeOrcamento()
        {
            Procedimentos = new ObservableCollection<Procedimento>(ProcedimentosEmOrcamento);
        }

        public void CarregarProcedimentosPelaListaDeTodos()
        {
            Procedimentos = new ObservableCollection<Procedimento>(TodosOsProcedimentos);
        }

        private void LimparlistaDeProdutos()
        {
            ListaDeProdutos = new ObservableCollection<Produto>();
        }

        public void AlterarValorDaConsulta()
        {
            if (ProcedimentoSelecionado != null)
                ValorDaConsulta = ProcedimentoSelecionado.Preco;
            else
                ValorDaConsulta = 0;
        }

        public void DeletarItemDaLista()
        {
            var listaParaRetirar = new List<ProdutoUtilizadoEmConsulta>();
            if (ProdutoSelecionadoParaRemover != null)
            {
                foreach(var aux in ListaProdutosUtilizadoNaConsulta)
                {
                    if (aux.Produto.Id == ProdutoSelecionadoParaRemover.Produto.Id)
                    {
                        if (aux.QtdProdutoUtilizado > 1)
                        {
                            aux.QtdProdutoUtilizado -= 1;
                        }
                        else
                        {
                            listaParaRetirar.Add(aux);
                        }
                    }
                }
                foreach(var aux in listaParaRetirar)
                {
                    ListaProdutosUtilizadoNaConsulta.Remove(aux);
                }
                var aux1 = ListaProdutosUtilizadoNaConsulta;
                ListaProdutosUtilizadoNaConsulta = new ObservableCollection<ProdutoUtilizadoEmConsulta>(aux1);
            }                    
        }

        public void AddProduto()
        {
            if (ProdutoSelecionadoParaAdd != null)
            {
                bool flag = false;
                foreach(var aux in ListaProdutosUtilizadoNaConsulta)
                {
                    if (aux.Produto.Id == ProdutoSelecionadoParaAdd.Id)
                    {
                        aux.QtdProdutoUtilizado += 1;
                        
                        flag = true;
                    }
                }
                //Feito assim para notificar a tela sobre a alteração e nao prescisar de mais codigos
                var aux1 = ListaProdutosUtilizadoNaConsulta;
                ListaProdutosUtilizadoNaConsulta = new ObservableCollection<ProdutoUtilizadoEmConsulta>(aux1);
                if (flag == false)
                {
                    ListaProdutosUtilizadoNaConsulta.Add(new ProdutoUtilizadoEmConsulta() {Consulta = Consulta, Produto = ProdutoSelecionadoParaAdd, QtdProdutoUtilizado = 1 });
                }
            }
        }

        private void CarregarProdutosDaConsulta()
        {
            var listaProdutos = Consulta.Procedimento.Produtos;
            foreach(var item in listaProdutos)
            {
                ListaProdutosUtilizadoNaConsulta.Add(new ProdutoUtilizadoEmConsulta() { Consulta = Consulta, Produto = item, QtdProdutoUtilizado = 1 });
            }            
        }

        public void BuscarIdTodosOsProdutos(string id)
        {
            int.TryParse(id, out int idInt);
            if (idInt != 0)
            {
                ListaDeProdutos = new ObservableCollection<Produto>(ProdutoData.BuscarProdutosId(id, out bool encontrado));
            }
            else
            {
                LimparlistaDeProdutos();
            }         
        }

        public void BuscarNomeTodosOsProdutos(string nome)
        {
            if (nome.Length >= 3)
            {
                ListaDeProdutos = new ObservableCollection<Produto>(ProdutoData.BuscarProdutosNome(nome, out bool encontrado));
            }
            else
            {
                LimparlistaDeProdutos();
            }
        }

        public bool SalvarConsulta()
        {
            Consulta.ValorConsulta = ValorDaConsulta;
            Consulta.Procedimento = ProcedimentoSelecionado;
            Consulta.ProdutoUtilizadoEmConsulta = new List<ProdutoUtilizadoEmConsulta>(ListaProdutosUtilizadoNaConsulta);
            bool consultaSalva = FinalizarConsultaData.SalvarFinalizacaoDeConsulta(Consulta, ListaProdutosUtilizadoNaConsulta);
            return consultaSalva;
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
