namespace app;
using Modele;
using SaveMgr;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using Application = Microsoft.Maui.Controls.Application;

public partial class IngsForRecipe : ContentPage
{
	public ApplicationManager Manager { get; set; } = (Application.Current as App).Manager;

    public List<string> Unites { get; set; } = new List<string>() { "cL", "L", "g", "kg", "boîtes", "CàS", "CàC", " ", "mL", "mg", "pincée.s"};
    public List<Ingredient> Inlist { get; set; } = new List<Ingredient>();
    public IngsForRecipe(int nbIngs)
	{
		InitializeComponent();
       
        for (int i = 0; i < nbIngs; i++)
        {
            Inlist.Add(new Ingredient("",0," "));
        }
        
        BindingContext = this;
        /*
        Grid grid = new Grid
        {
            RowDefinitions =
            {
                new RowDefinition(),
                new RowDefinition()
            },
            ColumnDefinitions =
            {
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition()
            }
        };


        for (int i = 0; i < nbIngs; i++)
        {
            grid.AddRowDefinition(new RowDefinition());
        }



        for (int k = 1; k <= nbIngs; k++)
        {
            grid.Add(new Label
            {
                Text = $"Ingredient n°{k}"
            }, 0, k);

            Entry nameI = new Entry();
            nameI.SetBinding(Entry.TextProperty, new Binding("SelectedOne.Nom"));

            grid.Add(nameI, 1, k);


            grid.Add(new Entry
            {
                Text = "{Binding CurrentOne.Qtite}"
            }, 2, k);

            grid.Add(new Entry
            {
                Text = "{Binding CurrentOne.Unite}"
            }, 3, k);

        }
        Content = grid;
        */

    }

    private void OK_Clicked(object sender, EventArgs e)
    {
        foreach (Ingredient ing in Inlist)
        {
            (Application.Current as App).SelectedRecipe.AddIngs(ing);
        }
        
        Manager.MyApp.Recipes.AddRecipe((Application.Current as App).SelectedRecipe);
        (Application.Current as App).SelectedRecipe = new Recipe();
        Navigation.PopAsync();

    }
}
