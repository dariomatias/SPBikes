namespace FinalProgramacionWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tabla_Transaccion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transaccions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdTipoTransaccion = c.Int(nullable: false),
                        IdFactura = c.Int(nullable: false),
                        IdPresupuesto = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaBaja = c.DateTime(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Transaccions");
        }
    }
}
