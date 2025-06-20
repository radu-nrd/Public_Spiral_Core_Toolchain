using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpiralCoreNetworkPluginInterface
{
    public class NoMachineLearnModelLoadedException : Exception
    {
        public NoMachineLearnModelLoadedException() : base() { }

        public NoMachineLearnModelLoadedException(string message) : base(message) { }

    }
}
