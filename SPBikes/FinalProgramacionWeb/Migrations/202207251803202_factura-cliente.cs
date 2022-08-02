namespace FinalProgramacionWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class facturacliente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Facturas", "Cliente_Id", c => c.Int());
            CreateIndex("dbo.Facturas", "Cliente_Id");
            AddForeignKey("dbo.Facturas", "Cliente_Id", "dbo.Clientes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Facturas", "Cliente_Id", "dbo.Clientes");
            DropIndex("dbo.Facturas", new[] { "Cliente_Id" });
            DropColumn("dbo.Facturas", "Cliente_Id");
        }
    }
}
