namespace Projekt1Eget.Views;

public partial class CovidInfo : ContentPage
{
	public CovidInfo()
	{
		InitializeComponent();
	}

    private async void GetAmountOfTotalCovidSickness(object sender, EventArgs e)
    {
        var htmlContent = await ViewModel.CallMethods.GetWebClient("https://www.worldometers.info/coronavirus/");
        var output = ViewModel.CovidView.AmountOfCovidWorldWide(htmlContent);
        var noOutput = ViewModel.CallMethods.CatchReturn();
        if (output == noOutput)
        {
            CoronaInfo.Text = "Det gick inte att hitta n�gon data kontakta admin eller f�rs�k senare";
        }
        else
        {
            CoronaInfo.Text = "Totalt antal bekr�ftade Covid fall sen Covid br�t ut i v�rlden " + output;

        }
    }

    private void GoBack(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}