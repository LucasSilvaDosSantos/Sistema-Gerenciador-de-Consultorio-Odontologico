namespace Consultorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste10091932 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Procedimentos", "TempoRecomendado", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Procedimentos", "TempoRecomendado");
        }
    }
}
