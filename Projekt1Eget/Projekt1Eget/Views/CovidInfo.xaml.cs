namespace Projekt1Eget.Views;

public partial class CovidInfo : ContentPage
{
	public CovidInfo()
	{
		InitializeComponent();
	}

    private void GetAmountOfTotalCovidSickness(object sender, EventArgs e)
    {
		var output = ViewModel.CovidView.AmountOfCovidWorldWide();
        var noReturn = ViewModel.CallMethods.CatchReturn();
        if (output == noReturn)
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