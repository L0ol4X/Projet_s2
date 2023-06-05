using Modele;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;

namespace TestsProject
{
    public class TestAccount
    {
        [Theory]
        [InlineData("", "Kevin35leboss")]
        [InlineData("Jean Patate", "Kevin35leboss")]
        public void TestWithVoidField(string pseudo, string password)
        {
            try
            {
                new Account(pseudo, password);
            }
            catch (ArgumentException ex)
            {

                Assert.Equal("The fields <password> and <pseudo> must be filled or non_white spaces", ex.Message);
            }
        }
        

        [Theory]
        [InlineData("bibou", "Kevin35leboss")]
        [InlineData("coucou", "        ")]
        [InlineData("Jean Patate", "Kevin35leboss")]
        [InlineData("Aled", "jcodp")]
        [InlineData("bis", "s")]
        public void TestShortPasswd(string pseudo, string password) 
        { 
            try
            {
                new Account(pseudo, password);
            }
            catch(ArgumentException e)
            {
                Assert.Equal("The password must be at least long of 8 characters", e.Message);
            }
        }

        [Fact]
        public void TestVoidAccount()
        {
            Account voidA = new Account();
            Assert.Null(voidA.UserName);
        }

        [Fact]
        public void TestAddFavIng()
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

            Account a = new Account("pablo", "picassooo");//création d'un nouveau compte correct
            a.AddFav(Soupe);

            Assert.Contains(Soupe, a.FavList);
        }

        [Fact]
        public void TestEqualsAccount()
        {
            Account a1 = new Account("Jeanine", "jyconnaisrienalinfo");
            Account a2 = new Account("Jeanine", "jyconnaisrienalinfo");
            Assert.True(a1.Equals(a2));

            Account a3 = new Account("Jeanine", "jyconnaisrienalinfo");
            Account? a4 = null;
            Assert.False(a3.Equals(a4));

            Assert.False(a3.Equals(new Quantite(4, "g")));
            Assert.False(a3.Equals(null));
        }


        [Fact]
        public void TestToString()
        {
            Account a1 = new Account("Jeanine", "jyconnaisrienalinfo");
            Recipe r1 = new Recipe("apero", Category.Entree, "toasts", "facile", new List<Ingredient>(), "tartiner de beurre vos toasts puis ajouter le quart d'une tranche de saumon et enfin, vous pouvez ajouter une petite rondelle de citron au besoin.", 15, 1, new List<Rating>(), "");
            Recipe r2 = new Recipe("sauce", Category.Aperitifs, "Sauce ciboulette", "fa-cile", new List<Ingredient>(), "dans un bol, ajoutez trois cuilleres de fromages blanc, de la ciboulette coupee en fin morceaux et du citron, melangez et c'est pret !", 5,1,new List<Rating>(), "");
            a1.AddFav(r1);
            a1.AddFav(r2);

            StringBuilder sbfavlist = new StringBuilder($"{a1.UserName} : ");
            if (a1.FavList.Count != 0)
            {
                for (int i = 0; i < a1.FavList.Count; i++)
                {
                    sbfavlist.Append(", " + a1.FavList[i].Name);
                }
            }

            Assert.Equal(sbfavlist.ToString(), a1.ToString());
        }


        [Theory]
        [InlineData("jp")]
        [InlineData("lola")]
        [InlineData("cathrine")]
        [InlineData("s4like")]
        [InlineData("sUlly")]
        [InlineData("hervedu50")]
        [InlineData("monse")]
        public void TestGetHashCode(string nom)
        {
            Account a = new Account(nom, "lalalalalala");
            Assert.Equal(a.UserName.GetHashCode(), a.GetHashCode());
        }



        [Fact]
        public void TestSeeFav()
        {
            Account a1 = new Account("Jeanine", "jyconnaisrienalinfo");
            Recipe r1 = new Recipe("apero", Category.Entree, "toasts", "facile", new List<Ingredient>(), "tartiner de beurre vos toasts puis ajouter le quart d'une tranche de saumon et enfin, vous pouvez ajouter une petite rondelle de citron au besoin.", 15, 1, new List<Rating>(), "");
            Recipe r2 = new Recipe("sauce", Category.Aperitifs, "Sauce ciboulette", "fa-cile", new List<Ingredient>(), "dans un bol, ajoutez trois cuilleres de fromages blanc, de la ciboulette coupee en fin morceaux et du citron, melangez et c'est pret !", 5, 1, new List<Rating>(), "");
            a1.AddFav(r1);
            a1.AddFav(r2);

            StringBuilder sb = new StringBuilder(a1.FavList[0].Name);
            for (int i = 1; i < a1.FavList.Count; i++)
            {
                sb.Append(", " + a1.FavList[i].Name);
            }

            Assert.Equal(sb.ToString(), a1.SeeFav());
        }
    }
}