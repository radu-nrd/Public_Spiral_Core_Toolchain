using ISpiralCoreNetworkPluginInterface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpiralCoreNetworkPlugin
{
    public partial class NeuralNetworkViewerWindow : UserControl
    {
        ISpiralCoreObj? __mainObj;
        public NeuralNetworkViewerWindow(ISpiralCoreObj obj)
        {
            InitializeComponent();
            if (!obj.ActiveNeuralNetwork)
            {
                MessageBox.Show("Please import a Machine Learn Model before oppening the viewer!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            __mainObj = obj;
            this.treeView.ImageList = new ImageList();
            this.treeView.ImageList.ColorDepth = ColorDepth.Depth32Bit;
            this.treeView.ImageList.ImageSize = new Size(24, 24);
            this.treeView.ImageList.Images.Add("network", Image.FromFile("lib/img/neural_network_logo.png"));
            this.treeView.ImageList.Images.Add("error", Image.FromFile("lib/img/error_logo.png"));
            this.treeView.ImageList.Images.Add("layers", Image.FromFile("lib/img/layers_logo.png"));
            this.treeView.ImageList.Images.Add("layer", Image.FromFile("lib/img/layer_logo.png"));
            this.treeView.ImageList.Images.Add("activationFunctions", Image.FromFile("lib/img/activation_functions_logo.png"));
            this.treeView.ImageList.Images.Add("activationFunction", Image.FromFile("lib/img/activation_function_logo.png"));
            this.treeView.ImageList.Images.Add("value", Image.FromFile("lib/img/value_logo.png"));
            this.treeView.ImageList.Images.Add("weight", Image.FromFile("lib/img/weight_logo.png"));
            this.treeView.ImageList.Images.Add("weights", Image.FromFile("lib/img/weights_logo.png"));
            this.treeView.ImageList.Images.Add("weightSets", Image.FromFile("lib/img/weight_sets_logo.png"));
            this.treeView.ImageList.Images.Add("bias", Image.FromFile("lib/img/bias_logo.png"));
            this.treeView.ImageList.Images.Add("biases", Image.FromFile("lib/img/biases_logo.png"));

            LoadData();
        }

        private JObject BuildJson()
        {
            var fileBytes = File.ReadAllBytes(__mainObj!.Filepath);
            for (int i = 0; i < fileBytes.Length; i++)
                fileBytes[i] -= 26;
            var jsonStr = Encoding.ASCII.GetString(fileBytes);
            return JObject.Parse(jsonStr);
        }

        private void LoadData()
        {
            var json = BuildJson();
            var root = new TreeNode(Path.GetFileNameWithoutExtension(__mainObj!.Filepath));
            BuildRoot(ref root, ref json);

        }
        private void BuildRoot(ref TreeNode root, ref JObject jsonObj)
        {
            root.ImageKey = "network";
            root.SelectedImageKey = "network";

            BuildErrorNode(ref root, ref jsonObj);
            BuildLayersCountNode(ref root, ref jsonObj);
            BuildLayersNode(ref root, ref jsonObj);
            BuildWeights(ref root, ref jsonObj);
            BuildActivationFunctions(ref root, ref jsonObj);
            BuildLayerTypes(ref root,ref jsonObj);

            this.treeView.Nodes.Add(root);
        }
        private void BuildLayerTypes(ref TreeNode root,ref JObject jsonObj)
        {
            var layersTypeNode = new TreeNode("Layers Type");
            layersTypeNode.ImageKey = layersTypeNode.SelectedImageKey = "layers";

            foreach(var layerType in jsonObj["Layers_type"]!.Values())
            {
                var layerTypeNode = new TreeNode($"LayerType {layerType["Index"]}");
                layerTypeNode.ImageKey = layerTypeNode.SelectedImageKey = "layer";

                var valueNode = new TreeNode(layerType["Value"]!.ToString());
                valueNode.ImageKey = valueNode.SelectedImageKey = "value";
                layerTypeNode.Nodes.Add(valueNode);
                layersTypeNode.Nodes.Add(layerTypeNode);
            }
            root.Nodes.Add(layersTypeNode);
        }

        private void BuildWeights(ref TreeNode root, ref JObject jsonObj)
        {
            var weightsNode = new TreeNode("Weights");
            weightsNode.ImageKey = weightsNode.SelectedImageKey = "weights";
            foreach (var weightObj in jsonObj["Weights"]!.Values())
            {
                var weightNode = new TreeNode($"Weight{weightObj["Index"]}");
                weightNode.ImageKey = weightNode.SelectedImageKey = "weights";
                var valuesNode = new TreeNode("Values");
                valuesNode.ImageKey = valuesNode.SelectedImageKey = "weightSets";
                foreach (var set in weightObj["Values"]!.Values())
                {
                    var setNode = new TreeNode($"Set{set["Neuron_Index"]}");
                    setNode.ImageKey = setNode.SelectedImageKey = "weightSets";

                    foreach (var elem in (set["Data"] as JArray)!)
                    {
                        var setElem = new TreeNode(elem.ToString());
                        setElem.ImageKey = setElem.SelectedImageKey = "value";
                        setNode.Nodes.Add(setElem);
                    }

                    valuesNode.Nodes.Add(setNode);
                }

                weightNode.Nodes.Add(valuesNode);
                weightsNode.Nodes.Add(weightNode);
            }
            root.Nodes.Add(weightsNode);
        }

        private void BuildActivationFunctions(ref TreeNode root, ref JObject jsonObj)
        {
            var activationFunctionsNode = new TreeNode("Activation Functions");
            activationFunctionsNode.ImageKey = activationFunctionsNode.SelectedImageKey = "activationFunctions";
            foreach (var actFct in jsonObj["Activation_Layer_Functions"]!.Values())
            {
                var actFctNode = new TreeNode($"Activation{actFct["Index"]}");
                actFctNode.ImageKey = actFctNode.SelectedImageKey = "activationFunction";
                var valueNode = new TreeNode($"{actFct["Value"]}");
                valueNode.ImageKey = valueNode.SelectedImageKey = "value";
                actFctNode.Nodes.Add(valueNode);
                activationFunctionsNode.Nodes.Add(actFctNode);
            }
            root.Nodes.Add(activationFunctionsNode);
        }

        private void BuildErrorNode(ref TreeNode root, ref JObject jsonObj)
        {
            var errorNode = new TreeNode($"Error: {Convert.ToDouble(jsonObj["Error"]):f4}");
            errorNode.ImageKey = "error";
            errorNode.SelectedImageKey = "error";
            root.Nodes.Add(errorNode);
        }
        private void BuildLayersCountNode(ref TreeNode root, ref JObject jsonObj)
        {
            var layersCountNode = new TreeNode($"Layers Count : {jsonObj["Layer_Count"]}");
            layersCountNode.ImageKey = layersCountNode.SelectedImageKey = "layer";
            root.Nodes.Add(layersCountNode);

        }

        private void BuildLayersNode(ref TreeNode root, ref JObject jsonObj)
        {
            var layersNode = new TreeNode("Layers");
            layersNode.ImageKey = "layers";
            layersNode.SelectedImageKey = "layers";

            foreach (var layer in jsonObj["Layers"]!.Values())
            {
                var layerNode = new TreeNode($"Layer{layer["Index"]}");
                layerNode.ImageKey = "layer";
                layerNode.SelectedImageKey = "layer";
                var biasesNode = new TreeNode("Biases");
                biasesNode.ImageKey = biasesNode.SelectedImageKey = "biases";

                foreach(var neuron_biases in (layer["Neurons_Biases"] as JArray)!)
                {
                    var value = new TreeNode($"{neuron_biases}");
                    value.ImageKey = value.SelectedImageKey = "bias";
                    biasesNode.Nodes.Add(value);
                }
                var neuronsCountNode = new TreeNode($"Neurons Count: {(layer["Neurons_Biases"] as JArray)!.Count}");
                neuronsCountNode.ImageKey = neuronsCountNode.SelectedImageKey = "value";

                layerNode.Nodes.Add(neuronsCountNode);
                layerNode.Nodes.Add(biasesNode);
                layersNode.Nodes.Add(layerNode);

            }
            root.Nodes.Add(layersNode);
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.treeView.SelectedNode = null;
        }
    }
}
