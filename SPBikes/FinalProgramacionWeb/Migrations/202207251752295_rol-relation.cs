namespace FinalProgramacionWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rolrelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "Rol_Id", c => c.Int());
            CreateIndex("dbo.Clientes", "Rol_Id");
            AddForeignKey("dbo.Clientes", "Rol_Id", "dbo.Rols", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "Rol_Id", "dbo.Rols");
            DropIndex("dbo.Clientes", new[] { "Rol_Id" });
            DropColumn("dbo.Clientes", "Rol_Id");
        }
    }
}
