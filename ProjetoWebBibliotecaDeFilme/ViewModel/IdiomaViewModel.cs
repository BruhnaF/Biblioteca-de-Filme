using ProjetoBibliotecaDeFilme.Model;

namespace ProjetoWebBibliotecaDeFilme.ViewModel
{
    public class IdiomaViewModel
    {
        /// <summary>
        /// Construtor Padrão
        /// </summary>
        public IdiomaViewModel()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idioma"></param>
        public IdiomaViewModel(Idioma idioma)
        {
            this.IdiomaId = idioma.IdiomaId;
            this.Descricao = idioma.Descricao;
        }

        /// <summary>
        /// 
        /// </summary>
        public string IdiomaId { get; set; }
        public string Descricao { get; set; }
    }
}