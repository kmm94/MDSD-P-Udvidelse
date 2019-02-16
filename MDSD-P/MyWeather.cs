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
        private const string storm = "Storm";
        private const string winter = "Winter";
        private const string prePostSummer = "Pre/Post-Summer";
        private const string snowStorm = "SnowStorm";
        private const string iceAge = "IceAge";
        private const string summer = "summer";
        private const string gale = "gale";

        //Attributes
        private const string wind = "Wind";
        private const string temperture = "Temperture";


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
                .Transition(storm, wind, 10)
                .StartState(winter);
            //.State(iceAge)
            //        .Attribute(temperture, -50)
            //        .Transition(winter, temperture, -10)
            //.State(storm)
            //        .Attribute(wind, 10)
            //        .Transition(summer, wind, 0).ThisOrLower()
            //        .Transition(gale,wind, 0)
            //.State(gale)
            //        .Attribute(wind, 10)
            //        .Transition()



        }
    }
}
