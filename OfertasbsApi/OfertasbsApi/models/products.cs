using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OfertasbsApi.models
{
    public class products
    {
        public string? id { get; set; }
        public string Name { get; set; }
        public string EventDateString { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public string DestinationCity { get; set; }
        public string TransportType { get; set; }
        public int PeopleNumber { get; set; }
        public string OriginCity { get; set; }
        public DateTime LastUpdated { get; set; }

        [Display(Name = "File")]
        public IFormFile File { get; set; }

    }

    public class LogisticTransport
    {
        public string transportType { get; set; }
        public int passengersNumber { get; set; }
        public string originCityDescription { get; set; }
        public string destinationCityDescription { get; set; }
        public string departureDate { get; set; }
        public string returnDate { get; set; }
    }

    public class LogisticHotels
    {
        public int guestNumber { get; set; }
        public string city { get; set; }
        public string chekInDay { get; set; }
        public string chekOutDay { get; set; }
    }
}
