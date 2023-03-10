namespace Projekt1Eget.Views;

public partial class ShootingInfo : ContentPage
{
	public ShootingInfo()
	{
		InitializeComponent();
	}
    private async void GetAmountofShootings(object sender, EventArgs e)
    {
        var htmlContent = await ViewModel.CallMethods.GetWebClient("https://bombings.incharts.se/sv/skjutningar/kommun/stockholm");
        var amount = ViewModel.ShootingViews.AmountOfShootings(htmlContent);
        var date = ViewModel.ShootingViews.DateOfLastShooting(htmlContent);
        var infoShooting = ViewModel.ShootingViews.LastShootingInfo(htmlContent);

        var noReturn = ViewModel.CallMethods.CatchReturn();

        if (await amount != noReturn)
        {
            ShootingAmount.Text = amount.Result;
        }
        else
        {
            ShootingAmount.Text = "Gick inte att hämta någon data försök igen senare eller kontakta admin";
        }

       
        if (await date != noReturn)
        {

            DateofShooting.Text = "Senaste skjutningen: " + date.Result;
        }
        else
        {
            DateofShooting.Text = "Gick inte att hitta något datum för senaste skjutningen.";
        }

        
        if (await infoShooting != noReturn)
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