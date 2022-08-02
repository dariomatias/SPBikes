namespace FinalProgramacionWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class elimineindicesredundantes : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Detalles", "IdFactura");
            DropColumn("dbo.Detalles", "IdProducto");
            DropColumn("dbo.Facturas", "IdCliente");
            DropColumn("dbo.Facturas", "IdDetalle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Facturas", "IdDetalle", c => c.Int(nullable: false));
            AddColumn("dbo.Facturas", "IdCliente", c => c.Int(nullable: false));
            AddColumn("dbo.Detalles", "IdProducto", c => c.Int(nullable: false));
            AddColumn("dbo.Detalles", "IdFactura", c => c.Int(nullable: false));
        }
    }
}
