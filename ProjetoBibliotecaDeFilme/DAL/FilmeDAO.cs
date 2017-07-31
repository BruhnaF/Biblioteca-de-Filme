using ProjetoBibliotecaDeFilme.Context;
using ProjetoBibliotecaDeFilme.Model;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoBibliotecaDeFilme.DAL
{
    public class FilmeDAO
    {
        /// <summary>
        /// Classe para manipulação de Dados do Filme.
        /// </summary>
        private readonly ContextBibliotecaDeFilme _context;

        /// <summary>
        /// Construtor para bloquear a Inicialização sem parametro.
        /// </summary>
        private FilmeDAO() { }

        /// <summary>
        /// Construtor Padrão
        /// </summary>
        /// <param name="context">Objeto com o contexto do entity</param>
        public FilmeDAO(ContextBibliotecaDeFilme context)
        {
            _context = context;
        }

        /// <summary>
        /// Listar Filmes.
        /// </summary>
        /// <returns>Lista de Filmes.</returns>
        public  IEnumerable<Filme> Listar()
        {
            return _context.Filmes.ToList();
        }

        /// <summary>
        /// Buscar Filme por Id.
        /// </summary>
        /// <param name="id">Valor a ser Comparado.</param>
        /// <returns>Valor Encontrado.</returns>
        public Filme BuscarPorId(string id)
        {
            return _context.Filmes.Find(id);
        }
    }
}
