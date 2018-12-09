using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class AllInfoController : Controller
    {
        // GET: AllInfo
        public ActionResult Index()
        {
            PhoneInfo pi = new PhoneInfo();
            pi.PhoneName = "mi 2s";
            pi.PhonePrice =1099;

            BuyerInfo bA = new Models.BuyerInfo();
            bA.Buyer = "小王"; 


            AllInfoViewModel al = new ViewModels.AllInfoViewModel();
            al.UserName = "超级管理员";
            al.PhoneName = pi.PhoneName;
            al.PhonePrice = pi.PhonePrice.ToString("C");
            if (pi.PhonePrice > 2299) al.Rank = "旗舰机";
            else al.Rank = "经济机";
            al.Buyer = bA.Buyer;

            return View(al);
        }
    }
}