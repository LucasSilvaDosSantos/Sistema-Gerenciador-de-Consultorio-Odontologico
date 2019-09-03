namespace Consultorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificandoconsulta : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Consultas", "QuemRealizou_Id", c => c.Int());
            CreateIndex("dbo.Consultas", "QuemRealizou_Id");
            AddForeignKey("dbo.Consultas", "QuemRealizou_Id", "dbo.Atores", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consultas", "QuemRealizou_Id", "dbo.Atores");
            DropIndex("dbo.Consultas", new[] { "QuemRealizou_Id" });
            DropColumn("dbo.Consultas", "QuemRealizou_Id");
        }
    }
}
