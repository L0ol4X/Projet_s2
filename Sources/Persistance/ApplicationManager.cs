using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml;

using Modele;
using XMLFile;
using StubFile;

namespace SaveMgr
{
    public class ApplicationManager
    {
        public ILoadable File { get; private set; }
        public Application MyApp { get; private set; }

        public ApplicationManager(ILoadable type)
        {
            File = type;
            MyApp = new Application();
        }

        public void CreateApp()
        {
            MyApp= File.Load();
        }

        public void SaveApp()
        {
            File.Save(MyApp);
        }
    }
}
