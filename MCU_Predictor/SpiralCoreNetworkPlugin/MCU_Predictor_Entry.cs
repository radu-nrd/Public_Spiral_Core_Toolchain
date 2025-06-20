

using ISpiralCoreNetworkPluginInterface;

namespace MCU_Predictor
{

    /// <summary>
    /// Entry point for a Spiral Core Network Plugin
    /// </summary>
    public class MCU_Predictor_Entry : ISpiralCoreNetworkPluginInterface.ISpiralCoreNetworkPluginInterface
    {
        public string PluginName => "MCU_Predictor";

        public string PluginVersion => "1.0.0.0";

        public string PluginDescription => "to set";
#pragma warning disable CS8618 // Non-nullable field is uninitialized

        public Form Parent { get; set; } //this will be set by the main application

        public ISpiralCoreObj SpiralCoreObj { get; set; } //this will be set by the main application

#pragma warning restore CS8618
        public void Link()
        {
            try
            {
                var pluginWindow = new MCU_Predictor_Window(SpiralCoreObj);
                Parent!.Controls.Add(pluginWindow);
                pluginWindow.Tag = PluginName;
            }
            catch (NoMachineLearnModelLoadedException)
            {
                MessageBox.Show("No Machine Learn Model Was Loaded! Please load a MLM model then launch plugin!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
