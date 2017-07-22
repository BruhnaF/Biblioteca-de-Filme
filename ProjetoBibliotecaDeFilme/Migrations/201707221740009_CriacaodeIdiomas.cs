namespace ProjetoBibliotecaDeFilme.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriacaodeIdiomas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Idioma",
                c => new
                    {
                        IdiomaId = c.String(nullable: false, maxLength: 9),
                        Descricao = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IdiomaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Idioma");
        }
    }
}
