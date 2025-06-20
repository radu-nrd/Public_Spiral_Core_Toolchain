using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkPredictor
{
    internal class ConfigElement
    {
        public required string ColumnName { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }

    }
}
