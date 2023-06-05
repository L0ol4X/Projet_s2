namespace app;
using Modele;
using SaveMgr;

public partial class ConnexionPage : ContentPage
{
    public ApplicationManager mgr = (Microsoft.Maui.Controls.Application.Current as App).Manager;
	public Account SelectedOne { get; set; } = new Account();

	public ConnexionPage()
	{
		InitializeComponent();
        BindingContext = SelectedOne;
    }


    private void CancelCo_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private void ValiderCo_Clicked(object sender, EventArgs e)
    {
        if (SelectedOne.UserName == null || SelectedOne.Passwd == null) { Navigation.PopAsync(); }
        else if (mgr.MyApp.LogIn(SelectedOne.UserName, SelectedOne.Passwd) == 1)
        {
            Navigation.PushAsync(new Connected());
        }
        Navigation.PopModalAsync();
    }
}