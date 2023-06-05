using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele;

namespace TestsProject
{
    public class TestRecipes
    {
        [Fact]
        public void TestToString()
        {
            Ingredient soupeI = new Ingredient("chou", 1, "");
            Ingredient soupeI2 = new Ingredient("carottes", 12, "");
            Ingredient soupeI3 = new Ingredient("patates", 3, "kg");
            Ingredient soupeI4 = new Ingredient("eau", 30, "cl");
            Recipe Soupe = new Recipe("soupe", Category.Plat, "soupe", "Facile", new List<Ingredient>(), "Mixer le tout une fois cuit au bout de 20 minutes", 20, 1, new List<Rating>(), "");
            Soupe.AddIngs(soupeI);
            Soupe.AddIngs(soupeI2);
            Soupe.AddIngs(soupeI3);
            Soupe.AddIngs(soupeI4);

            Ingredient tarteI = new Ingredient("pommes", 5, "");
            Ingredient tarteI2 = new Ingredient("pate feuilletée", 1, "");
            Ingredient tarteI3 = new Ingredient("sucre", 90, "g");
            Ingredient tarteI4 = new Ingredient("oeufs", 2, "");
            Ingredient tarteI5 = new Ingredient("beurre", 60, "g");
            Recipe TartePommes = new Recipe("tarte", Category.Dessert, "tarte aux pommes", "Facile", new List<Ingredient>(), "coupez les pommes en morceaux.\n Faites fondre le beurre dans une casserole.\n" +
                "Dans un saladier, melangez les oeufs, le sucre et le beurre fondu.\n Etalez la pate dans un moule et disposez y les morceaux de pommes\n Ajoutez ensuite le beurre, les oeufs et le sucre.\n" +
                "Faites cuire a 200° (thermostat 7) pendant 30 min", 30, 1, new List<Rating>(), "");
            TartePommes.AddIngs(tarteI);
            TartePommes.AddIngs(tarteI2);
            TartePommes.AddIngs(tarteI3);
            TartePommes.AddIngs(tarteI4);
            TartePommes.AddIngs(tarteI5);

            Recipes recipes = new Recipes();
            recipes.AddRecipe(TartePommes);
            recipes.AddRecipe(Soupe);

            StringBuilder sb = new StringBuilder();
            foreach (Recipe item in recipes.ListRecipes)
            {
               sb.Append(item.Name.ToString() + ", " + item.Level.ToString() + ", " + item.Time.ToString() + " min\n");
            }

            Assert.Equal(sb.ToString(), recipes.ToString()); 
        }

        [Fact]
        public void TestSearch()
        {
            Ingredient eau = new Ingredient("eau", 25, "cL");
            Recipe tea = new Recipe("boisson", Category.PetiteFaim, "tea", "Facile", 
                                    new List<Ingredient>() { eau }, "faire bouillir l'eau et ajouter le sachet",
                                    3, 0, new List<Rating>(), "");
            Ingredient nouilles_instant = new Ingredient("nouilles", 200, "g");
            Recipe nouilles = new Recipe("rapide", Category.Plat, "nouilles", "Facile",
                                    new List<Ingredient>() { eau, nouilles_instant }, "faire bouillir l'eau et la verser dans le bol",
                                    5, 0, new List<Rating>(),"");
            Recipes etudiant = new Recipes(new ObservableCollection<Recipe>() { nouilles, tea });

            ObservableCollection<Recipe> recipes_ = new ObservableCollection<Recipe>() { tea };
            Recipes list = new Recipes();
            list.ListRecipes = recipes_;
            List<Recipe> list2 = new List<Recipe>();
            list2 = etudiant.SearchName("tea");


            

            Assert.Equal(list.ListRecipes, list2);

        }
    }
}
