using System;
using System.Collections.Generic;

namespace DesignPatterns
{
    public class Program
    {
        static void Main()
        {
            User user = new User("snn", "12345");
            IBookShop order = new MaskOrderProxy();
            order.CreateOrder(user);

            Console.Read();
        }
    }

    public interface IBookShop
    {
        void CreateOrder(User user);
    }

    public class MaskOrder : IBookShop
    {
        public void CreateOrder(User user)
        {
            Console.WriteLine($"{user.Username} ki�isi i�in sipari� olu�turuldu.");
        }
    }

    public class MaskOrderProxy : IBookShop
    {
        IBookShop bookShop;

        public void CreateOrder(User user)
        {
            if (Auth.Login(user))
            {
                bookShop = new MaskOrder();
                bookShop.CreateOrder(user);
            }
            else
            {
                Console.WriteLine("Kullan�c� bilgileri hatal�.");
            }
        }
    }

    public class Auth
    {
        public static bool Login(User user)
        {
            return user.Username == "snn" && user.Password == "12345";
        }
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}