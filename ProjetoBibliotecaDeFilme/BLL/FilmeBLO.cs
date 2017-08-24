using ProjetoBibliotecaDeFilme.Context;
using ProjetoBibliotecaDeFilme.DAL;
using ProjetoBibliotecaDeFilme.Model;
using System.Collections.Generic;
using System.Linq;

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

        private readonly GeneroDAO _generoDAO;
        private readonly IdiomaDAO _idiomaDAO;

        /// <summary>
        /// Construtor Padrão.
        /// </summary>
        public FilmeBLO()
        {
            _context = new ContextBibliotecaDeFilme();
            _filmeDAO = new FilmeDAO(_context);
            _generoDAO = new GeneroDAO(_context);
            _idiomaDAO = new IdiomaDAO(_context);
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
            var novoFilme = new Filme { FilmeId = filme.FilmeId, Descricao = filme.Descricao,
                    Generos = new List<Genero>(), Idiomas = new List<Idioma>() };

            if (novoFilme != null)
            {
                foreach (var item in filme.Generos)
                {
                    novoFilme.Generos.Add(_generoDAO.BuscarPorId(item.GeneroId));
                }

                foreach (var item in filme.Idiomas)
                {
                    novoFilme.Idiomas.Add(_idiomaDAO.BuscarPorId(item.IdiomaId));
                }
            }

            _filmeDAO.Salvar(novoFilme);
        }

        /// <summary>
        /// Editar Filme.
        /// </summary>
        /// <param name="filme">Filme a ser Editado.</param>
        public void Editar(Filme filme)
        {
            var novoFilme = BuscarPorId(filme.FilmeId);
            novoFilme.Descricao = filme.Descricao;

            if (filme.Generos.Count > 0)
            {
                if (novoFilme.Generos == null)
                    novoFilme.Generos = new List<Genero>();

                foreach (var item in filme.Generos)
                {
                    var generos = _generoDAO.BuscarPorId(item.GeneroId);
                    novoFilme.Generos.Add(generos);
                }           
            }

            if (filme.Idiomas.Count > 0)
            {
                if (novoFilme.Idiomas == null)
                    novoFilme.Idiomas = new List<Idioma>();

                foreach (var item in filme.Idiomas)
                {
                    var idiomas = _idiomaDAO.BuscarPorId(item.IdiomaId);
                    novoFilme.Idiomas.Add(idiomas);
                }
            }

            _filmeDAO.Editar(novoFilme);
            filme = novoFilme;
        }

        public void Excluir(string idFilme)
        {
            var filme = _filmeDAO.BuscarPorId(idFilme);
            _filmeDAO.Excluir(filme);
        }

        public void RemoverItensLivro(Filme filme)
        {
            _filmeDAO.Editar(filme);          
        }
    }
}
