using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace mvcProject
{
    public static class Globalvariables
    {
        public static HttpClient WebApiClient = new HttpClient();
        static Globalvariables()
        {
            WebApiClient.BaseAddress = new Uri("https://localhost:44301/api/");
            WebApiClient.DefaultRequestHeaders.Clear();//First I clear the requestHeader 
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}