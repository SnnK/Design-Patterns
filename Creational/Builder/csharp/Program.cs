using System;

namespace DesignPatterns
{
    public class Program
    {
        static void Main()
        {
            PromosyonBuilder promosyonBuilder = new ConcreteEngineersBuilder();
            PromosyonGonder promosyonGonder = new PromosyonGonder();
            promosyonGonder.Gonder(promosyonBuilder);

            string setEdilen = promosyonBuilder.Promosyon.ToString();
            Console.WriteLine(setEdilen);

            Console.Read();
        }
    }

    public class Promosyon
    {
        public string ProductName { get; set; }
        public int PromotionNo { get; set; }
        public string EmployeeDepartment { get; set; }

        public override string ToString()
        {
            return $"{EmployeeDepartment} departmanınki işçilere {ProductName} ürünü promosyon olarak verildi.";
        }
    }

    public abstract class PromosyonBuilder
    {
        protected Promosyon promosyon;

        public Promosyon Promosyon
        {
            get
            {
                return promosyon;
            }
        }

        public abstract void SetProductName();
        public abstract void SetPromotionNo();
        public abstract void SetEmployeeDepartment();
    }

    public class ConcreteEngineersBuilder : PromosyonBuilder
    {
        public ConcreteEngineersBuilder()
        {
            promosyon = new Promosyon();
        }

        public override void SetEmployeeDepartment()
        {
            promosyon.EmployeeDepartment = "Muhendisler";
        }

        public override void SetProductName()
        {
            promosyon.ProductName = "Saat";
        }

        public override void SetPromotionNo()
        {
            promosyon.PromotionNo = 123;
        }
    }

    public class ConcreteCallCenterBuilder : PromosyonBuilder
    {
        public ConcreteCallCenterBuilder()
        {
            promosyon = new Promosyon();
        }

        public override void SetEmployeeDepartment()
        {
            promosyon.EmployeeDepartment = "Call Center";
        }

        public override void SetProductName()
        {
            promosyon.ProductName = "Gözlük";
        }

        public override void SetPromotionNo()
        {
            promosyon.PromotionNo = 124;
        }
    }

    public class PromosyonGonder
    {
        public void Gonder(PromosyonBuilder builder)
        {
            builder.SetEmployeeDepartment();
            builder.SetPromotionNo();
            builder.SetProductName();
        }
    }
}