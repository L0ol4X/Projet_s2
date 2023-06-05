
using Microsoft.VisualBasic;
using Modele;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace JSonFile
{
    public class PersistanceJSon : ILoadable
    {
        private string FileName { get; }


        public PersistanceJSon() { }
        public Application Load()
        {
            Application application = new Application();
            application = LoadRecipes(application);
            application = LoadAccounts(application);
            return application;
        }

        public static Application LoadRecipes(Application app)
        { 
            var jsonserializer = new DataContractJsonSerializer(typeof(Recipes));
            Recipes? recipes;

            
            Directory.SetCurrentDirectory(Path.Combine(Directory.GetCurrentDirectory()));

            using (FileStream stream = File.OpenRead("recipes.json"))
            {
                recipes = jsonserializer.ReadObject(stream) as Recipes;
                if (recipes != null)
                {
                    for (int i = 0; i < recipes.ListRecipes.Count; i++)
                    {
                        app.Recipes.AddRecipe(recipes.ListRecipes[i]);
                    }
                }
            }
            return app;
        }

        public static Application LoadAccounts(Application app)
        {
            var jsonserializer = new DataContractJsonSerializer(typeof(Accounts));
            Accounts? accounts;

            
            Directory.SetCurrentDirectory(Path.Combine(Directory.GetCurrentDirectory()));

            using (FileStream stream = File.OpenRead("accounts.json"))
            {
                accounts = jsonserializer.ReadObject(stream) as Accounts;
                if (accounts != null)
                {
                    foreach (string username in accounts.DictAccounts.Keys)
                    {
                        app.Accounts.AddUser(accounts.DictAccounts[username]);
                    }
                }
            }
            return app;
        }

        public void Save(Application application)
        {
            SaveRecipes(application);
            SaveAccounts(application);
        }

        public static void SaveRecipes(Application application)
        {
            var jsonserializer = new DataContractJsonSerializer(typeof(Recipes));
            MemoryStream memoryStream = new MemoryStream();

            string currentpath = Directory.GetCurrentDirectory();
            Directory.CreateDirectory("Save");
            Directory.SetCurrentDirectory(Path.Combine(currentpath, "Save"));

            jsonserializer.WriteObject(memoryStream, application.Recipes);
            using (FileStream stream = File.Create("recipes.json"))
            {
                memoryStream.WriteTo(stream);
            }
        }

        public static void SaveAccounts(Application application)
        {
            var jsonserializer = new DataContractJsonSerializer(typeof(Accounts));
            MemoryStream memoryStream = new MemoryStream();

            string currentpath = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(currentpath);

            jsonserializer.WriteObject(memoryStream, application.Accounts);
            using (FileStream stream = File.Create("accounts.json"))
            {
                memoryStream.WriteTo(stream);
            }
        }
    }
}