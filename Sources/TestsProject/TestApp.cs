using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele;

namespace TestsProject
{
    public class TestApp
    {
        [Fact]
        public void TestCreationApp()
        {
            Application application = new Application();
            Assert.False(application.IsConnected);
        }

        [Fact]
        public void testLogIn()
        {
            Application application = new Application();
            application.Accounts.AddUser(new Account("patate", "patatepatate"));
            int res = application.LogIn("patate", "patatepatate");
            Assert.True(application.IsConnected);
            Assert.Equal(1, res);
            application.LogOut();
            int res2 = application.LogIn("frere", "jesuisunrandom");
            Assert.Equal(0, res2);
            Assert.False(application.IsConnected);
        }

        [Fact]
        public void testSignIn()
        {
            Application application = new Application();
            int res = application.SignIn("perecastor", "unehistoire", "unehistoire");
            Assert.True(application.Accounts.DictAccounts.ContainsKey("perecastor"));
            Assert.Equal(1, res);

            int res2 = application.SignIn("perecastor2", "unehistoire", "unehistore");

            Assert.False(application.Accounts.DictAccounts.ContainsKey("perecastor2"));
            Assert.Equal(0, res2);
        }
    }
}
