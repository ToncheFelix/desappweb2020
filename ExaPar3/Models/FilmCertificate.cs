using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DVDCollection.Models
{
    public class FilmCertificate{
        [Key]
        public int CertificateID {get; set;}
        [Required]
        [StringLength(50)]
        [Display(Name="Certificate")]
        public string Certificate {get; set;}

        public ICollection<FilmTitle> FilmTitles {get; set;}

    }

}