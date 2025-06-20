using DocumentFormat.OpenXml.Bibliography;
using SpiralCoreNetworkPlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkPredictor
{
    internal class Raport
    {
        private const string _template = "Plugins/Templates/full_template_dynamic.txt";
        private List<Section> _sections;
        private string _title;
        public Raport()
        {
            this._sections = new List<Section>();
            this._title = "NA";
        }

        public void AddSection(Section section)
        {
            this._sections.Add(section);
        }
        public void SetTitle(string title)
        {
            this._title = title;
        }

        public string GetContent()
        {
            var content = File.ReadAllText(_template);
            content = content.Replace("$$TEST_FILE_NAME$$", _title);
            var all_sections = string.Join('\n', _sections.Select(s=>s.GetContent()));
            content = content.Replace("$$SECTION_LIST$$", all_sections);
            return content;
        }
    }
}
