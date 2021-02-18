using System;

namespace DesignPatterns
{
    public class Program
    {
        static void Main()
        {
            IEmail email = new GenelMail("from@from.com", "to@to.com");
            IEmail templateEmail = new TemplateDecorator(email);
            IEmail encryptedEmail = new EncryptedDecorator(email, "123");

            templateEmail.Gonder();
            encryptedEmail.Gonder();

            Console.Read();
        }
    }

    public interface IEmail
    {
        void Gonder();
    }

    public class GenelMail : IEmail
    {
        private readonly string from;
        private readonly string to;

        public GenelMail(string from, string to)
        {
            this.from = from;
            this.to = to;
        }

        public void Gonder()
        {
            Console.WriteLine($"{from}'dan {to}'ya mail gönderiliyor.");
        }
    }

    public abstract class Decorator : IEmail
    {
        protected IEmail Email { get; set; }

        public Decorator(IEmail email)
        {
            Email = email;
        }

        public virtual void Gonder()
        {
            Email.Gonder();
        }
    }

    public class TemplateDecorator : Decorator
    {
        public TemplateDecorator(IEmail email) : base(email)
        {
        }

        public override void Gonder()
        {
            Console.WriteLine("Template kullanıldı.");
            base.Gonder();
        }
    }

    public class EncryptedDecorator : Decorator
    {
        private string token;

        public EncryptedDecorator(IEmail email, string token) : base(email)
        {
            this.token = token;
        }

        public override void Gonder()
        {
            Console.WriteLine($"{token} ile şifrelendi.");
            base.Gonder();
        }
    }
}