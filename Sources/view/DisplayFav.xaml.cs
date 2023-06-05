using Modele;
using SaveMgr;

namespace app;

public partial class DisplayFav : ContentPage
{
    public static ApplicationManager mgr = (Microsoft.Maui.Controls.Application.Current as App).Manager;

    public Recipe SelectedRecipe { get; set; } = (Microsoft.Maui.Controls.Application.Current as App).SelectedRecipe;

    public DisplayFav()
	{
		InitializeComponent();
        BindingContext = this;
	}

    private void FavoriR_Clicked(object sender, EventArgs e)
    {
        if (mgr.MyApp.IsConnected)
        {
            Account current = mgr.MyApp.Accounts.FindUser(mgr.MyApp.CurUser.UserName);
            current.FavList.Remove(SelectedRecipe);
        }
    }
}