using System;
using System.ComponentModel.DataAnnotations;

namespace DVDCollection.Models
{
    public class FilmsActorRol{
        public int FilmTitleID {get; set;}
        public int ActorID {get; set;}
        public int RoleTypeID {get; set;}
        
        [Required]
        [StringLength(50)]
        [Display(Name="Character Name")]
        public string CharacterName {get; set;}
        
        [Required]
        [StringLength(150)]
        [Display(Name="Description")]
        public string CharacterDescription {get; set;}

        public Actor Actor {get; set;}
        public RoleType RoleType {get; set;}
        public FilmTitle FilmTitle {get; set;}
    }
}