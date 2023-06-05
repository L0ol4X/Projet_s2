
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Modele
{
    /// <summary>
    /// This class depicts the rates associated to a recipe.
    /// </summary>
    [DataContract]
    public sealed class Rating:IEquatable<Rating>
    {
        [DataMember]
        public Account Auteur { get; set; }

        [DataMember]
        public int NbEtoiles { get; set; }

        [DataMember]
        public string Commentaire { get; set; }

        /// <summary>
        /// So basically, the constructor initialize the properties.
        /// </summary>
        /// <param name="auteur"></param>
        /// <param name="nbEtoile"></param>
        /// <param name="commentaire"></param>
        public Rating(Account auteur, int nbEtoile, string commentaire)
        {
            Auteur = auteur;
            NbEtoiles = nbEtoile;
            Commentaire = commentaire;
        }


        /// <summary>
        /// Redefinition of the ToString() method.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Auteur.UserName}, {NbEtoiles} étoile(s) : \n{Commentaire}";
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
            return Equals(obj as Rating);
        }


        /// <summary>
        /// This function shows how two Ratings should be compared.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Rating? other)
        {
            if (other == null) return false;
            return Auteur.Equals(other.Auteur) && NbEtoiles == other.NbEtoiles && Commentaire.Equals(other.Commentaire);
        }


        /// <summary>
        /// Redefinition of GetHashCode() method.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Commentaire.GetHashCode();
        }
    }
}