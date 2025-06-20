using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpiralCoreNetworkPluginInterface
{
    public interface ISpiralCoreObj
    {
        bool ActiveNeuralNetwork { get; }
        bool IsGPUModelLoaded { get; }
        int OutputSize {  get; }
        string Filepath {  get; }
        double[] Predict(double[] data);
        void Create(string name,IEnumerable<LayerConfiguration> data);
        double TrainStep(double[][] batch, double[][] validResult,double learningRate = 0.1);
        double TrainStepGpu(double[][] batch, double learningRate = 0.1);
        void Save();
        void InitializeGPU(double[][] batch, double[][] validResults);
    }
}
