using Decorator.Component;
using Decorator.ConcreteDecorator;
using Decorator.ConcreteComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new CompactCar();

            Console.WriteLine($"Before:\n{myCar.GetDescription()}\n{myCar.GetCarPrice()}");


            myCar = new LeatherSeats(myCar);
            Console.WriteLine($"After:\n{myCar.GetDescription()}\n{myCar.GetCarPrice()}");

        }
    }
}
