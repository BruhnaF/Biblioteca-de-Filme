using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBibliotecaDeFilme.Model
{
    public class Idioma
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MaxLength(9)]
        public string IdiomaId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Descricao { get; set; }
    }
}
