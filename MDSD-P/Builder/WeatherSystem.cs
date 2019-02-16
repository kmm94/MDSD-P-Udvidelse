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

        public State _CurrentState { get; private set; }
        public List<State> States { get => states; }

        public abstract void Build();

        public WeatherSystem State(string name)
        {
            if (buildingState != null)
            {
                buildingState.Transitions.Add(buildingtransition);
                States.Add(buildingState);
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

        public void StartState(string StateName)
        {
            States.Add(buildingState);
            _CurrentState = States.Find(s => s.Name.Equals(StateName));
        }


        //Execution
        public State Action(string changeAttribute, float value)
        {
            State oldState = null;
            do
            {
                oldState = _CurrentState;
                _CurrentState = NextState(oldState, changeAttribute, value);

            } while (!oldState.Name.Equals(_CurrentState.Name));
            return _CurrentState;   
        }

        private State NextState(State currentState, string changeAttribute, float value)
        {
            State newState = currentState;
            var attributeValue = currentState.Attributes.Find(a => a.Name.Equals(changeAttribute));
            if (attributeValue == null)
            {
                Console.WriteLine("Attribute not found: " + changeAttribute);
                return currentState;
            }

            Console.WriteLine("Changing Attribute: " + attributeValue.Name + " old value: "+ attributeValue.Value +" with: " + value + " On state: "+ currentState.Name);
            attributeValue.Value += value;

            foreach (Transition currentTransition in _CurrentState.Transitions)
            {
                if (currentTransition.ControlAttribute.Equals(attributeValue.Name) && currentTransition.ShouldTransition(attributeValue.Value))
                {
                    newState = states.Find(state => state.Name.Equals(currentTransition.TargetState));
                }
            }

            return newState;
        }
    }
}
