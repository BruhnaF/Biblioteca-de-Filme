using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBibliotecaDeFilme.Model
{
    public class Genero
    {
        public Genero()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MaxLength(9)]
        public string GeneroId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Descricao { get; set; }

        public virtual List<Filme> Filmes { get; set; }

    }
}
