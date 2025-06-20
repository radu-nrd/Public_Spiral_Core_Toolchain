using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkNormalizerV2
{
    internal class MinMaxScaler
    {
        List<MinMaxElement> _data;
        Dictionary<string, double> _map;

        public Dictionary<string, double> Mapping => _map;
        public IReadOnlyCollection<MinMaxElement> Data => _data;
        public MinMaxScaler()
        {
            this._data = new List<MinMaxElement>();
            this._map = new Dictionary<string, double>();
        }

        public void AddElement(MinMaxElement element)
        {
            _data.Add(element);
        }
        public void SetMap(Dictionary<string, double> map)
        {
            _map = map;
        }
    }
}
