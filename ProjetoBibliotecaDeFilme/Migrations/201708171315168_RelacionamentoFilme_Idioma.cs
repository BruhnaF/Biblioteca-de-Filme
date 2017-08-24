namespace ProjetoBibliotecaDeFilme.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelacionamentoFilme_Idioma : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IdiomaFilme",
                c => new
                    {
                        Idioma_IdiomaId = c.String(nullable: false, maxLength: 9),
                        Filme_FilmeId = c.String(nullable: false, maxLength: 9),
                    })
                .PrimaryKey(t => new { t.Idioma_IdiomaId, t.Filme_FilmeId })
                .ForeignKey("dbo.Idioma", t => t.Idioma_IdiomaId, cascadeDelete: true)
                .ForeignKey("dbo.Filme", t => t.Filme_FilmeId, cascadeDelete: true)
                .Index(t => t.Idioma_IdiomaId)
                .Index(t => t.Filme_FilmeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdiomaFilme", "Filme_FilmeId", "dbo.Filme");
            DropForeignKey("dbo.IdiomaFilme", "Idioma_IdiomaId", "dbo.Idioma");
            DropIndex("dbo.IdiomaFilme", new[] { "Filme_FilmeId" });
            DropIndex("dbo.IdiomaFilme", new[] { "Idioma_IdiomaId" });
            DropTable("dbo.IdiomaFilme");
        }
    }
}
