using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkNormalizerV2
{
    internal class MinMaxElement
    {
        public required string Header {  get; set; }
        public required double Min { get; set; }
        public required double Max { get; set; }
    }
}
