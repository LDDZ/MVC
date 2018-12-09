using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BuyerController : Controller
    {
        public ActionResult Index()
        {
            BuyerInfo buyerInfo = new BuyerInfo();
            buyerInfo.Buyer = "狗蛋";
            return View(buyerInfo);
        }
    }
}