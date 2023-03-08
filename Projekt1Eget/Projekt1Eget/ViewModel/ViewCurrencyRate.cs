using Projekt1Eget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Projekt1Eget.ViewModel
{
    internal class ViewCurrencyRate
    {
        public static async Task<CurrencyRate> GetCurrenctValue(string uri)

        {
            var client = ViewModel.CallMethods.CreateApiClientForApiNinja();
            CurrencyRate currency = null;

            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                currency = JsonSerializer.Deserialize<CurrencyRate>(responseString);
            }

            return currency;
        }
    }
}
