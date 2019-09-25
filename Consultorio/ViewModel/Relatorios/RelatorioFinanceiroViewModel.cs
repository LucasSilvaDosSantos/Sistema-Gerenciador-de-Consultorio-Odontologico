using Consultorio.Data.Pagamentos;
using Consultorio.Model;
using Consultorio.ViewModel.Atores;
using System;
using System.Data;

namespace Consultorio.ViewModel.Relatorios
{
    public class RelatorioFinanceiroViewModel
    {
        public Ator AtorLogado { get; set; } = SingletonAtorLogado.Instancia.Ator;

        public double TotalGastosComProdutos { get; set; }        

        public RelatorioFinanceiroViewModel()
        {

        }

        public DataTable CarregaDataTableContasPagas(DateTime inicio, DateTime fim)
        {
            var listaContasPagas = FinanceiroData.TodasAsContas(inicio, fim);

            var dataTable = new DataTable();
            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Tipo");
            dataTable.Columns.Add("DataDePagamento");
            dataTable.Columns.Add("Valor", typeof(double));
            dataTable.Columns.Add("QuemCadastrou");

            foreach (var item in listaContasPagas)
            {
                dataTable.Rows.Add(item.Id, item.Tipo.Tipo, item.DataDePagamento.ToShortDateString(), item.Valor, item.QuemCadastrou.Nome);
            }
            return dataTable;
        }

        public DataTable CarregaDataTableProdutosComprados(DateTime inicio, DateTime fim)
        {
            TotalGastosComProdutos = 0;

            var listaProdutosComprados = FinanceiroData.TodosOsProdutosComprados(inicio, fim);

            var dataTable = new DataTable();
            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Produto");
            dataTable.Columns.Add("QuantidaDeComprada", typeof(int));
            dataTable.Columns.Add("PrecoCompra", typeof(double));
            dataTable.Columns.Add("DataDeCompra");

            foreach (var item in listaProdutosComprados)
            {
                dataTable.Rows.Add(item.Id, item.Produto.Nome, item.QuantidaDeComprada, item.PrecoCompra, item.DataDeCompra.ToShortDateString().ToString());
                TotalGastosComProdutos += (item.PrecoCompra * item.QuantidaDeComprada);
            }
            return dataTable;
        }

        public DataTable CarregaDataTablePagamentosRecebidos(DateTime inicio, DateTime fim)
        {
            var listaPagamentosRecebidos = FinanceiroData.TodosOsPagamentosRecebidos(inicio, fim);

            var dataTable = new DataTable();
            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Cliente");
            dataTable.Columns.Add("DataDePagamento");
            dataTable.Columns.Add("FormaDePagamento");
            dataTable.Columns.Add("Valor", typeof(double));

            foreach (var item in listaPagamentosRecebidos)
            {
                dataTable.Rows.Add(item.Id, item.Cliente.Nome, item.DataDePagamento.ToShortDateString().ToString(), item.FormaDePagamento, item.Valor);
            }
            return dataTable;
        }
    }
}
