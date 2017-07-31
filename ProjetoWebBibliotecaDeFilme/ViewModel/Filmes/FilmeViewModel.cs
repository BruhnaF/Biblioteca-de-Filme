using ProjetoBibliotecaDeFilme.Model;
using System.ComponentModel;

namespace ProjetoWebBibliotecaDeFilme.ViewModel.Filmes
{
    public class FilmeViewModel
    {
        /// <summary>
        /// Construtor Padrão.
        /// </summary>
        public FilmeViewModel()
        {

        }

        /// <summary>
        /// Construtor Recebendo Filme.
        /// </summary>
        /// <param name="filme"></param>
        public FilmeViewModel(Filme filme)
        {
            this.FilmeId = filme.FilmeId;
            this.Descricao = filme.Descricao;
        }

        /// <summary>
        /// Representa FilmeId
        /// </summary>
        [DisplayName("Código do Filme")]
        public string FilmeId { get; set; }

        /// <summary>
        /// Representa Descrição
        /// </summary>
        [DisplayName("Descrição do Filme")]
        public string Descricao { get; set; }
    }
}