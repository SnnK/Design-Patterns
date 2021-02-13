using System;

namespace DesignPatterns
{
    public class Program
    {
        static void Main()
        {
            Context context = new Context();
            Console.WriteLine("Lambanın başlangıç durumu: " + context.GetLampState().ToString());

            context.OnClose();
            context.OnOpen();

            Console.WriteLine("Lambanın şuan ki durumu: " + context.GetLampState().ToString());

            Console.Read();
        }
    }

    public interface ILampState
    {
        public void OnOpen();
        public void OnClose();
    }

    public class LampOpenState : ILampState
    {
        public void OnClose()
        {
            Console.WriteLine("Lamba açık. Kapanıyor.");
        }

        public void OnOpen()
        {
            Console.WriteLine("Lamba zaten açık.");
        }

        public override string ToString()
        {
            return "Açık";
        }
    }

    public class LampCloseState : ILampState
    {
        public void OnClose()
        {
            Console.WriteLine("Lamba zaten kapalı.");
        }

        public void OnOpen()
        {
            Console.WriteLine("Lamba kapalıydı. Açılıyor.");
        }

        public override string ToString()
        {
            return "Kapalı";
        }
    }

    public class Context
    {
        private ILampState LampState;

        public Context()
        {
            SetLampState(new LampCloseState());
        }

        public void OnOpen()
        {
            LampState.OnOpen();
            if (LampState is LampCloseState)
            {
                SetLampState(new LampOpenState());
            }
        }

        public void OnClose()
        {
            LampState.OnClose();
            if (LampState is LampOpenState)
            {
                SetLampState(new LampCloseState());
            }
        }

        public ILampState GetLampState()
        {
            return LampState;
        }

        public void SetLampState(ILampState lampState)
        {
            LampState = lampState;
        }
    }
}