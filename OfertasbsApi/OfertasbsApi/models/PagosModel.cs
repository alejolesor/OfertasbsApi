using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace OfertasbsApi.models
{
    public class PagosModel
    {
        public string referenciaId { get; set; }
        public string messageResponse { get; set; }
    }

    public class GetFacturaModel
    {
        public string referenciaId { get; set; }
        public double TotalAPagar { get; set; }
    }

    public class PagosFactura
    {
        public string referenciaFacturaId { get; set; }
        public string messageResponseFact { get; set; }
    }
}
