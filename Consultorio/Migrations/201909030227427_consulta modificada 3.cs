namespace Consultorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class consultamodificada3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Consultas", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Consultas", "Status", c => c.String(nullable: false, unicode: false));
        }
    }
}
