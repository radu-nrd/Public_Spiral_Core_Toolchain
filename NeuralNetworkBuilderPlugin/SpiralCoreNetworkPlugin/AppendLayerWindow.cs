using ISpiralCoreNetworkPluginInterface;
using NeuralNetworkBuilder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralNetworkBuilderPlugin
{
    public partial class AppendLayerWindow : Form
    {
        NeuralNetworkBuilderWindow _parent;
        int _idx;
        public AppendLayerWindow(NeuralNetworkBuilderWindow window)
        {
            InitializeComponent();
            this._parent = window;
            this.headerLabel.Text = $"Label {_idx}";
        }

        private void AddLayerButtonClick(object sender, EventArgs e)
        {
            var layerConfig = new LayerConfiguration { 
                Index = _idx,
                Activation = this.actFctComboBox.SelectedItem!.ToString(), 
                Neurons = ((int)neuronsNumericUpDown.Value),
                Type = layerTypeComboBox.SelectedItem!.ToString() };
            _parent.AppendLayer(layerConfig);
            this.Dispose();
        }
        public void SetIdx(int idx)
        {
            _idx = idx;
        }
    }
}
