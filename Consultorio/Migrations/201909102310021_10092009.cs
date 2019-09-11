namespace Consultorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10092009 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Procedimentos", "TempoRecomendado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Procedimentos", "TempoRecomendado", c => c.Double(nullable: false));
        }
    }
}
