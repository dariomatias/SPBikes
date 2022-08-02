namespace FinalProgramacionWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tabla_Factura : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCliente = c.Int(nullable: false),
                        IdDetalle = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaBaja = c.DateTime(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Facturas");
        }
    }
}
