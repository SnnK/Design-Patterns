using System;

namespace DesignPatterns
{
    public class Program
    {
        static void Main()
        {
            GameConsole gameConsole1 = new Xbox
            {
                Model = "Model 1"
            };

            GameConsole gameConsole2 = new Playstation
            {
                Model = "Model 1"
            };

            IGameConsoleBuyVisitor amazonBuyVisitor = new AmazonBuyVisitor();
            IGameConsoleBuyVisitor aliexpressBuyVisitor = new AliExpressBuyVisitor();

            gameConsole1.Accept(amazonBuyVisitor);
            gameConsole2.Accept(aliexpressBuyVisitor);

            Console.Read();
        }
    }

    public abstract class GameConsole
    {
        public string Model { get; set; }
        public abstract void Accept(IGameConsoleBuyVisitor visitor);
    }

    public interface IGameConsoleBuyVisitor
    {
        void BuyVisit(Xbox xbox);
        void BuyVisit(Playstation playstation);
    }

    public class Xbox : GameConsole
    {
        public override void Accept(IGameConsoleBuyVisitor visitor)
        {
            visitor.BuyVisit(this);
        }

        public override string ToString()
        {
            return "Xbox";
        }
    }

    public class Playstation : GameConsole
    {
        public override void Accept(IGameConsoleBuyVisitor visitor)
        {
            visitor.BuyVisit(this);
        }

        public override string ToString()
        {
            return "Playstation";
        }
    }

    public class AmazonBuyVisitor : IGameConsoleBuyVisitor
    {
        public void BuyVisit(Xbox xbox)
        {
            Console.WriteLine($"{xbox} konsolu Amazon'dan satın alındı.");
        }

        public void BuyVisit(Playstation playstation)
        {
            Console.WriteLine($"{playstation} konsolu Amazon'dan satın alındı.");
        }
    }

    public class AliExpressBuyVisitor : IGameConsoleBuyVisitor
    {
        public void BuyVisit(Xbox xbox)
        {
            Console.WriteLine($"{xbox} konsolu Aliexpress'den satın alındı.");
        }

        public void BuyVisit(Playstation playstation)
        {
            Console.WriteLine($"{playstation} konsolu Aliexpress'den satın alındı.");
        }
    }
}