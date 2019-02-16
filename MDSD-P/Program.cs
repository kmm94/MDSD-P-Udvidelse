using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDSD_P
{
    class Program
    {
        static void Main(string[] args)
        {
            MyWeather myWeather = new MyWeather();
            myWeather.Build();
            Console.WriteLine(myWeather._CurrentState);
            Console.WriteLine(myWeather.Action(MyWeather.temperture, 20).ToString());
            Console.WriteLine(myWeather.Action(MyWeather.temperture, -10).ToString());
            Console.WriteLine(myWeather.Action(MyWeather.temperture, 30).ToString());
            Console.WriteLine(myWeather.Action(MyWeather.temperture, 1).ToString());
            Console.WriteLine(myWeather.Action(MyWeather.wind, 1).ToString());
            Console.WriteLine(myWeather.Action(MyWeather.temperture, -50).ToString());
            Console.ReadLine();
            
        }
    }
}
