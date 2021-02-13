using System;
using System.Collections.Generic;

namespace DesignPatterns
{
    public class Program
    {
        static void Main()
        {
            Category category0 = new Category("Kitaplar");
            Category category1 = new Category("Yazılım Kitapları");
            Category category2 = new Category("Sanat Kitapları");
            Book book = new Book("C Kitabı");
            Book book2 = new Book("C# Kitabı");
            Book book3 = new Book("Sanat Kitabı");

            category0.Add(category1);
            category0.Add(category2);

            category1.Add(book);
            category1.Add(book2);
            category2.Add(book3);

            category0.Display(1);

            Console.Read();
        }
    }

    public interface ICategory
    {
        void Display(int line);
    }

    public class Book : ICategory
    {
        private string Ad;

        public Book(string ad)
        {
            Ad = ad;
        }

        public void Display(int line)
        {
            Console.WriteLine($"{new String('-', line)}Ad");
        }
    }

    public class Category : ICategory
    {
        private string Ad;

        public Category(string ad)
        {
            Ad = ad;
        }

        private List<ICategory> libraries = new List<ICategory>();

        public void Add(ICategory library)
        {
            libraries.Add(library);
        }

        public void Remove(ICategory library)
        {
            libraries.Remove(library);
        }

        public void Display(int line)
        {
            Console.WriteLine($"{new String('-', line++)}{Ad}({libraries.Count})");

            foreach (ICategory library in libraries)
            {
                library.Display(line);
            }
        }
    }
}