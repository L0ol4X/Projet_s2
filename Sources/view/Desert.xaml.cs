using SaveMgr;
using Modele;
namespace app;
using Application = Microsoft.Maui.Controls.Application;


public partial class Desert : ContentPage
{
    public ApplicationManager Manager = (Application.Current as App).Manager;
    public Recipes Soucat { get; set; } = new Recipes();
    public Desert()
	{
        (Application.Current as App).listR = Manager.MyApp.Recipes.SearchCatWst(Category.Dessert);
        InitializeComponent();
        BindingContext = (Application.Current as App).listR;


        Soucat.ListRecipes = (Application.Current as App).listR;
    }

    private void Gateaux_Clicked(object sender, EventArgs e)
    {
        (Application.Current as App).DownCategory = Soucat.SearchDownCat("gâteaux");
        Navigation.PushAsync(new CollectionDisplay());
    }

    private void Glace_Clicked(object sender, EventArgs e)
    {
        (Application.Current as App).DownCategory = Soucat.SearchDownCat("glacé");
        Navigation.PushAsync(new CollectionDisplay());
    }

    private void Patisserie_Clicked(object sender, EventArgs e)
    {        
        (Application.Current as App).DownCategory = Soucat.SearchDownCat("pâtisseries");
        Navigation.PushAsync(new CollectionDisplay());
    }

    private void But_Clicked(object sender, EventArgs e)
    {
        (Microsoft.Maui.Controls.Application.Current as App).SelectedRecipe = (Recipe)(sender as Button).BindingContext;
        Navigation.PushAsync(new RecipeDisplay());
    }
}