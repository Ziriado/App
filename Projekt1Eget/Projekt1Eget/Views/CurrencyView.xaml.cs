namespace Projekt1Eget.Views;

public partial class CurrencyView : ContentPage
{
	public CurrencyView()
	{
		InitializeComponent();
	}
    private void GetCurrencyEUR(object sender, EventArgs e)
    {
        string currency1 = "EUR";
        string currency2 = "SEK";
        CurrencyParing(currency1, currency2);
    }
    private void GetCurrencyUSD(object sender, EventArgs e)
    {
        string currency1 = "USD";
        string currency2 = "SEK";
        CurrencyParing(currency1, currency2);
    }

    private void GetCurrencySEK(object sender, EventArgs e)
    {
        string currency1 = "SEK";
        string currency2 = "RUB";
        CurrencyParing(currency1, currency2);
    }

    private void GetCurrencyGBP(object sender, EventArgs e)
    {
        string currency1 = "GBP";
        string currency2 = "SEK";
        CurrencyParing(currency1, currency2);
    }
    private async void CurrencyParing(string currency1, string currency2)
    {
        string currency = ($"v1/exchangerate?pair={currency1}_{currency2}");

        var currencyForDisplay =  ViewModel.ViewCurrencyRate.GetCurrenctValue(currency);

        if (await currencyForDisplay != null)
        {
            Currency.Text = $"1 {currency1} ger dig " + Math.Round(currencyForDisplay.Result.exchange_rate, 2) + $" {currency2}";

        }
        else
        {
            Currency.Text = "Gick inte att ansluta till API försök igen senare";
        }
    }


    private void GoBack(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}