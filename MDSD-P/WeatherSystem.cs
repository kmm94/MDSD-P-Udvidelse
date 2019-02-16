using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDSD_P
{
    public abstract class WeatherSystem
    {
        private List<State> states = new List<State>();

        private State buildingState;
        private Transition buildingtransition;

        public State CurrentState { get; private set; }

        public abstract void Build();

        public WeatherSystem State(string name)
        {
            if (buildingState != null)
            {
                buildingState.Transitions.Add(buildingtransition);
                states.Add(buildingState);
            }
            buildingState = new State(name);
            return this;
        }

        public WeatherSystem Transition(string targetState, string controlingAttribute, float threashold)
        {
            if (buildingtransition != null)
            {
                buildingState.Transitions.Add(buildingtransition);
            }
            buildingtransition = new Transition(targetState, controlingAttribute, threashold);
            return this;
        }

        public WeatherSystem Attribute(string name, float initialValue)
        {
            buildingState.Attributes.Add(new MDSD_P.Attribute(name, initialValue));
            return this;
        }

        public WeatherSystem ThisOrLower()
        {
            buildingtransition.ThresholdAndLower = true;
            buildingtransition.ThresholdAndOver = false;
            return this;
        }

        public WeatherSystem ThisOrHiger()
        {
            buildingtransition.ThresholdAndOver = true;
            buildingtransition.ThresholdAndLower = false;
            return this;
        }

        public State Action(string changeAttribute, float value)
        {

            State newState = null;
            var attributeValue = CurrentState.Attributes.Find(a => a.Name.Equals(changeAttribute));
            if (attributeValue == null)
            {
                Console.WriteLine("Attribute not found: " + changeAttribute);
                return CurrentState;
            }

            Console.WriteLine("Changing Attribute: " + attributeValue.Name + " with: " + value);
            attributeValue.Value += value;

            foreach (Transition currentTransition in CurrentState.Transitions)
            {
                if (currentTransition.ControlAttribute.Equals(attributeValue.Name) && currentTransition.ShouldTransition(attributeValue.Value))
                {
                    newState = states.Find(state => state.Name.Equals(currentTransition.TargetState));
                    if (newState != null && newState.Attributes.Exists(a => a.Name.Equals(attributeValue.Name)))
                    {
                        newState.Attributes.Find(a => a.Name.Equals(attributeValue.Name)).Value = attributeValue.Value;
                    }
                }
            }

            if (newState != null)
            {
                CurrentState = newState;
            }
            return CurrentState;
        }

        public void StartState(string StateName)
        {
            states.Add(buildingState);
            CurrentState = states.Find(s => s.Name.Equals(StateName));
        }
    }
}
