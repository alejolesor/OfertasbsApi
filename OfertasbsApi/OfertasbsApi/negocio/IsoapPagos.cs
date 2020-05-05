using OfertasbsApi.models;
using pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfertasbsApi.negocio
{
    public interface IsoapPagos
    {
        PagosModel pagoCompensar(string referenciaFactura, double valorFactura);
        GetFacturaModel GetFactura(string referenciaFactura);

    }
}
