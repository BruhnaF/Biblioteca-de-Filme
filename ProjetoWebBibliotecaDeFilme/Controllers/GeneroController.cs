using ProjetoBibliotecaDeFilme.BLL;
using ProjetoWebBibliotecaDeFilme.ViewModel;
using System.Linq;
using System.Web.Mvc;

namespace ProjetoWebBibliotecaDeFilme.Controllers
{
    public class GeneroController : Controller
    {
        /// <summary>
        /// Armazena Instancia de GeneroBLO.
        /// </summary>
        private readonly GeneroBLO _generoBLO;

        /// <summary>
        /// Construtor Padrão
        /// </summary>
        public GeneroController()
        {
            _generoBLO = new GeneroBLO();
        }

        /// <summary>
        /// Mostra lista de Generos Cadastrados.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            var view = new GeneroIndexViewModel();
            return View(view);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult BuscarItensGeneros(string nome)
        {
            var listaGeneros = _generoBLO.Listar();

            if (!string.IsNullOrEmpty(nome))
                listaGeneros
                    = listaGeneros.Where(x =>
                    x.Descricao.ToUpper().Contains(nome.ToUpper())
                    || x.GeneroId.ToUpper().Contains(nome.ToUpper()));

            var listaView
                = listaGeneros
                .Select(x =>
                new Genero_Item_TabelaViewModel
                {
                    GeneroId = x.GeneroId,
                    Descricao = x.Descricao
                }
                ).OrderBy(x => x.GeneroId).ToList();

            return PartialView("_genero_Tabela", listaView);
        }

        /// <summary>
        /// Mostra a Pagina Para Cadastrar o Genero
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }
    }
}