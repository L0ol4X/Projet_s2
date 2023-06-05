using SaveMgr;
namespace app;

using Modele;
using System.Collections.ObjectModel;
using Application = Microsoft.Maui.Controls.Application;

public partial class Meal : ContentPage
{
    public ApplicationManager Manager = (Application.Current as App).Manager;
    public Recipes Soucat { get; set; } = new Recipes();
    public Meal()
	{
        (Application.Current as App).listR = Manager.MyApp.Recipes.SearchCatWst(Category.Plat);
        InitializeComponent();
        BindingContext = (Application.Current as App).listR;


        Soucat.ListRecipes = (Application.Current as App).listR;
    }

    private void Quiche_Clicked(object sender, EventArgs e)
    {
        (Application.Current as App).DownCategory = Soucat.SearchDownCat("quiche");
        Navigation.PushAsync(new CollectionDisplay());
    }

    private void Viande_Clicked(object sender, EventArgs e)
    {
        (Application.Current as App).DownCategory = Soucat.SearchDownCat("base viande");
        Navigation.PushAsync(new CollectionDisplay());
    }

    private void Salade_Clicked(object sender, EventArgs e)
    {
        (Application.Current as App).DownCategory = Soucat.SearchDownCat("salades");
        Navigation.PushAsync(new CollectionDisplay());
    }

    private void But_Clicked(object sender, EventArgs e)
    {
        (Microsoft.Maui.Controls.Application.Current as App).SelectedRecipe = (Recipe)(sender as Button).BindingContext;
        Navigation.PushAsync(new RecipeDisplay());
    }
}