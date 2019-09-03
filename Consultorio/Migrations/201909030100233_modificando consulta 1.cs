namespace Consultorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificandoconsulta1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Consultas", "Status", c => c.String(nullable: false, unicode: false));
            DropColumn("dbo.Consultas", "Realizada");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Consultas", "Realizada", c => c.Boolean(nullable: false));
            DropColumn("dbo.Consultas", "Status");
        }
    }
}
