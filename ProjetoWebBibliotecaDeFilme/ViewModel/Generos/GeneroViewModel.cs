using ProjetoBibliotecaDeFilme.Model;
using System.ComponentModel;

namespace ProjetoWebBibliotecaDeFilme.ViewModel.Generos
{
    public class GeneroViewModel
    {
        /// <summary>
        /// Construtor Padrão.
        /// </summary>
        public GeneroViewModel()
        {

        }

        /// <summary>
        /// Construtor Recebendo o Genero
        /// </summary>
        /// <param name="genero"></param>
        public GeneroViewModel(Genero genero)
        {
            this.GeneroId = genero.GeneroId;
            this.Descricao = genero.Descricao;
        }

        /// <summary>
        /// Representa o GeneroId
        /// </summary>
        [DisplayName("Código do Genero")]
        public string GeneroId { get; set; }

        /// <summary>
        /// Representa a Descrição
        /// </summary>
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
    }
}