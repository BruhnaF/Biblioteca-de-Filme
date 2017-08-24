using ProjetoBibliotecaDeFilme.BLL;
using ProjetoBibliotecaDeFilme.Enumerador;
using ProjetoBibliotecaDeFilme.Model;
using ProjetoBibliotecaDeFilme.Utils;
using ProjetoWebBibliotecaDeFilme.Helper;
using ProjetoWebBibliotecaDeFilme.ViewModel.Filmes;
using ProjetoWebBibliotecaDeFilme.ViewModel.Generos;
using ProjetoWebBibliotecaDeFilme.ViewModel.Idiomas;
using System;
using System.Collections.Generic;
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

        private readonly GeneroBLO _generoBLO;
        private readonly IdiomaBLO _idiomaBLO;

        /// <summary>
        /// Construtor Padrão.
        /// </summary>
        public FilmeController()
        {
            _filmeBLO = new FilmeBLO();
            _generoBLO = new GeneroBLO();
            _idiomaBLO = new IdiomaBLO();
        }

        private static FilmeViewModel filmeTemp { get; set; }

        /// <summary>
        /// Adiciona Idioma ao FilmeTemp.
        /// </summary>
        /// <param name="codIdioma">Idioma a ser adicionado ao Filme.</param>
        /// <returns>Objeto com dados de Sucesso ou Falha.</returns>
        [HttpPost]
        public ActionResult AdicionarIdioma(string codIdioma)
        {
            var retorno = new RetornoMensagem();
            try
            {
                var idioma = _idiomaBLO.BuscarPorId(codIdioma);
                var view = new IdiomaViewModel(idioma);

                if (filmeTemp.ListaIdiomas.Count(x => x.IdiomaId.Equals(codIdioma)) > 0)
                    throw new ProjetoException(string.Format("{0} Já Adicionado", view.Descricao));

                filmeTemp.ListaIdiomas.Add(view);

                retorno.Mensagem = string.Empty;
                retorno.TipoMensagem = TipoMensagem.Sucesso;
                retorno.Resultado = true;
            }
            catch (ProjetoException ex)
            {
                retorno.Mensagem = ex.Message;
                retorno.TipoMensagem = TipoMensagem.Alerta;
                retorno.Resultado = false;
            }
            catch (Exception)
            {
                retorno.Mensagem = "Erro ao Adicionar Idioma ao Filme.<br />";
                retorno.TipoMensagem = TipoMensagem.Erro;
                retorno.Resultado = false;
            }
            return Json(retorno);
        }

        /// <summary>
        /// Adiciona Genero ao FilmeTemp.
        /// </summary>
        /// <param name="codGenero">cod do Genero a ser Adicionado.</param>
        /// <returns>Objeto com dados de Sucesso ou Falha.</returns>
        [HttpPost]
        public ActionResult AdicionarGenero(string codGenero)
        {
            var retorno = new RetornoMensagem();
            try
            {
                var genero = _generoBLO.BuscarPorId(codGenero);

                var view = new GeneroViewModel(genero);

                if (filmeTemp.ListaGeneros.Count(x => x.GeneroId.Equals(codGenero)) > 0)
                    throw new ProjetoException(string.Format("{0} Já Adicionado", view.Descricao));

                filmeTemp.ListaGeneros.Add(view);

                retorno.Mensagem = string.Empty;
                retorno.TipoMensagem = TipoMensagem.Sucesso;
                retorno.Resultado = true;
            }
            catch (ProjetoException ex)
            {
                retorno.Mensagem = ex.Message;
                retorno.TipoMensagem = TipoMensagem.Alerta;
                retorno.Resultado = false;
            }
            catch (Exception)
            {
                retorno.Mensagem = "Erro ao Adicionar Genero ao Filme.<br />";
                retorno.TipoMensagem = TipoMensagem.Erro;
                retorno.Resultado = false;
            }
            return Json(retorno);
        }

        /// <summary>
        /// Remove item da lista de Idiomas.
        /// </summary>
        /// <param name="codIdioma">Idioma a ser Removido.</param>
        /// <returns>>Objeto com dados de Sucesso ou Falha.</returns>
        [HttpPost]
        public ActionResult RemoverIdiomaDaLista(string codIdioma)
        {
            var retorno = new RetornoMensagem();
            try
            {
                var idiomaView = filmeTemp.ListaIdiomas.Where(x => x.IdiomaId == codIdioma).FirstOrDefault();

                if (idiomaView != null)
                {
                    filmeTemp.ListaIdiomas.Remove(idiomaView);

                    if (idiomaView != null)
                    {
                        filmeTemp.ListaIdiomas.Remove(idiomaView);

                        var filme = _filmeBLO.Listar().Where(x => x.FilmeId == filmeTemp.FilmeId).FirstOrDefault();

                        foreach (var item in filme.Idiomas.ToList())
                        {
                            if (item.IdiomaId == idiomaView.IdiomaId)
                            {
                                filme.Idiomas.Remove(item);
                                _filmeBLO.RemoverItensLivro(filme);
                            }
                        }
                    }
                }
                else
                    throw new ProjetoException("Idioma não encontrado na Lista.");

                retorno.Mensagem = string.Format("Idioma {0} - {1} Removido com Sucesso do Filme. <br />",
                        idiomaView.IdiomaId, idiomaView.Descricao);
                retorno.TipoMensagem = TipoMensagem.Sucesso;
                retorno.Resultado = true;
            }
            catch (ProjetoException ex)
            {
                retorno.Mensagem = ex.Message;
                retorno.TipoMensagem = TipoMensagem.Alerta;
                retorno.Resultado = false;
            }
            catch (Exception)
            {
                retorno.Mensagem = "Erro ao Adicionar Idioma ao Filme.<br />";
                retorno.TipoMensagem = TipoMensagem.Erro;
                retorno.Resultado = false;
            }
            return Json(retorno);
        }

        /// <summary>
        /// Remove item da lista de Generos
        /// </summary>
        /// <param name="codGenero">Genero a ser Removido.</param>
        /// <returns>Objeto com dados de Sucesso ou Falha.</returns>
        [HttpPost]
        public ActionResult RemoverGeneroDaLista(string codGenero)
        {
            var retorno = new RetornoMensagem();
            try
            {
                var generoView = filmeTemp.ListaGeneros.Where(x => x.GeneroId == codGenero).FirstOrDefault();

                if (generoView != null)
                {
                    filmeTemp.ListaGeneros.Remove(generoView);

                    var filme = _filmeBLO.Listar().Where(x => x.FilmeId == filmeTemp.FilmeId).FirstOrDefault();

                    foreach (var item in filme.Generos.ToList())
                    {
                        if (item.GeneroId == generoView.GeneroId)
                        {
                            filme.Generos.Remove(item);
                            _filmeBLO.RemoverItensLivro(filme);
                        }
                    }
                }
                else
                    throw new ProjetoException("Genero não encontrado na Lista.");

                retorno.Mensagem
                     = string.Format("Genero {0} - {1} Removido com Sucesso do Filme. <br />",
                        generoView.GeneroId, generoView.Descricao);
                retorno.TipoMensagem = TipoMensagem.Sucesso;
                retorno.Resultado = true;
            }

            catch (ProjetoException ex)
            {
                retorno.Mensagem = ex.Message;
                retorno.TipoMensagem = TipoMensagem.Alerta;
                retorno.Resultado = false;
            }
            catch (Exception)
            {
                retorno.Mensagem = "Erro ao Remover Genero ao Filme.<br />";
                retorno.TipoMensagem = TipoMensagem.Erro;
                retorno.Resultado = false;
            }

            return Json(retorno);
        }

        /// <summary>
        /// Carrega Tabela de Idiomas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CarregarTabelaIdioma()
        {
            var view = new List<IdiomaViewModel>();

            if (filmeTemp.ListaIdiomas.Any())
                view = filmeTemp.ListaIdiomas;

            return PartialView("_tabelaIdiomas", view);
        }

        /// <summary>
        /// Carrega Tabela de Generos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CarregarTabelaGenero()
        {
            var view = new List<GeneroViewModel>();

            if (filmeTemp.ListaGeneros.Any())
                view = filmeTemp.ListaGeneros;

            return PartialView("_tabelaGeneros", view);
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
            var generos = PegarSelectListaGenero();
            var idiomas = PegarSelectListaIdioma();

            var view = new FilmeViewModel();
            view.Generos.AddRange(generos);
            view.Idiomas.AddRange(idiomas);

            filmeTemp = view;

            return View(view);
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
                    Descricao = view.Descricao,
                    Generos = new List<Genero>(),
                    Idiomas = new List<Idioma>()
                };

                if (filmeTemp.ListaGeneros.Any())
                {
                    foreach (var item in filmeTemp.ListaGeneros)
                    {
                        var genero = new Genero { GeneroId = item.GeneroId, Descricao = item.Descricao };
                        filme.Generos.Add(genero);
                    }
                }

                if (filmeTemp.ListaIdiomas.Any())
                {
                    foreach (var item in filmeTemp.ListaIdiomas)
                    {
                        var idioma = new Idioma { IdiomaId = item.IdiomaId, Descricao = item.Descricao };
                        filme.Idiomas.Add(idioma);
                    }
                }

                _filmeBLO.Salvar(filme);
                retorno.Mensagem
                    = string.Format("Filme {0} - {1} Cadastrado com Sucesso. <br />", view.FilmeId, view.Descricao);
                retorno.TipoMensagem = TipoMensagem.Sucesso;
                retorno.Resultado = true;
            }
            catch (ProjetoException ex)
            {
                retorno.Mensagem = ex.Message;
                retorno.TipoMensagem = TipoMensagem.Alerta;
                retorno.Resultado = false;
            }
            catch (Exception ex)
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

            var generos = PegarSelectListaGenero();
            var idiomas = PegarSelectListaIdioma();

            var view = new FilmeViewModel(filme);
            view.Generos.AddRange(generos);
            view.Idiomas.AddRange(idiomas);

            filmeTemp = view;

            if (filme.Generos != null)
            {
                var listaGeneros = filme.Generos.Select(x => new GeneroViewModel(x));

                view.ListaGeneros.AddRange(listaGeneros);
            }

            if (filme.Idiomas != null)
            {
                var listaIdiomas = filme.Idiomas.Select(x => new IdiomaViewModel(x));

                view.ListaIdiomas.AddRange(listaIdiomas);
            }

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
                    Descricao = view.Descricao,
                    Generos = new List<Genero>(),
                    Idiomas = new List<Idioma>()
                };

                if (filmeTemp.ListaGeneros.Any())
                {
                    foreach (var item in filmeTemp.ListaGeneros)
                    {
                        var genero = new Genero { GeneroId = item.GeneroId, Descricao = item.Descricao };
                        filme.Generos.Add(genero);
                    }
                }

                if (filmeTemp.ListaIdiomas.Any())
                {
                    foreach (var item in filmeTemp.ListaIdiomas)
                    {
                        var idioma = new Idioma { IdiomaId = item.IdiomaId, Descricao = item.Descricao };
                        filme.Idiomas.Add(idioma);
                    }
                }

                _filmeBLO.Editar(filme);

                retorno.Mensagem
                    = string.Format("Filme {0} - {1} Editado com Sucesso. <br />", view.FilmeId, view.Descricao);
                retorno.TipoMensagem = TipoMensagem.Sucesso;
                retorno.Resultado = true;
            }
            catch (ProjetoException ex)
            {
                retorno.Mensagem = ex.Message;
                retorno.TipoMensagem = TipoMensagem.Alerta;
                retorno.Resultado = false;
            }
            catch (Exception ex)
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
                    = string.Format("Filme {0} - {1} Excluido com Sucesso. <br />",
                        filmeMensagem.FilmeId, filmeMensagem.Descricao);
                retorno.TipoMensagem = TipoMensagem.Sucesso;
                retorno.Resultado = true;
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
        /// Carrega SelectList de Generos.
        /// </summary>
        /// <returns>Retorna Item Selecionado.</returns>
        private List<SelectListItem> PegarSelectListaGenero()
        {
            var itens = new List<SelectListItem>();
            var generos = _generoBLO.Listar();

            if (generos != null)
            {
                var selectList = generos.Select(x => new SelectListItem
                { Text = x.Descricao, Value = x.GeneroId.ToString() }).ToList();

                itens.AddRange(selectList);
            }
            return itens;
        }

        /// <summary>
        /// Carrega SelectList de Idiomas.
        /// </summary>
        /// <returns>Retorna Item Selecionado.</returns>
        private List<SelectListItem> PegarSelectListaIdioma()
        {
            var itens = new List<SelectListItem>();
            var idiomas = _idiomaBLO.Listar();

            if (idiomas != null)
            {
                var selectList = idiomas.Select(x => new SelectListItem
                { Text = x.Descricao, Value = x.IdiomaId.ToString() }).ToList();

                itens.AddRange(selectList);
            }
            return itens;
        }
    }
}