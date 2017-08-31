using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBibliotecaDeFilme.Model
{
    public class Filme
    {
        public Filme()
        {

        }

        [Key]        
        public int FilmeId  { get; set; }

        [Required]
        [MaxLength(50)]
        public string Descricao { get; set; }

        public virtual List<Genero> Generos { get; set; }
        public virtual List<Idioma> Idiomas { get; set; }

    }
}
