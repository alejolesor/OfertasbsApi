using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfertasbsApi.servicesApi;
using OfertasbsApi.models;

namespace OfertasbsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private productService products;
        [HttpGet]
        [Route("Products")]
        public IActionResult Products()
        {
            products = new productService();
            var response = products.getProduct();
            var json = response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Se presento un Error");
                return BadRequest(json.Result);
            }
            else
            {
                Console.WriteLine("Success");
                return Ok(json.Result);
            }

        }

        [HttpGet]
        [Route("getProdcutxId")]
        public IActionResult getProdcutxId(int idproduct)
        {
            products = new productService();
            var response = products.getProductxId(idproduct);
            var json = response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Se presento un Error");
                return BadRequest(json.Result);
            }
            else
            {
                Console.WriteLine("Success");
                return Ok(json.Result);
            }
        }

        [HttpPost]
        [Route("createProduct")]
        public IActionResult createProduct([FromForm]products product)
        {
            products = new productService();
            var response = products.createProduct(product);
            var json = response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Se presento un Error");
                return BadRequest(json.Result);
            }
            else
            {
                Console.WriteLine("Success");
                return Ok(json.Result);
            }
        }

        [HttpPut]
        [Route("updateProduct")]
        public IActionResult updateProduct([FromForm]products product)
        {
            products = new productService();
            var response = products.updateProduct(product);
            var json = response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Se presento un Error");
                return BadRequest(json.Result);
            }
            else
            {
                Console.WriteLine("Success");
                return Ok(json.Result);
            }

        }



        [HttpDelete]
        [Route("deleteProduct")]
        public IActionResult deleteProduct(int productId)
        {
            products = new productService();
            var response = products.deleteProductxId(productId);
            var json = response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Se presento un Error");
                return BadRequest(json.Result);
            }
            else
            {
                Console.WriteLine("Success");
                return Ok(json.Result);
            }
      
        }
    }
}