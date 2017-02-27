using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using System.Linq;
using System.Net.Mail;
using System.Net;

namespace ShopingCar.Server
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ShoppingServer" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ShoppingServer.svc o ShoppingServer.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ShoppingServer : IShoppingServer
    {
        ShoppingDataDataContext BDUsuario = new ShoppingDataDataContext();

        #region Agregra Producto DB
        public wsSQLResult CrearProducto(Stream JSONdataStream)
        {
            wsSQLResult result = new wsSQLResult();

            try
            {
                StreamReader reader = new StreamReader(JSONdataStream);
                string JSONdata = reader.ReadToEnd();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                Producto_ obj = jss.Deserialize<Producto_>(JSONdata);

                if (obj == null)
                {
                    result.WasSucceful = 0;
                    result.Exception = "No se pudo deserializar el JSON";
                    return result;
                }

                Producto newProduct = new Producto
                {
                    Nombre = obj.Nombre,
                    Precio = Convert.ToDouble(obj.Precio),
                };

                BDUsuario.Producto.InsertOnSubmit(newProduct);
                BDUsuario.SubmitChanges();

                result.WasSucceful = 1;
                result.Exception = "";
                return result;
            }
            catch (Exception ex)
            {
                result.WasSucceful = 0;
                result.Exception = ex.Message;
                return result;
            }
        }
        #endregion

        #region Buscar un pedido existente
        public List<Pedido_> BuscaPedido(int id)
        {
            List<Pedido_> result = new List<Pedido_>();

            var list = from p in BDUsuario.Pedido
                       where p.EstadoId == 1 && p.ClienteId == id

                       select new Pedido_
                       {
                           Id = p.Id,
                           ClienteId = p.ClienteId
                       };
            int count = list.Count();
            return list.ToList();
        }
        #endregion

        #region Buscar Cliente por correo
        public List<Cliente_> FiltradoPorCorreo(string correo)
        {
            var result = from p in BDUsuario.Cliente
                       where p.Correo == correo

                       select new Cliente_
                       {
                           Id=p.Id,
                           Correo = p.Correo,
                           Clave = p.Clave
                       };

            int count = result.Count();
            
            return result.ToList();
        }
        #endregion

        #region  Buscar Producto Nombre
        public List<Producto_> BuscarProductoNombre(Stream JSONdataStream)
        {
            List<Producto_> result = new List<Producto_>();

            StreamReader reader = new StreamReader(JSONdataStream);
            string JSONdata = reader.ReadToEnd();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            Producto_ obj = jss.Deserialize<Producto_>(JSONdata);

            if (obj == null)
            {
                return result.ToList();
            }

            if (obj.Nombre != null || obj.Nombre == "")
            {
                var list = from p in BDUsuario.Producto
                             where (p.Nombre.Contains(obj.Nombre))

                           select new Producto_
                             {
                                 Id =  p.Id,
                                 Nombre = p.Nombre,
                                 Precio = p.Precio,
                             };
                int count = list.Count();
                return list.ToList();
            }
            else
            {
                var list = from p in BDUsuario.Producto

                             select new Producto_
                             {
                                 Id = p.Id,
                                 Nombre = p.Nombre,
                                 Precio = p.Precio,
                             };
                int count = list.Count();
                return list.ToList();
            }

        }
        #endregion

        #region  Buscar Producto Id
        public List<Producto_> BuscarProductoId(Stream JSONdataStream)
        {
            List<Producto_> result = new List<Producto_>();

            StreamReader reader = new StreamReader(JSONdataStream);
            string JSONdata = reader.ReadToEnd();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            Producto_ obj = jss.Deserialize<Producto_>(JSONdata);

            if (obj == null)
            {
                return result.ToList();
            }

            if (obj.Id != 0)
            {
                var list = from p in BDUsuario.Producto
                           where (p.Id == obj.Id)

                           select new Producto_
                           {
                               Id = p.Id,
                               Nombre = p.Nombre,
                               Precio = p.Precio,
                           };
                int count = list.Count();
                return list.ToList();
            }
            else
            {
                var list = from p in BDUsuario.Producto

                           select new Producto_
                           {
                               Id = p.Id,
                               Nombre = p.Nombre,
                               Precio = p.Precio,
                           };
                int count = list.Count();
                return list.ToList();
            }

        }
        #endregion

        #region Crear Usuario
        public wsSQLResult CrearUsuario(Stream JSONdataStream)
        {
            wsSQLResult result = new wsSQLResult();
            try
            {
                StreamReader reader = new StreamReader(JSONdataStream);

                string JSONdata = reader.ReadToEnd();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                Cliente_ obj = jss.Deserialize<Cliente_>(JSONdata);

                if (obj == null)
                {
                    result.WasSucceful = 0;
                    result.Exception = "No se pudo deserializar el JSON a Cliente_";
                    return result;
                }

                Cliente newCustomer = new Cliente
                {
                    Nombres = obj.Nombres,
                    Correo = obj.Correo,
                    Clave = obj.Clave
                };

                
                if (FiltradoPorCorreo(obj.Correo).Count != 0)
                {
                    result.WasSucceful = 0;
                    result.Exception = "Correo ya existe";
                    return result;                    
                }

                BDUsuario.Cliente.InsertOnSubmit(newCustomer);
                BDUsuario.SubmitChanges();

                result.WasSucceful = 1;
                result.Exception = "";
                return result;
            }
            catch (Exception e)
            {
                result.WasSucceful = 0;
                result.Exception = e.Message;
                return result;
            }

        }
        #endregion

        #region Crear un pedido
        public wsSQLResult CrearPedido(Stream JSONdataStream)
        {
            wsSQLResult result = new wsSQLResult();

            try
            {
                StreamReader reader = new StreamReader(JSONdataStream);

                string JSONdata = reader.ReadToEnd();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                Pedido_ objPedido = jss.Deserialize<Pedido_>(JSONdata);
                DetallePedido_ objDetalle = jss.Deserialize<DetallePedido_>(JSONdata);

                if (objPedido == null)
                {
                    result.WasSucceful = 0;
                    result.Exception = "No se pudo deserializar el JSON a Pedido_";
                    return result;
                }

                if (objDetalle == null)
                {
                    result.WasSucceful = 0;
                    result.Exception = "No se pudo deserializar el JSON a Detalle_";
                    return result;
                }
                var list = BuscaPedido(objPedido.ClienteId);
                
                if (list.Count == 0)
                {
                    Pedido newOrder = new Pedido()
                    {
                        ClienteId = objPedido.ClienteId,
                        FechaPedido = DateTime.Now,
                        EstadoId = 1
                    };

                    BDUsuario.Pedido.InsertOnSubmit(newOrder);
                    BDUsuario.SubmitChanges();
                    var pedidoId = newOrder.Id;

                    DetallePedido newDetailOrder = new DetallePedido()
                    {
                        PedidoId = pedidoId,
                        ProductoId = objDetalle.ProductoId,
                        Cantidad = objDetalle.Cantidad
                    };

                    BDUsuario.DetallePedido.InsertOnSubmit(newDetailOrder);
                    BDUsuario.SubmitChanges();

                    result.WasSucceful = 1;
                    result.Exception = "";
                    return result;
                }
                else
                {
                    int pedidoId = 0;
                    foreach (var i in list)
                    {
                        pedidoId = i.Id;
                    }

                    if (objDetalle.Cantidad != 0)
                    {
                        DetallePedido newDetailOrder = new DetallePedido()
                        {
                            PedidoId = pedidoId,
                            ProductoId = objDetalle.ProductoId,
                            Cantidad = objDetalle.Cantidad
                        };

                        BDUsuario.DetallePedido.InsertOnSubmit(newDetailOrder);
                        BDUsuario.SubmitChanges();

                        result.WasSucceful = 1;
                        result.Exception = "";
                        return result;
                    }

                    DetallePedido newDetailOrderDel = new DetallePedido()
                    {
                        PedidoId = pedidoId,
                        ProductoId = objDetalle.ProductoId
                    };

                    var deleteOrderDetails = from d in BDUsuario.DetallePedido
                                             where d.PedidoId == pedidoId &&
                                              d.ProductoId == objDetalle.ProductoId
                                             select d;
                    foreach (var d in deleteOrderDetails)
                    {
                        BDUsuario.DetallePedido.DeleteOnSubmit(d);
                    }

                    try
                    {
                        BDUsuario.SubmitChanges();

                        result.WasSucceful = 1;
                        result.Exception = "";
                        return result;
                    }
                    catch (Exception e)
                    {

                        result.WasSucceful = 0;
                        result.Exception = e.Message;
                        return result;
                    }
                                        
                }
                
            }
            catch (Exception e)
            {
                result.WasSucceful = 0;
                result.Exception = e.Message;
                return result;
            }
        }
        #endregion

        #region Hacer pedido
        public wsSQLResult HacerPedido(Stream JSONdataStream)
        {
            wsSQLResult result = new wsSQLResult();

            try
            {
                StreamReader reader = new StreamReader(JSONdataStream);
                string JSONdata = reader.ReadToEnd();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                Pedido_ obj = jss.Deserialize<Pedido_>(JSONdata);

                if (obj == null)
                {
                    result.WasSucceful = 0;
                    result.Exception = "No se pudo deserializar el JSON";
                    return result;
                }

                BDUsuario.Pedido.Where(e => e.ClienteId == obj.ClienteId)
                    .Where(e => e.EstadoId == 1)
                    .ToList()
                    .ForEach(e => e.TotalPago = obj.TotalPago);

                BDUsuario.Pedido.Where(e => e.ClienteId == obj.ClienteId)
                    .Where(e => e.EstadoId == 1)
                    .ToList()
                    .ForEach(e => e.EstadoId = 2);                

                BDUsuario.SubmitChanges();
                
                if (!SendEmail(obj.ClienteId, Convert.ToString(obj.TotalPago)))
                {
                    result.WasSucceful = 1;
                    result.Exception = "No se envio el correo";
                    return result;
                } 

                result.WasSucceful = 1;
                result.Exception = "";

                return result;
            }
            catch (Exception ex)
            {
                result.WasSucceful = 0;
                result.Exception = ex.Message;
                return result;
            }
        }
        #endregion

        #region Listar Pedidos
        public List<Pedido_> ListarPedidos(Stream JSONdataStream)
        {
            List<Pedido_> result = new List<Pedido_>();
            StreamReader reader = new StreamReader(JSONdataStream);

            string JSONdata = reader.ReadToEnd();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            Pedido_ obj= jss.Deserialize <Pedido_ >(JSONdata);

            if (obj == null)
            {
                return result.ToList();
            }

            var list = from p in BDUsuario.Pedido
                       where (p.ClienteId == obj.ClienteId)
                       select new Pedido_
                       {
                           Id = p.Id,
                           EstadoId = p.EstadoId,
                           FechaPedido = Convert.ToString(p.FechaPedido),
                           TotalPago = Convert.ToDouble(p.TotalPago)
                       };
            return list.ToList();
        }
        #endregion

        #region Listar detalle
        public List<DetallePedido_> ListarDetalle(Stream JSONdataStream)
        {
            List<DetallePedido_> result = new List<DetallePedido_>();
            StreamReader reader = new StreamReader(JSONdataStream);

            string JSONdata = reader.ReadToEnd();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            DetallePedido_ obj = jss.Deserialize<DetallePedido_>(JSONdata);

            if (obj == null)
            {
                return result;
            }

            var list = from p in BDUsuario.DetallePedido
                       where (p.PedidoId == obj.PedidoId)
                       select new DetallePedido_
                       {
                           NombreProducto = (from d in BDUsuario.Producto
                                      where (d.Id == p.ProductoId)
                                      select d.Nombre).First(),
                           Precio = (from d in BDUsuario.Producto
                                     where (d.Id == p.ProductoId)
                                     select d.Precio).First(),
                           Cantidad = p.Cantidad
                       };
            return list.ToList();
        }
        #endregion

        #region Login User
        public wsSQLResult LoginUsuario(Stream JSONdataStream)
        {
            wsSQLResult result = new wsSQLResult();

            try
            {
                string queLaClave = "";
                int idCliente = 0;
                StreamReader reader = new StreamReader(JSONdataStream);

                string JSONdata = reader.ReadToEnd();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                Cliente_ obj = jss.Deserialize<Cliente_>(JSONdata);

                if (obj == null)
                {
                    result.WasSucceful = 0;
                    result.Exception = "No se pudo deserializar el JSON";
                    return result;
                }

                var log = FiltradoPorCorreo(obj.Correo);
                if (log.Count == 0)
                {
                    result.WasSucceful = 0;
                    result.Exception = "Usuario y clave invalidos";
                    return result;
                }

                var lista = log.ToList();
                foreach (var i in lista)
                {
                    queLaClave = i.Clave;
                    idCliente = i.Id;
                }

                if (queLaClave  != obj.Clave)
                {
                    result.WasSucceful = 0;
                    result.Exception = "Usuario y clave invalidos";
                    return result;
                }
                else
                {
                    result.WasSucceful = idCliente;
                    result.Exception = "";
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.WasSucceful = 0;
                result.Exception = ex.Message;
                return result;
            }
        }
        #endregion

        #region send Email
        public bool SendEmail(int idCliente, string totalPago)
        {
            bool sent = false;

            MailMessage email = new MailMessage();
            string correo = "";
            var result = from p in BDUsuario.Cliente
                         where p.Id == idCliente

                         select new Cliente_
                         {
                             Correo = p.Correo,
                             Clave = p.Clave
                         };
            
            foreach (var c in result)
            {
                correo = c.Correo;
            }
            email.To.Add(new MailAddress(Convert.ToString(correo)));
            email.From = new MailAddress("shoppingcar@ci2.co");
            email.Subject = "Detalle de la compra Shopping Car";
            email.Body = "<h1>detalle de compra<h1/> <br/> <h2> <strong>Total Compra: </strong>"+ totalPago +"</h2>";
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("shoppingcarci2@gmail.com", "_ShoppingCarCi2");
            try
            {
                smtp.Send(email);
                email.Dispose();
                return sent = true;
            }
            catch (Exception)
            {
                return sent = false;
            }
        }
        #endregion

        #region Serializer
        public JavaScriptSerializer Serializer(Stream JSONdataStream, TypedReference Tipo)
        {
            StreamReader reader = new StreamReader(JSONdataStream);
            string JSONdata = reader.ReadToEnd();
            JavaScriptSerializer jss = new JavaScriptSerializer();

            return jss;
        }
        #endregion
    }
}
