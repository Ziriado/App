using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1Eget.ViewModel
{
    class CallMethods
    {
        public static string GetWebClient(string url)
        {
            string htmlContent = new System.Net.WebClient().DownloadString(url);

            return htmlContent;
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
    }
}
