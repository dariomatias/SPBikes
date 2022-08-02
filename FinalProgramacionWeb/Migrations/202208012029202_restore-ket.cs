namespace FinalProgramacionWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restoreket : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Facturas", "Cliente_Id", "dbo.Clientes");
            DropIndex("dbo.Facturas", new[] { "Cliente_Id" });
            RenameColumn(table: "dbo.Facturas", name: "Cliente_Id", newName: "Cliente_CUIT");
            DropPrimaryKey("dbo.Clientes");
            AlterColumn("dbo.Clientes", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Facturas", "Cliente_CUIT", c => c.String(maxLength: 15));
            AddPrimaryKey("dbo.Clientes", "CUIT");
            CreateIndex("dbo.Facturas", "Cliente_CUIT");
            AddForeignKey("dbo.Facturas", "Cliente_CUIT", "dbo.Clientes", "CUIT");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Facturas", "Cliente_CUIT", "dbo.Clientes");
            DropIndex("dbo.Facturas", new[] { "Cliente_CUIT" });
            DropPrimaryKey("dbo.Clientes");
            AlterColumn("dbo.Facturas", "Cliente_CUIT", c => c.Int());
            AlterColumn("dbo.Clientes", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Clientes", "Id");
            RenameColumn(table: "dbo.Facturas", name: "Cliente_CUIT", newName: "Cliente_Id");
            CreateIndex("dbo.Facturas", "Cliente_Id");
            AddForeignKey("dbo.Facturas", "Cliente_Id", "dbo.Clientes", "Id");
        }
    }
}
