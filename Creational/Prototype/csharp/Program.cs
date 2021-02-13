using System;

namespace DesignPatterns
{
    public class Program
    {
        static void Main()
        {
            Engineer engineer = new Engineer("Sinan", 123.11);
            Engineer engineer2 = engineer.Clone();

            Console.Read();
        }
    }

    public interface IClonable<Tprototype>
    {
        Tprototype Clone();
    }

    class Engineer : IClonable<Engineer>
    {
        private string name;
        private double salary;

        public Engineer(string name, double salary)
        {
            this.name = name;
            this.salary = salary;
        }

        public Engineer Clone()
        {
            return base.MemberwiseClone() as Engineer;
        }
    }
}