namespace FinalProgramacionWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nuevosannotations2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "RazonSocial", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Clientes", "Nombre", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Clientes", "Apellido", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Clientes", "CUIT", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Clientes", "Direccion", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Clientes", "Telefono", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Productoes", "Nombre", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Productoes", "Descripcion", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Proveedors", "RazonSocial", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Proveedors", "CUIT", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Proveedors", "Direccion", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Proveedors", "Telefono", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Proveedors", "Telefono", c => c.String());
            AlterColumn("dbo.Proveedors", "Direccion", c => c.String());
            AlterColumn("dbo.Proveedors", "CUIT", c => c.String());
            AlterColumn("dbo.Proveedors", "RazonSocial", c => c.String());
            AlterColumn("dbo.Productoes", "Descripcion", c => c.String());
            AlterColumn("dbo.Productoes", "Nombre", c => c.String());
            AlterColumn("dbo.Clientes", "Telefono", c => c.String());
            AlterColumn("dbo.Clientes", "Direccion", c => c.String());
            AlterColumn("dbo.Clientes", "CUIT", c => c.String());
            AlterColumn("dbo.Clientes", "Apellido", c => c.String());
            AlterColumn("dbo.Clientes", "Nombre", c => c.String());
            AlterColumn("dbo.Clientes", "RazonSocial", c => c.String());
        }
    }
}
