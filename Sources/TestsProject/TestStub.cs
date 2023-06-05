using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele;
using StubFile;

namespace TestsProject
{
  
    public class TestStub
    {
        [Fact]
        public void TestCreationStub()
        {
            Stub stub = new Stub();
            stub.Load();
            Assert.True(stub.Application.Accounts.DictAccounts.ContainsKey("patrick"));
        }


        [Fact]
        public void TestSaveStub() 
        {
            Stub stub = new Stub();
            stub.Load();
            stub.Application.Accounts.AddUser(new Account("jeane", "ccpasboecritcommeca"));
            stub.Save(stub.Application);
            Assert.True(stub.Application.Accounts.DictAccounts.ContainsKey("jeane"));
        }
    }
}
