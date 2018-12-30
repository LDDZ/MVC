using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstNewDatabaseSample.Models;
using CodeFirstNewDatabaseSample.BusinessLayer;
using CodeFirstNewDatabaseSample.DataAccessLayer;
//正则表达式,所需引用
using System.Text.RegularExpressions;

namespace CodeFirstNewDatabaseSample
{
    class Program
    {
        static void Main()
        {
            //QueryPostForName();
            QueryPostForTitle();
            Console.ReadKey();
            //while (true)
            //{
            //    Console.Clear();
            //    OpBlog();
            //}
        }
        static void QueryPostForName()
        {
            Console.WriteLine("请输入将要查找的博客名称");
            string name = Console.ReadLine();
            BlogBusinessLayer pbl = new BusinessLayer.BlogBusinessLayer();
            var query = pbl.QueryForName(name);
            foreach (var item in query)
            {
                Console.WriteLine(item.BlogId + "  " + item.Name);
            }

        }
        static void QueryPostForTitle()
        {
            Console.WriteLine("请输入将要查找的帖子标题");
            string title = Console.ReadLine();
            PostBusinessLayer pbl = new BusinessLayer.PostBusinessLayer();
            var query= pbl.QueryForTitle(title);
            foreach (var item in query)
            {
                Console.WriteLine(item.Title + "  " + item.Content);
            }

        }

        /// <summary>
        /// 操作博客
        /// </summary>
        static void OpBlog()
        {
            //显示博客列表
            QueryBlog();
            Console.WriteLine("1--退出  2--新增博客  3--删除博客  4--更新博客  5--操作帖子");
            //定义变量op记录用户输入的操作符
            string op = Console.ReadLine();

            // 检测用户输入的操作符是否规范,并将符合规范的操作符返回后重新赋值
            op=OpBlogOperatorDetection(op);
            switch (op)
            {
                case "1":
                    Environment.Exit(0);
                    break;
                case "2":
                    CrateBlog();
                    break;
                case "3":
                    Delete();
                    break;
                case "4":
                    Update();
                    break;
                case "5":
                    //用户选择某个博客（id）
                    Console.WriteLine("请选择博客ID");
                    //获取输入并检测输入的博客ID是否为正整数
                    string idStr = PositiveWholeNumberDetection();
                    int id = int.Parse(idStr);
                    //检测博客ID是否存在
                    id = BlogIdDetection(idStr, id);
                    while (true)
                    {
                        OpPost(id);
                    }
                    break;
            }
        }

        /// <summary>
        /// 操作帖子
        /// </summary>
        static void OpPost(int blogId)
        {

            Console.Clear();
            //显示指定博客的帖子列表
            DisplayPosts(blogId);
            List<Post> list = null;
            using (var db = new BloggingContext())
            {
                Blog blog = db.Blogs.Find(blogId);
                //根据博客导航属性，获取所有该博客的帖子
                list = blog.Posts.ToList();
            }
            //Count = 0
            if (list.Count() == 0)
            {
                Console.WriteLine("1--返回上一层  2--新增帖子");
                string op = Console.ReadLine();
                // 检测用户输入的操作符是否规范,并将符合规范的操作符返回后重新赋值
                op = OpPostOperatorDetection1(op);
                switch (op)
                {
                    case "1":
                        Console.Clear();
                        Main();
                        break;
                    case "2":
                        AddPost(blogId);
                        Console.Clear();
                        break;
                }
            }
            else
            {
                Console.WriteLine("1--返回上一层  2--新增帖子  3--删除帖子  4--更新帖子");
                string op = Console.ReadLine();
                // 检测用户输入的操作符是否规范,并将符合规范的操作符返回后重新赋值
                op = OpPostOperatorDetection2(op);
                switch (op)
                {
                    case "1":
                        Console.Clear();
                        Main();
                        break;
                    case "2":
                        AddPost(blogId);
                        Console.Clear();
                        break;
                    case "3":
                        DeletePost();

                        break;
                    case "4":
                        UpdatePost(blogId);
                        break;
                }
            }
        }

        /// <summary>
        /// 博客操作界面 操作符检测方法
        /// </summary>
        /// <param name="oD"></param>
        /// <param name="op"></param>
        static string OpBlogOperatorDetection(string op)
        {
            bool oD = true;
            while (oD)
            {
                if (op != "1" && op != "2" && op != "3" && op != "4" && op != "5")
                {
                    Console.WriteLine("非法操作符，请重新输入！");
                    op = Console.ReadLine();
                }
                else { oD = false; }
            }
            return op;
        }

        /// <summary>
        /// 帖子操作界面 操作符检测方法1(该ID下没有帖子)
        /// </summary>
        /// <param name="oD"></param>
        /// <param name="op"></param>
        static string OpPostOperatorDetection1( string op)
        {
            bool oD = true;
            while (oD)
            {
                if (op != "1" && op != "2")
                {
                    Console.WriteLine("非法操作符，请重新输入！");
                    op = Console.ReadLine();
                }
                else { oD = false; }
            }
            return op;
        }

        /// <summary>
        /// 帖子操作界面 操作符检测方法2(该ID下拥有帖子)
        /// </summary>
        /// <param name="op"></param>
        static string OpPostOperatorDetection2(string op)
        {
            bool oD = true;
            while (oD)
            {
                if (op != "1" && op != "2" && op != "3" && op != "4")
                {
                    Console.WriteLine("非法操作符，请重新输入！");
                    op = Console.ReadLine();
                }
                else { oD = false; }
            }
            return op;
        }

        /// <summary>
        /// 添加帖子
        /// </summary>
        static void AddPost(int blogId)
        {
            //根据指定到博客信息创建新帖子 
            Post post = new Post();
            Console.WriteLine("请输入将要添加的帖子标题");
            post.Title = Console.ReadLine();
            Console.WriteLine("请输入将要添加的帖子内容");
            post.Content = Console.ReadLine();
            post.BlogId = blogId;
            PostBusinessLayer pbl = new PostBusinessLayer();
            pbl.Add(post);
            //显示指定博客的帖子列表
            DisplayPosts(blogId);
        }

        /// <summary>
        /// 修改帖子
        /// </summary>
        static void UpdatePost(int blogId)
        {
            Console.WriteLine("请输入将要更改的帖子id");
            //获取输入并检测输入的帖子ID是否为正整数
            string idStr = PositiveWholeNumberDetection();
            int id = int.Parse(idStr);
            //检测帖子ID是否存在
            id = PostIdDetection(idStr, id);

            PostBusinessLayer pbl = new PostBusinessLayer();
            Post post = pbl.QueryPost(id);
            Console.WriteLine("请输入新标题");
            string title = Console.ReadLine();
            Console.WriteLine("请输入新内容");
            string content = Console.ReadLine();
            post.Title = title;
            post.Content = content;
            pbl.Update(post);
        }

        /// <summary>
        /// 根据ID删除帖子
        /// </summary>
        static void DeletePost()
        {
            Console.WriteLine("请输入将要删除的帖子ID");
            //获取输入并检测输入的帖子ID是否为正整数
            string idStr = PositiveWholeNumberDetection();
            int id = int.Parse(idStr);
            //检测帖子ID是否存在
            id = PostIdDetection(idStr, id);
            PostBusinessLayer pbl = new BusinessLayer.PostBusinessLayer();
            Post post = pbl.QueryPost(id);
            pbl.Delete(post);
        }

        /// <summary>
        /// 检测帖子ID是否存在
        /// </summary>
        /// <param name="idStr"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        static int PostIdDetection(string idStr,int id)
        {
            PostBusinessLayer pbl = new BusinessLayer.PostBusinessLayer();
            bool idDetection = true;
            while (idDetection)
            {
                if (pbl.QueryPost(id) == null)
                {
                    Console.WriteLine("没有该帖子ID,请重新输入!");
                    idStr = PositiveWholeNumberDetection();
                    id = int.Parse(idStr);
                }
                else { idDetection = false; }
            }
            return id;
        }

        /// <summary>
        /// 检测博客ID是否存在
        /// </summary>
        /// <returns></returns>
        static int BlogIdDetection(string idStr, int id)
        {
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            bool idDetection = true;
            while (idDetection)
            {
                if (bbl.Query(id) == null)
                {
                    Console.WriteLine("没有该博客ID,请重新输入!");
                    idStr = PositiveWholeNumberDetection();
                    id = int.Parse(idStr);
                }
                else
                {
                    idDetection = false;
                }
            }
            return id;
        }

        /// <summary>
        /// 检测控制台输入的ID是否为正整数
        /// </summary>
        /// <returns></returns>
        static string PositiveWholeNumberDetection()
        {
            string idStr = Console.ReadLine();
            bool idError = true;
            while (idError)
            {
                //Regex 类表示不可变（只读）的正则表达式。
                //指示 Regex 构造函数中指定的正则表达式在指定的输入字符串中是否找到了匹配项。
                if (!Regex.IsMatch(idStr, @"^\+?[1-9][0-9]*$"))
                {
                    Console.WriteLine("非法ID,请重新输入!");
                    idStr = Console.ReadLine();
                }
                else
                {
                    idError = false;
                }
            }
            return idStr;
        }

        /// <summary>
        /// 显示某个博客下的所有帖子(第一种方法，比较旧的方式)
        /// </summary>
        /// <param name="blogId">博客ID</param>
        //static void DisplayPosts(int blogId)
        //{
        //    Console.WriteLine("{0}的帖子列表", blogId);
        //    //根据博客ID获取博客
        //    BlogBusinessLayer bbl = new BusinessLayer.BlogBusinessLayer();
        //    Blog blog = bbl.Query(blogId);
        //    //根据博客导航属性，获取所有该博客的帖子
        //    PostBusinessLayer pbl = new PostBusinessLayer();
        //    List<Post> postList = pbl.Query(blogId);
        //    //遍历所有帖子，显示帖子标题（博客号-帖子标题）
        //    foreach (var item in postList)
        //    {
        //        Console.WriteLine("博客号:{0}---帖子标题:{1}", item.BlogId, item.Title);
        //    }
        //}

        /// <summary>
        /// 显示某个博客下的所有帖子(第二种方法，现在流行的方式)
        /// </summary>
        /// <param name="blogId">博客ID</param>
        static void DisplayPosts(int blogId)
        {
            Console.WriteLine("{0}的帖子列表", blogId);
            List<Post> list = null;
            //根据博客ID获取博客
            using (var db = new BloggingContext())
            {
                Blog blog = db.Blogs.Find(blogId);
                //根据博客导航属性，获取所有该博客的帖子
                list = blog.Posts.ToList();
            }
            //遍历所有帖子，显示帖子标题（博客号-帖子标题）
            foreach (var item in list)
            {
                Console.WriteLine("帖子ID：{0}  帖子标题:{1}  内容：{2}", item.PostId, item.Title, item.Content);
            }
        }
    
        /// <summary>
        /// 创建一个博客
        /// </summary>
        static void CrateBlog()
        {
            Console.WriteLine("请输入将要添加的博客用户名称");
            string name = Console.ReadLine();
            Blog blog = new Models.Blog();
            blog.Name = name;
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            bbl.Add(blog);
        }

        /// <summary>
        /// 显示所有博客
        /// </summary>
        static void QueryBlog()
        {
            BlogBusinessLayer bbl = new BusinessLayer.BlogBusinessLayer();
            var query = bbl.Query();
            Console.WriteLine("所有数据库中的博客：");
            foreach (var item in query)
            {
                Console.WriteLine("ID:" + item.BlogId + " Name:" + item.Name);
            }
        }

        /// <summary>
        /// 更改一个博客的名称
        /// </summary>
        static void Update()
        {
            Console.WriteLine("请输入将要更改的博客id");
            //获取输入并检测输入的博客ID是否为正整数
            string idStr = PositiveWholeNumberDetection();
            int id = int.Parse(idStr);
            //检测博客ID是否存在
            id = BlogIdDetection(idStr, id);
            BlogBusinessLayer bbl = new BusinessLayer.BlogBusinessLayer();
            Blog blog = bbl.Query(id);
            Console.WriteLine("请输入新名字");
            string name = Console.ReadLine();
            blog.Name = name;
            bbl.Update(blog);
        }

        /// <summary>
        /// 删除一个博客
        /// </summary>
        static void Delete()
        {
            Console.WriteLine("请输入将要删除的博客ID");
            //获取输入并检测输入的博客ID是否为正整数
            string idStr = PositiveWholeNumberDetection();
            int id = int.Parse(idStr);
            //检测博客ID是否存在
            id = BlogIdDetection(idStr, id);
            BlogBusinessLayer bbl = new BusinessLayer.BlogBusinessLayer();
            Blog blog = bbl.Query(id);
            bbl.Delete(blog);
        }
    }
}
