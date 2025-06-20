using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpiralCoreNetworkPluginInterface
{
    public interface ISpiralCoreNetworkPluginInterface
    {
        string PluginName { get; }
        string PluginVersion { get; }
        string PluginDescription {  get; }
        Form Parent { get; set; }
        ISpiralCoreObj SpiralCoreObj { get; set; }
        void Link();

    }
}
