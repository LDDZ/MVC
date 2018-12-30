using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolConsoleApplication.Models
{
    public  class StudentClass
    {
        public int StudentClassID { get; set; }
        public string StudentClassName { get; set; }
        public virtual List<Student> Students { get; set; }
    }
}
