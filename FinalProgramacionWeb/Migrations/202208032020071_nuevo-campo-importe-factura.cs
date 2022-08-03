namespace FinalProgramacionWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nuevocampoimportefactura : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Facturas", "Importe", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Facturas", "Importe");
        }
    }
}
