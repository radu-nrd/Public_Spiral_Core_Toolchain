using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildHelper
{
    internal class IniProp
    {
        string _name;
        string _value;
        public IniProp(string name, string value)
        {
            _name = name;
            _value = value;
        }
        public string Name
        {
            get { return _name; }
        }
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}
