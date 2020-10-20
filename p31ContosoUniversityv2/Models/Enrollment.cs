using System;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public enum Grade{
        A,B,C,D,F
    }

    public class Enrollment
    {
        [Key]
        public int EnrollmentID { get; set; }
        public int CourseID     { get; set; }
        public int StudentID    { get; set; }
        
        // name? permite valor nulo
        [DisplayFormat(NullDisplayText = "No Grade")]
        public Grade? Grade      { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }


    }

}