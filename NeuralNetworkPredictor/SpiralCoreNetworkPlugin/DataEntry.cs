using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkPredictor
{
    internal class DataEntry
    {
        private string _row_id;
        private string _input_data;
        private string _prediction_data;
        private string _real_value_data;

        private const string _template = "Plugins/Templates/data_entry.txt";
        public DataEntry(string row_id,string inputData,string predictionData,string realValueData)
        {
            this._row_id = row_id;
            this._input_data = inputData;
            this._prediction_data = predictionData;
            this._real_value_data = realValueData;
        }

        public string GetContent()
        {
            var content = File.ReadAllText(_template);
            content = content.Replace("$$ROW_ID$$", this._row_id);
            content = content.Replace("$$INPUT_DATA$$", this._input_data);
            content = content.Replace("$$PREDICTION_DATA$$", this._prediction_data);
            content = content.Replace("$$REAL_VALUE_DATA$$", this._real_value_data);
            ComputeDeviation(ref content);
            return content;
        }

        private void ComputeDeviation(ref string content)
        {
            var prediction_data = _prediction_data.Replace("[", "").Replace("]","").Split(',').Select(e=>Convert.ToDouble(e)).ToArray();
            var real_value_data = _real_value_data.Replace("[", "").Replace("]", "").Split(',').Select(e => Convert.ToDouble(e)).ToArray();

            var cache = new double[prediction_data.Length];
            for(int i = 0; i < cache.Length; i++)
                cache[i] = prediction_data[i] - real_value_data[i];

            if(cache.Count(e=>e>0) > cache.Count(e => e < 0))
            {
                content = content.Replace("$$DEVIATION_CLASS_TAG$$", "up");
                content = content.Replace("$$DEVIATION_DATA$$", $"[{string.Join(',', cache.Select(e=>e.ToString("F4")))}]" + Utils.UpArrow);
            }
            else
            {
                content = content.Replace("$$DEVIATION_CLASS_TAG$$", "down");
                content = content.Replace("$$DEVIATION_DATA$$", $"[{string.Join(',', cache.Select(e => e.ToString("F4")))}]" + Utils.DownArrow);
            }


        }
    }
}
