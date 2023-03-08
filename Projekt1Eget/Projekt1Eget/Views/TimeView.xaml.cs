using Microsoft.Maui.Controls;
using Microsoft.Maui;
using Projekt1Eget.Models;

namespace Projekt1Eget.Views;

public partial class TimeView : ContentPage
{
	public TimeView()
    {
        InitializeComponent();
	}
    private async void GetTime(string region,string city)
    {

        string input = "timezone/" + region + "/" + city;
        while (true)
        {

            var a = ViewModel.ViewTime.GetTimeForACity(input);
            if (await a != null)
            {
                var forSplit = (await a).datetime.ToString().Split('T', '.');
                var outPut = forSplit[1];
                if (city == "Stockholm")
                {
                TimeSweden.Text = outPut;

                CitySweden.Text = $"Tid i staden {city}";

                }
                if (city == "London")
                {
                    TimeLondon.Text = outPut;

                    CityEngland.Text = $"Tid i staden {city}";
                }
                if(city== "Moscow")
                {
                    TimeMoskva.Text = outPut;
                    CityRussia.Text= $"Tid i staden {city}";
                }
            }

        }
    }
    private void GetTimeSweden(object sender, EventArgs e)
    {
        string region = "Europe";
        string city = "Stockholm";

        GetTime(region,city);
    }
    private void GetTimeInputLondon(object sender, EventArgs e)
    {
       string region = "Europe";
        string city = "London";

        GetTime(region, city);
    }

    private void GetTimeInputMoskva(object sender, EventArgs e)
    {
        string region = "Europe";
        string city = "Moscow";
        GetTime(region, city);
    }

    private void GoBack(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}