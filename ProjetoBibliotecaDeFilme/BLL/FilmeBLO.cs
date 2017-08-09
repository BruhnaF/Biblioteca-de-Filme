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

        /// <summary>
        /// Salvar Filme.
        /// </summary>
        /// <param name="filme">Filme a ser Salvo.</param>
        public void Salvar(Filme filme)
        {
            _filmeDAO.Salvar(filme);
        }

        /// <summary>
        /// Editar Filme.
        /// </summary>
        /// <param name="filme">Filme a ser Editado.</param>
        public void Editar(Filme filme)
        {
            _filmeDAO.Editar(filme);
        }

        public void Excluir(string idFilme)
        {
            var filme = _filmeDAO.BuscarPorId(idFilme);
            _filmeDAO.Excluir(filme);
        }
    }
}
