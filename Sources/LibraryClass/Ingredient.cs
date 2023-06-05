
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Modele
{
    /// <summary>
    /// This class represents an ingredient of the Recipe with its name and its quantity.
    /// </summary>
    [DataContract]
    public sealed class Ingredient : IEquatable<Ingredient>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
       => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        private string nom;
        [DataMember]
        public string Nom 
        {
            get => nom;
            set
            {
                if (nom == value) return;
                nom = value;
                OnPropertyChanged();
            }
        }


        private Quantite qte;
        [DataMember]
        public Quantite Qte 
        {
            get => qte;
            set
            {
                if (qte == value) return;
                qte = value;
                OnPropertyChanged();
            }
        }

        public Ingredient(string nom, int qte, string unite)
        {
            Qte = new Quantite(qte, unite);
            Nom = nom;
        }



        /// <summary>
        /// Redfinition of the ToString() method.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Qte} {Nom}";
        }



        /// <summary>
        /// Redefinition of the Equals method to implement the IEquatable<T> interface.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as Ingredient);
        }

        /// <summary>
        /// Definition of how to Ingredients should be compared
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Ingredient? other)
        {
            if (other == null) return false;
            if (Qte.Equals(other.Qte) && Nom.Equals(other.Nom))
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// Redefinition of the GetHashCode() method.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Nom.GetHashCode();
        }
    }
}
