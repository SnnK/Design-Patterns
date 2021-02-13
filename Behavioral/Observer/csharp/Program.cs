using System;
using System.Collections.Generic;

namespace DesignPatterns
{
    public class Program
    {
        static void Main()
        {
            Product product = new Product();

            product.AddObserver(new CustomerObserver());

            product.ChangePrice();

            Console.Read();
        }
    }

    public class Product
    {
        private readonly List<Observer> _observers;

        public Product()
        {
            _observers = new List<Observer>();
        }

        public void AddObserver(Observer observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(Observer observer)
        {
            _observers.Remove(observer);
        }

        private void Notify()
        {
            //gözlemcilerdeki ilgili metod tetikleniyor.
            foreach (var observer in _observers)
            {
                observer.SendEmail();
            }
        }

        public void ChangePrice()
        {
            //tutar değiştirildi.
            Notify();
        }
    }

    public abstract class Observer
    {
        public abstract void SendEmail();
    }

    public class CustomerObserver : Observer
    {
        public override void SendEmail()
        {
            Console.WriteLine("Email gönderildi.");
        }
    }
}