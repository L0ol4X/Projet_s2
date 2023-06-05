using Modele;
using SaveMgr;
namespace app;
using Application = Microsoft.Maui.Controls.Application;



public partial class LittleDishes : ContentPage
{
    public ApplicationManager Manager = (Application.Current as App).Manager;
    public Recipes Soucat { get; set; } = new Recipes();


    public LittleDishes()
	{
        (Application.Current as App).listR = Manager.MyApp.Recipes.SearchCatWst(Category.PetiteFaim);
        InitializeComponent();
        BindingContext = (Application.Current as App).listR;


        Soucat.ListRecipes = (Application.Current as App).listR;
    }

    public void Viennoiserie_Clicked(object sender, EventArgs e)
    {
        (Application.Current as App).DownCategory = Soucat.SearchDownCat("viennoiseries");
        Navigation.PushAsync(new CollectionDisplay());
    }

    private void But_Clicked(object sender, EventArgs e)
    {
        (Microsoft.Maui.Controls.Application.Current as App).SelectedRecipe = (Recipe)(sender as Button).BindingContext;
        Navigation.PushAsync(new RecipeDisplay());
    }

    private void Sucre_Clicked(object sender, EventArgs e)
    {
        (Application.Current as App).DownCategory = Soucat.SearchDownCat("sucré");
        Navigation.PushAsync(new CollectionDisplay());
    }

    private void Sale_Clicked(object sender, EventArgs e)
    {
        (Application.Current as App).DownCategory = Soucat.SearchDownCat("salé");
        Navigation.PushAsync(new CollectionDisplay());
    }
}