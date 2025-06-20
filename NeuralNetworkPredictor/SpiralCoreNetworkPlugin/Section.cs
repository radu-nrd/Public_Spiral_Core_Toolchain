using NeuralNetworkPredictor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiralCoreNetworkPlugin
{
    internal class Section
    {
        private string _fileName;
        private const string _template = "Plugins/Templates/section.txt";
        private List<DataEntry> _data;
        public Section(string fileName)
        {
            this._fileName = fileName;
            this._data = new List<DataEntry>();
        }

        public void AddEntry(DataEntry entry)
        {
            this._data.Add(entry);
        }
        public string GetContent()
        {
            string content = File.ReadAllText(_template);
            content = content.Replace("$$FILE_NAME$$", this._fileName);
            content = content.Replace("$$DATA_ENTRY_LIST$$", string.Join('\n', _data.Select(e=>e.GetContent())));
            return content;
        }
    }
}
