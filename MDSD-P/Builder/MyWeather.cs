using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDSD_P
{
    public class MyWeather : WeatherSystem
    {
        //States:
        public const string storm = "Storm";
        public const string winter = "Winter"; 
        public const string prePostSummer = "Pre/Post-Summer";
        public const string snowStorm = "SnowStorm";
        public const string iceAge = "IceAge";
        public const string summer = "summer";
        public const string gale = "gale";

        //Attributes
        public const string wind = "Wind";
        public const string temperture = "Temperture";


        public override void Build()
        {
            this.State(winter)
                    .Attribute(temperture, -10)
                    .Attribute(wind, 0)
                    .Transition(prePostSummer, temperture, 12).ThisOrHiger()
                    .Transition(snowStorm, wind, 10).ThisOrHiger()
                    .Transition(iceAge, temperture, -50).ThisOrLower()
            .State(prePostSummer)
                    .Attribute(temperture, 12)
                    .Attribute(wind, 0)
                    .Transition(winter, temperture, -10).ThisOrLower()
                    .Transition(gale, wind, 10).ThisOrHiger()
                    .Transition(summer, temperture, 20).ThisOrHiger()
         .State(summer)
                .Attribute(temperture, 20)
                .Attribute(wind, 0)
                .Transition(prePostSummer, temperture, 15).ThisOrLower()
                .Transition(storm, wind, 10).ThisOrLower()
            .State(iceAge)
                    .Attribute(temperture, -50)
                    .Transition(winter, temperture, -10).ThisOrHiger()
             .State(storm)
                    .Attribute(wind, 10)
                    .Attribute(temperture, 20)
                    .Transition(summer, wind, 0).ThisOrLower()
                    .Transition(gale, temperture, 12).ThisOrLower()
            .State(gale)
                    .Attribute(wind, 10)
                    .Attribute(temperture, 12)
                    .Transition(snowStorm, temperture, -10).ThisOrLower()
                    .Transition(storm, temperture, 20).ThisOrHiger()
                    .Transition(prePostSummer, wind, 0).ThisOrLower()
            .State(snowStorm)
                .Attribute(wind, 10)
                .Attribute(temperture, -1)
                .Transition(winter, wind, 0).ThisOrHiger()
                .StartState(winter);

        }
    }
}
