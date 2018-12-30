using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolConsoleApplication.Models;
using SchoolConsoleApplication.DataAccessLayer;
using System.Data.Entity;

namespace SchoolConsoleApplication.BusinessLayer
{
    public  class SchoolBusinessLayer
    {
        public void AddStudentClass(StudentClass studentClass)
        {
            //设置上下文生存期
            using (var db = new Context())
            {
                // 或者将实体状态改为添加
                db.Entry(studentClass).State = EntityState.Added;

                //保存状态改变
                db.SaveChanges();
            }
        }
        public List<StudentClass> QueryStudentClass()
        {
            using (var db = new Context())
            {
                // Linq查询
                var query = from b in db.StudentClasss
                            orderby b.StudentClassName
                            select b;
                // 将数据转换为列表
                return query.ToList();
            }
        }
        public StudentClass QueryStudentClass(int id)
        {
            //设置上下文生存期
            using (var db = new Context())
            {
                return db.StudentClasss.Find(id);
            }
        }
        public void UpdateStudentClass(StudentClass studentClass)
        {
            //设置上下文生存期
            using (var db = new Context())
            {
                // 或者将实体状态改为添加
                db.Entry(studentClass).State = EntityState.Modified;

                //保存状态改变
                db.SaveChanges();
            }
        }
        public void DeleteStudentClass(StudentClass studentClass)
        {
            // 设置上下文生存期
            using (var db = new Context())
            {
                //改变实体状态为删除
                db.Entry(studentClass).State = EntityState.Deleted;
                //保存状态改变
                db.SaveChanges();
            }
        }
    }
}
