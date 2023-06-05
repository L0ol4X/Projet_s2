using SaveMgr;

namespace app;

public partial class Connected : ContentPage
{
	public ApplicationManager mgr = (Application.Current as App).Manager;

	public Connected()
	{
		InitializeComponent();
		BindingContext = mgr.MyApp.CurUser;
	}

    private async void Deco_Clicked(object sender, EventArgs e)
    {
		mgr.SaveApp();
		mgr.MyApp.LogOut();
		await Navigation.PopAsync();
    }

    private void Fav_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new Favorites());
    }
}