using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolConsoleApplication.Models;
using System.Data.Entity;

namespace SchoolConsoleApplication.DataAccessLayer
{
    public class Context:DbContext
    {
        public DbSet<StudentClass> StudentClasss { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
