using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace DVDCollection.Models
{
    public class Actor{
        [Key]
        public int ActorID {get; set;}
        [Required]
        [StringLength(50)]
        [Display(Name="Actor Name")]
        public string ActorFullName {get; set;}
        [Required]
        [StringLength(150)]
        [Display(Name="Notes")]
        public string ActorNotes {get; set;}

        public ICollection<FilmsActorRol> FilmsActorRoles {get; set;}

    }

}