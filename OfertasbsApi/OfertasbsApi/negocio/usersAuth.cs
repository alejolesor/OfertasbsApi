using Microsoft.AspNetCore.Http;
using OfertasbsApi.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace OfertasbsApi.negocio
{

    public class usersAuth
    {
        private string keyfire = "AIzaSyA_77661e1_smtGKLCXEojUcccPZKvkHxQ";
        private string URL = "https://identitytoolkit.googleapis.com/v1";


        public HttpResponseMessage registerUser(users value)
        {
            var endpoint = URL + "/accounts:signUp?key=" + keyfire;
            var client = new HttpClient();
            users p = new users { email = value.email, password = value.password, returnSecureToken = true};
            var response = client.PostAsJsonAsync(endpoint, p).Result;
            client.Dispose();
            return response;
        }

        public HttpResponseMessage loginAuth(userLogin value)
        {
            var endpoint = URL + "/accounts:signInWithPassword?key=" + keyfire;
            var client = new HttpClient();
            userLogin p = new userLogin { email = value.email, password = value.password, returnSecureToken = true };
            var response = client.PostAsJsonAsync(endpoint, p).Result;
            client.Dispose();
            return response;
        }
    }
}
