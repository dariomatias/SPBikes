namespace FinalProgramacionWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rolfacturadetalle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Detalles", "Factura_Id", c => c.Int());
            CreateIndex("dbo.Detalles", "Factura_Id");
            AddForeignKey("dbo.Detalles", "Factura_Id", "dbo.Facturas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Detalles", "Factura_Id", "dbo.Facturas");
            DropIndex("dbo.Detalles", new[] { "Factura_Id" });
            DropColumn("dbo.Detalles", "Factura_Id");
        }
    }
}
