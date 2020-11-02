using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OfertasbsApi.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OfertasbsApi.negocio
{
    public class servicesSbs
    {

        public HttpResponseMessage getProduct()
        {
            var URL = "http://ec2-3-22-102-75.us-east-2.compute.amazonaws.com/api";
            var endpoint = URL + "/Product/Filter";
            var client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(endpoint).Result;
            client.Dispose();
            return response;
        }


        public HttpResponseMessage createProduct(productos value)
        {
            var endpoint = "http://ec2-3-22-102-75.us-east-2.compute.amazonaws.com/api" + "/Product/Create";
            var client = new HttpClient();
            var response = client.PostAsJsonAsync(endpoint, value).Result;
            client.Dispose();
            return response;
        }

        public HttpResponseMessage getProductId(int Id)
        {
            var URL = "http://ec2-3-22-102-75.us-east-2.compute.amazonaws.com/api";
            var endpoint = URL + "/Product/RetriveByID/" + Id;
            var client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(endpoint).Result;
            client.Dispose();
            return response;
        }

        public HttpResponseMessage createCotizacion(cotizacion value)
        {
            creaCotizacion p = new creaCotizacion { cotizacion_fecha = value.cotizacion_fecha, id_cliente = value.id_cliente };
            var endpoint = "http://coposoftware.org:8090" + "/cotizacion/create";
            var client = new HttpClient();
            var response = client.PostAsJsonAsync(endpoint, p).Result;
            var json = response.Content.ReadAsAsync(typeof(creaCotizacion)).Result;
            creaCotizacion responsecotizacion = new creaCotizacion();
            responsecotizacion = (creaCotizacion)json;

            int idCotizacion = responsecotizacion.id_cotizacion;
            value.id_cotizacion = idCotizacion;



            var respuesta = cotizacionItem(value);

            client.Dispose();
            return respuesta;
        }

        public HttpResponseMessage cotizacionItem(cotizacion valores)
        {

            var endpoint = "http://coposoftware.org:8090/itemcotizacion/create";
            var client = new HttpClient();
            var response = client.PostAsJsonAsync(endpoint, valores).Result;

            return response;

        }

        public HttpResponseMessage getCotizaciones()
        {
            var URL = "http://coposoftware.org:8090/itemcotizacion/listAll";
            var endpoint = URL;
            var client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(endpoint).Result;
            client.Dispose();
            return response;
        }


        public HttpResponseMessage createOferta(oferta value)
        {
            creaOferta oferta = new creaOferta { id_item_cotizacion = value.id_item_cotizacion, id_proveedor = value.id_proveedor, oferta_fecha = value.oferta_fecha };
            var endpoint = "http://coposoftware.org:8091/oferta/create";
            var client = new HttpClient();
            var response = client.PostAsJsonAsync(endpoint, oferta).Result;

            var respuesta = insertaOferta(value);
            client.Dispose();
            return respuesta;
        }

        public HttpResponseMessage insertaOferta(oferta value)
        {
            var endpoint = "http://coposoftware.org:8090/itemcotizacion/update";
            var client = new HttpClient();
            var response = client.PutAsJsonAsync(endpoint, value).Result;
            client.Dispose();
            return response;
        }


        public HttpResponseMessage getCotizacionId(int id)
        {
            var URL = "http://coposoftware.org:8090/itemcotizacion/findById/";
            var endpoint = URL + id;
            var client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(endpoint).Result;
            client.Dispose();
            return response;
        }

        public HttpResponseMessage getProductMarvel()
        {
            var URL = "https://gateway.marvel.com/v1/public/characters?ts=1&apikey=dbed0b0b4be0c504d1cc542f35dc60c6&hash=669a7da1aa8aef1b4824fa24073402b5&offset=100&limit=20";

            var client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(URL).Result;
            client.Dispose();
            return response;
        }

        public HttpResponseMessage getProductMarvelxId(int id)
        {
            var URL = "https://gateway.marvel.com:443/v1/public/characters/";
            var endpoint = URL + id + "?ts=1&apikey=dbed0b0b4be0c504d1cc542f35dc60c6&hash=669a7da1aa8aef1b4824fa24073402b5";
            var client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(endpoint).Result;

            client.Dispose();
            return response;
        }

    }
}
