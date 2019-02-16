using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDSD_P
{
    public class Attribute
    {
        public Attribute(string name, float value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public float Value { get; set; }

        public override string ToString()
        {
            return Name + ": " + Value;
        }
    }
}
