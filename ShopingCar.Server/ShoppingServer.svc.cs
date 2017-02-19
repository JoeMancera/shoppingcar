using System;
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

        #region Buscar Cliente por correo
        public bool FiltradoPorCorreo(string correo)
        {
            bool found = false;
            var result = from p in BDUsuario.Cliente
                       where p.Correo == correo

                       select new Cliente_
                       {
                           Correo = p.Correo,
                       };

            int count = result.Count();

            if (count != 0)
                found = true;
            
            return found;
        }
        #endregion

        #region Guardar Registro
        public wsSQLResult CrearUsuario(Stream JSONdataStream)
        {
            wsSQLResult result = new wsSQLResult();
            try
            {
                StreamReader reader = new StreamReader(JSONdataStream);

                string JSONdata = reader.ReadToEnd();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                Cliente_ cust = jss.Deserialize<Cliente_>(JSONdata);

                if (cust == null)
                {
                    result.WasSucceful = 0;
                    result.Exception = "No se pudo deserializar el JSON a Cliente_";
                    return result;
                }

                Cliente newCustomer = new Cliente
                {
                    Nombres = cust.Nombres,
                    Correo = cust.Correo,
                    Clave = cust.Clave
                };

                
                if (FiltradoPorCorreo(cust.Correo))
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
    }
}
