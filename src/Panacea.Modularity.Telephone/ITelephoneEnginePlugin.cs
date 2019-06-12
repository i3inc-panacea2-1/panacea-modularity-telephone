using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panacea.Modularity.Telephone
{
    public interface ITelephoneEnginePlugin : IPlugin
    {
        bool SupportsType(string type);

        TelephoneBase CreateInstance(ITelephoneAccount account);
    }
}
