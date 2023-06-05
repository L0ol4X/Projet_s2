using Modele;
using System.Runtime.Serialization;
using System.Xml;

namespace XMLFile
{
    public class PersistanceXml : ILoadable
    {
        public PersistanceXml() {}

        public Application Load()
        {
            Application app = new Application();
            app = LoadRecipes(app);
            app = LoadAccounts(app);           

            return app;
        }


        public static Application LoadRecipes(Application application)
        {
            string xmlFile = "recipes.xml";
            Recipes? recipes;

            var serializer = new DataContractSerializer(typeof(Recipes));

            Directory.SetCurrentDirectory(Path.Combine(Directory.GetCurrentDirectory()));

            using (Stream s = File.OpenRead(xmlFile))
            {
                recipes = serializer.ReadObject(s) as Recipes;
                if (recipes != null)
                {
                    for (int i = 0; i < recipes.ListRecipes.Count; i++)
                    {
                        application.Recipes.AddRecipe(recipes.ListRecipes[i]);
                    }

                }
            }
            return application;
        }

        public static Application LoadAccounts(Application application)
        {
            string xmlFile = "accounts.xml";
            Accounts? accounts;

            var serializer = new DataContractSerializer(typeof(Accounts));

            Directory.SetCurrentDirectory(Path.Combine(Directory.GetCurrentDirectory()));

            using (Stream s = File.OpenRead(xmlFile))
            {
                accounts = serializer.ReadObject(s) as Accounts;
                if (accounts != null)
                {
                    foreach (string username in accounts.DictAccounts.Keys)
                    {
                        application.Accounts.AddUser(accounts.DictAccounts[username]);
                    }

                }
            }
            return application;
        }

        public void Save(Application application)
        {
            SaveRecipes(application);
            SaveAccounts(application);
        }

        public static void SaveRecipes(Application application)
        {
            var serializer = new DataContractSerializer(typeof(Recipes));

            string currentpath = Directory.GetCurrentDirectory();
            Directory.CreateDirectory("Save");
            Directory.SetCurrentDirectory(Path.Combine(currentpath, "Save"));
            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };

            using (TextWriter tw = File.CreateText("recipes.xml"))
            using (XmlWriter writer = XmlWriter.Create(tw, settings))
            {
                serializer.WriteObject(writer, application.Recipes);
            }
        }

        public static void SaveAccounts(Application application)
        {
            var serializer = new DataContractSerializer(typeof(Accounts));

            string currentpath = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(currentpath);
            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };

            using (TextWriter tw = File.CreateText("accounts.xml"))
            using (XmlWriter writer = XmlWriter.Create(tw, settings))
            {
                serializer.WriteObject(writer, application.Accounts);
            }
        }
    }
}