namespace ProjetoBibliotecaDeFilme.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelacionamentoFilme_Genero : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GeneroFilme",
                c => new
                    {
                        Genero_GeneroId = c.String(nullable: false, maxLength: 9),
                        Filme_FilmeId = c.String(nullable: false, maxLength: 9),
                    })
                .PrimaryKey(t => new { t.Genero_GeneroId, t.Filme_FilmeId })
                .ForeignKey("dbo.Genero", t => t.Genero_GeneroId, cascadeDelete: true)
                .ForeignKey("dbo.Filme", t => t.Filme_FilmeId, cascadeDelete: true)
                .Index(t => t.Genero_GeneroId)
                .Index(t => t.Filme_FilmeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GeneroFilme", "Filme_FilmeId", "dbo.Filme");
            DropForeignKey("dbo.GeneroFilme", "Genero_GeneroId", "dbo.Genero");
            DropIndex("dbo.GeneroFilme", new[] { "Filme_FilmeId" });
            DropIndex("dbo.GeneroFilme", new[] { "Genero_GeneroId" });
            DropTable("dbo.GeneroFilme");
        }
    }
}
