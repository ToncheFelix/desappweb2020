using System;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public class OfficeAssignment {
        [Key]
        public int InstrucorID {get; set;}
        [StringLength(50)]
        [Display(Name = "Office Location ")]
        public string Location {get; set;}
    
        //Relación uno a uno
        public Instructor Instructor {get; set;}
    }
}