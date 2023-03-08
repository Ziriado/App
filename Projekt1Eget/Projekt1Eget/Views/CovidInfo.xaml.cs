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
        if (output == "null")
        {
            CoronaInfo.Text = "Det gick inte att hitta någon data kontakta admin eller försök senare";
        }
        else
        {
		CoronaInfo.Text = "Totalt antal bekräftade Covid fall sen Covid bröt ut i världen " + output;

        }
    }

    private void GoBack(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}