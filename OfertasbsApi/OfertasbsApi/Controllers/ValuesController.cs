using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfertasbsApi.models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OfertasbsApi.Controllers
{
    [ApiController]
    [Route("api/Values")]
    public class ValuesController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        [EnableCors("AllowMyOrigin")]
        public IActionResult Get()
        {

            var request = (HttpWebRequest)WebRequest.Create("https://restcountries.eu/rest/v2/lang/es");

            request.Method = "GET";
            

            var content = string.Empty;

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(stream))
                    {
                        content = sr.ReadToEnd();
                    }
                }
            }

            return Ok(content);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        //[HttpPost]
        //public IActionResult Post(users value)
        //{
        //    var keyfire = "AIzaSyA_77661e1_smtGKLCXEojUcccPZKvkHxQ";
        //    var URL = "https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=" + keyfire;
        //    var client = new HttpClient();
        //    users p = new users { email = value.email, password = value.password, returnSecureToken = value.returnSecureToken };
        //    //client.BaseAddress = new Uri(URL);
        //    var response = client.PostAsJsonAsync(URL, p).Result;
        //    var json = response.Content.ReadAsStringAsync();
        //    if (response.IsSuccessStatusCode)
        //    {
        //        Console.Write("Success");
        //    }
        //    else {
        //        Console.Write("Si presenta error");
        //        return BadRequest(json.Result);

        //    }
        //    return Ok(json.Result);
        //}

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet]
        [Route("getuser")]
        public IActionResult Getuser(string user)
        {
            
            var URL = "http://ec2-3-22-102-75.us-east-2.compute.amazonaws.com/api";
            var endpoint = URL + "/User/validateUser?user=" + user;
            var client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(endpoint).Result;
            if (response.IsSuccessStatusCode)
            {
                var services = response.Content.ReadAsStringAsync();
                Console.WriteLine(services.Result);
                return Ok(services.Result);
            }

            return BadRequest();
        }
    }
}
