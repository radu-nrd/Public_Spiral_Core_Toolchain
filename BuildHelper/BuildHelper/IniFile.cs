using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildHelper
{
    internal class IniFile
    {
        List<IniField> fields;
        public IniFile(string iniFile) 
        { 
            this.fields = new List<IniField>();   
            Parse(iniFile);
        }

        private void Parse(string iniFile)
        {
            using (var reader = new StreamReader(iniFile))
            {
                string? line;
                IniField? currentField = null;
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (string.IsNullOrEmpty(line) || line.StartsWith(";"))
                        continue;
                    if (line.StartsWith("[") && line.EndsWith("]"))
                    {
                        if (currentField != null)
                            fields.Add(currentField);
                        string fieldName = line.Substring(1, line.Length - 2).Trim();
                        currentField = new IniField(fieldName);
                    }
                    else if (currentField != null)
                    {
                        var parts = line.Split(new[] { '=' }, 2);
                        if (parts.Length == 2)
                        {
                            string propName = parts[0].Trim();
                            string propValue = parts[1].Trim();
                            currentField.AddProp(new IniProp(propName, propValue));
                        }
                    }
                }
                // Add the last field if it exists
                if (currentField != null)
                    fields.Add(currentField);
            }
        }

        public IniField? this[string fieldName]
        {
            get => fields.FirstOrDefault(f => f.Name.ToLower() == fieldName.ToLower());
        }

        public IniProp? this[string fieldName, string propName]
        {
            get
            {
                var field = this[fieldName];
                if (field != null)
                    return field[propName];
                return null;
            }
        }   

    }
}
