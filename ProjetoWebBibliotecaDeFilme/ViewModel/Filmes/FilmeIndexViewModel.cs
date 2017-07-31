using System.Collections.Generic;
using System.ComponentModel;

namespace ProjetoWebBibliotecaDeFilme.ViewModel.Filmes
{
    /// <summary>
    /// Representa a Tela Index de Filmes Cadastrados
    /// </summary>
    public class FilmeIndexViewModel
    {
        /// <summary>
        /// Construtor Padrão
        /// </summary>
        public FilmeIndexViewModel()
        {
            Itens = new List<Filme_Item_TabelaViewModel>();
        }

        /// <summary>
        /// Representa a Descrição
        /// </summary>
        [DisplayName("Descrição do Filme")]
        public string Descricao { get; set; }

        /// <summary>
        /// Representa Lista de Filmes
        /// </summary>
        public List<Filme_Item_TabelaViewModel> Itens { get; set; }
    }
}