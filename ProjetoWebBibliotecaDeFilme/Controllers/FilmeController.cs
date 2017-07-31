using ProjetoBibliotecaDeFilme.BLL;
using ProjetoWebBibliotecaDeFilme.ViewModel.Filmes;
using System.Linq;
using System.Web.Mvc;

namespace ProjetoWebBibliotecaDeFilme.Controllers
{
    public class FilmeController : Controller
    {
        /// <summary>
        /// Armazena Instancia de FilmeBLO.
        /// </summary>
        private readonly FilmeBLO _filmeBLO;

        /// <summary>
        /// Construtor Padrão.
        /// </summary>
        public FilmeController()
        {
            _filmeBLO = new FilmeBLO();
        }

        /// <summary>
        /// Mostra Tela de Filmes Cadastrados.
        /// </summary>
        /// <returns>Tela de Filmes Cadastrados.</returns>
        [HttpGet]
        public ActionResult Index()
        {
            var view = new FilmeIndexViewModel();
            return View(view);
        }

        /// <summary>
        /// Buscar Itens da Lista de Filmes Cadastrados.
        /// </summary>
        /// <param name="nome">Valor a ser Comparado.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult BuscarItensFilmes(string nome)
        {
            var listaFilmes = _filmeBLO.Listar();
            if (!string.IsNullOrEmpty(nome))
                listaFilmes = listaFilmes.Where
                    (x => x.Descricao.ToUpper().Contains
                    (nome.ToUpper()) || x.FilmeId.ToUpper().Contains(nome.ToUpper()));
            var listaView
                = listaFilmes.Select(x => new Filme_Item_TabelaViewModel
                {
                    FilmeId = x.FilmeId,
                    Descricao = x.Descricao
                }
                ).OrderBy(x => x.FilmeId).ToList();
            return PartialView("_filme_Tabela", listaView);
        }
    }
}