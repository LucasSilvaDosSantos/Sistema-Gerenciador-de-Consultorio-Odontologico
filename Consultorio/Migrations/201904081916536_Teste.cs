namespace Consultorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Teste : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Produtos", "Validade", c => c.DateTime(precision: 0));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produtos", "Validade", c => c.DateTime(nullable: false, precision: 0));
        }
    }
}
