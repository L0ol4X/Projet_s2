using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.CompilerServices;

namespace Modele
{
    /// <summary>
    /// This class is the manager of the accounts.
    /// </summary>
    [DataContract]
    public class Accounts
    {
        [DataMember]
        public Dictionary<string, Account> DictAccounts { get; private set; }
        public Accounts()
        {
            DictAccounts = new Dictionary<string, Account>();
        }


        /// <summary>
        /// This function add a user to the dictionnary of accounts.
        /// </summary>
        /// <param name="u"></param>
        public void AddUser(Account u)
        {
            DictAccounts.Add(u.UserName, u);
        }

        /// <summary>
        /// This function returns a user of the dictionnary of accounts
        /// </summary>
        /// <param name="pseudo"></param>
        /// <returns></returns>
        public Account FindUser(string pseudo)
        {
            return DictAccounts[pseudo];
        }


        /// <summary>
        /// This function verify if the password pwd given in parameter is the same as the one already stored and hashed which correspond to the username pseudo.
        /// </summary>
        /// <param name="pseudo"></param>
        /// <param name="pwd"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public bool IsTheSame(string pseudo, string pwd, string hash)
        {
            Account tmp = new Account(pseudo, pwd);//new account with hashed passwd
            return hash.Equals(tmp.Passwd);//if both are equals it's ok else return false
        }


        /// <summary>
        /// Redefinition of the ToString() method.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string account in DictAccounts.Keys)
            {
                sb.Append(DictAccounts[account].ToString()+"\n");
            }
            return sb.ToString();
        }

    }
}
