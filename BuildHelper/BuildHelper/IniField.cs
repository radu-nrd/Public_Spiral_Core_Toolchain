using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildHelper
{
    internal class IniField
    {
        string _name;
        List<IniProp> _props;

        public string Name
        {
            get { return _name; }
        }

        public int Count => _props.Count;

        public IniProp? this[string propName]
        {
            get => _props.FirstOrDefault(p => p.Name.ToLower() == propName.ToLower());
        }
        public IniProp? this[int index]
        {
            get => index >= 0 && index < _props.Count ? _props[index] : null;
        }

        public IniField(string name)
        {
            _name = name;
            _props = new List<IniProp>();
        }

        public void AddProp(IniProp prop)
        {
            _props.Add(prop);
        }
    }
}
