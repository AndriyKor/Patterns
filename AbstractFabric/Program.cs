using System;

namespace AbstractFabric
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var team = new NoNameTeam();
            var racing = new GrandPri(team);
            racing.MakeARace();
        }
    }

    #region Cars

    public abstract class AbstractCar
    {
        public abstract void Move();
    }

    public class Toyota : AbstractCar
    {
        public override void Move()
        {
            Console.WriteLine("Toyota is moving!");
        }
    }

    public class Audi : AbstractCar
    {
        public override void Move()
        {
            Console.WriteLine("Audi is moving!");
        }
    }

    #endregion Cars

    #region Drivers

    public abstract class AbstractDriver
    {
        public abstract void Drive();
    }

    public class ProfiDriver : AbstractDriver
    {
        public override void Drive()
        {
            Console.WriteLine("Don't worry, profi is driving!");
        }
    }

    public class NoobDriver : AbstractDriver
    {
        public override void Drive()
        {
            Console.WriteLine("Watch out! Noob is driving!");
        }
    }

    #endregion Drivers

    #region Teams

    public abstract class AbstractTeam
    {
        public abstract AbstractCar CreateCar();

        public abstract AbstractDriver CreateDriver();
    }

    public class McLarenTeam : AbstractTeam
    {
        public override AbstractCar CreateCar()
        {
            return new Toyota();
        }

        public override AbstractDriver CreateDriver()
        {
            return new ProfiDriver();
        }
    }

    public class NoNameTeam : AbstractTeam
    {
        public override AbstractCar CreateCar()
        {
            return new Audi();
        }

        public override AbstractDriver CreateDriver()
        {
            return new NoobDriver();
        }
    }

    #endregion Teams

    public class GrandPri
    {
        private readonly AbstractDriver driver;
        private readonly AbstractCar car;

        public GrandPri(AbstractTeam team)
        {
            driver = team.CreateDriver();
            car = team.CreateCar();
        }

        public void MakeARace()
        {
            driver.Drive();
            car.Move();
        }
    }
}