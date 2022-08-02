namespace FinalProgramacionWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arreglofechasasqldatetime : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Clientes", "FechaAlta");
            DropColumn("dbo.Clientes", "FechaBaja");
            DropColumn("dbo.Detalles", "FechaAlta");
            DropColumn("dbo.Detalles", "FechaBaja");
            DropColumn("dbo.Facturas", "FechaAlta");
            DropColumn("dbo.Facturas", "FechaBaja");
            DropColumn("dbo.Productoes", "FechaAlta");
            DropColumn("dbo.Productoes", "FechaBaja");
            DropColumn("dbo.Proveedors", "FechaAlta");
            DropColumn("dbo.Proveedors", "FechaBaja");
            DropColumn("dbo.Rols", "FechaAlta");
            DropColumn("dbo.Rols", "FechaBaja");
            DropColumn("dbo.Usuarios", "FechaAlta");
            DropColumn("dbo.Usuarios", "FechaBaja");
            DropColumn("dbo.Transaccions", "FechaAlta");
            DropColumn("dbo.Transaccions", "FechaBaja");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transaccions", "FechaBaja", c => c.DateTime(nullable: false));
            AddColumn("dbo.Transaccions", "FechaAlta", c => c.DateTime(nullable: false));
            AddColumn("dbo.Usuarios", "FechaBaja", c => c.DateTime(nullable: false));
            AddColumn("dbo.Usuarios", "FechaAlta", c => c.DateTime(nullable: false));
            AddColumn("dbo.Rols", "FechaBaja", c => c.DateTime(nullable: false));
            AddColumn("dbo.Rols", "FechaAlta", c => c.DateTime(nullable: false));
            AddColumn("dbo.Proveedors", "FechaBaja", c => c.DateTime(nullable: false));
            AddColumn("dbo.Proveedors", "FechaAlta", c => c.DateTime(nullable: false));
            AddColumn("dbo.Productoes", "FechaBaja", c => c.DateTime(nullable: false));
            AddColumn("dbo.Productoes", "FechaAlta", c => c.DateTime(nullable: false));
            AddColumn("dbo.Facturas", "FechaBaja", c => c.DateTime(nullable: false));
            AddColumn("dbo.Facturas", "FechaAlta", c => c.DateTime(nullable: false));
            AddColumn("dbo.Detalles", "FechaBaja", c => c.DateTime(nullable: false));
            AddColumn("dbo.Detalles", "FechaAlta", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clientes", "FechaBaja", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clientes", "FechaAlta", c => c.DateTime(nullable: false));
        }
    }
}
