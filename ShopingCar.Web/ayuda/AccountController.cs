using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessObjects;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using CarroCompras.ClienteRest;
using ServiciosWeb.Models;


namespace MvcTest.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(classClienteBO clienteBO, string submitButton)
        {
            switch (submitButton)
            {
                case "Iniciar":
                    string endPoint = "http://localhost:58286/api/Login?" + "email=" + clienteBO.email + "&password=" + clienteBO.password;
                    string datos = JsonConvert.SerializeObject(clienteBO);

                    var cliente = new classRestClient(endpoint: endPoint,
                                                      method: HttpVerb.GET,
                                                      postData: datos);
                    string respuesta = cliente.MakeRequest();
                    respuesta = respuesta.Replace("\\", "");
                    respuesta = respuesta.Replace("\"{", "{");
                    respuesta = respuesta.Replace("}\"", "}");
                    classClienteBO clientebo = JsonConvert.DeserializeObject<classClienteBO>(respuesta);
                    Session["idCliente"] = clientebo.idCliente;
                    Session["emailCliente"] = clientebo.email;

                    if (clientebo.idCliente != 0) return RedirectToAction("ListaProductos", "Productos");
                    return View();

                case "Registrar":
                    return RedirectToAction("Registrar", "Account");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Registrar()
        {
            return View();
        }

        public ActionResult Registrar(classClienteBO clienteBO)
        {
            string endPoint = "http://localhost:58286/api/Login";
            string datos = JsonConvert.SerializeObject(clienteBO);

            var cliente = new classRestClient(endpoint: endPoint,
                                              method: HttpVerb.POST,
                                              postData: datos);
            string respuesta = cliente.MakeRequest();
            respuesta = respuesta.Replace("\\", "");
            respuesta = respuesta.Replace("\"{", "{");
            respuesta = respuesta.Replace("}\"", "}");
            classParametrosRespuestaBO parametrosRespuesta = JsonConvert.DeserializeObject<classParametrosRespuestaBO>(respuesta);

            if (parametrosRespuesta.estadoRegistro)
            {
                //classUtilGUI.GenerarMensaje("Se ha registrado correctamente el cliente.", Response);
                return RedirectToAction("Index", "Account");
            }
            else
            {
                //classUtilGUI.GenerarMensaje("No se ha registrado correctamente el cliente.", Response);
                return View();
            }
            //new classClienteBusiness().registrarCliente(clienteBO);
            //return RedirectToAction("Index", "Account");
        }
    }
}
