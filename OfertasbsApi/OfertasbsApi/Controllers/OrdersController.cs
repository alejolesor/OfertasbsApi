using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfertasbsApi.models;
using OfertasbsApi.servicesApi;

namespace OfertasbsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private productService productsOrder;

        [HttpPost]
        [Route("createOrden")]
        public async Task<IActionResult> createOrdenAsync(Orders order)
        {
            productsOrder = new productService();
            var response = productsOrder.createOrden(order);
            var json = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Se presento un Error");
                return BadRequest(json);
            }
            else
            {
                Order orderCreated = null;

                orderCreated = JsonConvert.DeserializeObject<Order>(json.ToString(), new JsonSerializerSettings()
                {
                    MissingMemberHandling = MissingMemberHandling.Ignore
                });

                int result = productsOrder.CreateProductOrden(order.OrderProducts, orderCreated.idOrden);
                Console.WriteLine("Success");
                return Ok(json);
            }
        }
    }
}