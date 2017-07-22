using ProjetoBibliotecaDeFilme.Context;
using ProjetoBibliotecaDeFilme.Model;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoBibliotecaDeFilme.DAL
{
    /// <summary>
    /// Classe para manipulação de Dados do Idioma.
    /// </summary>
    public class IdiomaDAO
    {
        /// <summary>
        /// armazena o context do entity framework.
        /// </summary>
        private readonly ContextBibliotecaDeFilme _context;

        /// <summary>
        /// Construtor para bloquear a Inicialização sem parametro.
        /// </summary>
        private IdiomaDAO() { }

        /// <summary>
        /// Construtor Padrão.
        /// </summary>
        /// <param name="context">Objeto com o contexto do entity.</param>
        public IdiomaDAO(ContextBibliotecaDeFilme context)
        {
            _context = context;
        }

        /// <summary>
        /// Lista os idiomas Cadastrados.
        /// </summary>
        /// <returns>Lista de Idiomas.</returns>
        public IEnumerable<Idioma> Listar()
        {
            return _context.Idiomas.ToList();
        }
    }
}
