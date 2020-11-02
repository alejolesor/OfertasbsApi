using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfertasbsApi.models
{
    public class productos
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public string Catalogue { get; set; }
    }

    public class cotizacion
    {
        public string cotizacion_fecha { get; set; } 
        public int id_cliente { get; set; }

        public int id_cotizacion { get; set; }

        public int id_estado { get; set; }

        public int id_item_catalogo { get; set; }

        public int item_cotizacion_cantidad { get; set; }

        public int item_cotizacion_precio { get; set; }

    }

    public class creaCotizacion
    {
        public string cotizacion_fecha { get; set; }
        public int id_cliente { get; set; }

        public int id_cotizacion { get; set; }

    }

    public class oferta
    {
        public int id_item_cotizacion { get; set; }
        public int id_proveedor { get; set; }
        public string oferta_fecha { get; set; }
        public int id_cotizacion { get; set; }
        public int id_estado { get; set; }
        public int id_item_catalogo { get; set; }
        public int id_oferta { get; set; }
        public int item_cotizacion_cantidad { get; set; }
        public int item_cotizacion_descuento { get; set; }
        public int item_cotizacion_precio { get; set; }
    }

    public class creaOferta
    {
        public int id_item_cotizacion { get; set; }
        public int id_proveedor { get; set; }
        public string oferta_fecha { get; set; }
    }

}
