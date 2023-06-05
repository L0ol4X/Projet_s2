using Modele;
using SaveMgr;

namespace app;

public partial class Favorites : ContentPage
{
    public ApplicationManager mgr = (Microsoft.Maui.Controls.Application.Current as App).Manager;

    public Favorites()
	{
		InitializeComponent();
		(Microsoft.Maui.Controls.Application.Current as App).listR = mgr.MyApp.CurUser.FavList;		
		BindingContext = (Microsoft.Maui.Controls.Application.Current as App).listR;
    }

    private void But_Clicked(object sender, EventArgs e)
    {
        (Microsoft.Maui.Controls.Application.Current as App).SelectedRecipe = (Recipe)(sender as Button).BindingContext;
        Navigation.PushAsync(new DisplayFav());
    }
}