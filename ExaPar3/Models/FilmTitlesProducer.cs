using System;
using System.ComponentModel.DataAnnotations;

namespace DVDCollection.Models
{
    public class FilmTitlesProducer{

        public int ProducerID {get; set;}
        public int FilmTitleID {get; set;}

        public Producer Producer {get; set;}
        public FilmTitle FilmTitle {get; set;}
    }

}