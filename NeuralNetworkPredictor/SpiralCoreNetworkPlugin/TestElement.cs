using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkPredictor
{
    internal class TestElement
    {
        public required double[][] Batch { get; set; }
        public required double[][] Predictions { get; set; }
        public required string Name { get; set; }
    }
}
