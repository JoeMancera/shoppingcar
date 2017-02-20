using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopingCar.Web.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            //ShoppingCarServer.ShoppingServerClient obj = new ShoppingCarServer.ShoppingServerClient();
            return View();
        }
    }
}