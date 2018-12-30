using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.DataAccessLayer;


namespace WebApplication1.Models
{
    public class EmployeeBusinessLayer
    {
        public void Add(Employee emp)
        {
            using (SalesERPDAL dal = new SalesERPDAL())
            {
                // 将实体状态改为添加
                dal.Entry(emp).State = EntityState.Added;

                //保存状态改变
                dal.SaveChanges();
            }
        }
        public List<Employee> GetEmployeeList()
        {
            using (SalesERPDAL dal = new SalesERPDAL())
            {
              
                var list = dal.Employees.ToList();
                return list;
            }   
        }
        public List<Employee> QueryForName(string name)
        {
            using (var dal = new SalesERPDAL())
            {
                var query = dal.Employees.Where(e => e.Name.Contains(name));
                return query.ToList();
            }
        }
        public Employee Query(int id)
        {
            using (var dal = new SalesERPDAL())
            {
                return dal.Employees.Find(id);
            }
        }
        public void Delete(Employee emp)
        {
            using(var dal=new SalesERPDAL())
            {
                dal.Entry(emp).State = EntityState.Deleted;
                dal.SaveChanges();
            }
        }
        public void Update(Employee emp)
        {
            using (var dal = new SalesERPDAL())
            {
                dal.Entry(emp).State = EntityState.Modified;
                dal.SaveChanges();
            }
        }
    }
}