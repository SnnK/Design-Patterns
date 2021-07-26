using System;
using System.Collections.Generic;

namespace DesignPatterns
{
    public class Program
    {
        static void Main()
        {
            CreateCommand createCommand = new CreateCommand(new OrderOperations());
            CargoCommand updateCommand = new CargoCommand(new OrderOperations());
            NotifyCommand notifyCommand = new NotifyCommand(new OrderOperations());

            List<ICommand> commands = new List<ICommand>
        {
            createCommand,
            updateCommand,
            notifyCommand
        };

            foreach (var command in commands)
                command.Execute();

            Console.Read();
        }
    }

    public class OrderOperations
    {
        public void Create() => Console.WriteLine("Yeni sipariş oluşturuldu.");
        public void Cargo() => Console.WriteLine("Kargoya verildi.");
        public void Notify() => Console.WriteLine("Müşteriye bildirim gönderildi.");
    }

    public class CreateCommand : ICommand
    {
        private readonly OrderOperations orderOperations;

        public CreateCommand(OrderOperations orderOperations)
        {
            this.orderOperations = orderOperations;
        }

        public void Execute()
        {
            orderOperations.Create();
        }
    }

    public class CargoCommand : ICommand
    {
        private readonly OrderOperations orderOperations;

        public CargoCommand(OrderOperations orderOperations)
        {
            this.orderOperations = orderOperations;
        }

        public void Execute()
        {
            orderOperations.Cargo();
        }
    }

    public class NotifyCommand : ICommand
    {
        private readonly OrderOperations orderOperations;

        public NotifyCommand(OrderOperations orderOperations)
        {
            this.orderOperations = orderOperations;
        }

        public void Execute()
        {
            orderOperations.Notify();
        }
    }

    public interface ICommand
    {
        void Execute();
    }
}