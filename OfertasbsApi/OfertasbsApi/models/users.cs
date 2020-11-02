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
        public string displayName { get; set; }

    }

    public class userLogin
    {
        public string email { get; set; }
        public string password { get; set; }
        public bool returnSecureToken { get; set; }
    }

    public class userFirebase
    {

        public string kind  { get; set; }
        public string localId  { get; set; }

        public string email { get; set; }

        public string displayName { get; set; }

        public string idToken { get; set; }

        public bool registered { get; set; }

        public string refreshToken { get; set; }
        public string expiresIn { get; set; }
        public string rol { get; set; }
        public string rute { get; set; }


    }

    public class usersWithROL
    {
        public string email { get; set; }
        public string rol { get; set; }
        public string userID { get; set; }
        public string rute { get; set; }

    }

    public class userRegisterFirebase
    {
        public string kind { get; set; }
        public string idToken { get; set; }
        public string email { get; set; }
        public string refreshToken { get; set; }
        public string expiresIn { get; set; }
        public string localId { get; set; }
        public string rol { get; set; }
        public string idDB { get; set; }
        public string rute { get; set; }

    }

    public class userName
    {
        public string name { get; set; }
    }

}
