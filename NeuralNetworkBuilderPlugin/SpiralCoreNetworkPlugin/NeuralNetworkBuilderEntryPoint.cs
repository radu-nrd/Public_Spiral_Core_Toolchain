

using ISpiralCoreNetworkPluginInterface;

namespace NeuralNetworkBuilder
{

    /// <summary>
    /// Entry point for a Spiral Core Network Plugin
    /// </summary>
    public class NeuralNetworkBuilderEntryPoint : ISpiralCoreNetworkPluginInterface.ISpiralCoreNetworkPluginInterface
    {
        public string PluginName => "Neural Network Builder";

        public string PluginVersion => "1.0.0.0";

        public string PluginDescription => "to set";

#pragma warning disable CS8618 // Non-nullable field is uninitialized

        public Form Parent { get; set; } //this will be set by the main application

        public ISpiralCoreObj SpiralCoreObj { get; set; } //this will be set by the main application

#pragma warning restore CS8618
        public void Link()
        {
            var pluginWindow = new NeuralNetworkBuilderWindow(SpiralCoreObj);
            Parent!.Controls.Add(pluginWindow);
            pluginWindow.Tag = PluginName;
        }
    }
}
