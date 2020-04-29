using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
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

        // POST api/<controller
        [HttpGet]
        public string Get()
        {
            return "Web Api Escuchando";

        }


        [HttpPost]
        public IActionResult Post(users value)
        {
            userb = new usersAuth();
            var response = userb.registerUser(value);
            var json = response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                Console.Write("Se presento error");
                return BadRequest(json.Result);
            }
            else
            {
                Console.Write("Success");
                return Ok(json.Result);
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(userLogin user)
        {
            userb = new usersAuth();
            var response = userb.loginAuth(user);
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
