using Newtonsoft.Json;
using OfertasbsApi.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OfertasbsApi.servicesApi
{
    
    public class productService
    {
        string urlProducts = "http://10.39.1.164:9092/api/Product";
        public HttpResponseMessage getProduct()
        {
            var endpoint = urlProducts ;
            var client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(endpoint).Result;
            client.Dispose();
            return response;
        }

        public HttpResponseMessage getProductxId(int id)
        {
            var endpoint = urlProducts + "/" + id;
            var client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(endpoint).Result;

            client.Dispose();
            return response;
        }


        public HttpResponseMessage createProduct(products product)
        {
            var endpoint = urlProducts;
            //products p = new products {Name = product.Name, Description = product.Description, Amount = product.Amount, DestinationCity = product.DestinationCity, EventDate=product.EventDate, TransportType = product.TransportType, PeopleNumber = product.PeopleNumber, OriginCity = product.OriginCity, File = product.File };
            var client = new HttpClient();

            var file = product.File;


            var fileStreamContent = new StreamContent(file.OpenReadStream());
            fileStreamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);


            var multiContent = new MultipartFormDataContent
            {
                {new StringContent(product.Name),"Name" },
                {new StringContent(product.Description), "Description" },
                {new StringContent(Convert.ToString(product.Amount)), "Amount" }, 
                {new StringContent(product.DestinationCity), "DestinationCity" },
                {new StringContent(product.EventDateString), "EventDateString" },
                {new StringContent(product.TransportType), "TransportType" },
                {new StringContent(Convert.ToString(product.PeopleNumber)), "PeopleNumber" },
                {new StringContent(product.OriginCity), "OriginCity" },


            };


            multiContent.Add(fileStreamContent,"FileImage", file.Name);
            var response =  client.PostAsync(endpoint, multiContent).Result;
            client.Dispose();
            return response;
        }



        public HttpResponseMessage deleteProductxId(int id)
        {
            var endpoint = urlProducts + "/" + id;
            var client = new HttpClient();
            HttpResponseMessage response = client.DeleteAsync(endpoint).Result;

            client.Dispose();
            return response;
        }


        public HttpResponseMessage updateProduct(products product)
        {
            var endpoint = urlProducts;

            var client = new HttpClient();

            var file = product.File;
            var Lastdate = DateTime.Now.ToString();
            var eventDate = product.EventDateString.ToString();


            var fileStreamContent = new StreamContent(file.OpenReadStream());
            fileStreamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);

        

            var multiContent = new MultipartFormDataContent
            {
                 {new StringContent(product.id),"Id" },
                {new StringContent(product.Name),"Name" },
                {new StringContent(product.Description), "Description" },
                {new StringContent(Convert.ToString(product.Amount)), "Amount" },
                {new StringContent(product.DestinationCity), "DestinationCity" },
                {new StringContent(product.EventDateString), "EventDateString" },
                {new StringContent(product.TransportType), "TransportType" },
                {new StringContent(Convert.ToString(product.PeopleNumber)), "PeopleNumber" },
                {new StringContent(product.OriginCity), "OriginCity" },
                


            };

            

            multiContent.Add(fileStreamContent, "FileImage", file.Name);
            var response = client.PutAsync(endpoint, multiContent).Result;
            client.Dispose();
            return response;
        }

        public HttpResponseMessage createOrden(Orders value)
        {
            var endpoint = "http://10.39.1.164:9096/api/Orden";
            var client = new HttpClient();
            var response = client.PostAsJsonAsync(endpoint, value).Result;
            client.Dispose();
            return response;
        }

        public int CreateProductOrden(OrdersProducts[] orderProducts, int orderId)
        {
            var endpoint = "http://10.39.1.164:9096/api/OrdenProductos";
            int value = 0;
            foreach (var item in orderProducts)
            {
                item.IdOrden = orderId;
            }
            
            var client = new HttpClient();
            var response = client.PostAsJsonAsync(endpoint, orderProducts).Result;
            client.Dispose();
            var json = response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Se presento un Error");
                value = 0;
                return value;
            }
            else
            {
                value = 1;
                return value;
            }

        }

        public HttpResponseMessage getTransport(LogisticTransport transport)
        {
            var URL = "http://10.39.1.164:9090/api/Logistic/GetAvailableTransport";

            var client = new HttpClient();

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(URL),
                Method = HttpMethod.Get,
            };

            var Json = JsonConvert.SerializeObject(transport, new JsonSerializerSettings());
   
            request.Content = new ByteArrayContent(Encoding.UTF8.GetBytes(Json));
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = client.SendAsync(request).Result;
            response.EnsureSuccessStatusCode();

            client.Dispose();
            return response;
        }

        public HttpResponseMessage getHotels(LogisticHotels transport)
        {
            var URL = "http://10.39.1.164:9090/api/Logistic/GetAvailableHotel";

            var client = new HttpClient();

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(URL),
                Method = HttpMethod.Get,
            };

            var Json = JsonConvert.SerializeObject(transport, new JsonSerializerSettings());

            request.Content = new ByteArrayContent(Encoding.UTF8.GetBytes(Json));
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = client.SendAsync(request).Result;
            response.EnsureSuccessStatusCode();

            client.Dispose();
            return response;
        }


        }
}
