namespace app;
using Modele;
using SaveMgr;
using Application = Microsoft.Maui.Controls.Application;

public partial class AddRecipe : ContentPage
{
	public ApplicationManager Manager = (Application.Current as App).Manager;

	public Recipe ToAdd { get; set; } = new Recipe();

	public int NbIngs { get; set; } = 0;

	public List<string> Types { get; set; } = new List<string>() { "boissons", "feuilletés", "brochettes", "salades", "cakes", "roulés", "quiche", "base viande", "pâtisseries", "glacé", "gâteaux", "viennoiseries", "sucré", "salé" };
	public List<string> CostR { get; set; } = new List<string>() { "$", "$$", "$$$" };

	public List<string> LevelTS { get; set; } = new List<string>() { "Facile", "Intermédiaire", "Difficile" };
	public List<Category> Categories { get; set; } = new List<Category>{ Modele.Category.Entree, Modele.Category.Plat, Modele.Category.PetiteFaim, Modele.Category.Aperitifs, Modele.Category.Dessert };
	public AddRecipe()
	{
		InitializeComponent();
		BindingContext = this;
	}

    private async void Ings_Clicked(object sender, EventArgs e)
    {
		(Application.Current as App).SelectedRecipe = ToAdd;
		await Navigation.PushAsync(new IngsForRecipe(NbIngs));
    }
}