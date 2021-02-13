using System;
using System.Collections.Generic;

namespace DesignPatterns
{
    public class Program
    {
        static void Main()
        {
            IChatMediator chatMediator = new ChatMediator();

            User user1 = new ChatUser(chatMediator)
            {
                Name = "Sinan",
                UserName = "snnk"
            };

            User user2 = new ChatUser(chatMediator)
            {
                Name = "Behzat",
                UserName = "behzatc"
            };


            User bot1 = new ChatBot(chatMediator)
            {
                Name = "Bot",
                UserName = "bot"
            };

            chatMediator.AddUser(user1);
            chatMediator.AddUser(user2);
            chatMediator.AddUser(bot1);

            user1.SendMessage("Selam?", user2.UserName);
            user2.SendMessage("İyiyim sen?", user1.UserName);
            bot1.SendMessage("konuşmalara dikkat edelim.", user1.UserName);
            user1.SendMessage("eyvallah.", bot1.UserName);

            Console.Read();
        }
    }

    public interface IChatMediator
    {
        void SendMessage(string message, string userName);
        void AddUser(User user);
    }

    public class ChatMediator : IChatMediator
    {
        private readonly Dictionary<string, User> _user;

        public ChatMediator()
        {
            _user = new Dictionary<string, User>();
        }

        public void AddUser(User user)
        {
            _user.Add(user.UserName, user);
        }

        public void SendMessage(string message, string userName)
        {
            User user = _user[userName];
            user.ReceiveMessage(message); //mesaj alındı, merkez tarafından iletimi de sağlanıyor.
        }
    }

    public abstract class User
    {
        public string UserName { get; set; }
        public string Name { get; set; }

        private readonly IChatMediator _chatMediator;

        public User(IChatMediator chatMediator)
        {
            _chatMediator = chatMediator;
        }

        //mediator tipinin çağırıda bulunacağı metod.
        public virtual void ReceiveMessage(string message)
        {
            Console.WriteLine($"{Name}: {message} -received-");
        }

        //çağrı mediator tipine ait nesne referansına doğru yapılıyor.
        public void SendMessage(string message, string userName)
        {
            Console.WriteLine($"{Name}: {message} -sent to {userName}-");
            _chatMediator.SendMessage(message, userName);
        }
    }

    public class ChatUser : User
    {
        public ChatUser(IChatMediator chatMediator) : base(chatMediator)
        {
        }
    }

    public class ChatBot : User
    {
        public ChatBot(IChatMediator chatMediator) : base(chatMediator)
        {
        }
    }
}