using Consultorio.Model;
using System;
using System.ComponentModel;
using Consultorio.Data.Clientes;
using Consultorio.Data.Procedimentos;
using Consultorio.ViewModel.Atores;
using System.Collections.ObjectModel;
using Consultorio.Data.Atores;
using System.Collections.Generic;

namespace Consultorio.ViewModel.Clientes
{
    public class OrcamentoViewModel : INotifyPropertyChanged
    {
        public Ator AtorLogado { get; set; }

        private Orcamento _Orcamento;
        public Orcamento Orcamento
        {
            get { return _Orcamento; }
            set { _Orcamento = value; OnPropertyChanged("Orcamento"); }
        }

        private ObservableCollection<Procedimento> _ListaDeTodosOsProcedimentos;
        public ObservableCollection<Procedimento> ListaDeTodosOsProcedimentos
        {
            get { return _ListaDeTodosOsProcedimentos; }
            set { _ListaDeTodosOsProcedimentos = value; OnPropertyChanged("ListaDeTodosOsProcedimentos");}
        }

        private Procedimento _ProcedimentoSelecionadoDeTodos;
        public Procedimento ProcedimentoSelecionadoDeTodos
        {
            get { return _ProcedimentoSelecionadoDeTodos; }
            set { _ProcedimentoSelecionadoDeTodos = value; OnPropertyChanged("ProcedimentoSelecionadoDeTodos"); }
        }

        private ObservableCollection<OrcamentosParaProcedimentos> _ListaDosProcedimentosAdicionados;
        public ObservableCollection<OrcamentosParaProcedimentos> ListaDosProcedimentosAdicionados
        {
            get { return _ListaDosProcedimentosAdicionados; }
            set { _ListaDosProcedimentosAdicionados = value; OnPropertyChanged("ListaDosProcedimentosAdicionados"); CalcularValoresTotais(); }
        }

        private OrcamentosParaProcedimentos _ProcedimentoSelecionadoDosAdicionados;
        public OrcamentosParaProcedimentos ProcedimentoSelecionadoDosAdicionados
        {
            get { return _ProcedimentoSelecionadoDosAdicionados; }
            set { _ProcedimentoSelecionadoDosAdicionados = value; OnPropertyChanged("ProcedimentoSelecionadoDosAdicionados"); }
        }

        private double _TotalParcial;
        public double TotalParcial
        {
            get { return _TotalParcial; }
            set { _TotalParcial = value; OnPropertyChanged("TotalParcial"); }
        }

        private double _BoxDesconto;
        public double BoxDesconto
        {
            get { return _BoxDesconto; }
            set { _BoxDesconto = value; OnPropertyChanged("BoxDesconto"); }
        }

        private double _TotalComDescontos;
        public double TotalComDescontos
        {
            get { return _TotalComDescontos; }
            set { _TotalComDescontos = value; OnPropertyChanged("TotalComDescontos"); }
        }


        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Construtor******--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        public OrcamentoViewModel(int id)
        {
            AtorLogado = SingletonAtorLogado.Instancia.Ator;

            Orcamento = OrcamentoData.BuscarOrcamentoPorIdCliente(id);
            if (Orcamento != null)
            {
                ListaDosProcedimentosAdicionados = new ObservableCollection<OrcamentosParaProcedimentos>(Orcamento.OrcamentosParaProcedimentos);
            }
            else
            {
                Orcamento = new Orcamento() { Cliente = CrudClienteData.BuscarClientePorId(id), OrcamentosParaProcedimentos = new List<OrcamentosParaProcedimentos>() };
                OrcamentoData.SalvarNovoOrcamento(Orcamento);

                Orcamento = OrcamentoData.BuscarOrcamentoPorIdCliente(id);
                ListaDosProcedimentosAdicionados = new ObservableCollection<OrcamentosParaProcedimentos>();
            }
            

            CarregarTodosOsProcedimentos();

            if (Orcamento == null)
            {
                Orcamento = new Orcamento();
                Orcamento.Cliente = CrudClienteData.BuscarClientePorId(id);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Botoes**********--------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        public void AdicionarProcedimento()
        {
            bool flagAchouNaLista = false;
            foreach (var i in ListaDosProcedimentosAdicionados)
            {
                if (ProcedimentoSelecionadoDeTodos.Id == i.Procedimento.Id)
                {
                    i.QtdDeProcedimentos += 1;
                    i.DataDeAdicao = DateTime.Now;
                    i.ColaboradorAlterou = AtorLogado;
                    flagAchouNaLista = true;
                    break;
                }
            }
            if (flagAchouNaLista == false)
            {
                OrcamentosParaProcedimentos aux = new OrcamentosParaProcedimentos() {
                    ColaboradorAlterou = AtorLogado, DataDeAdicao = DateTime.Now, DescontoEmProcentagem = 0, Orcamento = Orcamento, OrcamentoID = Orcamento.Id,
                    Procedimento = ProcedimentoSelecionadoDeTodos, ProcedimentoID = ProcedimentoSelecionadoDeTodos.Id, QtdDeProcedimentos = 1, ValorTotalDoProcedimento = ProcedimentoSelecionadoDeTodos.Preco };
                ListaDosProcedimentosAdicionados.Add(aux);
            }
            CalcularValoresTotais();
        }

        public void RemoverProcedimento()
        {
            if (ProcedimentoSelecionadoDosAdicionados.QtdDeProcedimentos > 1)
            {
                ProcedimentoSelecionadoDosAdicionados.QtdDeProcedimentos -= 1;
            }
            else
            {
                ListaDosProcedimentosAdicionados.Remove(ProcedimentoSelecionadoDosAdicionados);
            }
            CalcularValoresTotais();
        }

        public double GetDescontoEmProcentagem()
        { 
            if (ProcedimentoSelecionadoDosAdicionados != null)
            {
                return ProcedimentoSelecionadoDosAdicionados.DescontoEmProcentagem;
            }
            return 0;
        }

        public string SalvarOrcamento()
        {
            Orcamento.OrcamentosParaProcedimentos.Clear();

            foreach(var item in ListaDosProcedimentosAdicionados)
            {
                Orcamento.OrcamentosParaProcedimentos.Add(item);
            }

            string msg = OrcamentoData.SalvarOrcamento(Orcamento);

            return msg;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Metodos**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------

        public void CalculoDeDesconto(string descontoString)
        {
            bool flagDescontovalido = double.TryParse(descontoString, out double desconto);

            if (flagDescontovalido && 100 >= desconto && desconto >= 0)
            {
                if (ProcedimentoSelecionadoDosAdicionados != null)
                {
                    ProcedimentoSelecionadoDosAdicionados.DescontoEmProcentagem = desconto;

                    ProcedimentoSelecionadoDosAdicionados.ValorTotalDoProcedimento = (ProcedimentoSelecionadoDosAdicionados.QtdDeProcedimentos *
                        ProcedimentoSelecionadoDosAdicionados.Procedimento.Preco) - (ProcedimentoSelecionadoDosAdicionados.QtdDeProcedimentos *
                        ProcedimentoSelecionadoDosAdicionados.Procedimento.Preco * (desconto / 100));

                    CalcularValoresTotais();
                }
            }        
        }

        private void CarregarTodosOsProcedimentos()
        {
            ListaDeTodosOsProcedimentos = new ObservableCollection<Procedimento>(ListaDeProcedimentoData.ListarTodosProcedimentos());
            if (ProcedimentoSelecionadoDosAdicionados != null)
            {
                CalcularPrecoDeItem();
            }
            
        }

        public void BuscarProcedimento(string idString, string nome)
        {
            int.TryParse(idString, out int id);

            if (id != 0 || nome != "")
            {
                ListaDeTodosOsProcedimentos = new ObservableCollection<Procedimento>(ListaDeProcedimentoData.BuscarProcedimentos(id, nome));
            }
            else
            {
                CarregarTodosOsProcedimentos();
            }            
        } 

        private void CalcularPrecoDeItem()
        {
            ProcedimentoSelecionadoDosAdicionados.ValorTotalDoProcedimento = ProcedimentoSelecionadoDosAdicionados.Procedimento.Preco * 
                (ProcedimentoSelecionadoDosAdicionados.DescontoEmProcentagem/100) * ProcedimentoSelecionadoDosAdicionados.QtdDeProcedimentos;
        }

        private void CalcularValoresTotais()
        {
            TotalParcial = 0;
            TotalComDescontos = 0;
            foreach (var i in ListaDosProcedimentosAdicionados)
            {
                var aux = i.Procedimento.Preco * i.QtdDeProcedimentos;
                TotalParcial += aux;
                i.ValorTotalDoProcedimento = aux - ((i.DescontoEmProcentagem/100) * aux);
                TotalComDescontos += i.ValorTotalDoProcedimento;
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
