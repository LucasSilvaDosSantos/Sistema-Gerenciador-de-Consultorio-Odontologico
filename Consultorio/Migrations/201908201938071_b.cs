namespace Consultorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orcamentos", "Obs", c => c.String(unicode: false));
            DropColumn("dbo.Procedimentos", "Ativo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Procedimentos", "Ativo", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Orcamentos", "Obs", c => c.String(nullable: false, unicode: false));
        }
    }
}
