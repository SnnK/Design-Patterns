using System;
using System.Collections.Generic;

namespace DesignPatterns
{
    public class Program
    {
        static void Main()
        {
            PersonelListAggregate PersonelListAggregate = new PersonelListAggregate();

            Personel sinan = new Personel { Id = 1, Name = "sinan" };
            Personel mert = new Personel { Id = 2, Name = "mert" };

            PersonelListAggregate.Add(sinan);
            PersonelListAggregate.Add(mert);

            var iterator = PersonelListAggregate.CreateIterator();

            while (iterator.HasNext())
            {
                Personel currentPersonel = iterator.CurrentItem();
                Console.WriteLine($"{currentPersonel.Name}");
            }

            Console.Read();
        }
    }

    public class Personel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public interface IIterator<T>
    {
        bool HasNext();
        T CurrentItem();
    }

    public interface IPersonelAggregate
    {
        IIterator<Personel> CreateIterator();
    }

    public class PersonelListAggregate : IPersonelAggregate
    {
        private readonly List<Personel> _Personels;

        public PersonelListAggregate()
        {
            _Personels = new List<Personel>();
        }

        public IIterator<Personel> CreateIterator()
        {
            return new PersonelIterator(this);
        }

        public void Add(Personel Personel)
        {
            _Personels.Add(Personel);
        }

        public Personel Get(int index)
        {
            return _Personels[index];
        }

        public int Count
        {
            get
            {
                return _Personels.Count;
            }
        }
    }

    public class PersonelIterator : IIterator<Personel>
    {
        private readonly PersonelListAggregate _PersonelListAggregate;
        private int _currentIndex;

        public PersonelIterator(PersonelListAggregate PersonelListAggregate)
        {
            _PersonelListAggregate = PersonelListAggregate;
        }

        public Personel CurrentItem()
        {
            return _PersonelListAggregate.Get(_currentIndex++);
        }

        public bool HasNext()
        {
            if (_PersonelListAggregate.Count > _currentIndex)
                return true;

            return false;
        }
    }
}