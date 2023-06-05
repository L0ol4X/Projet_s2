namespace Modele
{
    using System.Text;
    using System.Runtime.Serialization;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// This class is the basis of the recipes.
    /// </summary>
    [DataContract, KnownType(typeof(Recipe))]
    public abstract class BaseRecipe :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
       => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        private string name;
        [DataMember]
        public string Name
        {
            get => name;
            set
            {
                if (name == value) return;
                name = value;
                OnPropertyChanged();
            }
        }


        private int time;
        [DataMember]
        public int Time
        {
            get => time;
            set
            {
                if (time == value) return;
                time = value;
                OnPropertyChanged();
            }
        }

        private int cost;
        [DataMember]
        public int Cost
        {
            get => cost;
            set
            {
                if (cost == value) return;
                cost = value;
                OnPropertyChanged();
            }
        }

        private string level;
        [DataMember]
        public string Level
        {
            get => level;
            set
            {
                if (level == value) return;
                level = value;
                OnPropertyChanged();
            }
        }

        private Category cat;
        [DataMember]
        public Category Cat 
        {
            get => cat;
            set
            {
                if (cat == value) return;
                cat = value;
                OnPropertyChanged();
            }
        }

     
        /// <summary>
        /// The constructor of the class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="level"></param>
        /// <param name="time"></param>
        /// <param name="cost"></param>
        /// <param name="cat"></param>
        protected BaseRecipe(string name, string level, int time, int cost ,Category cat)
        {
            Name = name;
            Level = level;
            Time = time;
            Cost = cost;
            Cat = cat;
        } 

      
    }
}
