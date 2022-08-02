namespace FinalProgramacionWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nuevosannotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rols", "Nombre", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Rols", "Descripcion", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Usuarios", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Usuarios", "Nombre", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Usuarios", "Apellido", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Usuarios", "Direccion", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Usuarios", "Telefono", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.TipoTransaccions", "Nombre", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.TipoTransaccions", "Descripcion", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TipoTransaccions", "Descripcion", c => c.String());
            AlterColumn("dbo.TipoTransaccions", "Nombre", c => c.String());
            AlterColumn("dbo.Usuarios", "Telefono", c => c.String());
            AlterColumn("dbo.Usuarios", "Direccion", c => c.String());
            AlterColumn("dbo.Usuarios", "Apellido", c => c.String());
            AlterColumn("dbo.Usuarios", "Nombre", c => c.String());
            AlterColumn("dbo.Usuarios", "Email", c => c.String());
            AlterColumn("dbo.Rols", "Descripcion", c => c.String());
            AlterColumn("dbo.Rols", "Nombre", c => c.String());
        }
    }
}
