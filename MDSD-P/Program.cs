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
            Console.WriteLine(myWeather.CurrentState);
            Console.WriteLine(myWeather.Action("Temperture", 20).ToString());
            Console.WriteLine(myWeather.Action("Temperture", -10).ToString());
            Console.WriteLine(myWeather.Action("Temperture", 30).ToString());
            Console.WriteLine(myWeather.Action("Temperture", 1).ToString());
            Console.ReadLine();
            
        }
    }
}
