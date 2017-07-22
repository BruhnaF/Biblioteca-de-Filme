using ProjetoBibliotecaDeFilme.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProjetoBibliotecaDeFilme.Context
{
    /// <summary>
    /// Context do Entity para o programa.
    /// </summary>
    public class ContextBibliotecaDeFilme : DbContext 
    {
        /// <summary>
        /// Construtor Padrão.
        /// </summary>
        public ContextBibliotecaDeFilme(): base("BibliotecaDeFilmes") { }
       
        /// <summary>
        /// DbSet Idiomas.
        /// </summary>
       public DbSet<Idioma> Idiomas { get; set; }

        /// <summary>
        /// Ajuste ao criar entity.
        /// </summary>
        /// <param name="modelBuilder">Objeto com as configurações de criação.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
