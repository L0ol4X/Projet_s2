using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele
{
    /// <summary>
    /// This interface is the basis of the saves and loads.
    /// </summary>
    public interface ILoadable
    {
        public Application Load();
        public void Save(Application application);

    }
}
