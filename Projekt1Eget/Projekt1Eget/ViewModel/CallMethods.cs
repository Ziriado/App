
using Projekt1Eget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Projekt1Eget.ViewModel
{
    class CallMethods
    {
        public static async Task<string> GetWebClient(string url)
        {
            string responseBody = "";
            try 
            { 
            var client = new HttpClient();
            using HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
             responseBody = await response.Content.ReadAsStringAsync();

            }

            catch (Exception e) 
                {
                responseBody = CatchReturn();
                } 

            return responseBody;

        }

        public static string CatchReturn()
        {
            string forReturn = "null";
            return forReturn;
        }

        public static HttpClient CreateApiClientForApiNinja()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.api-ninjas.com/");
            client.DefaultRequestHeaders.Add("X-Api-Key", "Qcxnt4nHksKM6BUvDU82BQ==HY6rAWgyWZVfU7Vz");

            return client;
        }
        public static string WeatherApiString(string city, string country)
        {
            string weatherApi = $"v1/weather?city={city},{country}";

            return weatherApi;
        }
        public static string GetIpString(string ipstring)
        {
            var myIpString = "v1/iplookup?address=" + ipstring;
            return myIpString;
        }
    }
}
