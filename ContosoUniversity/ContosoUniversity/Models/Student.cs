using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public class Student
    {
        public int ID { get; set; }

        [Display(Name ="姓名")]
        public string Name { get; set; }

        [Display(Name = "注册日期")]
        public DateTime EnrollmentDate { get; set; }
        
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}