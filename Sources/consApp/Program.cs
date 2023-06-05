// See https://aka.ms/new-console-template for more information
using Modele;
using SaveMgr;
using StubFile;
using System.Collections.ObjectModel;

namespace consApp
{
    public static class Program
    {
        static void ConnexionMenu()
        {
            ApplicationManager applicationStub = new ApplicationManager(new Stub());
            applicationStub.CreateApp();
            string answerstr = "";

            while (answerstr != "q")
            {
                Console.WriteLine("Welcome to Presto Cooko :)\n" +
                "tapez 1 pour connexion\n" +
                "tapez 2 pour s'inscrire\n" +
                "tapez 3 pour afficher les recettes de l'application\n" +
                "tapez 4 pour afficher tous les utilisateurs et leurs recettes favorites\n" +
                "tapez 5 pour chercher une recette en fonction d'une catégorie de recette\n" +
                "tapez 6 pour mettre une évaluation à une recette (en étant log)\n" +
                "tapez 7 pour mettre une recette en favori (en étant log)\n" +
                "tapez d pour se déconnecter\n" +
                "tapez s pour montrer les évaluations des recettes \n"+
                "tapez q pour quitter\n" +
                "tapez fav pour avoir accès à vos favoris (si vous êtes log)\n");
                answerstr = Console.ReadLine();
                int login;
                var usernamestr = string.Empty;
                var passwordstr = string.Empty;
                var passwordstr2 = string.Empty;

                switch (answerstr)
                {
                    case "q":
                        break;

                    case "1":
                        Console.Write("username : ");
                        usernamestr = Console.ReadLine();
                        Console.Write("password : ");
                        passwordstr = Console.ReadLine();
                        //readPassword(passwordstr); vu que ça return null je le mute temporairement (ou non) 
                        Console.WriteLine();
                        if (usernamestr == null || passwordstr == null) { return; }
                        login = applicationStub.MyApp.LogIn(usernamestr, passwordstr);
                        if (login != 0) { Console.WriteLine($"Bienvenue {usernamestr} !"); }
                        break;

                    case "2":
                        Console.Write("username : ");
                        usernamestr = Console.ReadLine();
                        Console.Write("password : ");
                        passwordstr = Console.ReadLine();
                        //readPassword(passwordstr);
                        Console.Write("Confirm password : ");
                        passwordstr2 = Console.ReadLine();
                        //readPassword(passwordstr2);
                        if (usernamestr == null || passwordstr == null || passwordstr2 == null) { return; }
                        else { applicationStub.MyApp.SignIn(usernamestr, passwordstr, passwordstr2); }
                        break;
                    case "3":
                        Console.WriteLine(applicationStub.MyApp.Recipes.ToString());
                        break;
                    case "4":
                        Console.WriteLine(applicationStub.MyApp.Accounts.ToString());
                        break;
                    case "5":
                        Console.WriteLine("Tapez le nom de la categorie à chercher");
                        string cat = Console.ReadLine();
                        ObservableCollection<Recipe> catR = applicationStub.MyApp.Recipes.SearchCat(cat);
                        if (catR == null) Console.WriteLine("empty");
                        else
                        {
                            foreach (Recipe r in catR) { Console.WriteLine(r.ToString()); }
                        }
                        
                        break;
                    case "6":
                        if (applicationStub.MyApp.IsConnected)
                        {
                            Console.WriteLine("entrez la recette à évaluer");
                            string recipeEval = Console.ReadLine();
                            List<Recipe> found2 = applicationStub.MyApp.Recipes.SearchName(recipeEval);
                            Console.WriteLine("Quel est le nombre d'étoiles à mettre ? (1-5)");
                            int nbetoiles = Int32.Parse(Console.ReadLine());
                            while (nbetoiles > 5 || nbetoiles < 0)
                            {
                                Console.WriteLine("Quel est le nombre d'étoiles à mettre ? (1-5)");
                                nbetoiles = Int32.Parse(Console.ReadLine());
                            }
                            Console.WriteLine("commentaire : ");
                            string com = Console.ReadLine();
                            Rating rate = new Rating(applicationStub.MyApp.CurUser, nbetoiles, com);
                            found2[0].AddRating(rate);
                        }
                        else
                        {
                            Console.WriteLine("il faut être connecté.e pour laisser un avis à la recette");
                        }
                        
                        break;
                    case "7":
                        Console.WriteLine("Tapez le nom de la recette à ajouter en favori");
                        string recipeToFav = Console.ReadLine();
                        List<Recipe> found = applicationStub.MyApp.Recipes.SearchName(recipeToFav);
                        if (found.Count == 0) { Console.WriteLine("pas trouvé"); }
                        Console.WriteLine(applicationStub.MyApp.IsConnected);
                        if (applicationStub.MyApp.IsConnected)
                        {
                            applicationStub.MyApp.CurUser.AddFav(found[0]);
                            Console.WriteLine($"La recette {found[0]} a bien été ajoutée aux favoris");
                        }                           
                        break;
                    case "d":
                        applicationStub.MyApp.LogOut();
                        Console.WriteLine("nouvel utilisateur : ", applicationStub.MyApp.CurUser.ToString());
                        break; 

                    case "fav":
                        if (applicationStub.MyApp.IsConnected)
                        {
                            Console.WriteLine(applicationStub.MyApp.CurUser.FavList);
                        }
                        else
                        {
                            Console.WriteLine("Vous n'êtes pas connecté.e vous ne pouvez pas avoir accès à vos favoris");
                        }
                        break;
                    case "s":
                        foreach (Recipe re in  applicationStub.MyApp.Recipes.ListRecipes)
                        {
                            Console.WriteLine(re.Name+" : \n"+re.DisplayEvals());
                        }
                        break;

                }

            }
        }
        /* ne fonctionne pas 
        static string readPassword(string pass)
        {
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    Console.Write("\b \b");
                    pass = pass[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    pass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            return pass;
        }
        */




        static void Main(string[] args)
        {
            //Stub stub = new Stub();
            //stub.Load(stub);
            ConnexionMenu();
            

        }
    }
}


