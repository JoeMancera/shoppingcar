﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using System.Linq;

namespace ShopingCar.Server
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ShoppingServer" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ShoppingServer.svc o ShoppingServer.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ShoppingServer : IShoppingServer
    {
        ShoppingDataDataContext BDUsuario = new ShoppingDataDataContext();

        #region Agregra Producto
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

        #region Buscar Cliente por correo
        public List<Cliente_> FiltradoPorCorreo(string correo)
        {
            var result = from p in BDUsuario.Cliente
                       where p.Correo == correo

                       select new Cliente_
                       {
                           Correo = p.Correo,
                           Clave = p.Clave
                       };

            int count = result.Count();
            
            return result.ToList();
        }
        #endregion

        #region  Buscar Producto
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

        #region Login User
        public wsSQLResult LoginUsuario(Stream JSONdataStream)
        {
            wsSQLResult result = new wsSQLResult();

            try
            {
                string queLaClave = "";
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
                }

                if (queLaClave  != obj.Clave)
                {
                    result.WasSucceful = 0;
                    result.Exception = "Usuario y clave invalidos";
                    return result;
                }
                else
                {
                    result.WasSucceful = 1;
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
