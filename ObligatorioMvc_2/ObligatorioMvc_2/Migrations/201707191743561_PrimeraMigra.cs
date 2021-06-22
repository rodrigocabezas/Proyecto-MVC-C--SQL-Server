namespace ObligatorioMvc_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimeraMigra : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Emprendimientoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 50, unicode: false),
                        Descripcion = c.String(nullable: false, maxLength: 500, unicode: false),
                        Costo = c.Int(nullable: false),
                        Dias = c.Int(nullable: false),
                        PuntajeFinal = c.Int(nullable: false),
                        Financiado = c.Int(nullable: false),
                        IdFinanciador = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Financiadors", t => t.IdFinanciador, cascadeDelete: true)
                .Index(t => t.IdFinanciador);
            
            CreateTable(
                "dbo.Financiadors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Contraseña = c.String(nullable: false, maxLength: 50, unicode: false),
                        NombreOrganizacion = c.String(nullable: false, maxLength: 50, unicode: false),
                        MontoMaximo = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Emprendimientoes", "IdFinanciador", "dbo.Financiadors");
            DropIndex("dbo.Emprendimientoes", new[] { "IdFinanciador" });
            DropTable("dbo.Financiadors");
            DropTable("dbo.Emprendimientoes");
        }
    }
}
