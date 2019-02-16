using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDSD_P
{
    public class State
    {
        public State(string name)
        {
            Name = name;
            Transitions = new List<Transition>();
            Attributes = new List<Attribute>();
        }

        public String Name { get; set; }
        public List<Transition> Transitions { get; }
        public List<Attribute> Attributes { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Current State: " + Name);
            Attributes.ForEach(a => sb.AppendLine(a.ToString()));
            return sb.ToString();
        }
    }
}
