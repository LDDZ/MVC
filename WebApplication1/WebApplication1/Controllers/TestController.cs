using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        public string GetString()
        {
            return "hello world! MVC";
        }
        public Phone GetPhoneInfo()
        {
            Phone phone = new Phone();
            phone.PhoneName = "MIX 2s";
            phone.PhonePrice = "2799";
            return phone;
        }
        public ActionResult GetView()
        {
            string greeting;
            int  h = 0;

            h=DateTime.Now.Hour;
            if (h < 12)
            {
                greeting = "上午好";
            }
            else
            {
                 greeting = "下午好";
            }
            //ViewData["greeting"] = greeting;
            ViewBag.greeting = greeting;
            PhoneInfo pi = new PhoneInfo();
            pi.PhoneName = "iPhone";
            pi.PhonePrice = 7999;
            // ViewData["PhoneInfo"] = pi;
            ViewBag.piKey = pi;


            PhoneViewModel vmP = new PhoneViewModel();
            vmP.PhoneName = pi.PhoneName;
            vmP.PhonePrice = pi.PhonePrice.ToString("C");
            if (pi.PhonePrice > 2299) vmP.Rank = "旗舰机";
            else vmP.Rank = "经济机";
            vmP.Greeting = greeting;
            vmP.UserName = "超级管理员";

            return View("MyView", vmP);
        }
    }
}