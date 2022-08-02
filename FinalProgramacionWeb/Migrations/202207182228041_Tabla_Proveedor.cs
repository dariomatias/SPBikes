namespace FinalProgramacionWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tabla_Proveedor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Proveedors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RazonSocial = c.String(),
                        CUIT = c.String(),
                        Direccion = c.String(),
                        Telefono = c.String(),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaBaja = c.DateTime(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Proveedors");
        }
    }
}
