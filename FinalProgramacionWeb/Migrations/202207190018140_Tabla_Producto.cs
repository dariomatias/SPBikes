namespace FinalProgramacionWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tabla_Producto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SKU = c.Int(nullable: false),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaBaja = c.DateTime(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Productoes");
        }
    }
}
