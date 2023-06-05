using System.Runtime.Serialization;

namespace Modele
{
    /// <summary>
    /// These are the differents categories possible for the recipes
    /// </summary>
    [DataContract(Name ="Category")]
    public enum Category
    {
        [EnumMember(Value ="1")]
        Entree = 1,
        [EnumMember(Value = "2")]
        Plat = 2,
        [EnumMember(Value = "3")]
        Dessert = 3,
        [EnumMember(Value = "4")]
        PetiteFaim = 4,
        [EnumMember(Value = "5")]
        Aperitifs = 5 
    }
}
