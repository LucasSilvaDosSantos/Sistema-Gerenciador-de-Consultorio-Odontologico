namespace Consultorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Anamneses",
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
                        P04Complemento = c.String(unicode: false),
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
                "dbo.Atores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, unicode: false),
                        Email = c.String(nullable: false, unicode: false),
                        Telefone1 = c.String(nullable: false, unicode: false),
                        Telefone2 = c.String(unicode: false),
                        Crosp = c.String(unicode: false),
                        Clinicar = c.Boolean(nullable: false),
                        CrudClientes = c.Boolean(nullable: false),
                        CrudConsultas = c.Boolean(nullable: false),
                        CrudProdutos = c.Boolean(nullable: false),
                        CadastroDeContasPagas = c.Boolean(nullable: false),
                        VisualizarContabilidade = c.Boolean(nullable: false),
                        ReceberDeClientes = c.Boolean(nullable: false),
                        CrudAtores = c.Boolean(nullable: false),
                        Login = c.String(nullable: false, unicode: false),
                        Senha = c.String(nullable: false, unicode: false),
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
                        Odontograma_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Anamneses", t => t.Anamnese_Id)
                .ForeignKey("dbo.Odontogramas", t => t.Odontograma_Id)
                .Index(t => t.Anamnese_Id)
                .Index(t => t.Odontograma_Id);
            
            CreateTable(
                "dbo.Odontogramas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Dente01 = c.String(unicode: false),
                        Dente02 = c.String(unicode: false),
                        Dente03 = c.String(unicode: false),
                        Dente04 = c.String(unicode: false),
                        Dente05 = c.String(unicode: false),
                        Dente06 = c.String(unicode: false),
                        Dente07 = c.String(unicode: false),
                        Dente08 = c.String(unicode: false),
                        Dente09 = c.String(unicode: false),
                        Dente10 = c.String(unicode: false),
                        Dente11 = c.String(unicode: false),
                        Dente12 = c.String(unicode: false),
                        Dente13 = c.String(unicode: false),
                        Dente14 = c.String(unicode: false),
                        Dente15 = c.String(unicode: false),
                        Dente16 = c.String(unicode: false),
                        Dente17 = c.String(unicode: false),
                        Dente18 = c.String(unicode: false),
                        Dente19 = c.String(unicode: false),
                        Dente20 = c.String(unicode: false),
                        Dente21 = c.String(unicode: false),
                        Dente22 = c.String(unicode: false),
                        Dente23 = c.String(unicode: false),
                        Dente24 = c.String(unicode: false),
                        Dente25 = c.String(unicode: false),
                        Dente26 = c.String(unicode: false),
                        Dente27 = c.String(unicode: false),
                        Dente28 = c.String(unicode: false),
                        Dente29 = c.String(unicode: false),
                        Dente30 = c.String(unicode: false),
                        Dente31 = c.String(unicode: false),
                        Dente32 = c.String(unicode: false),
                        Obs = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Consultas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Inicio = c.DateTime(nullable: false, precision: 0),
                        Fim = c.DateTime(nullable: false, precision: 0),
                        Obs = c.String(unicode: false),
                        ValorConsulta = c.Double(nullable: false),
                        Status = c.Int(nullable: false),
                        Cliente_Id = c.Int(nullable: false),
                        Procedimento_Id = c.Int(),
                        QuemRealizou_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Id, cascadeDelete: true)
                .ForeignKey("dbo.Procedimentos", t => t.Procedimento_Id)
                .ForeignKey("dbo.Atores", t => t.QuemRealizou_Id)
                .Index(t => t.Cliente_Id)
                .Index(t => t.Procedimento_Id)
                .Index(t => t.QuemRealizou_Id);
            
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
                "dbo.OrcamentosParaProcedimentos",
                c => new
                    {
                        OrcamentoID = c.Int(nullable: false),
                        ProcedimentoID = c.Int(nullable: false),
                        ColaboradorAlterouID = c.Int(nullable: false),
                        QtdDeProcedimentos = c.Int(nullable: false),
                        DataDeAdicao = c.DateTime(nullable: false, precision: 0),
                        ValorTotalDoProcedimento = c.Double(nullable: false),
                        DescontoEmProcentagem = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrcamentoID, t.ProcedimentoID })
                .ForeignKey("dbo.Atores", t => t.ColaboradorAlterouID, cascadeDelete: true)
                .ForeignKey("dbo.Orcamentos", t => t.OrcamentoID, cascadeDelete: true)
                .ForeignKey("dbo.Procedimentos", t => t.ProcedimentoID, cascadeDelete: true)
                .Index(t => t.OrcamentoID)
                .Index(t => t.ProcedimentoID)
                .Index(t => t.ColaboradorAlterouID);
            
            CreateTable(
                "dbo.Orcamentos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Obs = c.String(unicode: false),
                        Cliente_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Id, cascadeDelete: true)
                .Index(t => t.Cliente_Id);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, unicode: false),
                        Quantidade = c.Int(),
                        Descricao = c.String(unicode: false),
                        MinimoDeEstoque = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProdutosUtilizadosEmconsultas",
                c => new
                    {
                        ConsultaID = c.Int(nullable: false),
                        ProdutoID = c.Int(nullable: false),
                        QtdProdutoUtilizado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ConsultaID, t.ProdutoID })
                .ForeignKey("dbo.Consultas", t => t.ConsultaID, cascadeDelete: true)
                .ForeignKey("dbo.Produtos", t => t.ProdutoID, cascadeDelete: true)
                .Index(t => t.ConsultaID)
                .Index(t => t.ProdutoID);
            
            CreateTable(
                "dbo.ContasPagas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(unicode: false),
                        Valor = c.Double(nullable: false),
                        DataDePagamento = c.DateTime(nullable: false, precision: 0),
                        Obs = c.String(unicode: false),
                        QuemCadastrou_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Atores", t => t.QuemCadastrou_Id)
                .Index(t => t.QuemCadastrou_Id);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false, precision: 0),
                        ComoEra = c.String(unicode: false),
                        ComoFicou = c.String(unicode: false),
                        Ator_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Atores", t => t.Ator_Id)
                .Index(t => t.Ator_Id);
            
            CreateTable(
                "dbo.Pagamentos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FormaDePagamento = c.String(nullable: false, unicode: false),
                        DataDePagamento = c.DateTime(nullable: false, precision: 0),
                        Valor = c.Double(nullable: false),
                        Obs = c.String(unicode: false),
                        Cliente_Id = c.Int(nullable: false),
                        Recebedor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Id, cascadeDelete: true)
                .ForeignKey("dbo.Atores", t => t.Recebedor_Id, cascadeDelete: true)
                .Index(t => t.Cliente_Id)
                .Index(t => t.Recebedor_Id);
            
            CreateTable(
                "dbo.ProdutosCompras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PrecoCompra = c.Double(nullable: false),
                        QuantidaDeComprada = c.Int(nullable: false),
                        DataDeCompra = c.DateTime(nullable: false, precision: 0),
                        Obs = c.String(unicode: false),
                        Produto_Id = c.Int(),
                        QuemRegistrou_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produtos", t => t.Produto_Id)
                .ForeignKey("dbo.Atores", t => t.QuemRegistrou_Id)
                .Index(t => t.Produto_Id)
                .Index(t => t.QuemRegistrou_Id);
            
            CreateTable(
                "dbo.ProdutoProcedimentoes",
                c => new
                    {
                        Produto_Id = c.Int(nullable: false),
                        Procedimento_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Produto_Id, t.Procedimento_Id })
                .ForeignKey("dbo.Produtos", t => t.Produto_Id, cascadeDelete: true)
                .ForeignKey("dbo.Procedimentos", t => t.Procedimento_Id, cascadeDelete: true)
                .Index(t => t.Produto_Id)
                .Index(t => t.Procedimento_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProdutosCompras", "QuemRegistrou_Id", "dbo.Atores");
            DropForeignKey("dbo.ProdutosCompras", "Produto_Id", "dbo.Produtos");
            DropForeignKey("dbo.Pagamentos", "Recebedor_Id", "dbo.Atores");
            DropForeignKey("dbo.Pagamentos", "Cliente_Id", "dbo.Clientes");
            DropForeignKey("dbo.Logs", "Ator_Id", "dbo.Atores");
            DropForeignKey("dbo.ContasPagas", "QuemCadastrou_Id", "dbo.Atores");
            DropForeignKey("dbo.Consultas", "QuemRealizou_Id", "dbo.Atores");
            DropForeignKey("dbo.Consultas", "Procedimento_Id", "dbo.Procedimentos");
            DropForeignKey("dbo.ProdutosUtilizadosEmconsultas", "ProdutoID", "dbo.Produtos");
            DropForeignKey("dbo.ProdutosUtilizadosEmconsultas", "ConsultaID", "dbo.Consultas");
            DropForeignKey("dbo.ProdutoProcedimentoes", "Procedimento_Id", "dbo.Procedimentos");
            DropForeignKey("dbo.ProdutoProcedimentoes", "Produto_Id", "dbo.Produtos");
            DropForeignKey("dbo.OrcamentosParaProcedimentos", "ProcedimentoID", "dbo.Procedimentos");
            DropForeignKey("dbo.OrcamentosParaProcedimentos", "OrcamentoID", "dbo.Orcamentos");
            DropForeignKey("dbo.Orcamentos", "Cliente_Id", "dbo.Clientes");
            DropForeignKey("dbo.OrcamentosParaProcedimentos", "ColaboradorAlterouID", "dbo.Atores");
            DropForeignKey("dbo.Consultas", "Cliente_Id", "dbo.Clientes");
            DropForeignKey("dbo.Clientes", "Odontograma_Id", "dbo.Odontogramas");
            DropForeignKey("dbo.Clientes", "Anamnese_Id", "dbo.Anamneses");
            DropIndex("dbo.ProdutoProcedimentoes", new[] { "Procedimento_Id" });
            DropIndex("dbo.ProdutoProcedimentoes", new[] { "Produto_Id" });
            DropIndex("dbo.ProdutosCompras", new[] { "QuemRegistrou_Id" });
            DropIndex("dbo.ProdutosCompras", new[] { "Produto_Id" });
            DropIndex("dbo.Pagamentos", new[] { "Recebedor_Id" });
            DropIndex("dbo.Pagamentos", new[] { "Cliente_Id" });
            DropIndex("dbo.Logs", new[] { "Ator_Id" });
            DropIndex("dbo.ContasPagas", new[] { "QuemCadastrou_Id" });
            DropIndex("dbo.ProdutosUtilizadosEmconsultas", new[] { "ProdutoID" });
            DropIndex("dbo.ProdutosUtilizadosEmconsultas", new[] { "ConsultaID" });
            DropIndex("dbo.Orcamentos", new[] { "Cliente_Id" });
            DropIndex("dbo.OrcamentosParaProcedimentos", new[] { "ColaboradorAlterouID" });
            DropIndex("dbo.OrcamentosParaProcedimentos", new[] { "ProcedimentoID" });
            DropIndex("dbo.OrcamentosParaProcedimentos", new[] { "OrcamentoID" });
            DropIndex("dbo.Consultas", new[] { "QuemRealizou_Id" });
            DropIndex("dbo.Consultas", new[] { "Procedimento_Id" });
            DropIndex("dbo.Consultas", new[] { "Cliente_Id" });
            DropIndex("dbo.Clientes", new[] { "Odontograma_Id" });
            DropIndex("dbo.Clientes", new[] { "Anamnese_Id" });
            DropTable("dbo.ProdutoProcedimentoes");
            DropTable("dbo.ProdutosCompras");
            DropTable("dbo.Pagamentos");
            DropTable("dbo.Logs");
            DropTable("dbo.ContasPagas");
            DropTable("dbo.ProdutosUtilizadosEmconsultas");
            DropTable("dbo.Produtos");
            DropTable("dbo.Orcamentos");
            DropTable("dbo.OrcamentosParaProcedimentos");
            DropTable("dbo.Procedimentos");
            DropTable("dbo.Consultas");
            DropTable("dbo.Odontogramas");
            DropTable("dbo.Clientes");
            DropTable("dbo.Atores");
            DropTable("dbo.Anamneses");
        }
    }
}
