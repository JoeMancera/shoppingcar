using ShopingCar.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopingCar.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var login = new Home();
            login.NombreAPP = "Shopping Car Ci2";
            ViewBag.WelcomeMessage = "Inicia Sesion";
            return View(login);
        }
    }
}