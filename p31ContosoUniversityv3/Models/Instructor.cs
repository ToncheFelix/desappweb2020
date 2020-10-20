using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Instructor
    {
        [Key]
        public int ID {get; set;}
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [Required]
        [StringLength(50)]
        [Column("FirstName")]
        [Display(Name = "Firts Name")]
        public string FirstMidName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }

        [NotMapped] //Existe en el modelo pero no en la base de datos
        public string FullName => LastName + ", " + FirstMidName;
        
        //Relación uno a muchos
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
        //Relación uno a uno
        public OfficeAssignment officeAssignment {get; set;}
    }

}