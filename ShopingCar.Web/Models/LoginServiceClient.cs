using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;

namespace ShopingCar.Web.Models
{
    public class LoginServiceClient
    {
        public bool  access(Login login)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof (Login));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, login);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient wc = new WebClient();
                wc.Headers["Content-Type"] = "application/javascript";
                wc.Encoding = Encoding.UTF8;
                string url_base = ConfigurationManager.AppSettings["ServiceShoppingCar"];
                wc.UploadString(url_base + "LoginUsuario", "POST", data);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}