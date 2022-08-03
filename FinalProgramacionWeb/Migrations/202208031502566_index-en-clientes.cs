namespace FinalProgramacionWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class indexenclientes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Facturas", "Cliente_CUIT", "dbo.Clientes");
            DropIndex("dbo.Facturas", new[] { "Cliente_CUIT" });
            RenameColumn(table: "dbo.Facturas", name: "Cliente_CUIT", newName: "Cliente_Id");
            DropPrimaryKey("dbo.Clientes");
            AlterColumn("dbo.Clientes", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Facturas", "Cliente_Id", c => c.Int());
            AddPrimaryKey("dbo.Clientes", "Id");
            CreateIndex("dbo.Facturas", "Cliente_Id");
            AddForeignKey("dbo.Facturas", "Cliente_Id", "dbo.Clientes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Facturas", "Cliente_Id", "dbo.Clientes");
            DropIndex("dbo.Facturas", new[] { "Cliente_Id" });
            DropPrimaryKey("dbo.Clientes");
            AlterColumn("dbo.Facturas", "Cliente_Id", c => c.String(maxLength: 15));
            AlterColumn("dbo.Clientes", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Clientes", "CUIT");
            RenameColumn(table: "dbo.Facturas", name: "Cliente_Id", newName: "Cliente_CUIT");
            CreateIndex("dbo.Facturas", "Cliente_CUIT");
            AddForeignKey("dbo.Facturas", "Cliente_CUIT", "dbo.Clientes", "CUIT");
        }
    }
}
