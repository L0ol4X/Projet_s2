using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
namespace Modele
{
    /// <summary>
    /// This class represents a recipe.
    /// </summary>
    [DataContract]
    public class Recipe : BaseRecipe, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
       => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private string type;
        [DataMember]
        public string Type 
        {
            get => type;
            set
            {
                if (type == value) return;
                type = value;
                OnPropertyChanged();
            }
        }


        private List<Rating> rating;
        [DataMember]
        public List<Rating> RatingsList 
        {
            get => rating;
            set
            {
                if (rating == value) return;
                rating = value;
                OnPropertyChanged();
            }
        }


        private List<Ingredient> ings;
        [DataMember]
        public List<Ingredient> Ings 
        {
            get => ings;
            set
            {
                if (ings == value) return;
                ings = value;
                OnPropertyChanged();
            }
        }


        private string steps;
        [DataMember]
        public string Steps
        {
            get => steps;
            set
            {
                if (steps == value) return;
                steps = value;
                OnPropertyChanged();
            }
        }

        private string imageName;
        [DataMember]
        public string ImageName
        {
            get => imageName;
            set
            {
                if (imageName == value) return;
                imageName = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// The constructor of the Recipe w=initializes all his parameters and properties.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="categorie"></param>
        /// <param name="name"></param>
        /// <param name="level"></param>
        /// <param name="ings"></param>
        /// <param name="steps"></param>
        /// <param name="time"></param>
        /// <param name="cost"></param>
        /// <param name="ratings"></param>
        /// <param name="imagename"></param>
        public Recipe(string type, Category categorie, string name, string level, List<Ingredient> ings, string steps, int time, int cost, List<Rating> ratings, string imagename) : base(name, level, time, cost, categorie)
        {
            Steps = steps;
            Ings = ings;
            Type = type;
            RatingsList = ratings;
            ImageName = imagename;
        }


        /// <summary>
        /// As some properties should not be null, it initialize to empty strings and lists.
        /// </summary>
        public Recipe() : base("", "", 0, 0, Category.Plat)
        {
            Steps = "";
            Ings = new List<Ingredient>();
            Type = "";
            RatingsList = new List<Rating>();
            ImageName = "";
        }


        /// <summary>
        /// This function add a rating to a recipe.
        /// </summary>
        /// <param name="eval"></param>
        public void AddRating(Rating eval)
        {
            RatingsList.Add(eval);
        }


        /// <summary>
        /// This function returns the range of the Ingredient to be found on the list, if not found, it returns -1.
        /// </summary>
        /// <param name="ingredient"></param>
        /// <returns></returns>
        public int FindIng (Ingredient ingredient)
        {
            for (int i=0; i<Ings.Count; ++i)
            {
                if (Ings[i].Equals(ingredient))
                {
                    return i;
                }
            }
            return -1;  
        }


        /// <summary>
        /// This function remove the ingredient of the list of the recipe.
        /// </summary>
        /// <param name="ingredient"></param>
        public void RemoveIng(Ingredient ingredient) 
        {
            Ings.Remove(ingredient);
        }


        /// <summary>
        /// This function add ingredients to a recipe withe the parameter params.
        /// </summary>
        /// <param name="ings"></param>
        public void AddIngs(params Ingredient[] ings)
        {
            for (int i = 0; i < ings.Length; i++)
            {
                Ings.Add(ings[i]);
            }
        }


        /// <summary>
        /// Redefinition of the ToString() method.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(Name+" : "); 
            foreach (Ingredient item in Ings)
            {
                str.Append(item.ToString()+", ");
            }
            return str.ToString();
        }


        /// <summary>
        /// This funciton was useful for the Console to see which recipe had which ratings and from who.
        /// </summary>
        /// <returns></returns>
        public string DisplayEvals()
        {
            StringBuilder ev = new StringBuilder("Evaluations de la recette :\n");
            foreach (Rating eval in RatingsList)
            {
                ev.Append(eval + "\n\n");
            }
            return ev.ToString();
        }
    }
}
