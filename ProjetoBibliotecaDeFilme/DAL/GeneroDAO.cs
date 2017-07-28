using ProjetoBibliotecaDeFilme.Context;
using ProjetoBibliotecaDeFilme.Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ProjetoBibliotecaDeFilme.DAL
{
    class GeneroDAO
    {
        /// <summary>
        /// Classe para manipulação de Dados do Genero.
        /// </summary>
        private readonly ContextBibliotecaDeFilme _context;

        /// <summary>
        /// Construtor para bloquear a Inicialização sem parametro.
        /// </summary>
        private GeneroDAO() { }

        /// <summary>
        /// Construtor Padrão.
        /// </summary>
        /// <param name="context">Objeto com o contexto do entity.</param>
        public GeneroDAO(ContextBibliotecaDeFilme context)
        {
            _context = context;
        }

        /// <summary>
        /// Lista os Generos Cadastrados.
        /// </summary>
        /// <returns>Retorna Lista de Generos.</returns>
        public IEnumerable<Genero>Listar()
        {
            return _context.Generos.ToList();
        }

        /// <summary>
        /// Salva Genero.
        /// </summary>Idioma a ser salvo.</param>
        public void Salvar(Genero genero)
        {
            _context.Generos.Add(genero);
            _context.SaveChanges();
        }

        internal Genero BuscarPorId(string id)
        {
            return _context.Generos.Find(id);
        }
    }
}
