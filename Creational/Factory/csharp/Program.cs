using System;

namespace DesignPatterns
{
    public class Program
    {
        static void Main()
        {
            GameFactory gameFactory = new GameFactory();

            IGame game = gameFactory.CreateGame(GameTypes.Xbox);

            game.BuyGame();

            Console.Read();
        }
    }

    public class Playstation : IGame
    {
        public void BuyGame()
        {
            Console.WriteLine("Playstation oyunu satın alındı.");
        }
    }

    public class Xbox : IGame
    {
        public void BuyGame()
        {
            Console.WriteLine("Xbox oyunu satın alındı.");
        }
    }

    public interface IGame
    {
        void BuyGame();
    }

    public class GameFactory
    {
        private static Playstation playstation;
        private static Xbox xbox;
        private static Object lockObject = new object();

        public IGame CreateGame(GameTypes gameType)
        {
            switch (gameType)
            {
                case GameTypes.Playstation:
                    lock (lockObject)
                    {
                        if (playstation == null)
                            playstation = new Playstation();

                        return playstation;
                    }
                case GameTypes.Xbox:
                    lock (lockObject)
                    {
                        if (xbox == null)
                            xbox = new Xbox();

                        return xbox;
                    }
                default:
                    return null;
            }
        }
    }

    public enum GameTypes
    {
        Playstation,
        Xbox
    }
}