namespace app;
using SaveMgr;
using Modele;
using Application = Microsoft.Maui.Controls.Application;


public partial class CollectionDisplay : ContentPage
{
	public ApplicationManager Manager = (Application.Current as App).Manager;

	public CollectionDisplay()
	{
        InitializeComponent();
        BindingContext = (Application.Current as App).DownCategory;
    }

    private void But_Clicked(object sender, EventArgs e)
    {
        (Microsoft.Maui.Controls.Application.Current as App).SelectedRecipe = (Recipe)(sender as Button).BindingContext;
        Navigation.PushAsync(new RecipeDisplay());
    }
}