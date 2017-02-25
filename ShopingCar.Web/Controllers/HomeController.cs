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
        public ActionResult Index(string submitButton, string email, string usernameR, string password, string emailR, string passwordR)
        {
            string ws = "";
            JavaScriptSerializer jss = new JavaScriptSerializer();
            Login log = new Login();
            switch (submitButton)
            {
                case "Log":
                    ws = ConfigurationManager.AppSettings["ServiceShoppingCarURL"] + "/LoginUsuario";                    
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

                    ViewBag.Error = "Bienvenido!";
                    return RedirectToAction("ListaProductos", "Productos"); 

                case "Reg":
                    ws = ConfigurationManager.AppSettings["ServiceShoppingCarURL"] + "/CrearUsuario";
                    log.Nombres = usernameR;
                    log.Correo = emailR;
                    log.Clave = passwordR;
                    if (log.Nombres  == "" || log.Correo == "" || log.Clave =="")
                    {
                        ViewBag.Error = "Datos incompletos!";
                        return View();
                    }
                    string dataJsonReg = jss.Serialize(log);

                    var senderReg = new ClientService(
                        endpoint: ws,
                        method: HttpMethod.POST,
                        postData: dataJsonReg
                        );
                    string requestReg = senderReg.MakeRequest();
                    wsRequest log_req_reg = jss.Deserialize<wsRequest>(requestReg);
                    if (log_req_reg.WasSucceful == 0)
                    {
                        ViewBag.Error = "Este correo ya esta registrado";
                        return View();
                    }

                    ViewBag.Error = "Registrado correctamente!";
                    return View();

                default:
                    break;
            }

            return View();
        }
    }
}