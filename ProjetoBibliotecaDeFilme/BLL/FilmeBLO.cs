using ProjetoBibliotecaDeFilme.Context;
using ProjetoBibliotecaDeFilme.DAL;
using ProjetoBibliotecaDeFilme.Model;
using System.Collections.Generic;

namespace ProjetoBibliotecaDeFilme.BLL
{
    /// <summary>
    /// Classe de Negocios do Filme
    /// </summary>
    public class FilmeBLO
    {
        /// <summary>
        /// Armazena o Context.
        /// </summary>
        private readonly ContextBibliotecaDeFilme _context;

        /// <summary>
        /// Armazena Instancia do FilmeDAO.
        /// </summary>
        private readonly FilmeDAO _filmeDAO;

        /// <summary>
        /// Construtor Padrão.
        /// </summary>
        public FilmeBLO()
        {
            _context = new ContextBibliotecaDeFilme();
            _filmeDAO = new FilmeDAO(_context);
        }

        /// <summary>
        /// Busca por Filmes.
        /// </summary>
        /// <returns>Lista de Filmes.</returns>
        public IEnumerable<Filme> Listar()
        {
            return _filmeDAO.Listar();
        }

        /// <summary>
        /// Buscar por Id.
        /// </summary>
        /// <param name="id">Id a ser Comparado.</param>
        /// <returns>Valor Encontrado.</returns>
        public Filme BuscarPorId(string id)
        {
            return _filmeDAO.BuscarPorId(id);
        }
    }
}
