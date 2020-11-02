using Microsoft.AspNetCore.Mvc;
using OfertasbsApi.models;
using pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace OfertasbsApi.negocio
{
    public class services : IsoapPagos
    {

        public readonly string serviceUrl = "http://DESKTOP-3A7QUP7:8088/mockServicioPagos";
        public readonly EndpointAddress endpointAddress;
        public readonly BasicHttpBinding basicHttpBinding;
        public readonly CustomBinding bindingcust;

        public services()
        {
            endpointAddress = new EndpointAddress(serviceUrl);


            basicHttpBinding =
                new BasicHttpBinding(endpointAddress.Uri.Scheme.ToLower() == "http" ?
                            BasicHttpSecurityMode.None : BasicHttpSecurityMode.Transport);




            //Please set the time accordingly, this is only for demo
            basicHttpBinding.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
            basicHttpBinding.MaxReceivedMessageSize = int.MaxValue;
            basicHttpBinding.OpenTimeout = TimeSpan.MaxValue;
            basicHttpBinding.CloseTimeout = TimeSpan.MaxValue;
            basicHttpBinding.ReceiveTimeout = TimeSpan.MaxValue;
            basicHttpBinding.SendTimeout = TimeSpan.MaxValue;








        }

        public HttpResponseMessage getLoadServices()
        {
            var URL = "http://ec2-3-22-102-75.us-east-2.compute.amazonaws.com:81/api";
            var endpoint = URL + "/PublicServices/LoadServices";
            var client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(endpoint).Result;
            client.Dispose();
            return response;
        }

        public HttpResponseMessage getValidationUser(string user)
        {
            var URL = "http://ec2-3-22-102-75.us-east-2.compute.amazonaws.com/api";
            var endpoint = URL + "/User/validateUser?user=" + user;
            var client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(endpoint).Result;
            client.Dispose();
            return response;
        }


        public PagosInerfaceClient GetClientAsync()
        {
            var client = new PagosInerfaceClient(basicHttpBinding, endpointAddress);
            return client;

        }

        public PagosModel pagoCompensar(string referenciaFactura, double valorFactura)
        {
            ReferenciaFactura refe = new ReferenciaFactura { referenciaFactura = referenciaFactura };
            Pago pagoRealizado = new Pago { referenciaFactura = refe, totalPagar = valorFactura };
            PagosInerfaceClient cliente = new PagosInerfaceClient();
            var response = cliente.CompensarAsync(pagoRealizado).Result;
            PagosModel responseSoap = new PagosModel { referenciaId = response.Resultado.referenciaFactura.referenciaFactura, messageResponse = response.Resultado.mensaje };
            return responseSoap;
        }

        public GetFacturaModel GetFactura(string referenciaFactura)
        {
            ReferenciaFactura refe = new ReferenciaFactura { referenciaFactura = referenciaFactura };
            PagosInerfaceClient cliente2 = new PagosInerfaceClient();
            var response = cliente2.CosultarAsync(refe).Result;
            GetFacturaModel factura = new GetFacturaModel { referenciaId = response.ResultadoConsulta.referenciaFactura.referenciaFactura, TotalAPagar = response.ResultadoConsulta.totalPagar };
            return factura;
        }

        public PagosFactura PagarFactura(string referenciaFactura, double valorFactura)
        {
            ReferenciaFactura refe = new ReferenciaFactura { referenciaFactura = referenciaFactura };
            Pago pagoRealizado = new Pago { referenciaFactura = refe, totalPagar = valorFactura };
            PagosInerfaceClient cliente3 = new PagosInerfaceClient();
            var response = cliente3.PagarAsync(pagoRealizado).Result;
            PagosFactura responseFactura = new PagosFactura { referenciaFacturaId = response.Resultado.referenciaFactura.referenciaFactura, messageResponseFact = response.Resultado.mensaje };
            return responseFactura;
        }

        public HttpResponseMessage getMediosPagos()
        {
            var URL = "http://ec2-3-22-102-75.us-east-2.compute.amazonaws.com:82/api";
            var endpoint = URL + "/Payment/LoadPaymentMethods";
            var client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(endpoint).Result;
            client.Dispose();
            return response;
        }

        public HttpResponseMessage ValidateBalance(string numberTarjet)
        {
            var URL = "http://ec2-3-22-102-75.us-east-2.compute.amazonaws.com:82/api/Payment";
            var endpoint = URL + "/ValidateBalance?targetNumber=" + numberTarjet;
            var client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(endpoint).Result;
            client.Dispose();
            return response;
        }

        public HttpResponseMessage FacturaAgua(int numeroFactura)
        {
            var URL = "http://localhost:9090/servicios/pagos/v1/payments/";
            var endpoint = URL + numeroFactura;
            var client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(endpoint).Result;
            client.Dispose();
            return response;
        }

    }
}
