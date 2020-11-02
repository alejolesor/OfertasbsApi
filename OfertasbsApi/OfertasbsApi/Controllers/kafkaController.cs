using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OfertasbsApi.negocio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OfertasbsApi.Controllers
{
    [ApiController]
    [Route("api/kafka")]
    public class kafkaController : Controller
    {
        private serviceKafka kafka;
        private services services;
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        [Route("Producer")]
        public IActionResult Producer(string messageProd, string topicId)
        {
            kafka = new serviceKafka();
            var response = kafka.ProducerTopic(messageProd, topicId);
            if (!response)
            {
                Console.Write("Se presento error");
                return BadRequest("Se presento un error al producir el mensaje");

            }

            Console.Write("Success");
            return Ok("Mensaje publicado en Topic");

        }

        [HttpGet]
        [Route("Consumer")]
        public IActionResult Consumer(string topic)
        {
            kafka = new serviceKafka();
            var response = kafka.ConsumerTopic(topic);
            if (response.Contains("Error"))
            {
                Console.Write("Se presento error");
                return BadRequest("Se presento un error al consumir el mensaje");

            }
            Console.Write("Success");
            return Ok(response);

        }

        [HttpGet]
        [Route("ValidateUser")]
        public IActionResult ValidateUser(string user)
        {
            services = new services();
            var response = services.getValidationUser(user);
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

        [HttpGet]
        [Route("LoadServices")]
        public IActionResult LoadServices(string topic)
        {
            services = new services();
            kafka = new serviceKafka();
            var response = services.getLoadServices();
            var json = response.Content.ReadAsStringAsync();
            var responseJson = string.Empty;
            if (!response.IsSuccessStatusCode)
            {
                Console.Write("Se presento error");
                return BadRequest(json.Result);
            }
            else
            {
                Console.Write("Success");
                var res = json.Result.ToString();
                var resProducer = kafka.ProducerTopic(res, topic);
                if (resProducer)
                {
                    responseJson = "Se ha realizado la publicacion del Topic de servicios publicos" + " // " + topic;
                }
                else
                {
                    responseJson = "No se ha publicado el Topic ";
                }
                return Ok(responseJson);
            }

        }

        [HttpPost]
        [Route("PagoCompensar")]
        public IActionResult PagoCompensar(string referenciaFactura, double valorTotal)
        {
            services = new services();
            var response = services.pagoCompensar(referenciaFactura, valorTotal);
            return Ok(response);

        }

        [HttpGet]
        [Route("getFactura")]
        public IActionResult GetGactura(string referenciaFactura)
        {
            services = new services();
            var response = services.GetFactura(referenciaFactura);
            return Ok(response);
        }

        [HttpPost]
        [Route("PagoFactura")]
        public IActionResult PagoFactura(string referenciaid, double valorTotalfact)
        {
            services = new services();
            var response = services.PagarFactura(referenciaid, valorTotalfact);
            return Ok(response);

        }

        [HttpGet]
        [Route("MediosdePago")]
        public IActionResult MediosdePago(string topic)
        {
            kafka = new serviceKafka();
            services = new services();
            var response = services.getMediosPagos();
            var json = response.Content.ReadAsStringAsync();
            var responseJsonD = string.Empty;
            if (!response.IsSuccessStatusCode)
            {
                Console.Write("Se presento error");
                return BadRequest(json.Result);
            }
            else
            {
                Console.Write("Success");
                var res = json.Result.ToString();
                var resProducer = kafka.ProducerTopic(res, topic);
                if (resProducer)
                {
                    responseJsonD = "Se ha realizado la publicacion del Topic medios de pagos" + " // " + topic;
                }
                else
                {
                    responseJsonD = "No se ha publicado el Topic ";
                }
                return Ok(responseJsonD);
            }

        }

        [HttpGet]
        [Route("ValidateBalance")]
        public IActionResult ValidateBalance(string numberTarjet)
        {
            services = new services();
            var response = services.ValidateBalance(numberTarjet);
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


        [HttpGet]
        [Route("ConsultaFactura")]
        public IActionResult ConsultaFactura(int numeroFactura, string topic)
        {
            kafka = new serviceKafka();
            services = new services();
            var response = services.FacturaAgua(numeroFactura);
            var json = response.Content.ReadAsStringAsync();
            var responseJsonD = string.Empty;
            if (!response.IsSuccessStatusCode)
            {
                Console.Write("Se presento error");
                return BadRequest(json.Result);
            }
            else
            {
                Console.Write("Success");
                var res = json.Result.ToString();
                var resProducer = kafka.ProducerTopic(res, topic);
                if (resProducer)
                {
                    responseJsonD = "Se ha realizado la publicacion del Topic factura de agua" + " // " + topic;
                }
                else
                {
                    responseJsonD = "No se ha publicado el Topic ";
                }
                return Ok(responseJsonD);
            }

        }



    }
}
