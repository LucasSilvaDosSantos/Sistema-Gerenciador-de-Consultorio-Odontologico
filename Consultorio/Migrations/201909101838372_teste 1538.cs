namespace Consultorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste1538 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Atores", "VisualizarFinanceiro", c => c.Boolean(nullable: false));
            DropColumn("dbo.Atores", "VisualizarContabilidade");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Atores", "VisualizarContabilidade", c => c.Boolean(nullable: false));
            DropColumn("dbo.Atores", "VisualizarFinanceiro");
        }
    }
}
