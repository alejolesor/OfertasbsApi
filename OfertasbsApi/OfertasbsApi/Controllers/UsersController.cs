using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfertasbsApi.models;
using OfertasbsApi.negocio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OfertasbsApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : Controller
    {
        private usersAuth userb;
        private servicesSbs servsbs;

        // POST api/<controller
        [HttpGet]
        public string Get()
        {
            return "Web Api Escuchando";

        }


        [HttpPost]
        public async Task<IActionResult> PostAsync(users value)
        {
            userb = new usersAuth();

            usersWithROL userRol = new usersWithROL();
            userRol.email = value.email;
            userRol.userID = "idUser";
            userRol.rol = value.rol;


            var result = userb.registerUserRol(userRol);

            if (!result.IsSuccessStatusCode)
            {
                Console.Write("Se presento error");
                return BadRequest(result);
            }


            var jsonDB = await result.Content.ReadAsStringAsync();

            userName nameID = null;

            nameID = JsonConvert.DeserializeObject<userName>(jsonDB.ToString(), new JsonSerializerSettings()
            {
                MissingMemberHandling = MissingMemberHandling.Ignore
            });


            value.displayName = nameID.name;
            var response = userb.registerUser(value);
            var json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode )
            {
                Console.Write("Se presento error");
                return BadRequest(json);
            }
            else
            {
                userRegisterFirebase claims = null;

                claims = JsonConvert.DeserializeObject<userRegisterFirebase>(json.ToString(), new JsonSerializerSettings()
                {
                    MissingMemberHandling = MissingMemberHandling.Ignore
                });

                claims.rol = value.rol;
                claims.rute = "0";

                Console.Write("Success");
                return Ok(claims);
            }

        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(userLogin user)
        {
            userb = new usersAuth();
            var response = userb.loginAuth(user);

            var json = await  response.Content.ReadAsStringAsync();

            userFirebase claims = null;

            claims = JsonConvert.DeserializeObject<userFirebase>(json.ToString(), new JsonSerializerSettings()
            {

                MissingMemberHandling = MissingMemberHandling.Ignore
            });


            var result = userb.GetrRolxID(claims.displayName);

            var jsonRol = await result.Content.ReadAsStringAsync();

            usersWithROL rol = null;

            rol = JsonConvert.DeserializeObject<usersWithROL>(jsonRol.ToString(), new JsonSerializerSettings()
            {

                MissingMemberHandling = MissingMemberHandling.Ignore
            });

            claims.rol = rol.rol;
            claims.rute = rol.rute;
            

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Se presento un Error");
                return BadRequest(claims);
            }
            else
            {
                Console.WriteLine("Success");
                return Ok(claims);
            }
        }

        [HttpGet]
        [Route("loadProducts")]
        public IActionResult loadProducts()
        {
            servsbs = new servicesSbs();
            var response = servsbs.getProduct();
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
        public IActionResult createProduct(productos product)
        {
            servsbs = new servicesSbs();
            var response = servsbs.createProduct(product);
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
        [Route("ProductId")]
        public IActionResult ProductId(int idproduct){
            servsbs = new servicesSbs();
            var response = servsbs.getProductId(idproduct);
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
        [Route("ProductsT")]
        public IActionResult ProductsT()
        {

            servsbs = new servicesSbs();
            var response = servsbs.getProductMarvel();
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
            servsbs = new servicesSbs();
            var response = servsbs.getProductMarvelxId(idproduct);
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
