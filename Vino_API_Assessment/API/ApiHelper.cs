using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace Vino_API_Assessment.API
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }

        public static void InitializeClient()
        {
            var usr = "c6a5778bd92909a6";
            var psw = "ade51e327ebd2d642df926";
            var comb = Convert.ToBase64String(Encoding.Default.GetBytes(usr + ":" + psw)); ;
            ApiClient = new HttpClient();
            
            //ApiClient.BaseAddress = new Uri("");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/vnd.cpc.ship.rate-v4+xml"));//change to xml
            ApiClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", comb);
            ApiClient.DefaultRequestHeaders.Add("Accept-Language", "en-CA");
        }
    }
}