using System.Collections.Generic;
using System.ComponentModel;

namespace ProjetoWebBibliotecaDeFilme.ViewModel
{
    /// <summary>
    /// Representa tela Index Idioma Cadastrados.
    /// </summary>
    public class IdiomaIndexViewModel
    {
        public IdiomaIndexViewModel()
        {
            Itens = new List<Idioma_Item_TabelaViewModel>();
        }

        /// <summary>
        /// Representa o campo de busca da pagina.
        /// </summary>
        [DisplayName("Nome do Idioma")]
        public string NomeIdioma { get; set; }

        /// <summary>
        /// Representa uma lista de Idiomas
        /// </summary>
        public List<Idioma_Item_TabelaViewModel> Itens { get; set; }
    }
}