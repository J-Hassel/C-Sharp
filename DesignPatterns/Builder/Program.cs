using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            var superBuilder = new SuperCarBuilder();
            var notSuperBuilder = new NotSoSuperCarBuilder();

            var factory = new Carfactory();
            var builders = new List<CarBuilder>() { superBuilder, notSuperBuilder};

            foreach(var b in builders)
            {
                var c = factory.Build(b);
                Console.WriteLine($"The Car requested by " +
                    $"{b.GetType().Name}: " +
                    $"\n------------------------------------- " +
                    $"\nHorsePower: {c.HorsePower} " +
                    $"\nImpressiveFeature: {c.MostImpressiveFeature} " +
                    $"\nTop Speed: {c.TopSpeedMPH} mph\n");
            }
        }
    }

    public class Car
    {
        public int TopSpeedMPH { get; set; }
        public int HorsePower { get; set; }
        public string MostImpressiveFeature { get; set; }
    }

    public abstract class CarBuilder
    {
        protected readonly Car _car = new Car();
        public abstract void SetHorsePower();
        public abstract void SetTopSpeed();
        public abstract void SetImpressiveFeature();

        public virtual Car GetCar() => _car;
    }

    public class Carfactory
    {
        public Car Build(CarBuilder builder)
        {
            builder.SetHorsePower();
            builder.SetTopSpeed();
            builder.SetImpressiveFeature();
            return builder.GetCar();
        }
    }

    public class NotSoSuperCarBuilder : CarBuilder
    {
        public override void SetHorsePower()
        {
            _car.HorsePower = 120;
        }

        public override void SetImpressiveFeature()
        {
            _car.MostImpressiveFeature = "Has air conditioning";
        }

        public override void SetTopSpeed()
        {
            _car.TopSpeedMPH = 70;
        }
    }

    public class SuperCarBuilder : CarBuilder
    {
        public override void SetHorsePower()
        {
            _car.HorsePower = 1640;
        }

        public override void SetImpressiveFeature()
        {
            _car.MostImpressiveFeature = "Can fly";
        }

        public override void SetTopSpeed()
        {
            _car.TopSpeedMPH = 600;
        }
    }
}
