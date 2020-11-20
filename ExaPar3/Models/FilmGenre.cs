using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DVDCollection.Models
{
    public class FilmGenre{
        [Key]
        public int GenreID {get; set;}
        [Required]
        [StringLength(50)]
        [Display(Name="Genre")]
        public string Genre {get; set;}

        public ICollection<FilmTitle> FilmTitles {get; set;}
    }

}