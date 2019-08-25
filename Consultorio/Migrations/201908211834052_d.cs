namespace Consultorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContasPagas", "QuemCadastrou_Id", "dbo.Atores");
            DropIndex("dbo.ContasPagas", new[] { "QuemCadastrou_Id" });
            DropTable("dbo.ContasPagas");
        }
    }
}
