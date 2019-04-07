namespace Consultorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class códigoscopiados : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Anamnese",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        P01 = c.Boolean(nullable: false),
                        P01ComplementoPq = c.String(unicode: false),
                        P01ComplementoTel = c.String(unicode: false),
                        P02 = c.Boolean(nullable: false),
                        P02Complemento = c.String(unicode: false),
                        P03 = c.Boolean(nullable: false),
                        P03Complemento = c.String(unicode: false),
                        P04 = c.Boolean(nullable: false),
                        P05 = c.Boolean(nullable: false),
                        P05Complemento = c.String(unicode: false),
                        P06 = c.Boolean(nullable: false),
                        P07 = c.Boolean(nullable: false),
                        P08 = c.Boolean(nullable: false),
                        P09 = c.Boolean(nullable: false),
                        P09Complemento = c.String(unicode: false),
                        P10 = c.Boolean(nullable: false),
                        P11 = c.Boolean(nullable: false),
                        P12 = c.Boolean(nullable: false),
                        P13 = c.Boolean(nullable: false),
                        P14 = c.Boolean(nullable: false),
                        P15 = c.Boolean(nullable: false),
                        P16 = c.Boolean(nullable: false),
                        P17 = c.Boolean(nullable: false),
                        P17Complemento = c.String(unicode: false),
                        P18 = c.Boolean(nullable: false),
                        P19 = c.Boolean(nullable: false),
                        P20 = c.Boolean(nullable: false),
                        P21 = c.Boolean(nullable: false),
                        P22 = c.Boolean(nullable: false),
                        P23 = c.Boolean(nullable: false),
                        P24 = c.Boolean(nullable: false),
                        P25 = c.Boolean(nullable: false),
                        P26 = c.Boolean(nullable: false),
                        P27 = c.Boolean(nullable: false),
                        Obs = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, unicode: false),
                        Nascimento = c.DateTime(nullable: false, precision: 0),
                        Cpf = c.String(nullable: false, unicode: false),
                        Rg = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Telefone1 = c.String(nullable: false, unicode: false),
                        Telefone2 = c.String(unicode: false),
                        Endereco = c.String(unicode: false),
                        Bairro = c.String(unicode: false),
                        Uf = c.String(unicode: false),
                        Cidade = c.String(unicode: false),
                        Cep = c.String(unicode: false),
                        Obs = c.String(unicode: false),
                        Anamnese_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Anamnese", t => t.Anamnese_Id)
                .Index(t => t.Anamnese_Id);
            
            CreateTable(
                "dbo.Consultas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Inicio = c.DateTime(nullable: false, precision: 0),
                        Fim = c.DateTime(nullable: false, precision: 0),
                        Dente = c.String(unicode: false),
                        Realizada = c.Boolean(nullable: false),
                        Cliente_Id = c.Int(nullable: false),
                        Procedimento_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Id, cascadeDelete: true)
                .ForeignKey("dbo.Procedimentos", t => t.Procedimento_Id)
                .Index(t => t.Cliente_Id)
                .Index(t => t.Procedimento_Id);
            
            CreateTable(
                "dbo.Procedimentos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, unicode: false),
                        Descricao = c.String(unicode: false),
                        Preco = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProdutosParaProcedimentos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProdutoId = c.Int(nullable: false),
                        QuantidadeProduto = c.Int(nullable: false),
                        ProcedimentoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Procedimentos", t => t.ProcedimentoId, cascadeDelete: true)
                .ForeignKey("dbo.Produtos", t => t.ProdutoId, cascadeDelete: true)
                .Index(t => t.ProdutoId)
                .Index(t => t.ProcedimentoId);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, unicode: false),
                        Quantidade = c.Int(nullable: false),
                        Descricao = c.String(unicode: false),
                        Validade = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Atores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, unicode: false),
                        Sobrenome = c.String(nullable: false, unicode: false),
                        Email = c.String(nullable: false, unicode: false),
                        Telefone1 = c.String(nullable: false, unicode: false),
                        Telefone2 = c.String(unicode: false),
                        Login = c.String(nullable: false, unicode: false),
                        Senha = c.String(nullable: false, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pagamentos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FormaDePagamento = c.String(nullable: false, unicode: false),
                        DataDePagamento = c.DateTime(nullable: false, precision: 0),
                        Valor = c.Double(nullable: false),
                        Cliente_Id = c.Int(),
                        Recebedor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Id)
                .ForeignKey("dbo.Atores", t => t.Recebedor_Id)
                .Index(t => t.Cliente_Id)
                .Index(t => t.Recebedor_Id);
            
            CreateTable(
                "dbo.Dentistas",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Crosp = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Atores", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.GestoresDeEstoque",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Atores", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Secretarias",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Crosp = c.String(unicode: false),
                        CrudClientes = c.Boolean(nullable: false),
                        CrudSecretarias = c.Boolean(nullable: false),
                        CrudProdutos = c.Boolean(nullable: false),
                        CrudGestoresDeEstoque = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Atores", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Secretarias", "Id", "dbo.Atores");
            DropForeignKey("dbo.GestoresDeEstoque", "Id", "dbo.Atores");
            DropForeignKey("dbo.Dentistas", "Id", "dbo.Atores");
            DropForeignKey("dbo.Pagamentos", "Recebedor_Id", "dbo.Atores");
            DropForeignKey("dbo.Pagamentos", "Cliente_Id", "dbo.Clientes");
            DropForeignKey("dbo.Consultas", "Procedimento_Id", "dbo.Procedimentos");
            DropForeignKey("dbo.ProdutosParaProcedimentos", "ProdutoId", "dbo.Produtos");
            DropForeignKey("dbo.ProdutosParaProcedimentos", "ProcedimentoId", "dbo.Procedimentos");
            DropForeignKey("dbo.Consultas", "Cliente_Id", "dbo.Clientes");
            DropForeignKey("dbo.Clientes", "Anamnese_Id", "dbo.Anamnese");
            DropIndex("dbo.Secretarias", new[] { "Id" });
            DropIndex("dbo.GestoresDeEstoque", new[] { "Id" });
            DropIndex("dbo.Dentistas", new[] { "Id" });
            DropIndex("dbo.Pagamentos", new[] { "Recebedor_Id" });
            DropIndex("dbo.Pagamentos", new[] { "Cliente_Id" });
            DropIndex("dbo.ProdutosParaProcedimentos", new[] { "ProcedimentoId" });
            DropIndex("dbo.ProdutosParaProcedimentos", new[] { "ProdutoId" });
            DropIndex("dbo.Consultas", new[] { "Procedimento_Id" });
            DropIndex("dbo.Consultas", new[] { "Cliente_Id" });
            DropIndex("dbo.Clientes", new[] { "Anamnese_Id" });
            DropTable("dbo.Secretarias");
            DropTable("dbo.GestoresDeEstoque");
            DropTable("dbo.Dentistas");
            DropTable("dbo.Pagamentos");
            DropTable("dbo.Atores");
            DropTable("dbo.Produtos");
            DropTable("dbo.ProdutosParaProcedimentos");
            DropTable("dbo.Procedimentos");
            DropTable("dbo.Consultas");
            DropTable("dbo.Clientes");
            DropTable("dbo.Anamnese");
        }
    }
}
