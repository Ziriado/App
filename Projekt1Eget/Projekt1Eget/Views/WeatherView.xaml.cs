using CommunityToolkit.Mvvm.ComponentModel;
using Projekt1Eget.Models;
using System.Diagnostics.Metrics;


namespace Projekt1Eget.Views;

public partial class WeatherView : ContentPage 
{
  
    public WeatherView()
	{
		InitializeComponent();
       
	}
    private async void GetWeatherAtYourLocation(object sender, EventArgs e)
    {
        var ip = ViewModel.ViewIp.GetIPAddress();
        string ipstring = (await ip).ToString();
        var ipForApp = ViewModel.ViewIp.GetIp(ViewModel.CallMethods.GetIpString(ipstring));
        if (await ipForApp != null)
        { 
            var city = ipForApp.Result.city;
            var country = ipForApp.Result.country;
            string weatherApi = ViewModel.CallMethods.WeatherApiString(city, country);

            var weatherForIp = await ViewModel.ViewWeather.GetWeatherInfoOneCity(weatherApi);

            if ( weatherForIp != null)
            {
                Weather.Text = "Det är " + weatherForIp.temp + " °C varmt i staden " + city + " som ligger i landet " +
                    country + " informationen är baserat på din IP adress";

                if (weatherForIp.temp < 2)
                {
                    PictureWeather.Source = "is.jpg";
                }

            }

            else
            {
                Weather.Text = "Gick inte att ansluta till API försök igen senare";
            }
        }
    }
    private async void GetWeatherWithInputs(object sender, EventArgs e)
    {
        var city1 = city.Text;
        var country1 = country.Text;
        var weatherApi= ViewModel.CallMethods.WeatherApiString(city1, country1);
        var weatherInputs = await ViewModel.ViewWeather.GetWeatherInfoOneCity(weatherApi);

        if (weatherInputs != null && country1!="null" &&  country1!="Null" && country1.Length>2)
        {
            InputWeatherText.Text = "Det är " + weatherInputs.temp + " °C varmt i staden " + city1 +
                " som ligger i landet " + country1;

            ClearText();
        }
      
        else
        {
            InputWeatherText.Text = "Det finns ingen data på det du har angivit";
            ClearText();
        }
    }
    private void ClearText()
    {
        city.Text = string.Empty;
        country.Text = string.Empty;
    }

    private void GoBack(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}