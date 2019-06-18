using Panacea.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panacea.Modularity.Telephone
{
    public static class PanaceaServicesExtensions
    {
        public static bool TryGetTelephone(this PanaceaServices core, out ITelephonePlugin telephone)
        {
            return (telephone = core.PluginLoader.GetPlugins<ITelephonePlugin>().FirstOrDefault()) != null;
        }
    }
}
