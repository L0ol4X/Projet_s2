using System;
using Modele;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestsProject
{
    public class TestRecipe
    {
        [Fact]
        public void TestNewRecipe()
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

            Assert.Contains(new Ingredient("chou", 1, ""), Soupe.Ings);
            Assert.True(Soupe.FindIng(new Ingredient("chou", 1, "")) != -1);
            Assert.Contains(new Ingredient("carottes", 12, ""), Soupe.Ings);
            Assert.Contains(new Ingredient("patates", 3, "kg"), Soupe.Ings);
            Assert.Contains(new Ingredient("eau", 30, "cl"), Soupe.Ings);
            Assert.Equal("soupe", Soupe.Name);
            Assert.Equal(Category.Plat, Soupe.Cat);
            Assert.Equal("Facile", Soupe.Level);
        }

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

            StringBuilder sb = new StringBuilder();
            sb.Append(Soupe.Name + " : ");
            foreach (Ingredient item in Soupe.Ings)
            {
                sb.Append(item.ToString() + ", ");
            }

            Assert.Equal(sb.ToString(), Soupe.ToString());
            
        }


        [Fact]
        public void TestAddRatingAndDisplay()
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


            Account pierre = new Account("pierre", "sisilafamille");
            Rating rate = new Rating(pierre, 1, "J'aime pas la soupe");
            Soupe.AddRating(rate);

            Assert.Contains(new Rating(pierre, 1, "J'aime pas la soupe"), Soupe.RatingsList);

            StringBuilder ev = new StringBuilder("Evaluations de la recette :\n");
            foreach (Rating eval in Soupe.RatingsList)
            {
                ev.Append(eval + "\n\n");
            }

            string display = Soupe.DisplayEvals();
            Assert.Equal(ev.ToString(), display);
        }

        [Fact]
        public void TestRemoveIng()
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

            Soupe.RemoveIng(soupeI);
            Assert.DoesNotContain(soupeI, Soupe.Ings);

        }

        [Fact]
        public void TestSearchIng()
        {
            Ingredient chou = new Ingredient("chou", 1, "");
            Recipe Soupetoujours = new Recipe("soupe", Category.Plat, "soupe", "Facile", new List<Ingredient>(), "Mixer le tout une fois cuit au bout de 20 minutes", 20, 1, new List<Rating>(), "");
            Soupetoujours.AddIngs(chou);

            int found = Soupetoujours.FindIng(chou);
            Assert.Equal(0, found);

            Ingredient pain = new Ingredient("pain", 2, "tranches");
            int foundpain = Soupetoujours.FindIng(pain);
            Assert.Equal(-1, foundpain);
        }
    }
}
