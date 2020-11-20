using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DVDCollection.Models
{
    public class RoleType{
        [Key]
        public int RoleTypeID {get; set;}
        [Required]
        [StringLength(50)]
        [Display(Name="Role Type")]
        public string RoleTypes {get; set;}

        public ICollection<FilmsActorRol> FilmsActorRols {get; set;}

    }
}