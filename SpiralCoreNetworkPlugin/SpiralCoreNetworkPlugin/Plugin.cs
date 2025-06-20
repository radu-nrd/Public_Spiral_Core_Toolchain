

using ISpiralCoreNetworkPluginInterface;

namespace SpiralCoreNetworkPlugin
{

    /// <summary>
    /// Entry point for a Spiral Core Network Plugin
    /// </summary>
    public class Plugin : ISpiralCoreNetworkPluginInterface.ISpiralCoreNetworkPluginInterface
    {
        public string PluginName => throw new NotImplementedException();

        public string PluginVersion => throw new NotImplementedException();

        public string PluginDescription => throw new NotImplementedException();
#pragma warning disable CS8618 // Non-nullable field is uninitialized

        public Form Parent { get; set; } //this will be set by the main application

        public ISpiralCoreObj SpiralCoreObj { get; set; } //this will be set by the main application

#pragma warning restore CS8618
        public void Link()
        {
            var pluginWindow = new PluginWindow();
            Parent!.Controls.Add(pluginWindow);
            pluginWindow.Tag = PluginName;
        }
    }
}
