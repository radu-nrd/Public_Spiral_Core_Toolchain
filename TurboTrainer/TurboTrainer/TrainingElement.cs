using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurboTrainer
{
    internal class TrainingElement
    {
        public required double[][] Batch { get; set; }
        public required double[][] Predictions { get; set; }
        public required string Name { get; set; }
    }
}
