using System;

namespace Patterns
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var fabric = new AppleFabric();
            var fruit = fabric.GrowSomeFruits();
            fruit.EatMe();
        }
    }

    public interface IFruit
    {
        void EatMe();
    }

    public class Apple : IFruit
    {
        public void EatMe()
        {
            Console.WriteLine("Eating an apple");
        }
    }

    public class Orange : IFruit
    {
        public void EatMe()
        {
            Console.WriteLine("Eating an orange");
        }
    }

    public interface IFabric
    {
        public IFruit GrowSomeFruits();
    }

    public class AppleFabric : IFabric
    {
        public IFruit GrowSomeFruits()
        {
            return new Apple();
        }
    }

    public class OrangeFabric : IFabric
    {
        public IFruit GrowSomeFruits()
        {
            return new Orange();
        }
    }
}