using Consultorio.Data.Pagamentos;
using Consultorio.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Consultorio.ViewModel.Pagamentos
{
    public class ContabilidadeViewModel : INotifyPropertyChanged
    {
        public string TotalDeDiasSelecionados
        {
            get {
                var a = ((DataFinal - DataInicial).TotalDays + 1);
                if (a == 1)
                {
                    return $"{a} Dia Selecionado";
                }
                else
                {
                    return $"{a} Dias Selecionados";
                }
            }
        }

        //************************************************************Atributos De soma*******************************************
        private double _SomaContasPagas;
        public double SomaContasPagas
        {
            get { return _SomaContasPagas; }
            set { _SomaContasPagas = value; OnPropertyChanged("SomaContasPagas"); }
        }

        private double _SomaConsulta;
        public double SomaConsulta
        {
            get { return _SomaConsulta; }
            set { _SomaConsulta = value; OnPropertyChanged("SomaConsulta"); }
        }

        private double _SomaDeProdutos;
        public double SomaDeProdutos
        {
            get { return _SomaDeProdutos; }
            set { _SomaDeProdutos = value; OnPropertyChanged("SomaDeProdutos"); }
        }

        private double _SomaPagamentos;
        public double SomaPagamentos
        {
            get { return _SomaPagamentos; }
            set { _SomaPagamentos = value; OnPropertyChanged("SomaPagamentos"); }
        }

        private double _SomaGastos;
        public double SomaGastos
        {
            get { return _SomaGastos; }
            set { _SomaGastos = value; OnPropertyChanged("SomaGastos"); }
        }

        private double _SomaBalanco;
        public double SomaBalanco
        {
            get { return _SomaBalanco; }
            set { _SomaBalanco = value; OnPropertyChanged("SomaBalanco"); }
        }

        private double _LucroEmPorcentagem;
        public double LucroEmPorcentagem
        {
            get { return _LucroEmPorcentagem; }
            set { _LucroEmPorcentagem = value; OnPropertyChanged("LucroEmPorcentagem"); }
        }
        
        //Fim************************************************************Atributos De soma****************************************

        //*****************************************Atributos De Listas para data grid********************************************
        private List<ContaPaga> _TodasAsContas;
        public List<ContaPaga> TodasAsContas
        {
            get { return _TodasAsContas; }
            set { _TodasAsContas = value; OnPropertyChanged("TodasAsContas"); }
        }


        private List<Consulta> _TodasAsConsultas;
        public List<Consulta> TodasAsConsultas
        {
            get { return _TodasAsConsultas; }
            set { _TodasAsConsultas = value; OnPropertyChanged("TodasAsConsultas"); }
        }


        private List<ProdutoCompra> _TodosOsProdutosComprados;
        public List<ProdutoCompra> TodosOsProdutosComprados
        {
            get { return _TodosOsProdutosComprados; }
            set { _TodosOsProdutosComprados = value; OnPropertyChanged("TodosOsProdutosComprados"); }
        }


        private List<Pagamento> _TodosOsPagamentosRecebidos;
        public List<Pagamento> TodosOsPagamentosRecebidos
        {
            get { return _TodosOsPagamentosRecebidos; }
            set { _TodosOsPagamentosRecebidos = value; OnPropertyChanged("TodosOsPagamentosRecebidos"); }
        }
        //Fim*****************************************Atributos De Listas para data grid********************************************

        //*****************************************Atributos De Inatividade de Listas para data grid********************************
        private bool _DgContasPagasIsEnabled;
        public bool DgContasPagasIsEnabled
        {
            get { return _DgContasPagasIsEnabled; }
            set { _DgContasPagasIsEnabled = value; OnPropertyChanged("DgContasPagasIsEnabled"); }
        }


        private bool _DgConsultasRealizadasIsEnabled;
        public bool DgConsultasRealizadasIsEnabled
        {
            get { return _DgConsultasRealizadasIsEnabled; }
            set { _DgConsultasRealizadasIsEnabled = value; OnPropertyChanged("DgConsultasRealizadasIsEnabled"); }
        }


        private bool _DgProdutosCompradosIsEnabled;
        public bool DgProdutosCompradosIsEnabled
        {
            get { return _DgProdutosCompradosIsEnabled; }
            set { _DgProdutosCompradosIsEnabled = value; OnPropertyChanged("DgProdutosCompradosIsEnabled"); }
        }
        

        private bool _DgPagamentosRecebidosIsEnabled;
        public bool DgPagamentosRecebidosIsEnabled
        {
            get { return _DgPagamentosRecebidosIsEnabled; }
            set { _DgPagamentosRecebidosIsEnabled = value; OnPropertyChanged("DgPagamentosRecebidosIsEnabled"); }
        }
        //Fim*****************************************Atributos De Inatividade de Listas para data grid*****************************

        private List<string> _CbListaOpcaoDataGrid;

        public List<string> CbListaOpcaoDataGrid
        {
            get { return _CbListaOpcaoDataGrid; }
            set { _CbListaOpcaoDataGrid = value; OnPropertyChanged("CbListaOpcaoDataGrid"); }
        }

        private string _CbSelecaoDataGrid;

        public string CbSelecaoDataGrid
        {
            get { return _CbSelecaoDataGrid; }
            set { _CbSelecaoDataGrid = value; OnPropertyChanged("CbSelecaoDataGrid"); ModificarDataGridAtivo(); }
        }

        private string _Aviso;

        public string Aviso
        {
            get { return _Aviso; }
            set { _Aviso = value; OnPropertyChanged("Aviso"); }
        }

        private DateTime _DataFinal;

        public DateTime DataFinal
        {
            get { return _DataFinal; }
            set {
                if (DataInicial <= value)
                {
                    Aviso = "";
                    _DataFinal = value; OnPropertyChanged("DataFinal"); OnPropertyChanged("TotalDeDiasSelecionados"); CarregarDatasGrid();
                }
                else
                {
                    Aviso = "A data final não pode ser menor que a data inicial!";
                }
            }
        }

        private DateTime _DataInicial;

        public DateTime DataInicial
        {
            get { return _DataInicial; }
            set {
                if (DataFinal >= value)
                {
                    Aviso = "";
                    _DataInicial = value; OnPropertyChanged("DataInicial"); OnPropertyChanged("TotalDeDiasSelecionados"); CarregarDatasGrid();
                }
                else
                {
                    Aviso = "A data inicial não pode ser maior que a data final!";
                }
            }
        }


        //*****************************************Construtor********************************************

        public ContabilidadeViewModel()
        {
            DataFinal = DateTime.Now.Date;
            DataInicial = DataFinal.AddDays(-30).Date;

            CarregarDatasGrid();

            CbListaOpcaoDataGrid = new List<string>{ "Contas Pagas", "Consultas Realizadas", "Produtos Comprados", "Pagamentos Recebidos"} ;
            CbSelecaoDataGrid = CbListaOpcaoDataGrid[0];           
        }

        //-----------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------*********Metodos**********-------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        private void CarregarDatasGrid()
        {
            CarregarTodasAsContasPagas();
            CarregarTodasASConsultasRealizadas();
            CarregarTodosOsProdutosComprados();
            CarregarTodosOsPagamentosRecebidos();

            SomaGastos = SomaContasPagas + SomaDeProdutos;
            SomaBalanco = SomaPagamentos - SomaGastos;
            LucroEmPorcentagem = (SomaPagamentos / 100) * SomaGastos;
        }

        //***************************************************Carregamento dos data grid********************************************
        private void CarregarTodasAsContasPagas()
        {
            TodasAsContas = ContabilidadeData.TodasAsContas(DataInicial, DataFinal);

            SomaContasPagas = 0;

            foreach (var i in TodasAsContas)
            {
                SomaContasPagas += i.Valor;
            }
        }

        private void CarregarTodasASConsultasRealizadas()
        {
            TodasAsConsultas = ContabilidadeData.TodasAsConsultasRealizadas(DataInicial, DataFinal);

            SomaConsulta = 0;

            foreach (var i in TodasAsConsultas)
            {
                SomaConsulta += i.ValorConsulta;
            }
        }

        private void CarregarTodosOsProdutosComprados()
        {
            TodosOsProdutosComprados = ContabilidadeData.TodosOsProdutosComprados(DataInicial, DataFinal);

            SomaDeProdutos = 0;

            foreach(var i in TodosOsProdutosComprados)
            {
                SomaDeProdutos += (i.PrecoCompra * i.QuantidaDeComprada);
            }
        }

        private void CarregarTodosOsPagamentosRecebidos()
        {
            TodosOsPagamentosRecebidos = ContabilidadeData.TodosOsPagamentosRecebidos(DataInicial, DataFinal);

            SomaPagamentos = 0;

            foreach(var i in TodosOsPagamentosRecebidos)
            {
                SomaPagamentos += i.Valor;
            }
        }

        //fim***************************************************Carregamento dos data grid********************************************

        private void ModificarDataGridAtivo()
        {
            DgContasPagasIsEnabled = false;
            DgConsultasRealizadasIsEnabled = false;
            DgProdutosCompradosIsEnabled = false;
            DgPagamentosRecebidosIsEnabled = false;


            if (CbSelecaoDataGrid == "Contas Pagas")
            {
                DgContasPagasIsEnabled = true;
            }
            else if(CbSelecaoDataGrid == "Consultas Realizadas")
            {
                DgConsultasRealizadasIsEnabled = true;
            }
            else if (CbSelecaoDataGrid == "Produtos Comprados")
            {
                DgProdutosCompradosIsEnabled = true;
            }
            else if (CbSelecaoDataGrid == "Pagamentos Recebidos")
            {
                DgPagamentosRecebidosIsEnabled = true;
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
