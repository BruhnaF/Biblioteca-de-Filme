using ProjetoBibliotecaDeFilme.Context;
using ProjetoBibliotecaDeFilme.DAL;
using ProjetoBibliotecaDeFilme.Model;
using System.Collections.Generic;

namespace ProjetoBibliotecaDeFilme.BLL
{
    /// <summary>
    /// Classe de Negocios de Genero.
    /// </summary>
    public class GeneroBLO
    {
        /// <summary>
        /// Armazena o Context do entity.
        /// </summary>
        private readonly ContextBibliotecaDeFilme _context;

        /// <summary>
        /// Armazena instancia da classe de dados de Genero.
        /// </summary>
        private readonly GeneroDAO _generoDAO;

        /// <summary>
        /// Construtor Padrão.
        /// </summary>
        public GeneroBLO()
        {
            _context = new ContextBibliotecaDeFilme();
            _generoDAO = new GeneroDAO(_context);
        }

        /// <summary>
        /// Retorna uma Lista de Generos Cadastrados.
        /// </summary>
        /// <returns>Retorna Lista de Generos</returns>
        public IEnumerable<Genero> Listar()
        {
            return _generoDAO.Listar();
        }

        public Genero BuscarPorId(string id)
        {
            return _generoDAO.BuscarPorId(id);
        }
    }
}
