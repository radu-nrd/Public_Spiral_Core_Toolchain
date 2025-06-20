using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkNormalizer
{
    internal class HeaderParser
    {
        public void Parse(string headerPath)
        {
            Dictionary<string, string> _header = new Dictionary<string, string>();
            using (var sr = new StreamReader(headerPath))
            {
                var line = string.Empty;
                while((line = sr.ReadLine())!= null)
                    if (line.Contains("=>"))
                    {
                        var content = line.Split("=>");
                        _header.Add(content[1].Trim(), content[0].Trim());
                    }
            }
        }

    }
}
