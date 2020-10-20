using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public class Student
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
        public DateTime EnrollmentDate { get; set; }
        
        [NotMapped] //Existe en el modelo pero no en la base de datos
        public string FullName => LastName + ", " + FirstMidName;
        public ICollection<Enrollment> Enrollments {get; set;}
    }

}