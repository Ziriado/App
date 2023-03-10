

using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using System.Net;

namespace Projekt1Eget.Views;

public partial class IpView : ContentPage
{
	public IpView()
	{
		InitializeComponent();
	}
	public async void GetIp(object sender, EventArgs e)
	{
		var ip=ViewModel.ViewIp.GetIPAddress();
        string ipstring = (await ip).ToString();
		var noReturn = ViewModel.CallMethods.CatchReturn();
		if (ipstring != noReturn)
		{
			var ipForApp = ViewModel.ViewIp.GetIp("v1/iplookup?address=" + ipstring);

			if (await ipForApp != null)
			{
				MyIp.Text = "Din publika ip adress är: " + ipForApp.Result.address;
				MyAdress.Text = "Du befinner dig i staden: " + ipForApp.Result.city;
				MyCountry.Text = "Som ligger i landet " + ipForApp.Result.country;
			}
			else
			{
				MyIp.Text = "Gick inte att få fram någon data nu försök igen senare";
			}
		}

		else
		{
			MyIp.Text = "Problem med att ta fram ip adressen prova igen senare";
		}
    }   
    private void GoBack(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

}