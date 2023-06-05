using Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsProject
{
    public class TestsAccounts
    {
        //test de is the same
        [Theory]
        [InlineData("patrick", "longenough")]
        [InlineData("patrick", "pattaiberergrzgerg")]
        [InlineData("patrick", "l6655+p)çà'-,vough")]
        [InlineData("patrick", "ouiouiouipio")]
        public void testSamePasswd(string pseudo, string passwd)
        {
            string hash;
            hash = Account.HashMdp(passwd);
            Accounts accs = new Accounts();
            Assert.True(accs.IsTheSame(pseudo, passwd, hash));
        }

        [Theory]
        [InlineData("jean","nairienafer")]
        [InlineData("alain", "tairryeur")]
        [InlineData("kevin", "histoirequecesoitpastropcourt")]
        [InlineData("lemec", "bienrelouu")]
        public void TestAddUser(string username, string password)
        {
            Accounts accounts = new Accounts();
            accounts.AddUser(new Account(username, password));
            Assert.NotEmpty(accounts.DictAccounts);
        }
        
    }
}
