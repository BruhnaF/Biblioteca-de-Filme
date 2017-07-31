﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBibliotecaDeFilme.Model
{
    public class Filme
    {
        public Filme()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MaxLength(9)]
        public string FilmeId  { get; set; }

        [Required]
        [MaxLength(50)]
        public string Descricao { get; set; }
    }
}