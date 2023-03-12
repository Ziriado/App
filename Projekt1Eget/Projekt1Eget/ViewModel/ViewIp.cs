using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Projekt1Eget.ViewModel
{
    internal class ViewIp
    {
        public static async Task<string> GetIPAddress()
        {
            string address = "";
            try
            {
                address = await CallMethods.GetWebClient("http://checkip.dyndns.org/");

                int first = address.IndexOf("Address: ") + 9;
                int last = address.LastIndexOf("</body>");
                address = address.Substring(first, last - first);
            }
            catch (Exception e)
            {
                address = CallMethods.CatchReturn();
            }
            return address;
        }
        public static async Task<Models.Ip> GetIp(string uri)
        {
            Models.Ip myIp = null;
            var client = ViewModel.CallMethods.CreateApiClientForApiNinja();

            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                myIp = JsonSerializer.Deserialize<Models.Ip>(responseString);
            }

            return myIp;
        }
    }
}
