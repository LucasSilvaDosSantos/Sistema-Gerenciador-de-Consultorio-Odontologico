namespace Consultorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class logs : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logs", "Ator_Id", "dbo.Atores");
            DropIndex("dbo.Logs", new[] { "Ator_Id" });
            DropTable("dbo.Logs");
        }
    }
}
