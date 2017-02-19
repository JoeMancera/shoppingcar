using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ShopingCar.Server
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IShoppingServer" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IShoppingServer
    {
        #region Agregar Poducto
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/CrearProducto")]
        wsSQLResult CrearProducto(Stream JSONdataStream);
        #endregion

        #region Guardar una persona
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/CrearUsuario")]
        wsSQLResult CrearUsuario(Stream JSONdataStream);
        #endregion

        #region Ingreso al aplictativo
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/LoginUsuario")]
        wsSQLResult LoginUsuario(Stream JSONdataStream);
        #endregion
    }


    [DataContract]
    public class Cliente_
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nombres { get; set; }

        [DataMember]
        public string Correo { get; set; }

        [DataMember]
        public string Clave { get; set; }

    }

    [DataContract]
    public class DetallePedido_
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int PedidoId { get; set; }

        [DataMember]
        public int ProductoId { get; set; }

        [DataMember]
        public string Cantidad { get; set; }

    }

    [DataContract]
    public class Pedido_
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int ClienteId { get; set; }

        [DataMember]
        public string FechaPedido { get; set; }

    }

    [DataContract]
    public class Producto_
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Precio { get; set; }

    }
}
