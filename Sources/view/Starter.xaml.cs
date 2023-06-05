using SaveMgr;
namespace app;
using Modele;
using Application = Microsoft.Maui.Controls.Application;

public partial class Starter : ContentPage
{
    public ApplicationManager Manager = (Application.Current as App).Manager;
    public Recipes Soucat { get; set; } = new Recipes();

    public Starter()
	{
        (Application.Current as App).listR = Manager.MyApp.Recipes.SearchCatWst(Category.Entree);
        InitializeComponent();
        BindingContext = (Application.Current as App).listR;


        Soucat.ListRecipes = (Application.Current as App).listR;
    }

    private void Salade_Clicked(object sender, EventArgs e)
    {
        (Application.Current as App).DownCategory = Soucat.SearchDownCat("salades");
        Navigation.PushAsync(new CollectionDisplay());
    }


    private void Cake_Clicked(object sender, EventArgs e)
    {
        (Application.Current as App).DownCategory = Soucat.SearchDownCat("cakes");
        Navigation.PushAsync(new CollectionDisplay());
    }


    private void Roules_Clicked(object sender, EventArgs e)
    {
        (Application.Current as App).DownCategory = Soucat.SearchDownCat("roulés");
        Navigation.PushAsync(new CollectionDisplay());
    }

    private void But_Clicked(object sender, EventArgs e)
    {
        (Microsoft.Maui.Controls.Application.Current as App).SelectedRecipe = (Recipe)(sender as Button).BindingContext;
        Navigation.PushAsync(new RecipeDisplay());
    }
}