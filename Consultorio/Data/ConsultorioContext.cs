using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Consultorio.Model;

namespace Consultorio.Data
{ 
    class ConsultorioContext : DbContext
    {
        public DbSet<Anamnese> Anamneses { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Ator> Atores { get; set; }
        //public DbSet<Dentista> Dentistas { get; set; }
        //public DbSet<GestorDeEstoque> GestoresDeEstoque { get; set; }
        //public DbSet<Secretaria> Secretarias { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Procedimento> Procedimentos { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        public ConsultorioContext()
            : base("name=ConsultorioContext")
        {            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
