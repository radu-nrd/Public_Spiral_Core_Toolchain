using ISpiralCoreNetworkPluginInterface;
using NeuralNetworkBuilderPlugin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralNetworkBuilder
{
    public partial class NeuralNetworkBuilderWindow : UserControl
    {
        List<LayerConfiguration> _config;
        ISpiralCoreObj __mainObj;

        public NeuralNetworkBuilderWindow(ISpiralCoreObj mainObj)
        {
            InitializeComponent();
            this.treeView.ImageList = new ImageList();
            this.treeView.ImageList.ImageSize = new Size(24, 24);
            this.treeView.ImageList.Images.Add("network", Image.FromFile("lib/img/neural_network_logo.png"));
            this.treeView.ImageList.Images.Add("layers", Image.FromFile("lib/img/layers_logo.png"));
            this.treeView.ImageList.Images.Add("layer", Image.FromFile("lib/img/layer_logo.png"));
            this.treeView.ImageList.Images.Add("activationFunctions", Image.FromFile("lib/img/activation_functions_logo.png"));
            this.treeView.ImageList.Images.Add("activationFunction", Image.FromFile("lib/img/activation_function_logo.png"));
            this.treeView.ImageList.Images.Add("value", Image.FromFile("lib/img/value_logo.png"));

            this._config = new List<LayerConfiguration>();
            this.__mainObj = mainObj;
        }

        private void applyNameButton_Click(object sender, EventArgs e)
        {
            this.treeView.Nodes.Clear();
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Please enter a valid name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.treeView.Nodes.Add(nameTextBox.Text);
            this.treeView.Nodes[0].ImageKey = this.treeView.Nodes[0].SelectedImageKey = "network";

            this.treeView.Nodes[0].Nodes.Add("Layers");
            this.treeView.Nodes[0].Nodes[0].ImageKey = this.treeView.Nodes[0].Nodes[0].SelectedImageKey = "layers";

            this.treeView.Nodes[0].Nodes.Add("Activation Functions");
            this.treeView.Nodes[0].Nodes[1].ImageKey = this.treeView.Nodes[0].Nodes[1].SelectedImageKey = "activationFunctions";

            this.treeView.Nodes[0].Nodes.Add("Layer Types");
            this.treeView.Nodes[0].Nodes[2].ImageKey = this.treeView.Nodes[0].Nodes[2].SelectedImageKey = "layers";

            this._config = new List<LayerConfiguration>();
        }

        public void AppendLayer(LayerConfiguration element)
        {
            var layerNode = new TreeNode($"Layer{element.Index}");
            layerNode.ImageKey = layerNode.SelectedImageKey = "layer";
            var neuronsNode = new TreeNode($"Neurons: {element.Neurons}");
            neuronsNode.ImageKey = neuronsNode.SelectedImageKey = "value";
            layerNode.Nodes.Add(neuronsNode);
            this.treeView.Nodes[0].Nodes[0].Nodes.Add(layerNode);

            var activationFunctionNode = new TreeNode($"Activation{element.Index}");
            activationFunctionNode.ImageKey = activationFunctionNode.SelectedImageKey = "activationFunction";
            var valueNode = new TreeNode(element.Activation);
            valueNode.ImageKey = valueNode.SelectedImageKey = "value";
            activationFunctionNode.Nodes.Add(valueNode);
            this.treeView.Nodes[0].Nodes[1].Nodes.Add(activationFunctionNode);

            var layerTypeNode = new TreeNode($"Layer Type {element.Index}");
            layerTypeNode.ImageKey = layerTypeNode.SelectedImageKey = "layer";

            var layerTypeValueNode = new TreeNode(element.Type);
            layerTypeValueNode.ImageKey = layerTypeValueNode.SelectedImageKey = "value";
            layerTypeNode.Nodes.Add(layerTypeValueNode);
            this.treeView.Nodes[0].Nodes[2].Nodes.Add(layerTypeNode);

            _config.Add(element);
        }

        private void appendLayerButton_Click(object sender, EventArgs e)
        {
            var appendLayerWindow = new AppendLayerWindow(this);
            appendLayerWindow.SetIdx(_config.Count);
            appendLayerWindow.ShowDialog();
        }

        private void SaveButtonOnClickEvent(object sender, EventArgs e)
        {
            try
            {
                __mainObj.Create(this.treeView.Nodes[0].Text, _config);
                MessageBox.Show($"Machine Learn Model {this.treeView.Nodes[0].Text}.nn was successfully created!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.treeView.SelectedNode = null;
        }
    }
}
