
using Modele;
using SaveMgr;
using JSonFile;
using StubFile;
using XMLFile;
using System.Collections.ObjectModel;

namespace app;

public partial class App : Microsoft.Maui.Controls.Application
{
    /// <summary>
    /// manager of accounts
    /// </summary>
    public ApplicationManager Manager { get; set; } = new ApplicationManager(new Stub());

    /// <summary>
    /// the list of recipes that will be selected on the different pages
    /// </summary>
    public ObservableCollection<Recipe> listR { get; set; } = new ObservableCollection<Recipe>();

    /// <summary>
    /// manager of recipes
    /// </summary>
    public Recipes Recipes { get; set; } = new Recipes();


    public List<Recipe> DownCategory { get; set; } = new List<Recipe>();

    public Recipe SelectedRecipe { get; set; } = new Recipe();

    public App()
	{
        Manager.CreateApp();
        InitializeComponent();
		MainPage = new AppShell();
		
	}
}
