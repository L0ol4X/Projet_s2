using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;

namespace Modele
{
    /// <summary>
    /// This class manage the manager of recipes and the manager of accounts.
    /// </summary>
    [DataContract]
    public class Application
    {
        [DataMember]
        public Recipes Recipes { get; private set; }

        [DataMember]
        public bool IsConnected { get; private set; }

        [DataMember]
        public Accounts Accounts { get; private set; }

        [DataMember]
        public Account CurUser { get; private set; }

        /// <summary>
        /// The consrtuctor of the application which initializes each of his properties.
        /// </summary>
        public Application()
        { 
            Accounts = new Accounts();
            IsConnected = false;
            Recipes = new Recipes();
            CurUser = new Account();//which got the default values that are "unknown" for username and "none" for password
        }

       
        /// <summary>
        /// This function allow a user to be connected and stay connected to the application when the account already exists.
        /// </summary>
        /// <param name="pseudo"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public int LogIn(string pseudo, string pwd)
        {            
            if (Accounts.DictAccounts.ContainsKey(pseudo) && Accounts.IsTheSame(pseudo, pwd, Accounts.DictAccounts[pseudo].Passwd)) 
            {
                IsConnected = true;
                CurUser = Accounts.FindUser(pseudo);
                return 1;//success                
            }
            return 0;//failed
        }



        /// <summary>
        /// This function allow a user non-member to create an account to be logged in in the future.
        /// </summary>
        /// <param name="pseudo"></param>
        /// <param name="pwd"></param>
        /// <param name="confirmpwd"></param>
        /// <returns></returns>
        public int SignIn(string pseudo, string pwd, string confirmpwd)
        {
            if (pwd.Equals(confirmpwd)) 
            {
                Account newUser = new Account(pseudo, pwd);
                Accounts.AddUser(newUser);
                return 1;//it's ok
            }
            return 0;//failed because passwd were different or user already existed
        }

        /// <summary>
        /// Function to log out the user.
        /// </summary>
        public void LogOut()
        {
            IsConnected = false;
            CurUser = new Account();
        }

        
    }

}
