namespace app;
using Modele;
using SaveMgr;
using Application = Microsoft.Maui.Controls.Application;

public partial class AddRecipe : ContentPage
{
	public ApplicationManager Manager = (Application.Current as App).Manager;

	public Recipe ToAdd { get; set; } = new Recipe();

	public int NbIngs { get; set; } = 0;

	public List<string> Types { get; set; } = new List<string>() { "boissons", "feuillet�s", "brochettes", "salades", "cakes", "roul�s", "quiche", "base viande", "p�tisseries", "glac�", "g�teaux", "viennoiseries", "sucr�", "sal�" };
	public List<string> CostR { get; set; } = new List<string>() { "$", "$$", "$$$" };

	public List<string> LevelTS { get; set; } = new List<string>() { "Facile", "Interm�diaire", "Difficile" };
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