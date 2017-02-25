using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace ShopingCar.Web.Class
{
    public class ClientService
    {
        public string EndPoint { get; set; }
        public HttpMethod Method { get; set; }
        public string ContentType { get; set; }
        public string SendData { get; set; }

        //Sobrecargas
        public ClientService()
        {
            EndPoint = "";
            Method = HttpMethod.POST;
            ContentType = "application/javascript";
            SendData = "";
        }

        public ClientService(string endpoint)
        {
            EndPoint = endpoint;
            Method = HttpMethod.POST;
            ContentType = "application/javascript";
            SendData = "";
        }

        public ClientService(string endpoint, HttpMethod method, string postData)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = "application/javascript";
            SendData = postData;
        }

        public string MakeRequest()
        {
            return MakeRequest("");
        }

        public string MakeRequest(string parameters)
        {
            var request = (HttpWebRequest)WebRequest.Create(EndPoint + parameters);

            request.Method = Method.ToString();
            request.ContentLength = 0;
            request.ContentType = ContentType;

            if (!string.IsNullOrEmpty(SendData) && Method == HttpMethod.POST)
            {
                var encoding = new UTF8Encoding();
                var bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(SendData);
                request.ContentLength = bytes.Length;

                using (var writeStream = request.GetRequestStream())
                {
                    writeStream.Write(bytes, 0, bytes.Length);
                }
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var responseValue = string.Empty;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    var message = String.Format("Request failed. Received HTTP {0}", response.StatusCode);
                    throw new ApplicationException(message);
                }
                
                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                        using (var reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                        }
                }
                return responseValue;
            }
        }
    }    
}