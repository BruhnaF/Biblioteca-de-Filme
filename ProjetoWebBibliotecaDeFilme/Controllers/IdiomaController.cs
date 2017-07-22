using ProjetoBibliotecaDeFilme.BLL;
using ProjetoWebBibliotecaDeFilme.ViewModel;
using System.Linq;
using System.Web.Mvc;

namespace ProjetoWebBibliotecaDeFilme.Controllers
{
    public class IdiomaController : Controller
    {
        /// <summary>
        /// Armazena Instancia de IdiomaBLO.
        /// </summary>
        private readonly IdiomaBLO _idiomaBLO;

        /// <summary>
        /// Contrutor Padrao.
        /// </summary>
        public IdiomaController()
        {
            _idiomaBLO = new IdiomaBLO();
        }

        /// <summary>
        /// Mostra Lista de Idiomas Cadastrados.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        { 
            var view = new IdiomaIndexViewModel();
            return View(view);
        }

        /// <summary>
        /// Metodo que busca a lista de idiomas cadastrados.
        /// </summary>
        /// <param name="nome">Parâmetro para filtrar a lista.</param>
        /// <returns>Partial View de Tabela de Idiomas.</returns>
        [HttpPost]
        public ActionResult BuscarItensIdiomas(string nome)
        {
            var listaIdiomas = _idiomaBLO.Listar();

            if (!string.IsNullOrEmpty(nome))
                listaIdiomas 
                    = listaIdiomas.Where(x => 
                    x.Descricao.ToUpper().Contains(nome.ToUpper()) 
                    || x.IdiomaId.ToUpper().Contains(nome.ToUpper()));

            var listaidiomasView
                = listaIdiomas
                .Select(x =>
                new Idioma_Item_TabelaViewModel
                {
                    IdiomaId = x.IdiomaId,
                    IdiomaNome = x.Descricao
                }
                ).ToList();

            return PartialView("_idioma_Tabela", listaidiomasView);
        }
    }
}