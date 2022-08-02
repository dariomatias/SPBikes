namespace FinalProgramacionWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rolfacturadetalleproducto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Detalles", "Producto_Id", c => c.Int());
            CreateIndex("dbo.Detalles", "Producto_Id");
            AddForeignKey("dbo.Detalles", "Producto_Id", "dbo.Productoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Detalles", "Producto_Id", "dbo.Productoes");
            DropIndex("dbo.Detalles", new[] { "Producto_Id" });
            DropColumn("dbo.Detalles", "Producto_Id");
        }
    }
}
