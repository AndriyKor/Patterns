using System;

namespace Builder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //var builder = new LateBuilder();
            var builder = new AmericanoBuilder();
            var kredensCafe = new KredensCafe(builder);
            var cofee = kredensCafe.MakeCoffe();

            cofee.ShowWhatIHave();
        }
    }

    public class Coffee
    {
        public bool HasMilk { get; set; }
        public bool HasSugar { get; set; }
        public string Brand { get; set; }

        public void ShowWhatIHave()
        {
            var result = string.Format("My {0} coffe has {1}milk and {2}sugar",
                string.IsNullOrWhiteSpace(Brand) ? "NO NAME" : Brand,
                !HasMilk ? "NO " : "",
                !HasSugar ? "NO " : "");
            Console.WriteLine(result);
        }
    }

    public abstract class CoffeeBuilder
    {
        public abstract void AddMilk();

        public abstract void AddSugar();

        public abstract void NameIt();

        public abstract Coffee GetCofee();
    }

    public class LateBuilder : CoffeeBuilder
    {
        private readonly Coffee _cofee;

        public LateBuilder() => _cofee = new Coffee();

        public override void AddMilk() => _cofee.HasMilk = true;

        public override void AddSugar() => _cofee.HasSugar = true;

        public override void NameIt() => _cofee.Brand = string.Empty;

        public override Coffee GetCofee() => _cofee;
    }

    public class AmericanoBuilder : CoffeeBuilder
    {
        private readonly Coffee _cofee;

        public AmericanoBuilder() => _cofee = new Coffee();

        public override void AddMilk() => _cofee.HasMilk = false;

        public override void AddSugar() => _cofee.HasSugar = false;

        public override void NameIt() => _cofee.Brand = "Diablo";

        public override Coffee GetCofee() => _cofee;
    }

    public class KredensCafe
    {
        private readonly CoffeeBuilder builder;

        public KredensCafe(CoffeeBuilder builder)
        {
            this.builder = builder;
        }

        public Coffee MakeCoffe()
        {
            builder.AddMilk();
            builder.AddSugar();
            builder.NameIt();
            return builder.GetCofee();
        }
    }
}