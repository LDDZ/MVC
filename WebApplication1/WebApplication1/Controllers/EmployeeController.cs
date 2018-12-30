using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.ViewModels;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeListViewModel empListModel = new EmployeeListViewModel();
            //获取将处理过的数据列表
            empListModel.EmployeeViewList =getEmpVmList();
            // 获取问候语
            empListModel.Greeting = getGreeting();
            //获取用户名
            empListModel.UserName = getUserName();
            //将数据送往视图
            return View(empListModel);
        }

        public ActionResult CreateEmployee() {
            return View();
        }

        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateEmployee(Employee emp)
        {
            EmployeeBusinessLayer ebl = new EmployeeBusinessLayer();
            ebl.Add(emp);
            //return new RedirectResult("index");
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            EmployeeBusinessLayer ebl = new Models.EmployeeBusinessLayer();
            Employee emp= ebl.Query(id);
            ebl.Delete(emp);

            return RedirectToAction("Index");
        }

        public ActionResult UpdateEmployee(int id)
        {
            EmployeeBusinessLayer ebl = new Models.EmployeeBusinessLayer();
            Employee emp = ebl.Query(id);
            return View(emp);
        }

        [HttpPost]
        public ActionResult UpdateEmployee(Employee emp)
        {
            EmployeeBusinessLayer ebl = new EmployeeBusinessLayer();
            ebl.Update(emp);
            return RedirectToAction("Index");
        }

        public ActionResult QueryEmployeeForName(string queryString)
        {
            EmployeeListViewModel elvm = new ViewModels.EmployeeListViewModel();
            EmployeeBusinessLayer ebl = new EmployeeBusinessLayer();
            // 查询到的员工原始数据
            var listEmp = ebl.QueryForName(queryString);
            //视图数据列表(用于储存[加工后]的员工原始数据)，当前状态是空的
            var listEmpVm = new List<EmployeeViewModel>();

            foreach (var emp in listEmp)
            {
                listEmpVm.Add(ConvertToViewModel(emp));
            }
            elvm.EmployeeViewList = listEmpVm;

            // 获取问候语
            elvm.Greeting = getGreeting();
            //获取用户名
            elvm.UserName = getUserName();
            return View("Index", elvm);
        }

        [NonAction]
        List<EmployeeViewModel> getEmpVmList()
        {
            //实例化员工信息业务层
            EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
            //员工原始数据列表，获取来自业务层类的数据
            var listEmp = empBL.GetEmployeeList();
            //员工原始数据加工后的视图数据列表，当前状态是空的
            var listEmpVm = new List<EmployeeViewModel>();

            foreach (var emp in listEmp)
            {
                listEmpVm.Add( ConvertToViewModel(emp));
            }

            return listEmpVm;

        }

        [NonAction]
        string getGreeting()
        {
            string greeting;
            //获取当前时间
            DateTime dt = DateTime.Now;
            //获取当前小时数
            int hour = dt.Hour;
            //根据小时数判断需要返回哪个视图，<12 返回myview 否则返回 yourview
            if (hour < 12)
            {
                greeting = "早上好";
            }
            else
            {
                greeting = "下午好";
            }
            return greeting;
        }
        
        [NonAction]
        string getUserName()
        {
            return "Admin";
        }

        public EmployeeViewModel ConvertToViewModel(Employee emp) {
            EmployeeViewModel empVmObj = new EmployeeViewModel();
            empVmObj.EmployeeId = emp.EmployeeID;
            empVmObj.EmployeeName = emp.Name;
            empVmObj.EmployeeSalary = emp.Salary.ToString("C");
            if (emp.Salary > 10000)
            {
                empVmObj.EmployeeGrade = "土豪";
            }
            else
            {
                empVmObj.EmployeeGrade = "qiong";
            }
            return empVmObj;
        }
    }
}