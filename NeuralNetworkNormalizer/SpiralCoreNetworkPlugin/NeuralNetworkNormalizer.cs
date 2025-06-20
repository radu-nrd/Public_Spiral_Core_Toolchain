

using ISpiralCoreNetworkPluginInterface;

namespace SpiralCoreNetworkPlugin
{

    /// <summary>
    /// Entry point for a Spiral Core Network Plugin
    /// </summary>
    public class NeuralNetworkNormalizer : ISpiralCoreNetworkPluginInterface.ISpiralCoreNetworkPluginInterface
    {
        public string PluginName => "Neural Network Normalizer";

        public string PluginVersion => "1.0.0.0";

        public string PluginDescription => "No";
#pragma warning disable CS8618 // Non-nullable field is uninitialized

        public Form Parent { get; set; } //this will be set by the main application

        public ISpiralCoreObj SpiralCoreObj { get; set; } //this will be set by the main application

#pragma warning restore CS8618
        public void Link()
        {
            var pluginWindow = new NeuralNetworkNormalizerWindow(SpiralCoreObj);
            Parent!.Controls.Add(pluginWindow);
            pluginWindow.Tag = PluginName;
        }
    }
}
