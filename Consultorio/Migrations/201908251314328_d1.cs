namespace Consultorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d1 : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Produtos", "MinimoDeEstoque", c => c.Int(nullable: false));
            AlterColumn("dbo.Produtos", "Quantidade", c => c.Int());
            DropColumn("dbo.Produtos", "Validade");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produtos", "Validade", c => c.DateTime(precision: 0));
            DropForeignKey("dbo.ProdutosCompras", "QuemRegistrou_Id", "dbo.Atores");
            DropForeignKey("dbo.ProdutosCompras", "Produto_Id", "dbo.Produtos");
            DropIndex("dbo.ProdutosCompras", new[] { "QuemRegistrou_Id" });
            DropIndex("dbo.ProdutosCompras", new[] { "Produto_Id" });
            AlterColumn("dbo.Produtos", "Quantidade", c => c.Int(nullable: false));
            DropColumn("dbo.Produtos", "MinimoDeEstoque");
            DropTable("dbo.ProdutosCompras");
        }
    }
}
