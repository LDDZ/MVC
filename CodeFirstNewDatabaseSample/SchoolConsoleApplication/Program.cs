using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolConsoleApplication.Models;
using SchoolConsoleApplication.BusinessLayer;

namespace SchoolConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            AddStudentClass();
            QueryStudentClass();
            Console.WriteLine("-------------");
            UpdateStudentClass();
            QueryStudentClass();
            Console.WriteLine("-------------");
            DeleteStudentClass();
            QueryStudentClass();
            Console.WriteLine("按任意键退出");
            Console.ReadKey();
        }
        static void AddStudentClass()
        {
            Console.WriteLine("请输入一个新班级名");
            string studentClassName = Console.ReadLine();
            StudentClass studentClass = new StudentClass();
            studentClass.StudentClassName = studentClassName;
            SchoolBusinessLayer sbl = new SchoolBusinessLayer();
            sbl.AddStudentClass(studentClass);
        }
        static void QueryStudentClass()
        {
            SchoolBusinessLayer sbl = new SchoolBusinessLayer();
            var query = sbl.QueryStudentClass();
            Console.WriteLine("所有数据库中的班级：");
            foreach (var item in query)
            {
                Console.WriteLine("班级ID:" + item.StudentClassID + " 班级名:" + item.StudentClassName);
            }
        }
        static void UpdateStudentClass()
        {
            Console.WriteLine("请输入将要更改的班级id");
            int id = int.Parse(Console.ReadLine());
            SchoolBusinessLayer sbl = new SchoolBusinessLayer();
            StudentClass studentClass = sbl.QueryStudentClass(id);
            Console.WriteLine("请输入新班级名");
            string name = Console.ReadLine();
            studentClass.StudentClassName = name;
            sbl.UpdateStudentClass(studentClass);
        }
        static void DeleteStudentClass()
        {
            Console.WriteLine("请输入将要删除的班级ID");
            int id = int.Parse(Console.ReadLine());
            SchoolBusinessLayer sbl = new SchoolBusinessLayer();
            StudentClass studentClass = sbl.QueryStudentClass(id);
            sbl.DeleteStudentClass(studentClass);
        }
    }
}
