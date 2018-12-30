using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolConsoleApplication.Models
{
    public  class Student
    {
        public int StudentID { get; set; }
        public string  StudentName { get; set; }
        
        //相当于数据库外键
        public int StudentClassID { get; set; }
        //导航属性
        public virtual StudentClass StudentClass { get; set; }
    }
}
