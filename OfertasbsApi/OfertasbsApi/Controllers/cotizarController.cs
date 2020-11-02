using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OfertasbsApi.models;
using OfertasbsApi.negocio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OfertasbsApi.Controllers
{
    [ApiController]
    [Route("api/cotizar")]
    public class cotizarController : Controller
    {

        private servicesSbs servsbs;


        [HttpPost]
        [Route("creaCotiza")]
        public IActionResult creaCotiza(cotizacion cotizac)
        {
            servsbs = new servicesSbs();
            var response = servsbs.createCotizacion(cotizac);
            var json = response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Se presento un Error");
                return BadRequest(json.Result);
            }
            else
            {

                Console.WriteLine("Success");
                return Ok(1);
            }
        }

        [HttpGet]
        [Route("loadCotizaciones")]
        public IActionResult loadCotizaciones()
        {
            servsbs = new servicesSbs();
            var response = servsbs.getCotizaciones();
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
        [Route("creaOferta")]
        public IActionResult creaOferta(oferta oferta)
        {
                Console.WriteLine("Success");
                return Ok(1);

        }



        [HttpGet]
        [Route("cotizacionId")]
        public IActionResult cotizacionId(int id)
        {
            servsbs = new servicesSbs();
            var response = servsbs.getCotizacionId(id);
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
