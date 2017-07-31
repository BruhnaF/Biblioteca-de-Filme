namespace ProjetoBibliotecaDeFilme.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriacaodeFilmes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Filme",
                c => new
                    {
                        FilmeId = c.String(nullable: false, maxLength: 9),
                        Descricao = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.FilmeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Filme");
        }
    }
}
