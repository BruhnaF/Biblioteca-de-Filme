namespace ProjetoBibliotecaDeFilme.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriacaodeGeneros : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genero",
                c => new
                    {
                        GeneroId = c.String(nullable: false, maxLength: 9),
                        Descricao = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.GeneroId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Genero");
        }
    }
}
