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

        #region Buscar y listar productos
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/BuscarProductoNombre")]
        List<Producto_> BuscarProductoNombre(Stream JSONdataStream);
        #endregion

        #region Buscar Detalle
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/BuscaDetalle")]
        List<DetallePedido_> BuscaDetalle(Stream JSONdataStream);
        #endregion

        #region Buscar productos Id
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/BuscarProductoId")]
        List<Producto_> BuscarProductoId(Stream JSONdataStream);
        #endregion

        #region Crear Pedido
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/CrearPedido")]
        wsSQLResult CrearPedido(Stream JSONdataStream);
        #endregion

        #region Guardar una persona
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/CrearUsuario")]
        wsSQLResult CrearUsuario(Stream JSONdataStream);
        #endregion

        #region Hacer pedido
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/HacerPedido")]
        wsSQLResult HacerPedido(Stream JSONdataStream);
        #endregion

        #region Ingreso al aplictativo
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/LoginUsuario")]
        wsSQLResult LoginUsuario(Stream JSONdataStream);
        #endregion

        #region listado de Detalles
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ListarDetalle")]
        List<DetallePedido_> ListarDetalle(Stream JSONdataStream);
        #endregion

        #region listado de pedidos
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ListarPedidos")]
        List<Pedido_> ListarPedidos(Stream JSONdataStream);
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
        public string NombreProducto { get; set; }

        [DataMember]
        public double Precio { get; set; }

        [DataMember]
        public int Cantidad { get; set; }

    }

    [DataContract]
    public class Pedido_
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int ClienteId { get; set; }

        [DataMember]
        public int EstadoId { get; set; }

        [DataMember]
        public string FechaPedido { get; set; }

        [DataMember]
        public double TotalPago { get; set; }

    }

    [DataContract]
    public class Producto_
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public double Precio { get; set; }

    }
}
