using ProjetoBibliotecaDeFilme.Context;
using ProjetoBibliotecaDeFilme.DAL;
using ProjetoBibliotecaDeFilme.Model;
using System.Collections.Generic;

namespace ProjetoBibliotecaDeFilme.BLL
{
    /// <summary>
    /// Classe de Negocios de idioma.
    /// </summary>
    public class IdiomaBLO
    {
        /// <summary>
        /// Armazena o Context do entity.
        /// </summary>
        private readonly ContextBibliotecaDeFilme _context;

        /// <summary>
        /// Armazena instancia da classe de dados de Idioma.
        /// </summary>
        private readonly IdiomaDAO _idiomaDAO;

        /// <summary>
        /// Construtor Padrão.
        /// </summary>
        public IdiomaBLO()
        {
            _context = new ContextBibliotecaDeFilme();
            _idiomaDAO = new IdiomaDAO(_context);
        }

        /// <summary>
        /// Retorna uma Lista de Idiomas Cadastrados.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Idioma> Listar()
        {
            return _idiomaDAO.Listar();
        }
    }
}
