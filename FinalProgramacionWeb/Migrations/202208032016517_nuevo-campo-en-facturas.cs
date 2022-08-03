namespace FinalProgramacionWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nuevocampoenfacturas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Facturas", "NumeroDeFactura", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Facturas", "NumeroDeFactura");
        }
    }
}
