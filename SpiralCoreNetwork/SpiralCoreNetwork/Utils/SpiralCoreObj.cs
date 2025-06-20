using FinalNeuralNetwork.Interfaces;
using FinalNeuralNetwork.Models;
using ISpiralCoreNetworkPluginInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiralCoreNetwork.Utils
{
    public class SpiralCoreObj : ISpiralCoreObj
    {
        private INeuralNetwork? _nn { get; }

        public string Filepath {  get; set; }

        public bool ActiveNeuralNetwork { get; set; }

        public int OutputSize { get; }

        public bool IsGPUModelLoaded { get; set; }

        public SpiralCoreObj()
        {
            Filepath = "NA";
            ActiveNeuralNetwork = false;
            OutputSize = -1;
        }

        public SpiralCoreObj(string filePath)
        {
            Filepath = filePath;
            this._nn = INeuralNetwork.Load(filePath);
            this.ActiveNeuralNetwork = true;
            OutputSize = this._nn.OutputSize;
        }

        public double[] Predict(double[] data)
        {
            return this._nn!.Predict(data).ToArray();
        }

        public void Create(string name,IEnumerable<LayerConfiguration> data)
        {
            var newNetwork = INeuralNetwork.CreateNetwork(data.Count());
            foreach (var layer in data)
            {
                var layerType = Enum.Parse<LayerType>(layer.Type!);
                var layerActivation = Enum.Parse<ActivationFunction>(layer.Activation!);
                newNetwork.AppendLayer(layer.Neurons, layerType, layerActivation);
            }
            newNetwork.Build();
            newNetwork.Save($"MachineLearnModels/{name}.nn");
        }

        public double TrainStep(double[][] batch, double[][] validResult, double learningRate = 0.1)
        {
            return _nn!.TrainStep(batch, validResult, learningRate);
        }

        public void Save()
        {
            _nn!.Save(Filepath);
        }

        public double TrainStepGpu(double[][] batch, double learningRate = 0.1)
        {
            return _nn!.TrainStepGPU(batch, learningRate);
        }

        public void InitializeGPU(double[][] batch, double[][] validResults)
        {
            _nn!.InitializeGPU(batch, validResults);
            IsGPUModelLoaded = true;
        }
    }
}
