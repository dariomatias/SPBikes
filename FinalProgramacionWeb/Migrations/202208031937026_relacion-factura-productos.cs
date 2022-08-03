namespace FinalProgramacionWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relacionfacturaproductos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productoes", "Factura_Id", c => c.Int());
            CreateIndex("dbo.Productoes", "Factura_Id");
            AddForeignKey("dbo.Productoes", "Factura_Id", "dbo.Facturas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productoes", "Factura_Id", "dbo.Facturas");
            DropIndex("dbo.Productoes", new[] { "Factura_Id" });
            DropColumn("dbo.Productoes", "Factura_Id");
        }
    }
}
