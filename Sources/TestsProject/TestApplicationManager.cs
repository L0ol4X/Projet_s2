using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveMgr;
using JSonFile;
using Modele;
using XMLFile;

namespace TestsProject
{
    public class TestApplicationManager
    {
        [Fact]
        public void TestManagerJson()
        {
            ApplicationManager smgr = new ApplicationManager(new PersistanceJSon());
            ApplicationManager smgr2 = new ApplicationManager(new PersistanceJSon());

            Ingredient soupeI = new Ingredient("chou", 1, "");
            Ingredient soupeI2 = new Ingredient("carottes", 12, "");
            Ingredient soupeI3 = new Ingredient("patates", 3, "kg");
            Ingredient soupeI4 = new Ingredient("eau", 30, "cl");
            Recipe Soupe = new Recipe("soupe", Category.Plat, "soupe", "Facile", new List<Ingredient>(), "Mixer le tout une fois cuit au bout de 20 minutes", 20, 1, new List<Rating>(), "");
            Soupe.AddIngs(soupeI);
            Soupe.AddIngs(soupeI2);
            Soupe.AddIngs(soupeI3);
            Soupe.AddIngs(soupeI4);


            Recipe recipe = new Recipe("sandwich", Category.PetiteFaim,
                                       "sandwich jambon beurre", "facile",
                                       new List<Ingredient>(),
                                       "ajouter le beurre puis le jambon au pain prealablement coupe en deux",
                                       5, 1, new List<Rating>(), "");
            Ingredient pain = new Ingredient("pain", 1, "");
            Ingredient beurre = new Ingredient("beurre", 5, "g");
            Ingredient jambon = new Ingredient("jambon", 3, "tranches");
            Ingredient[] ings = { pain, beurre, jambon };
            recipe.AddIngs(ings);

            smgr.MyApp.Recipes.AddRecipe(Soupe);
            smgr.MyApp.Recipes.AddRecipe(recipe);

            Account patoche = new Account("patrick", "patochelabrioche");
            Account marie = new Account("marie", "monchatcestlemeilleur");

            smgr.MyApp.Accounts.AddUser(marie);
            smgr.MyApp.Accounts.AddUser(patoche);

            smgr.SaveApp();

            smgr2.CreateApp();

            foreach (string user in smgr2.MyApp.Accounts.DictAccounts.Keys)
            {
                Console.WriteLine(user);
                Assert.True(smgr.MyApp.Accounts.DictAccounts.ContainsKey(user));
            }

        }




        [Fact]
        public void TestManagerxml()
        {
            ApplicationManager smgr = new ApplicationManager(new PersistanceXml());
            ApplicationManager smgr2 = new ApplicationManager(new PersistanceXml());

            Ingredient soupeI = new Ingredient("chou", 1, "");
            Ingredient soupeI2 = new Ingredient("carottes", 12, "");
            Ingredient soupeI3 = new Ingredient("patates", 3, "kg");
            Ingredient soupeI4 = new Ingredient("eau", 30, "cl");
            Recipe Soupe = new Recipe("soupe", Category.Plat, "soupe", "Facile", new List<Ingredient>(), "Mixer le tout une fois cuit au bout de 20 minutes", 20, 1, new List<Rating>(), "");
            Soupe.AddIngs(soupeI);
            Soupe.AddIngs(soupeI2);
            Soupe.AddIngs(soupeI3);
            Soupe.AddIngs(soupeI4);


            Recipe recipe = new Recipe("sandwich", Category.PetiteFaim,
                                       "sandwich jambon beurre", "facile",
                                       new List<Ingredient>(),
                                       "ajouter le beurre puis le jambon au pain préalablement coupé en deux",
                                       5, 1, new List<Rating>(), "");
            Ingredient pain = new Ingredient("pain", 1, "");
            Ingredient beurre = new Ingredient("beurre", 5, "g");
            Ingredient jambon = new Ingredient("jambon", 3, "tranches");
            Ingredient[] ings = { pain, beurre, jambon };
            recipe.AddIngs(ings);

            smgr.MyApp.Recipes.AddRecipe(Soupe);
            smgr.MyApp.Recipes.AddRecipe(recipe);

            Account patoche = new Account("patrick", "patochelabrioche");
            Account marie = new Account("marie", "monchatcestlemeilleur");

            smgr.MyApp.Accounts.AddUser(marie);
            smgr.MyApp.Accounts.AddUser(patoche);

            smgr.SaveApp();


            smgr2.CreateApp();

            foreach (string user in smgr2.MyApp.Accounts.DictAccounts.Keys)
            {
                Console.WriteLine(user);
                Assert.True(smgr.MyApp.Accounts.DictAccounts.ContainsKey(user));
            }

        }
    }
}
