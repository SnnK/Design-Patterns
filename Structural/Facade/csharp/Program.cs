using System;

namespace DesignPatterns
{
    public class Program
    {
        static void Main()
        {
            CreateCarSkeleton createCarSkeleton = new CreateCarSkeleton() { Bottom = "Bottom component", Top = "Top component" };
            CreateEngine createEngine = new CreateEngine() { Oil_pump = "Oil pump", Roller = "Roller" };

            CarGeneratorFacade facade = new CarGeneratorFacade(createCarSkeleton, createEngine);
            Console.WriteLine(facade.Operation());

            Console.Read();
        }
    }

    public class CreateCarSkeleton
    {
        public string Top { get; set; }
        public string Bottom { get; set; }

        public string Operation()
        {
            return $"\nLOG: {Top} ve {Bottom} araç iskeletleri oluşturuldu.";
        }
    }

    public class CreateEngine
    {
        public string Roller { get; set; }
        public string Oil_pump { get; set; }

        public string Operation()
        {
            return $"\nLOG: {Roller} ve {Oil_pump} birleştirildi ve motor oluşturuldu.";
        }
    }

    public class CarGeneratorFacade
    {
        private readonly CreateCarSkeleton createCarSkeleton;
        private readonly CreateEngine createEngine;

        public CarGeneratorFacade(CreateCarSkeleton createCarSkeleton, CreateEngine createEngine)
        {
            this.createCarSkeleton = createCarSkeleton;
            this.createEngine = createEngine;
        }

        public string Operation()
        {
            string result = "Sonuc";
            result += createCarSkeleton.Operation();
            result += createEngine.Operation();

            return result;
        }
    }
}