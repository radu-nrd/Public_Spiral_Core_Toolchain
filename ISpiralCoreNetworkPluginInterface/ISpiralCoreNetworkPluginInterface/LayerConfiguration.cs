using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpiralCoreNetworkPluginInterface
{
    public class LayerConfiguration
    {
        public required int Index { get; set; }
        public required int Neurons { get; set; }
        public required string? Activation { get; set; }
        public required string? Type { get; set; }
        public LayerConfiguration()
        {

        }
    }
}
