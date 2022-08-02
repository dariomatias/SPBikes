namespace FinalProgramacionWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tabla_Detalles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Detalles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdFactura = c.Int(nullable: false),
                        IdProducto = c.Int(nullable: false),
                        PrecioUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cantidad = c.Int(nullable: false),
                        Descuento = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaBaja = c.DateTime(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Detalles");
        }
    }
}
