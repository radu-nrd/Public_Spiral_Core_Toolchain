

using ISpiralCoreNetworkPluginInterface;

namespace SpiralCoreNetworkPlugin
{

    /// <summary>
    /// Entry point for a Spiral Core Network Plugin
    /// </summary>
    public class NeuralNetworkViewer : ISpiralCoreNetworkPluginInterface.ISpiralCoreNetworkPluginInterface
    {
        public string PluginName => "Neural Network Viewer";

        public string PluginVersion => "1.0.0.0";

        public string PluginDescription => "UI Interface for reading (*).nn files.";

#pragma warning disable CS8618
        public Form Parent { get; set; } //this will be set by the main application

        public ISpiralCoreObj SpiralCoreObj { get; set; } //this will be set by the main application
#pragma warning restore CS8618

        public void Link()
        {
            var pluginWindow = new NeuralNetworkViewerWindow(SpiralCoreObj);
            Parent!.Controls.Add(pluginWindow);
            pluginWindow.Tag = PluginName;
        }
        //public void Show()
        //{
        //    var pluginWindow = new NeuralNetworkViewerWindow(SpiralCoreObj);
        //    Parent!.Controls.Add(pluginWindow);
        //    pluginWindow.Location = new Point(10, 90);
        //    pluginWindow.Show();
        //    pluginWindow.BringToFront();
        //}
    }
}
