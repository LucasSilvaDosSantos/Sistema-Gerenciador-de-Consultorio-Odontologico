namespace Consultorio.Migrations
{
    using Consultorio.Model;
    using MySql.Data.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Consultorio.Data.ConsultorioContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySqlMigrationSqlGenerator());
        }

        protected override void Seed(Consultorio.Data.ConsultorioContext context)
        {
            //seed Anamnese
            Anamnese anamnese1 = new Anamnese(true, "p1 compl", "p1compl2", true, "p2comp", true, "p3Complemento", true, true, "p05Complemento", true, true, true, true,
                "p09Compemeto", true, true, true, true, true, true, true, true, "p17comp", true, true, true, true, true, true, true, true, true, true, "Obs");

            //seed Cliente
            Cliente cliente1 = new Cliente("Teste Cliente Nome", DateTime.Parse("16/02/1994"), "123.456.789-10", "28.919.716-8", "testeemail@email.com", "91234-5678", "91234-5678", "Rua: perna longa", "Vila abc", "SP", "Campos", "12460-000");
            Cliente cliente2 = new Cliente("Teste Cliente Nome 2", DateTime.Parse("1/2/2003"), "987.654.321-11", "24.385.915-6", "testeemail@gmail.com", "9971234567", "9123912312", "Rua: 123", "Vila 2", "SP", "Taubate", "12356-123");

            //seed Dentista
            Dentista dentista1 = new Dentista("Teste Dentista Sobrenome dentista", "Dentista@dentista.com", "Telefone1", "Telefone2", "Logindentista", "Senha", "Numero Crosp");

            // seed Gestor de estoque
            GestorDeEstoque gestor1 = new GestorDeEstoque("Teste Gestor Sobrenome Gestor", "gestor@Gestor.com", "Telefone1", "Telefone2", "Logingestor", "Senha");

            // seed secretaria
            Secretaria secretaria1 = new Secretaria("Teste Secretaria Sobrenome Secretaria", "secretaria@secretaria", "Telefone1", "Telefone2", "Loginsecretaria", "Senha", "Numero Crosp",
                true, true, true, true);

            //seed Produto
            Produto produto1 = new Produto("Luva M", 5, "Luva M para procedimentos em geral");
            Produto produto2 = new Produto("Luva P", 10, "Luva P para procedimentos em geral");
            Produto produto3 = new Produto("Luva G", 15, "Luva G para procedimentos em geral");

            //seed Procedimento
            Procedimento procedimento1 = new Procedimento("Análise Clínica", "Análise inicial do paciente", 0.0);
            Procedimento procedimento2 = new Procedimento("Teste de banco de dados", "controle de banco", 10.50);

            //seed ProdutosParaProcedimentos
            ProdutosParaProcedimentos pp1 = new ProdutosParaProcedimentos(produto1, procedimento1);
            ProdutosParaProcedimentos pp2 = new ProdutosParaProcedimentos(produto2, procedimento1);

            // seed consulta
            Consulta consulta1 = new Consulta(cliente1, DateTime.Parse("12/12/2012 12:00"), DateTime.Parse("12/12/2012 12:30"), procedimento1);

            // seed Pagamentos
            Pagamento pagamento1 = new Pagamento(secretaria1, "Dinheiro", DateTime.Parse("12/12/2012 12:12"), 200.00, cliente1);

            context.Anamneses.Add(anamnese1);
            context.Clientes.Add(cliente1);
            context.Clientes.Add(cliente2);
            context.Dentistas.Add(dentista1);
            context.GestoresDeEstoque.Add(gestor1);
            context.Secretarias.Add(secretaria1);
            context.Produtos.Add(produto1);
            context.Produtos.Add(produto2);
            context.Produtos.Add(produto3);
            context.Procedimentos.Add(procedimento1);
            context.Procedimentos.Add(procedimento2);
            context.ProdutosProcedimentos.Add(pp1);
            context.ProdutosProcedimentos.Add(pp2);
            context.Consultas.Add(consulta1);
            context.Pagamentos.Add(pagamento1);
            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data/
        }
    }
}
