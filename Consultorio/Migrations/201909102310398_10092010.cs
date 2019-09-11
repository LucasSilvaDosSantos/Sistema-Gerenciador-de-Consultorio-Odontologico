namespace Consultorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10092010 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Procedimentos", "TempoRecomendado", c => c.DateTime(nullable: false, precision: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Procedimentos", "TempoRecomendado");
        }
    }
}
