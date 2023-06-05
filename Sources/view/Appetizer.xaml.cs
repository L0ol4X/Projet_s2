using SaveMgr;
using Modele;
namespace app;
using Application = Microsoft.Maui.Controls.Application;



public partial class Appetizer : ContentPage
{
    public ApplicationManager Manager = (Application.Current as App).Manager;
    public Recipes Soucat { get; set; } = new Recipes();
    public Appetizer()
	{
        (Application.Current as App).listR = Manager.MyApp.Recipes.SearchCatWst(Category.Aperitifs);
        InitializeComponent();
        BindingContext = (Application.Current as App).listR;

        Soucat.ListRecipes = (Application.Current as App).listR;
    }

    private void Boisson_Clicked(object sender, EventArgs e)
    {
        (Application.Current as App).DownCategory = Soucat.SearchDownCat("boissons");
        Navigation.PushAsync(new CollectionDisplay());
    }

    private void Feuilletés_Clicked(object sender, EventArgs e)
    {
        (Application.Current as App).DownCategory = Soucat.SearchDownCat("feuilletés");
        Navigation.PushAsync(new CollectionDisplay());
    }

    private void Brochette_Clicked(object sender, EventArgs e)
    {
        (Application.Current as App).DownCategory = Soucat.SearchDownCat("brochettes");
        Navigation.PushAsync(new CollectionDisplay());
    }

    private void But_Clicked(object sender, EventArgs e)
    {
        (Microsoft.Maui.Controls.Application.Current as App).SelectedRecipe = (Recipe)(sender as Button).BindingContext;
        Navigation.PushAsync(new RecipeDisplay());
    }

}