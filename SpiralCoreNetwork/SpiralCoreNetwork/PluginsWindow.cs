using ISpiralCoreNetworkPluginInterface;
using SpiralCoreNetwork.CustomControls;
using SpiralCoreNetwork.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpiralCoreNetwork
{
    public partial class PluginsWindow : Form
    {
        public PluginsWindow(IEnumerable<ISpiralCoreNetworkPluginInterface.ISpiralCoreNetworkPluginInterface?> plugins,Form1 linkedForm)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            _AddPlugins(plugins,linkedForm);
        }
        private void _AddPlugins(IEnumerable<ISpiralCoreNetworkPluginInterface.ISpiralCoreNetworkPluginInterface?> plugins,Form1 linkedForm)
        {
            int row = 0;
            int col = 0;

            foreach(var plugin in plugins)
            {
                SquareButton button = new SquareButton();
                button.Text = plugin!.PluginName;
                button.Width = 100;
                button.Location = new Point(50 + 110 * row, 50 + 60 * col);
                button.Click += (s,e)=> { 
                    plugin.Link();
                    linkedForm.LinkPlugin(plugin!.PluginName!);
                    this.Close();
                    this.Dispose(); 
                };
                scrollablePanel1.AddControl(button);

                if (row != 0 && row % 6 == 0)
                {
                    col++;
                    row = 0;
                    continue;
                }
                row++;
            }
        }
    }
}
