using System;

namespace DesignPatterns
{
    public class Program
    {
        static void Main()
        {
            Purchasing purchasing = new Computer();
            purchasing.TemplateMethod();

            Console.Read();
        }
    }

    public enum PaymentType
    {
        KrediKarti,
        HavaleEft
    }

    public enum CargoCompany
    {
        Yurtici,
        Aras
    }

    public abstract class Purchasing
    {
        protected string ProductName;
        protected PaymentType PaymentType;
        protected CargoCompany cargoCompany;

        void Start() => Console.WriteLine($"Sipariş oluşturma başladı.");
        void Step0() => Console.WriteLine($"Ürün sepete eklendi. Ürün adı {ProductName}");
        void Step1() => Console.WriteLine($"Ödeme yapıldı. Ödeme yöntemi: {PaymentType}");
        void Step2() => Console.WriteLine($"Kargoya şirketi seçildi. Seçilen: {cargoCompany}");
        void Finish() => Console.WriteLine("Sipariş tamamlandı.");

        public abstract void Product();
        public abstract void Payment();
        public abstract void Cargo();

        public void TemplateMethod()
        {
            Start(); //sabit işlev
            Step0();
            Step1();
            Step2();
            Finish(); //sabit işlev
        }
    }

    public class Computer : Purchasing
    {
        public override void Product()
        {
            ProductName = "MonsterNotebook";
        }

        public override void Payment()
        {
            PaymentType = PaymentType.KrediKarti;
        }

        public override void Cargo()
        {
            cargoCompany = CargoCompany.Yurtici;
        }
    }
}