using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ContosoUniversity.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID {get; set;}
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        
        [DataType(DataType.Currency)]
        [Column(TypeName = "Money")]
        public decimal Budget { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        public int InstructorID {get; set;} 

        public Instructor Administrator {get; set;}
        //Relación uno a muchos
        public ICollection<Course> Courses { get; set; }
    }

}