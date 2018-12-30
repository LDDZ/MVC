using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstNewDatabaseSample.Models;
using CodeFirstNewDatabaseSample.DataAccessLayer;
using System.Data.Entity;

namespace CodeFirstNewDatabaseSample.BusinessLayer
{
    public class BlogBusinessLayer
    {
        public void Add(Blog blog)
        {
            //设置上下文生存期
            using (var db=new BloggingContext())
            {
                //向上下文Blogs数据集添加一个实体（改变实体状态为添加）
                //db.Blogs.Add(blog);

                // 或者将实体状态改为添加
                db.Entry(blog).State = EntityState.Added;

                //保存状态改变
                db.SaveChanges();
            }
        }
        public List<Blog > Query()
        {
            using (var db=new BloggingContext())
            {
                // Linq查询所有的博客，以博客名为排序依据返回数据集
                var query = from b in db.Blogs
                            orderby b.Name
                            select b;
                // 将数据转换为列表
                return query.ToList();
            }
        }
        public Blog Query(int id)
        {
            //设置上下文生存期
            using (var db = new BloggingContext())
            {
                return db.Blogs.Find(id);
            }
        }
        public void Update(Blog blog)
        {
            //设置上下文生存期
            using (var db = new BloggingContext())
            {
                //改变实体状态为更新
                db.Entry(blog).State = EntityState.Modified;
                //保存状态改变
                db.SaveChanges();
            }
        }
        public void Delete(Blog blog)
        {
            // 设置上下文生存期
            using (var db = new BloggingContext())
            {
                //改变实体状态为删除
                db.Entry(blog).State = EntityState.Deleted;
                //保存状态改变
                db.SaveChanges();
            }
        }
        public List<Blog> QueryForName(string name)
        {
            using (var db = new BloggingContext())
            {
                var query = db.Blogs.Where(b => b.Name.Contains(name));
                //var query = from b in db.Blogs
                //            where b.Name.Contains(name)
                //            select b;
                return query.ToList();
            }
        }
    }
}
