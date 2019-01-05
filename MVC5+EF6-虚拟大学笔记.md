# MVC5+EF6-虚拟大学笔记
## 1.HTML辅助器
1. **Html.ActionLink**（超链接文本，行为，控制器，路由值，HTML属性值）
```
@Html.ActionLink("柳州职业技术学院", "Index", "Home", new { area = "" }, new { @class = "navbar-brand" })
```
```
<a class="navbar-brand" href="/">应用程序名称</a>
```
&nbsp;  
2. **Html.ActionLink**（超链接文本，行为，控制器）
```
@Html.ActionLink("学生", "Index", "Student")
```
&nbsp;  
3. **Html.DisplayNameFor**显示实体属性名
```
@Html.DisplayNameFor(model => model.Name)
```
等价于
```
@item.Name
```
&nbsp;  
4. **Html.BeginForm**将 <form> 开始标记写入响应。表单使用 POST 方法，并由视图的操作方法处理请求。  
```
@using (Html.BeginForm())
{
    <p>
        根据姓名查找: @Html.TextBox("SearchString")
        <input type="submit" value="搜索" />
    </p>
}
```


5. **@Html.ValidationSummary() @Html.ValidationMessageFor()** 校验
```
@Html.ValidationSummary(true, "", new { @class = "text-danger" })
```
```
@Html.ValidationMessageFor(model => model.Name, "", new { @class = "text-danger" })
```
为由指定表达式表示的每个数据字段的验证错误消息返回对应的 HTML 标记


6. **@Html.EditorFor()** 返回一个由表达式表示的对象中的每个属性所对应的input元素,主要是针对强类型,一般这种方式用得多些
```
@Html.EditorFor(model => model.EnrollmentDate, new { htmlAttributes = new { @class = "form-control" } })
```


7. **@Html.LabelFor**返回一个 HTML label元素以及由指定表达式表示的属性的属性名称。
```
@Html.LabelFor(model => model.Name, htmlAttributes: new { @class = "control-label col-md-2" })
```

## 2.模型N-M关系
转换为两个1-N关系  
1-N关系 学生和注册记录之间是1：N关系。1个学生可以有多个注册记录  
1-N关系 课程和注册记录之间是1：N关系。1门课程可以有多个注册记录
##### Model中使用导航属性来表现1-N关系
```
public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }       
        public DateTime EnrollmentDate { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }  //注意
    }
```
```
public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }

        public virtual Course Course { get; set; }  //注意
        public virtual Student Student { get; set; }  //注意
    }
```
```
public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }  //注意
    }
```
## 3.数据特性
#### 取消数据库主键自增长特性，改为用户自己为记录赋予ID
```
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;  //注意
namespace ContosoUniversity.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]  //注意
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
```


#### 安全警告-ValidateAntiForgeryToken特性用来防止跨站点请求伪造攻击。它需要相应Html.AntiForgeryToken()语句在视图中。
```
[HttpPost]
[ValidateAntiForgeryToken]  //注意
public ActionResult Create([Bind(Include = "Name, EnrollmentDate")]Student student)   // Bind属性是一种用来防止过度发布的方法。
{
    语句块
}
```
```
@using (Html.BeginForm()) 
{
    @Html.AntiForgeryToken()  @*注意*@
    
    其他html元素
}
```
数据特性具体参考—MVC高级编程第5章数据注解和验证
## 4.seed数据库初始化
### （1）重写seed方法
```
public class SchoolInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            //构建学生数据          
            //将学生数据加入实体集，保存实体集状态
           
            //构建课程数据           
            //将课程数据加入实体集，保存实体集状态            

            //构建注册数据            
            //将注册数据加入实体集，保存实体集状态
         }
｝
```
### （2）设置web.config
```
<entityFramework>
  <contexts>
    <context type="ContosoUniversity.DAL.SchoolContext, ContosoUniversity">
      <databaseInitializer type="ContosoUniversity.DAL.SchoolInitializer, ContosoUniversity" />
    </context>
  </contexts>
 </entityFramework>
```
## 5.对象初始化
```
new 类型名｛属性1=值1，属性2=值2…｝
```
## 6.集合初始化
```
new List<类型>{
对象1，
对象2，
…
}
```
