using ShopingCar.Web.Class;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ShopingCar.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string submitButton, string email, string username, string password)
        {
            string ws = "";
            JavaScriptSerializer jss = new JavaScriptSerializer();
            switch (submitButton)
            {
                case "Log":
                    ws = ConfigurationManager.AppSettings["ServiceShoppingCarURL"] + "/LoginUsuario";
                    Login log = new Login();
                    log.Correo = email;
                    log.Clave = password;
                    string dataJson = jss.Serialize(log);

                    var sender = new ClientService(
                        endpoint: ws,
                        method: HttpMethod.POST,
                        postData: dataJson
                        );
                    string request = sender.MakeRequest();
                    wsRequest log_req = jss.Deserialize<wsRequest>(request);
                    if (log_req.WasSucceful == 0)
                    {
                        ViewBag.Error = "Usuario y contraseña inválidos";
                        return View();
                    }
                    Session["idCliente"] = log_req.WasSucceful;
                    Session["emailCliente"] = email;

                    return RedirectToAction("ListaProductos", "Productos"); 

                case "Reg":
                    ws = ConfigurationManager.AppSettings["ServiceShoppingCarURL"] + "/CrearUsuario";
                    
                    break;
                default:
                    break;
            }

            return View();
        }
    }
}