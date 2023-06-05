using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;

namespace Modele
{
    /// <summary>
    /// This class is the manager of the recipes.
    /// </summary>
    [DataContract]
    public class Recipes : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
      => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private ObservableCollection<Recipe> _recipes;
        [DataMember]
        public ObservableCollection<Recipe> ListRecipes
        {
            get
                => _recipes;
            set
            {
                if (_recipes == value) return;
                _recipes = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// This constructor build the collection with its arguments.
        /// </summary>
        /// <param name="recipes"></param>
        public Recipes(ObservableCollection<Recipe> recipes)
        {
            this.ListRecipes = recipes;
        }

        /// <summary>
        /// This empty constructor initializes the ListRecipes to a new one if no parameters.
        /// </summary>
        public Recipes()
        {
            ListRecipes = new ObservableCollection<Recipe>(); 
        }

        /// <summary>
        /// This function add a recipe to the collection of recipes.
        /// </summary>
        /// <param name="recipes"></param>
        public void AddRecipe(params Recipe[] recipes)
        {
            for (int i = 0; i < recipes.Length; i++)
            {
                ListRecipes.Add(recipes[i]);
            }
            
        }

        /// <summary>
        /// The redefinition of the ToString() method.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            foreach (Recipe item in ListRecipes)
            {
                str.Append(item.Name.ToString() + ", " + item.Level.ToString() + ", " + item.Time.ToString() + " min\n");
            }
            return str.ToString();
        }

        /// <summary>
        /// This function using LINQ to select the recipes that has the same category as the one given in parameter.
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        public ObservableCollection<Recipe> SearchCat(string cat)
        {
            var catAsCat = Enum.Parse(typeof(Category), cat);
            if (catAsCat.Equals(Category.Plat) ||catAsCat.Equals(Category.Aperitifs) || catAsCat.Equals(Category.PetiteFaim) || catAsCat.Equals(Category.Dessert) || catAsCat.Equals(Category.Entree))
            {
                ObservableCollection<Recipe> targets = (ObservableCollection<Recipe>)(from r in ListRecipes
                                                                                      where r.Cat.Equals(catAsCat)
                                                                                      select r);
                return targets;
            }
            return new ObservableCollection<Recipe>();            
        }

        /// <summary>
        /// This function using LINQ to select the recipes that has a name that contains the word given in parameter.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public List<Recipe> SearchName(string word)
        {
            var findname = from r in ListRecipes
                           where r.Name.Contains(word)
                           select r;
            return findname.ToList();
        }

        /// <summary>
        /// Search of recipes by category Without the STring.
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        public ObservableCollection<Recipe> SearchCatWst(Category cat)
        {
            ObservableCollection<Recipe> list = new ObservableCollection<Recipe>();
            foreach (Recipe recipe in ListRecipes)
            {
                if (recipe.Cat.Equals(cat))
                {
                    list.Add(recipe);
                }
            }
            return list;
        }

        /// <summary>
        /// This function is for the detail of the app (e.g. when we are in the category, it is to go to the subcategory)
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        public List<Recipe> SearchDownCat(string cat)
        {
            var findName = (from r in ListRecipes where r.Type == cat select r);
            return findName.ToList();
        }

    }
}
