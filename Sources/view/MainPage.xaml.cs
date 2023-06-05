using Modele;
namespace app;
using SaveMgr;
using System.Collections.ObjectModel;
using Application = Microsoft.Maui.Controls.Application;

public partial class MainPage : ContentPage
{
    public ApplicationManager Manager = (Application.Current as App).Manager;

    public ObservableCollection<Recipe> listR { get; set; } = new ObservableCollection<Recipe>();

    public Recipe SelectedRecipe { get; set; }

    public string SearchName { get; set; } = "";

    public MainPage()
    {
        listR = Manager.MyApp.Recipes.ListRecipes;
        BindingContext = this;
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        (Microsoft.Maui.Controls.Application.Current as App).SelectedRecipe = (Recipe)(sender as Button).BindingContext;
        Navigation.PushAsync(new RecipeDisplay());
    }

    private void Search_Clicked(object sender, EventArgs e)
    {
        (Application.Current as App).DownCategory = Manager.MyApp.Recipes.SearchName(SearchName);
        Navigation.PushAsync(new CollectionDisplay());
    }
}