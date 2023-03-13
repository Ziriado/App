using System.Net.WebSockets;
namespace Projekt1Eget;

public partial class MainPage : ContentPage
{
    static ViewModel.MainPageOneCityFromList city1 = ViewModel.MainPageOneCityFromList.GetCity();
    static ViewModel.MainPageOneCityFromList city2 = ViewModel.MainPageOneCityFromList.GetCity();

    public MainPage()
    {
        InitializeComponent();
    }

    private async void GoToIp(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.IpView());
    }
    private async void GoToShooting(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.ShootingInfo());
    }
    private async void GoTime(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.TimeView());
    }

    private async void GetCurrencyPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.CurrencyView());
    }
    private async void GetCovidPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.CovidInfo());
    }
    private async void GetWeatherpage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.WeatherView());
    }
    public async void CityOutput(object sender, EventArgs e)
    {
        //Selected singleton pattern to show that it is possible to use a list that containts several diffrent elements
        //but it will always take the next index in the list if you call for it several times. It would be very useful
        //when working with a queue system. 
        NextCity.Text = "Nästa element i listan: "+city1.GetNextCity();
        NextCity2.Text = "Elementet är nästa element i samma lista med en annan metod: "+city2.GetNextCity();
    }
}

