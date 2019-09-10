namespace Consultorio.Migrations
{
    using Consultorio.Model;
    using MySql.Data.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Consultorio.Data.ConsultorioContext>
    {
        public Configuration()
        {
            //AutomaticMigrationsEnabled = true;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySqlMigrationSqlGenerator());
        }

        protected override void Seed(Consultorio.Data.ConsultorioContext context)
        {
            //seed Ator
            /*Ator ator1 = new Ator("Thiago Santos", "dentista@dentista.com", "(31)7133-5723", "(31)98666-5645", "Numero Crosp", true, true, true, true, true, true, true, true, "admin", "21232f297a57a5a743894a0e4a801fc3");


            //seed Anamnese
            Anamnese anamnese1 = new Anamnese(true, "p1 compl", "p1compl2", true, "p2comp", true, "p3Complemento", true, true, "p05Complemento", true, true, true, true,
                "p09Compemeto", true, true, true, true, true, true, true, true, "p17comp", true, true, true, true, true, true, true, true, true, true, "Obs");
            Anamnese anamnese2 = new Anamnese(false, "", "", false, "", false, "", false, false, "", false, false, false, false,
                "", false, false, false, false, false, false, false, false, "", false, false, false, false, false, false, false, false, false, false, "");

            //seed Odontograma
            Odontograma odontograma1 = new Odontograma("O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "Teste odontograma 1");
            Odontograma odontograma2 = new Odontograma("O", "X", "O", "O", "O", "O", "O", "O", "O", "O", "X", "O", "O", "O", "O", "O", "O", "O", "O", "O", "X", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "", "Teste obs 2");

            //seed Cliente
            Cliente cliente1 = new Cliente("Ana Maria de Jesus", DateTime.Parse("16/02/1995"), "703.841.360-01", "41.976.260-7", "Ana@email.com", "(31)9998-9535", "(12)99124-5678", "Rua: perna longa", "Vila abc", "SP", "Campos do Jordão", "12460-000", "obs", anamnese1, odontograma1);
            Cliente cliente2 = new Cliente("José Roberto Silva", DateTime.Parse("01/02/2003"), "537.228.480-32", "", "jose@gmail.com", "(31)91370-1903", "", "Rua: 123", "Vila 2", "SP", "Taubate", "12356-123", "obs2", anamnese2, odontograma2);
            
            //seed Produto
            Produto produto1 = new Produto("Luva M", 5, "Luva M para procedimentos em geral");
            Produto produto2 = new Produto("Luva P", 10, "Luva P para procedimentos em geral");
            Produto produto3 = new Produto("Luva G", 15, "Luva G para procedimentos em geral");

            //seed Procedimento
            Procedimento procedimento1 = new Procedimento { Nome = "Análise Clínica", Descricao = "Análise inicial do paciente", Preco = 0.0, Produtos = new List<Produto> { produto1, produto2 } };

            Procedimento procedimento2 = new Procedimento("Retirada do dente siso", "", 200.00);
            Procedimento procedimento3 = new Procedimento("Limpeza", "", 150.00);
            Procedimento procedimento4 = new Procedimento("Obturação", "", 100.00);

            // seed consulta
            Consulta consulta1 = new Consulta { Cliente = cliente1, Inicio = DateTime.Parse("06/09/2019 11:00"), Fim = DateTime.Parse("06/09/2019 12:00"), Procedimento = procedimento1, ValorConsulta = procedimento1.Preco, Status = Model.Enums.StatusConsulta.Agendada };

            // seed Pagamentos
            Pagamento pagamento1 = new Pagamento(ator1, "Dinheiro", DateTime.Parse("24/06/2019 12:16"), 200.00, cliente1);

            // seed tipoDeContaPaga
            TipoDeContaPaga tipoDeContaPaga1 = new TipoDeContaPaga { Tipo = "Água" };
            TipoDeContaPaga tipoDeContaPaga2 = new TipoDeContaPaga { Tipo = "Luz" };


            context.Anamneses.AddOrUpdate(anamnese1);
            context.Anamneses.AddOrUpdate(anamnese2);
            context.Clientes.AddOrUpdate(cliente1);
            context.Clientes.AddOrUpdate(cliente2);
            context.Atores.AddOrUpdate(ator1);
            context.Produtos.AddOrUpdate(produto1);
            context.Produtos.AddOrUpdate(produto2);
            context.Produtos.AddOrUpdate(produto3);
            context.Procedimentos.AddOrUpdate(procedimento1);
            context.Procedimentos.AddOrUpdate(procedimento2);
            context.Procedimentos.AddOrUpdate(procedimento3);
            context.Procedimentos.AddOrUpdate(procedimento4);
            context.Consultas.AddOrUpdate(consulta1);
            context.Pagamentos.AddOrUpdate(pagamento1);
            context.TiposDeContasPagas.AddOrUpdate(tipoDeContaPaga1);
            context.TiposDeContasPagas.AddOrUpdate(tipoDeContaPaga2);
            context.SaveChanges();*/
            
             
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data/
        }
    }
}
