namespace FinalProgramacionWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class elimineindicesredundantesyagreguevirtualalosobjetosrelacionales : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clientes", "Rol_Id", "dbo.Rols");
            DropIndex("dbo.Clientes", new[] { "Rol_Id" });
            AddColumn("dbo.Rols", "Usuario_Id", c => c.Int());
            AddColumn("dbo.Transaccions", "Factura_Id", c => c.Int());
            AddColumn("dbo.Transaccions", "TipoTransaccion_Id", c => c.Int());
            CreateIndex("dbo.Rols", "Usuario_Id");
            CreateIndex("dbo.Transaccions", "Factura_Id");
            CreateIndex("dbo.Transaccions", "TipoTransaccion_Id");
            AddForeignKey("dbo.Rols", "Usuario_Id", "dbo.Usuarios", "Id");
            AddForeignKey("dbo.Transaccions", "Factura_Id", "dbo.Facturas", "Id");
            AddForeignKey("dbo.Transaccions", "TipoTransaccion_Id", "dbo.TipoTransaccions", "Id");
            DropColumn("dbo.Clientes", "Rol_Id");
            DropColumn("dbo.Transaccions", "IdTipoTransaccion");
            DropColumn("dbo.Transaccions", "IdFactura");
            DropColumn("dbo.Transaccions", "IdPresupuesto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transaccions", "IdPresupuesto", c => c.Int(nullable: false));
            AddColumn("dbo.Transaccions", "IdFactura", c => c.Int(nullable: false));
            AddColumn("dbo.Transaccions", "IdTipoTransaccion", c => c.Int(nullable: false));
            AddColumn("dbo.Clientes", "Rol_Id", c => c.Int());
            DropForeignKey("dbo.Transaccions", "TipoTransaccion_Id", "dbo.TipoTransaccions");
            DropForeignKey("dbo.Transaccions", "Factura_Id", "dbo.Facturas");
            DropForeignKey("dbo.Rols", "Usuario_Id", "dbo.Usuarios");
            DropIndex("dbo.Transaccions", new[] { "TipoTransaccion_Id" });
            DropIndex("dbo.Transaccions", new[] { "Factura_Id" });
            DropIndex("dbo.Rols", new[] { "Usuario_Id" });
            DropColumn("dbo.Transaccions", "TipoTransaccion_Id");
            DropColumn("dbo.Transaccions", "Factura_Id");
            DropColumn("dbo.Rols", "Usuario_Id");
            CreateIndex("dbo.Clientes", "Rol_Id");
            AddForeignKey("dbo.Clientes", "Rol_Id", "dbo.Rols", "Id");
        }
    }
}
