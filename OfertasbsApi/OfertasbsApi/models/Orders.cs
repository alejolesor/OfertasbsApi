using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfertasbsApi.models
{
    public class Orders
    {
        public int IdCliente { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha { get; set; }
        public int Total { get; set; }
        public OrdersProducts[] OrderProducts { get; set; }
    }
    public class OrdersProducts
    {
        public int IdOrden { get; set; }
        public int idProducto { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
    }

    public class Order
    {
        public int idOrden { get; set; }
        public string Estado { get; set; }
    }
}
