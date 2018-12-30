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
    public  class PostBusinessLayer
    {
        public List<Post> Query(int blogId)
        {
            using (var db = new BloggingContext())
            {
                var query = from b in db.Posts
                            where b.BlogId== blogId
                            select b;
                // 将数据转换为列表
                return query.ToList();
            }
        }
        public void Add(Post post)
        {
            //设置上下文生存期
            using (var db = new BloggingContext())
            {

                // 或者将实体状态改为添加
                db.Entry(post).State = EntityState.Added;

                //保存状态改变
                db.SaveChanges();
            }
        }
        public Post QueryPost(int id)
        {
            //设置上下文生存期
            using (var db = new BloggingContext())
            {
                return db.Posts.Find(id);
            }
        }
        public void Update(Post post)
        {
            //设置上下文生存期
            using (var db = new BloggingContext())
            {
                //改变实体状态为更新
                db.Entry(post).State = EntityState.Modified;
                //保存状态改变
                db.SaveChanges();
            }
        }
        public void Delete(Post post)
        {
            // 设置上下文生存期
            using (var db = new BloggingContext())
            {
                //改变实体状态为删除
                db.Entry(post).State = EntityState.Deleted;
                //保存状态改变
                db.SaveChanges();
            }
        }
        public List<Post> QueryForTitle(string title)
        {
            using (var db = new BloggingContext())
            {
                var query = db.Posts.Where(p => p.Title.Contains(title));
                return query.ToList();
            }
        }
    }
}
