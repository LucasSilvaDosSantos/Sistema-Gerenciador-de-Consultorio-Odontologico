using System.Data.Entity;
using Consultorio.Model;

namespace Consultorio.Data
{ 
    class ConsultorioContext : DbContext
    {
        public DbSet<Anamnese> Anamneses { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Ator> Atores { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Procedimento> Procedimentos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Orcamento> Orcamentos { get; set; }
        public DbSet<OrcamentosParaProcedimentos> OrcamentosParaProcedimentos { get; set; }
        public DbSet<ContaPaga> ContasPagas  { get; set; }
        public DbSet<ProdutoCompra> ProdutosCompras { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<ProdutoUtilizadoEmConsulta> ProdutoUtilizadoEmConsultas { get; set; }
        public DbSet<TipoDeContaPaga> TiposDeContasPagas { get; set; }

        public ConsultorioContext()
            : base("name=ConsultorioContext")
        {            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
