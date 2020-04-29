using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfertasbsApi.models
{
    public class users
    {
        public string email { get; set; }
        public string password { get; set; }
        public bool returnSecureToken { get; set; }
        public string name { get; set; }
        public string rol { get; set; }

    }

    public class userLogin
    {
        public string email { get; set; }
        public string password { get; set; }
        public bool returnSecureToken { get; set; }
    }
}
