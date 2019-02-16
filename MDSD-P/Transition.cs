using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDSD_P
{
    public class Transition
    {
        public Transition(string targetState, string controlattribute ,float threshold)
{
            TargetState = targetState;
            Threshold = threshold;
            ControlAttribute = controlattribute;
            ThresholdAndLower = true;
            ThresholdAndOver = true;
            
        }

        public bool ShouldTransition(float value)
        {
            if (ThresholdAndLower && value <= Threshold)
            {
                return true;
            }
            else if (ThresholdAndOver && value >= Threshold)
            {
                return true;
            }
            else if(!ThresholdAndLower && !ThresholdAndOver && value == Threshold)
            {
                return true;
            }
            return false;
        }

        public float Threshold { get; }
        public string TargetState { get; set; }
        public string ControlAttribute { get; }
        public bool ThresholdAndOver { get; set; }
        public bool ThresholdAndLower { get; set; }
    }
}
