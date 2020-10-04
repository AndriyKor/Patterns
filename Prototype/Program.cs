using System;

namespace Prototype
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //var someVehicle = new Car(2, "Coupe");
            var someVehicle = new Bicycle("Speddy Road Runner");
            var vehicleCopy = someVehicle.Clone();

            someVehicle.WhoAmI();
            vehicleCopy.WhoAmI();
        }
    }

    public interface IVehicle
    {
        public abstract IVehicle Clone();

        public abstract void WhoAmI();
    }

    public class Car : IVehicle
    {
        public int NumberOfDoors { get; private set; }
        public string Type { get; private set; }

        public Car(int numberOfDoors, string type)
        {
            NumberOfDoors = numberOfDoors;
            Type = type;
        }

        public IVehicle Clone()
        {
            return new Car(NumberOfDoors, Type);
        }

        public void WhoAmI()
        {
            Console.WriteLine($"I am a {Type} car with {NumberOfDoors} doors");
        }
    }

    public class Bicycle : IVehicle
    {
        public string Type { get; private set; }

        public Bicycle(string type)
        {
            Type = type;
        }

        public IVehicle Clone()
        {
            return new Bicycle(Type);
        }

        public void WhoAmI()
        {
            Console.WriteLine($"I am a {Type} bicycle");
        }
    }
}