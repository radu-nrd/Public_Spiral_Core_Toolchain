using PluginParser;
using SpiralCoreNetwork.CustomControls;
using SpiralCoreNetwork.Utils;
using System.Windows.Forms;

namespace SpiralCoreNetwork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }
        private void pluginsButton_Click(object sender, EventArgs e)
        {
            var parser = new PluginParser<ISpiralCoreNetworkPluginInterface.ISpiralCoreNetworkPluginInterface>();
            var plugins = parser.Parse();
            foreach(var plugin in plugins)
            {
                plugin!.Parent = this;
                plugin!.SpiralCoreObj = SpiralCoreEntryPoint.MainObj;
            }

            var pluginsForm = new PluginsWindow(plugins,this);
            pluginsForm.ShowDialog();
        }

        public void SetCurrentMachineModel(string model)
        {
            this.currentModelLabelValue.Text = $"Current Model: {model}";
        }

        public void LinkPlugin(string pluginName)
        {
            var plugin = GetPlugin(pluginName);
            if (plugin is not null)
            {
                this.animatedPanel1.Controls.Add(plugin);
                plugin.Show();
                plugin.BringToFront();
            }
        }
        private Control? GetPlugin(string pluginName)
        {
            foreach(Control control in this.Controls)
                if(control.Tag is not null &&control.Tag.ToString() == pluginName)
                    return control;
            return null;
        }

    }
}
