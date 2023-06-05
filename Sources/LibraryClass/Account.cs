using System.Security.Cryptography;
using System.Text;
using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace Modele
{
    /// <summary>
    /// This class is the representation of an account
    /// </summary>
    [DataContract]
    public sealed class Account: IEquatable<Account>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = null)
       => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private string? userName;
        [DataMember]
        public string? UserName
        {
            get => userName;
            set
            {
                if (userName == value) return;
                userName = value;
                OnPropertyChanged();
            }
        }

        private string? passwd;
        [DataMember]
        public string? Passwd
        {
            get => passwd;
            set
            {
                if (passwd == value) return;
                passwd = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Recipe> favList = new ObservableCollection<Recipe>();
        [DataMember]
        public ObservableCollection<Recipe> FavList 
        {
            get => favList;
            set
            {
                if (favList == value) return;
                favList = value;
                OnPropertyChanged();
            }
        }
       
        /// <summary>
        /// The constructor of an account with the pseudo and password given by the entry
        /// </summary>
        /// <param name="pseudo"></param>
        /// <param name="passwd"></param>
        /// <exception cref="ArgumentException"></exception>
        public Account(string pseudo, string passwd)
        {
           
            if (pseudo == "" || passwd == "")
            {
                throw new ArgumentException("The fields <password> and <pseudo> must be filled or non_white spaces");
            }
            else if (pseudo != "" && passwd.Length < 8)
            {
                throw new ArgumentException("The password must be at least long of 8 characters");
            }
            else
            {
                UserName = pseudo;
                Passwd = HashMdp(passwd);
                FavList = new ObservableCollection<Recipe>();
            }
        }

       

        /// <summary>
        /// The account a non-log person will use and is used to fill the binding selected elements
        /// </summary>
        public Account()
        {
            UserName = null;
            Passwd = null;
        }


        /// <summary>
        /// This will be useful to add a recipe to the list of favorites of the account
        /// </summary>
        /// <param name="r"></param>
        public void AddFav(Recipe r)
        {
            if (!FavList.Contains(r))
            {
                FavList.Add(r);
            }
        }


        /// <summary>
        /// This was used in the Console to see the recipes that was set favorite to the account.
        /// </summary>
        /// <returns></returns>
        public string SeeFav()
        {
            if (FavList.Count != 0)             
            {
                StringBuilder sb = new StringBuilder(FavList[0].Name);
                for (int i = 1; i < FavList.Count; i++)
                {
                    sb.Append(", " + FavList[i].Name);
                }
                return sb.ToString();
            }
            return "";
        }


        /// <summary>
        /// The redefinition of the ToString() method.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder recipes = new StringBuilder("");
            if (FavList.Count != 0)
            {
                for (int i = 0; i < FavList.Count; i++)
                {
                    recipes.Append(", " + FavList[i].Name);
                }               
            }
            return $"{UserName} : {recipes}";

        }

        

        /// <summary>
        /// Redefinition of the Equals method to implement the IEquatable<T> interface
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as Account);
        }
       

        /// <summary>
        /// Definition of how it is possible to compare two accounts
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Account? other)
        {
            if (other == null) return false;
            return (UserName.Equals(other.UserName) && Passwd.Equals(other.Passwd));
        }



        /// <summary>
        /// Redefinition of the GetHashCode() method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return UserName.GetHashCode();
        }


        //This function is useful for hashing the password in another function later.                     
        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return SHA256.HashData(Encoding.UTF8.GetBytes(inputString));
        }


        /// <summary>
        /// This function is using the encoding method GetHash to hash the entire password.
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static string HashMdp(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }


    }




    
}
