using System;

namespace DesignPatterns
{
    public class Program
    {
        static void Main()
        {
            var database = Database.GetInstance;
            //...
            Console.Read();
        }
    }

    public class Database
    {
        private static Database database;
        private static Object _lockObject = new object();

        private Database()
        {

        }

        public static Database GetInstance
        {
            get
            {
                lock (_lockObject)
                {
                    if (database == null)
                        database = new Database();

                    return database;
                }
            }
        }
    }
}