using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVDCollection.Models
{
    public class FilmTitle{
        [Key]
        public int FilmTitleID {get; set;}
        
        [Required]
        [StringLength(50)]
        [Display(Name="Film Titles")]
        public string FilmTitles {get; set;}
        
        [Required]
        [StringLength(150)]
        [Display(Name="Film Story")]
        public string FilmStory {get; set;}

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name="Release Date")]
        public DateTime FilmReleaseDate {get; set;}
        
        [Required]
        [Display(Name="Film Duration")]
        [Range(1, 350)]
        public int FilmDuration {get; set;}
        
        public int GenreID {get; set;}
        public int CertificateID {get; set;}
        
        [Required]
        [StringLength(100)]
        [Display(Name="Additional Info")]
        public string FilmAdditionalInfo {get; set;}


        public ICollection<FilmTitlesProducer> FilmTitlesProducers {get; set;}
        public ICollection<FilmsActorRol> FilmsActorRols {get; set;}

        public FilmGenre FilmGenre {get; set;}
        public FilmCertificate FilmCertificate {get; set;}
    }

}