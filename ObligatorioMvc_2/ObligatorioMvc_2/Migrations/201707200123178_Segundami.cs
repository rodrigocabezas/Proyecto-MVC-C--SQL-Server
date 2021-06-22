namespace ObligatorioMvc_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Segundami : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Financiadors", "NombreUsuario", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Financiadors", "NombreUsuario");
        }
    }
}
