using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DVDCollection.Models
{
    public class Producer{
        [Key]
        public int ProducerID {get; set;}
        [Required]
        [StringLength(50)]
        [Display(Name="Producer Name")]
        public string ProducerName {get; set;}
        [Required]
        [StringLength(50)]
        [Display(Name="Contact Email")]
        public string ContactEmailAddress {get; set;}
        [Required]
        [StringLength(50)]
        [Display(Name="Website")]
        public string Website {get; set;}

        public ICollection<FilmTitlesProducer> FilmTitlesProducers {get; set;}

    }
}