using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Modele
{
    /// <summary>
    /// As a quantity is made of a unit and a nulber of these unit, it should be represented by this class.
    /// </summary>
    [DataContract]
    public sealed class Quantite:IEquatable<Quantite>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        private int qtite;
        [DataMember]
        public int Qtite
        {
            get => qtite;
            set
            {
                if (qtite == value) return;
                qtite = value;
                OnPropertyChanged();
            }
        }

        private string unite;
        [DataMember]
        public string Unite
        {
            get => unite;
            set
            {
                if (unite == value) return;
                unite = value;
                OnPropertyChanged();
            }
        }

        public Quantite(int qte, string unite)
        {
            Qtite = qte;
            Unite = unite;
        }

     



        /// <summary>
        /// Redefinition of the ToString() method.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Qtite} {Unite}";
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
            return Equals(obj as Quantite);
        }
               

        /// <summary>
        /// This function defines how two quantities should be compared.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Quantite? other)
        {
            if (other == null) return false;
            return (Qtite.Equals(other.Qtite) && Unite.Equals(other.Unite));
        }



        /// <summary>
        /// Redefinition of the GetHashCode() method.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.Qtite.GetHashCode();
        }
    }
}
