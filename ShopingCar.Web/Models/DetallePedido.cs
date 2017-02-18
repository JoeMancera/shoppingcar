using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopingCar.Web.Models
{
    public class DetallePedido
    {
        public int Id { get; set; }

        #region Pedido
        public int PedidoId { get; set; }
        #endregion

        #region Producto
        public int ProductoId { get; set; }
        #endregion
    }
}