using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Projekt1Eget.ViewModel
{
    internal class ViewTime
    {
        public static async Task<Models.Time> GetTimeForACity(string uri)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://worldtimeapi.org/api/");


            Models.Time time = null;



            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                time = JsonSerializer.Deserialize<Models.Time>(responseString);
            }

            return time;
        }
    }
}
