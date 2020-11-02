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
        public string EventDate { get; set; }
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
}
