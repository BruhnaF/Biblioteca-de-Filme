using ProjetoBibliotecaDeFilme.BLL;
using ProjetoBibliotecaDeFilme.Enumerador;
using ProjetoBibliotecaDeFilme.Model;
using ProjetoBibliotecaDeFilme.Utils;
using ProjetoWebBibliotecaDeFilme.Helper;
using ProjetoWebBibliotecaDeFilme.ViewModel.Filmes;
using System;
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

        /// <summary>
        /// Mostra Tela para Cadastrar Filme
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        /// <summary>
        /// Cadastra Filme 
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Cadastrar(FilmeViewModel view)
        {
            var retorno = new RetornoMensagem();
            try
            {
                var filme = new Filme()
                {
                    FilmeId = view.FilmeId,
                    Descricao = view.Descricao
                };

                _filmeBLO.Salvar(filme);
                retorno.Mensagem
                    = string.Format("Filme {0} - {1} Cadastrado com Sucesso. <br />", view.FilmeId, view.Descricao);
                retorno.TipoMensagem = TipoMensagem.Sucesso;
                retorno.Resultado = false;
            }
            catch (ProjetoException ex)
            {
                retorno.Mensagem = ex.Message;
                retorno.TipoMensagem = TipoMensagem.Alerta;
                retorno.Resultado = false;
            }
            catch (Exception)
            {
                retorno.Mensagem = "Erro ao Cadastrar.<br />";
                retorno.TipoMensagem = TipoMensagem.Erro;
                retorno.Resultado = false;
            }
            return Json(retorno);
        }

        /// <summary>
        /// Mostra pagina para Editar Filme.
        /// </summary>
        /// <param name="id">Filme a ser Editado.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Editar(string id)
        {
            var filme = _filmeBLO.BuscarPorId(id);
            var view = new FilmeViewModel(filme);
            return View(view);
        }

        /// <summary>
        /// Editar Filme.
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Editar(FilmeViewModel view)
        {
            var retorno = new RetornoMensagem();
            try
            {
                var filme = new Filme()
                {
                    FilmeId = view.FilmeId,
                    Descricao = view.Descricao
                };

                _filmeBLO.Editar(filme);

                retorno.Mensagem
                    = string.Format("Filme {0} - {1} Editado com Sucesso. <br />", view.FilmeId, view.Descricao);
                retorno.TipoMensagem = TipoMensagem.Sucesso;
                retorno.Resultado = false;
            }
            catch (ProjetoException ex)
            {
                retorno.Mensagem = ex.Message;
                retorno.TipoMensagem = TipoMensagem.Alerta;
                retorno.Resultado = false;
            }
            catch (Exception)
            {
                retorno.Mensagem = "Erro ao Editar.<br />";
                retorno.TipoMensagem = TipoMensagem.Erro;
                retorno.Resultado = false;
            }
            return Json(retorno);
        }

        /// <summary>
        /// Excluir Filme
        /// </summary>
        /// <param name="id">Valor a ser Excluido</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Excluir(string id)
        {
            var retorno = new RetornoMensagem();
            try
            {
                var filmeMensagem = _filmeBLO.BuscarPorId(id);

                _filmeBLO.Excluir(id);

                retorno.Mensagem
                    = string.Format("Filme {0} - {1} Excluido com Sucesso. <br />", filmeMensagem.FilmeId, filmeMensagem.Descricao);
                retorno.TipoMensagem = TipoMensagem.Sucesso;
                retorno.Resultado = false;
            }
            catch (ProjetoException ex)
            {
                retorno.Mensagem = ex.Message;
                retorno.TipoMensagem = TipoMensagem.Alerta;
                retorno.Resultado = false;
            }
            catch (Exception)
            {
                retorno.Mensagem = "Erro ao Excluir.<br />";
                retorno.TipoMensagem = TipoMensagem.Erro;
                retorno.Resultado = false;
            }
            return Json(retorno);
        }
    }
}
