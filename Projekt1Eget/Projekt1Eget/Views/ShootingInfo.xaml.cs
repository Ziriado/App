namespace Projekt1Eget.Views;

public partial class ShootingInfo : ContentPage
{
	public ShootingInfo()
	{
		InitializeComponent();
	}
    private void GetAmountofShootings(object sender, EventArgs e)
    {
        GetAmountofShootings1();
    }

    private async void GetAmountofShootings1()
    {
        var htmlContent = await ViewModel.CallMethods.GetWebClient("https://bombings.incharts.se/sv/skjutningar/kommun/stockholm");
        var amount = ViewModel.ShootingViews.AmountOfShootings(htmlContent);
        var date = ViewModel.ShootingViews.DateOfLastShooting(htmlContent);
        var infoShooting = ViewModel.ShootingViews.LastShootingInfo(htmlContent);
        

        if (await amount != "null")
        {
            ShootingAmount.Text = amount.Result;
        }
        else
        {
            ShootingAmount.Text = "Gick inte att hämta någon data försök igen senare eller kontakta admin";
        }

       
        if (await date != "null")
        {

            DateofShooting.Text = "Senaste skjutningen: " + date.Result;
        }
        else
        {
            DateofShooting.Text = "Gick inte att hitta något datum för senaste skjutningen.";
        }

        
        if (await infoShooting != "null")
        {
            InfoLastShooting.Text = "Info: " + infoShooting.Result;
        }
        else
        {
            InfoLastShooting.Text = "Gick inte att hämta någon info om senaste skjutningen";
        }

    }

 

    private void GoBack(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}