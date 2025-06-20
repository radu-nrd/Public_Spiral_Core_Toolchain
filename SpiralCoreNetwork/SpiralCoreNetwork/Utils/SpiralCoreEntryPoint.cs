using ISpiralCoreNetworkPluginInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SpiralCoreNetwork.Utils
{
    /// <summary>
    /// Static entry point of Main Application
    /// </summary>
    internal static class SpiralCoreEntryPoint
    {
#pragma warning disable CS8618 // Non-nullable field is uninitialized
        internal static ISpiralCoreObj MainObj { get; private set; }
#pragma warning restore CS8618
        internal static void SetMainObj(ISpiralCoreObj obj) => SpiralCoreEntryPoint.MainObj = obj;
        internal static void SetMainObj(string filePath) => SpiralCoreEntryPoint.MainObj = new SpiralCoreObj(filePath);
        internal static void InitializeObj() => MainObj = new SpiralCoreObj();
        internal static void Save()=>MainObj.Save();
    }
}
