namespace Consultorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Prontoparaentrega : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Procedimentos", "Ativo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Produtos", "Ativo", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produtos", "Ativo");
            DropColumn("dbo.Procedimentos", "Ativo");
        }
    }
}
