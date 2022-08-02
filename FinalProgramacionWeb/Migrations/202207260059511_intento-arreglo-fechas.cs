namespace FinalProgramacionWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intentoarreglofechas : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TipoTransaccions", "FechaAlta");
            DropColumn("dbo.TipoTransaccions", "FechaBaja");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TipoTransaccions", "FechaBaja", c => c.DateTime(nullable: false));
            AddColumn("dbo.TipoTransaccions", "FechaAlta", c => c.DateTime(nullable: false));
        }
    }
}
