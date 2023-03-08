namespace Projekt1Eget.Views;

public partial class ShootingInfo : ContentPage
{
	public ShootingInfo()
	{
		InitializeComponent();
	}

    private void GetAmountofShootings(object sender, EventArgs e)
    {
        string url = "https://bombings.incharts.se/sv/skjutningar/kommun/stockholm";
        var amount = ViewModel.ShootingViews.AmountOfShootings(url);

        if (amount !="null")
        {
            ShootingAmount.Text = amount;
        }
        else
        {
            ShootingAmount.Text = "Gick inte att h�mta n�gon data f�rs�k igen senare eller kontakta admin";
        }

        var date=ViewModel.ShootingViews.DateOfLastShooting(url);

        if(date != "null")
        {

            DateofShooting.Text = "Senaste skjutningen: " + date;
        }
        else
        {
            DateofShooting.Text = "Gick inte att hitta n�got datum f�r senaste skjutningen.";
        }

        var infoShooting=ViewModel.ShootingViews.LastShootingInfo(url);

        if (infoShooting != "null")
        {
            InfoLastShooting.Text= "Info: "+infoShooting;
        }
        else
        {
            InfoLastShooting.Text = "Gick inte att h�mta n�gon info om senaste skjutningen";
        }
    }

    private void GoBack(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}