using Modele;
using SaveMgr;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Application = Microsoft.Maui.Controls.Application;

namespace app;

public partial class RecipeDisplay : ContentPage
{
    public static ApplicationManager mgr = (Application.Current as App).Manager;
   
    public Recipe SelectedRecipe { get; set; } = (Application.Current as App).SelectedRecipe;


    public RecipeDisplay()
	{
		InitializeComponent();
		BindingContext = this;
	}

    private void Favori_Clicked(object sender, EventArgs e)
    {
        if (mgr.MyApp.IsConnected)
        {
            Account current = mgr.MyApp.Accounts.FindUser(mgr.MyApp.CurUser.UserName);
            current.AddFav(SelectedRecipe);
        }        
    }

}

