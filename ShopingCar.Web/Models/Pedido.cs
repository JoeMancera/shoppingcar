using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace ShopingCar.Web.Models
{
    public class Pedido
    {
        public int Id { get; set; }

        #region cliente ID
        public int ClienteId { get; set; }
        #endregion

        #region estado del pedido
        public EstadoEstadoEnum EstadoPedido { get; set; }
        #endregion

        #region relacion con personas
        public virtual ObservableCollection<Persona> Clientes { get; set; }
        #endregion
    }
}