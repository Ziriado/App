using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Projekt1Eget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Projekt1Eget.ViewModel
{
    internal class ViewWeather
    {

        public static async Task<Weather> GetWeatherInfoOneCity(string uri)
        {
            var client = ViewModel.CallMethods.CreateApiClientForApiNinja();

            Weather weather = null;

            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                weather = JsonSerializer.Deserialize<Weather>(responseString);
            }

            return weather;
        }
    }
}
